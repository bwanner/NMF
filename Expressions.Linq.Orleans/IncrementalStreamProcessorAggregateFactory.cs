﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NMF.Expressions.Linq.Orleans.Linq.Interfaces;
using Orleans;
using Orleans.Collections;
using Orleans.Streams;
using Orleans.Streams.Linq.Aggregates;

namespace NMF.Expressions.Linq.Orleans
{
    public class IncrementalStreamProcessorAggregateFactory : IIncrementalStreamProcessorAggregateFactory
    {
        public IncrementalStreamProcessorAggregateFactory(IGrainFactory factory)
        {
            GrainFactory = factory;
        }

        public IGrainFactory GrainFactory { get; }
        public async Task<IStreamProcessorAggregate<ContainerElement<TIn>, ContainerElement<TOut>>> CreateSelect<TIn, TOut>(Expression<Func<ContainerElement<TIn>, TOut>> selectionFunc, IList<StreamIdentity> streamIdentities)
        {
            var processorAggregate = GrainFactory.GetGrain<IIncrementalSelectAggregateGrain<TIn, TOut>>(Guid.NewGuid());

            await processorAggregate.SetObservingFunc(selectionFunc);
            await processorAggregate.SetInput(streamIdentities);

            return processorAggregate;
        }

        public async Task<IStreamProcessorAggregate<ContainerElement<TIn>, ContainerElement<TIn>>> CreateWhere<TIn>(Expression<Func<ContainerElement<TIn>, bool>> filterFunc, IList<StreamIdentity> streamIdentities)
        {
            var processorAggregate = GrainFactory.GetGrain<IIncrementalWhereAggregateGrain<TIn>>(Guid.NewGuid());

            await processorAggregate.SetObservingFunc(filterFunc);
            await processorAggregate.SetInput(streamIdentities);

            return processorAggregate;
        }
    }
}