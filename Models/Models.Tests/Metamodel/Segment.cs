//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
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
using NMF.Models.Expressions;
using NMF.Models.Meta;
using NMF.Serialization;
using NMF.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;

namespace NMF.Models.Tests.Railway
{
    
    
    /// <summary>
    /// The default implementation of the Segment class
    /// </summary>
    [XmlNamespaceAttribute("http://www.semanticweb.org/ontologies/2015/ttc/trainbenchmark")]
    [XmlNamespacePrefixAttribute("hu.bme.mit.trainbenchmark")]
    [ModelRepresentationClassAttribute("http://www.semanticweb.org/ontologies/2015/ttc/trainbenchmark#//Segment/")]
    [DebuggerDisplayAttribute("Segment {Id}")]
    public class Segment : TrackElement, ISegment, IModelElement
    {
        
        /// <summary>
        /// The backing field for the Length property
        /// </summary>
        private int _length;
        
        /// <summary>
        /// The length property
        /// </summary>
        [XmlElementNameAttribute("length")]
        [XmlAttributeAttribute(true)]
        public virtual int Length
        {
            get
            {
                return this._length;
            }
            set
            {
                if ((this._length != value))
                {
                    int old = this._length;
                    this._length = value;
                    ValueChangedEventArgs e = new ValueChangedEventArgs(old, value);
                    this.OnLengthChanged(e);
                    this.OnPropertyChanged("Length", e);
                }
            }
        }
        
        /// <summary>
        /// Gets the Class element that describes the structure of this type
        /// </summary>
        public new static NMF.Models.Meta.IClass ClassInstance
        {
            get
            {
                return NMF.Models.Repository.MetaRepository.Instance.ResolveClass("http://www.semanticweb.org/ontologies/2015/ttc/trainbenchmark#//Segment/");
            }
        }
        
        /// <summary>
        /// Gets fired when the Length property changed its value
        /// </summary>
        public event EventHandler<ValueChangedEventArgs> LengthChanged;
        
        /// <summary>
        /// Raises the LengthChanged event
        /// </summary>
        /// <param name="eventArgs">The event data</param>
        protected virtual void OnLengthChanged(ValueChangedEventArgs eventArgs)
        {
            EventHandler<ValueChangedEventArgs> handler = this.LengthChanged;
            if ((handler != null))
            {
                handler.Invoke(this, eventArgs);
            }
        }
        
        /// <summary>
        /// Resolves the given attribute name
        /// </summary>
        /// <returns>The attribute value or null if it could not be found</returns>
        /// <param name="attribute">The requested attribute name</param>
        /// <param name="index">The index of this attribute</param>
        protected override object GetAttributeValue(string attribute, int index)
        {
            if ((attribute == "LENGTH"))
            {
                return this.Length;
            }
            return base.GetAttributeValue(attribute, index);
        }
        
        /// <summary>
        /// Sets a value to the given feature
        /// </summary>
        /// <param name="feature">The requested feature</param>
        /// <param name="value">The value that should be set to that feature</param>
        protected override void SetFeature(string feature, object value)
        {
            if ((feature == "LENGTH"))
            {
                this.Length = ((int)(value));
                return;
            }
            base.SetFeature(feature, value);
        }
        
        /// <summary>
        /// Gets the Class for this model element
        /// </summary>
        public override IClass GetClass()
        {
            return ((IClass)(NMF.Models.Repository.MetaRepository.Instance.Resolve("http://www.semanticweb.org/ontologies/2015/ttc/trainbenchmark#//Segment/")));
        }
        
        /// <summary>
        /// Represents a proxy to represent an incremental access to the length property
        /// </summary>
        private sealed class LengthProxy : ModelPropertyChange<ISegment, int>
        {
            
            /// <summary>
            /// Creates a new observable property access proxy
            /// </summary>
            /// <param name="modelElement">The model instance element for which to create the property access proxy</param>
            public LengthProxy(ISegment modelElement) : 
                    base(modelElement)
            {
            }
            
            /// <summary>
            /// Gets or sets the value of this expression
            /// </summary>
            public override int Value
            {
                get
                {
                    return this.ModelElement.Length;
                }
                set
                {
                    this.ModelElement.Length = value;
                }
            }
            
            /// <summary>
            /// Registers an event handler to subscribe specifically on the changed event for this property
            /// </summary>
            /// <param name="handler">The handler that should be subscribed to the property change event</param>
            protected override void RegisterChangeEventHandler(System.EventHandler<NMF.Expressions.ValueChangedEventArgs> handler)
            {
                this.ModelElement.LengthChanged += handler;
            }
            
            /// <summary>
            /// Registers an event handler to subscribe specifically on the changed event for this property
            /// </summary>
            /// <param name="handler">The handler that should be unsubscribed from the property change event</param>
            protected override void UnregisterChangeEventHandler(System.EventHandler<NMF.Expressions.ValueChangedEventArgs> handler)
            {
                this.ModelElement.LengthChanged -= handler;
            }
        }
    }
}

