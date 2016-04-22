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
    
    
    [XmlNamespaceAttribute("http://www.semanticweb.org/ontologies/2015/ttc/trainbenchmark")]
    [XmlNamespacePrefixAttribute("hu.bme.mit.trainbenchmark")]
    [ModelRepresentationClassAttribute("http://www.semanticweb.org/ontologies/2015/ttc/trainbenchmark#//RailwayElement/")]
    public abstract class RailwayElement : ModelElement, IRailwayElement, IModelElement
    {
        
        /// <summary>
        /// The backing field for the Id property
        /// </summary>
        private Nullable<int> _id;
        
        /// <summary>
        /// The id property
        /// </summary>
        [XmlElementNameAttribute("id")]
        [XmlAttributeAttribute(true)]
        public virtual Nullable<int> Id
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((value != this._id))
                {
                    this._id = value;
                    this.OnIdChanged(EventArgs.Empty);
                    this.OnPropertyChanged("Id");
                }
            }
        }
        
        /// <summary>
        /// Gets fired when the Id property changed its value
        /// </summary>
        public event EventHandler IdChanged;
        
        /// <summary>
        /// Raises the IdChanged event
        /// </summary>
        /// <param name="eventArgs">The event data</param>
        protected virtual void OnIdChanged(EventArgs eventArgs)
        {
            EventHandler handler = this.IdChanged;
            if ((handler != null))
            {
                handler.Invoke(this, eventArgs);
            }
        }
        
        /// <summary>
        /// Gets the Class element that describes the structure of the current model element
        /// </summary>
        public override NMF.Models.Meta.IClass GetClass()
        {
            return NMF.Models.Repository.MetaRepository.Instance.ResolveClass("http://www.semanticweb.org/ontologies/2015/ttc/trainbenchmark#//RailwayElement/");
        }
    }
}
