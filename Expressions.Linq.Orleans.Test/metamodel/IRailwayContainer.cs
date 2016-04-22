//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.34209
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using NMF.Collections.Generic;
using NMF.Collections.ObjectModel;
using NMF.Expressions;
using NMF.Expressions.Linq;
using NMF.Models;
using NMF.Models.Collections;
using NMF.Serialization;
using NMF.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;

namespace TTC2015.TrainBenchmark.Railway
{
    
    
    /// <summary>
    /// The public interface for RailwayContainer
    /// </summary>
    [XmlNamespaceAttribute("http://www.semanticweb.org/ontologies/2015/ttc/trainbenchmark")]
    [XmlNamespacePrefixAttribute("hu.bme.mit.trainbenchmark")]
    [ModelRepresentationClassAttribute("http://www.semanticweb.org/ontologies/2015/ttc/trainbenchmark#//RailwayContainer/" +
        "")]
    [XmlDefaultImplementationTypeAttribute(typeof(RailwayContainer))]
    [DefaultImplementationTypeAttribute(typeof(RailwayContainer))]
    public interface IRailwayContainer : IModelElement
    {
        
        /// <summary>
        /// The invalids property
        /// </summary>
        IListExpression<IRailwayElement> Invalids
        {
            get;
        }
        
        /// <summary>
        /// The semaphores property
        /// </summary>
        IListExpression<ISemaphore> Semaphores
        {
            get;
        }
        
        /// <summary>
        /// The routes property
        /// </summary>
        IListExpression<IRoute> Routes
        {
            get;
        }
    }
}
