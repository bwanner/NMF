﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Expressions.Linq.Orleans.Test.utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMF.Expressions.Linq.Orleans;
using NMF.Expressions.Linq.Orleans.Interfaces;
using NMF.Expressions.Linq.Orleans.Linq.Interfaces;
using NMF.Expressions.Linq.Orleans.Model;
using NMF.Models.Tests.Railway;
using Orleans;
using Orleans.Streams;
using Orleans.TestingHost;

namespace Expressions.Linq.Orleans.Test
{
    [TestClass]
    public class SqoGrainTest : TestingSiloHost
    {
        private IStreamProvider _provider;

        [TestInitialize]
        public void TestInitialize()
        {
            _provider = GrainClient.GetStreamProvider("CollectionStreamProvider");
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            // Optional. 
            // By default, the next test class which uses TestignSiloHost will
            // cause a fresh Orleans silo environment to be created.
            StopAllSilosIfRunning();
        }

        [TestMethod]
        public async Task TestIncrementalSelectAggregateGrain()
        {
            var modelGrain = await ModelTestUtil.LoadModelContainer(GrainFactory);

            var selectGrain =
                GrainFactory.GetGrain<IIncrementalSelectAggregateGrain<RailwayContainer, RailwayContainer, RailwayContainer>>(Guid.NewGuid());
            await selectGrain.SetOutputMultiplex(1);
            await selectGrain.SetModelContainer(modelGrain);
            await selectGrain.SetObservingFunc(new SerializableFunc<RailwayContainer, RailwayContainer>(_ => _));
            await selectGrain.SetInput(await modelGrain.GetOutputStreams());

            var consumer = new MultiStreamModelConsumer<RailwayContainer, RailwayContainer>(_provider,
                ModelTestUtil.ModelLoadingFunc(ModelTestUtil.ModelPath));
            await consumer.SetInput(await selectGrain.GetOutputStreams());

            await modelGrain.EnumerateToSubscribers(Guid.NewGuid());

            Assert.AreEqual(1, consumer.Items.Count);
            var model1 = await modelGrain.ModelToString(model => model);
            var model2 = consumer.Items[0].ToXmlString();

            Assert.AreEqual(model1, model2);
        }

        [TestMethod]
        public async Task TestIncrementalSelectNodeGrain()
        {
            var modelGrain = await ModelTestUtil.LoadModelContainer(GrainFactory);

            var selectNodeGrain =
                GrainFactory.GetGrain<IIncrementalSelectNodeGrain<RailwayContainer, RailwayContainer, RailwayContainer>>(Guid.NewGuid());
            await selectNodeGrain.SetOutputMultiplex(1);
            await selectNodeGrain.SetModelContainer(modelGrain);
            await selectNodeGrain.SubscribeToStreams(await modelGrain.GetOutputStreams());
            await selectNodeGrain.SetObservingFunc(new SerializableFunc<RailwayContainer, RailwayContainer>(_ => _));
            await selectNodeGrain.LoadModelFromPath(ModelTestUtil.ModelPath);

            var consumer = new MultiStreamModelConsumer<RailwayContainer, RailwayContainer>(_provider,
                ModelTestUtil.ModelLoadingFunc(ModelTestUtil.ModelPath));
            await consumer.SetInput(await selectNodeGrain.GetOutputStreams());

            await modelGrain.EnumerateToSubscribers(Guid.NewGuid());

            Assert.AreEqual(1, consumer.Items.Count);
            var model1 = await modelGrain.ModelToString(model => model);
            var model2 = consumer.Items[0].ToXmlString();

            Assert.AreEqual(model1, model2);
        }

        [TestMethod]
        public async Task TestObservableSimpleSelectManyNodeGrainRetrieveItems()
        {
            await TestObservableSimpleSelectManyNodeGrainRetrieveItemsGeneric(1);
        }

        [TestMethod]
        public async Task TestIncrementalSelectManyAggregateGrainMultiplexing()
        {
            await TestObservableSimpleSelectManyNodeGrainRetrieveItemsGeneric(4);
        }


        [TestMethod]
        public async Task TestObservableSimpleWhereNodeGrainRetrieveItems()
        {
            var modelGrain = await ModelTestUtil.LoadModelContainer(GrainFactory);

            var localModel = ModelTestUtil.ModelLoadingFunc(ModelTestUtil.ModelPath);

            var selectNodeGrain = GrainFactory.GetGrain<IIncrementalWhereNodeGrain<RailwayContainer, RailwayContainer>>(Guid.NewGuid());
            await selectNodeGrain.SetOutputMultiplex(1);
            await selectNodeGrain.SetModelContainer(modelGrain);
            await selectNodeGrain.SetObservingFunc(new SerializableFunc<RailwayContainer, bool>(model => model.Semaphores.Count == 5));
            await selectNodeGrain.LoadModelFromPath(ModelTestUtil.ModelPath);
            await selectNodeGrain.SubscribeToStreams(await modelGrain.GetOutputStreams());

            var consumer = new MultiStreamModelConsumer<RailwayContainer, RailwayContainer>(_provider,
                ModelTestUtil.ModelLoadingFunc(ModelTestUtil.ModelPath));
            await consumer.SetInput(await selectNodeGrain.GetOutputStreams());

            await modelGrain.EnumerateToSubscribers(Guid.NewGuid());

            Assert.AreEqual(1, consumer.Items.Count);

            var localXmlString = localModel.ToXmlString().SingleValueToList();
            var processedXmlstring = consumer.Items.Select(r => r.ToXmlString()).OrderBy(s => s).ToList();

            CollectionAssert.AreEqual(localXmlString, processedXmlstring);
        }

        private async Task TestObservableSimpleSelectManyNodeGrainRetrieveItemsGeneric(int multiplexingFactor = 1)
        {
            var modelGrain = await ModelTestUtil.LoadModelContainer(GrainFactory);

            var localModel = ModelTestUtil.ModelLoadingFunc(ModelTestUtil.ModelPath);

            var selectNodeGrain =
                GrainFactory.GetGrain<IIncrementalSimpleSelectManyNodeGrain<RailwayContainer, ISemaphore, RailwayContainer>>(Guid.NewGuid());
            await selectNodeGrain.SetOutputMultiplex((uint) multiplexingFactor);
            await selectNodeGrain.SetModelContainer(modelGrain);
            await selectNodeGrain.SetObservingFunc(new SerializableFunc<RailwayContainer, IEnumerable<ISemaphore>>(model => model.Semaphores));
            await selectNodeGrain.LoadModelFromPath(ModelTestUtil.ModelPath);
            await selectNodeGrain.SubscribeToStreams(await modelGrain.GetOutputStreams());

            var consumer = new MultiStreamModelConsumer<ISemaphore, RailwayContainer>(_provider,
                ModelTestUtil.ModelLoadingFunc(ModelTestUtil.ModelPath));
            var streams = await selectNodeGrain.GetOutputStreams();

            Assert.AreEqual(multiplexingFactor, streams.Count);
            await consumer.SetInput(streams);

            await modelGrain.EnumerateToSubscribers(Guid.NewGuid());

            var localSemaphores = localModel.Semaphores;

            Assert.AreEqual(localSemaphores.Count, consumer.Items.Count);

            var localXmlString = localSemaphores.Select(r => r.ToXmlString()).OrderBy(s => s).ToList();
            var processedXmlstring = consumer.Items.Select(r => r.ToXmlString()).OrderBy(s => s).ToList();

            CollectionAssert.AreEqual(localXmlString, processedXmlstring);
        }
    }
}