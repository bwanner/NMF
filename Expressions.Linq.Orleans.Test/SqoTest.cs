﻿using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Expressions.Linq.Orleans.Test.utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMF.Expressions.Linq.Orleans;
using NMF.Expressions.Linq.Orleans.Model;
using NMF.Models;
using NMF.Models.Tests.Railway;
using NMF.Utilities;
using Orleans;
using Orleans.Streams;
using Orleans.Streams.Linq;
using Orleans.TestingHost;

namespace Expressions.Linq.Orleans.Test
{
    [TestClass]
    public class SqoTest : TestingSiloHost
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
        public async Task SelectTest()
        {
            var localModel = ModelTestUtil.ModelLoadingFunc(ModelTestUtil.ModelPath);
            var modelContainer = await ModelTestUtil.LoadModelContainer(GrainFactory);
            var factory = new IncrementalNmfModelStreamProcessorAggregateFactory(GrainFactory, modelContainer);

            var query = await modelContainer.Select(x => x, factory);
            var resultConsumer = await query.ToNmfModelConsumer();

            Assert.AreEqual(0, resultConsumer.Items.Count);

            await modelContainer.EnumerateToSubscribers();

            ModelTestUtil.AssertXmlEquals(localModel.SingleValueToList(), resultConsumer.Items);
        }

        [TestMethod]
        public async Task SimpleSelectManyTest()
        {
            var localModel = ModelTestUtil.ModelLoadingFunc(ModelTestUtil.ModelPath);
            var modelContainer = await ModelTestUtil.LoadModelContainer(GrainFactory);
            var factory = new IncrementalNmfModelStreamProcessorAggregateFactory(GrainFactory, modelContainer);

            var query = await modelContainer.SimpleSelectMany(model => model.RootElements.Single().As<RailwayContainer>().Semaphores, factory);
            var resultConsumer = await query.ToNmfModelConsumer();

            Assert.AreEqual(0, resultConsumer.Items.Count);

            await modelContainer.EnumerateToSubscribers();

            var localResults = localModel.RootElements.Single().As<RailwayContainer>().Semaphores; 
            ModelTestUtil.AssertXmlEquals(localResults, resultConsumer.Items);
        }

        [TestMethod]
        public async Task SelectManyTest()
        {
            var localModel = ModelTestUtil.ModelLoadingFunc(ModelTestUtil.ModelPath);
            var modelContainer = await ModelTestUtil.LoadModelContainer(GrainFactory);
            var factory = new IncrementalNmfModelStreamProcessorAggregateFactory(GrainFactory, modelContainer);

            var query = await modelContainer.SimpleSelectMany(model => model.RootElements.Single().As<RailwayContainer>().Descendants().OfType<IRoute>(), factory);
            var query2 = await query.SelectMany(route => route.DefinedBy, (route, sensor) => route.DefinedBy.Count > 20); 
            var resultConsumer = await query2.ToNmfModelConsumer();

            Assert.AreEqual(0, resultConsumer.Items.Count);

            await modelContainer.EnumerateToSubscribers();

            var localResults = localModel.RootElements.Single()
                .As<RailwayContainer>()
                .Descendants()
                .OfType<IRoute>()
                .SelectMany(r => r.DefinedBy, (route, sensor) => route.DefinedBy.Count > 20);


            CollectionAssert.AreEqual(localResults.ToList(), resultConsumer.Items.ToList());
        }

        [TestMethod]
        public async Task WhereSelectManyTest()
        {
            var localModel = ModelTestUtil.ModelLoadingFunc(ModelTestUtil.ModelPath);
            var modelContainer = await ModelTestUtil.LoadModelContainer(GrainFactory);
            var factory = new IncrementalNmfModelStreamProcessorAggregateFactory(GrainFactory, modelContainer);

            var query =
                modelContainer.SimpleSelectMany(model => model.RootElements.Single().As<RailwayContainer>().Semaphores, factory)
                    .Where(s => s.Signal == Signal.GO);
            var resultConsumer = await query.ToNmfModelConsumer();

            Assert.AreEqual(0, resultConsumer.Items.Count);

            await modelContainer.EnumerateToSubscribers();

            var localResults = localModel.RootElements.Single().As<RailwayContainer>().Semaphores.Where(s => s.Signal == Signal.GO);
            ModelTestUtil.AssertXmlEquals(localResults, resultConsumer.Items);
        }

        [TestMethod]
        public async Task TestTupleClassSelectMany()
        {
            var localModel = ModelTestUtil.ModelLoadingFunc(ModelTestUtil.ModelPath);
            var modelContainer = await ModelTestUtil.LoadModelContainer(GrainFactory);
            var factory = new IncrementalNmfModelStreamProcessorAggregateFactory(GrainFactory, modelContainer);

            var query =
                modelContainer.SimpleSelectMany(model => model.RootElements.Single().Descendants().OfType<ISwitchPosition>(), factory)
                    .Select(swp => new ModelElementTuple<ISwitchPosition, IRoute>(swp, swp.Route));
            var resultConsumer = await query.ToNmfModelConsumer();

            Assert.AreEqual(0, resultConsumer.Items.Count);

            await modelContainer.EnumerateToSubscribers();

            var localQuery = localModel.RootElements.Single().Descendants().OfType<ISwitchPosition>()
                .Select(swp => new ModelElementTuple<ISwitchPosition, IRoute>(swp, swp.Route));

            var localResults = localQuery.OrderBy(x => x.Item1.RelativeUri.ToString()).ToList();
            var remoteResults = resultConsumer.Items.OrderBy(x => x.Item1.RelativeUri.ToString()).ToList();
            CollectionAssert.AreEqual(localResults.Select(x => x.Item1.RelativeUri).ToList(), remoteResults.Select(x => x.Item1.RelativeUri).ToList());
            CollectionAssert.AreEqual(localResults.Select(x => x.Item2.RelativeUri).ToList(), remoteResults.Select(x => x.Item2.RelativeUri).ToList());
        }

    }
}