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
using NMF.Serialization;
using NMF.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;

namespace NMF.Models.Meta
{
    
    
    /// <summary>
    /// The default implementation of the Model class
    /// </summary>
    [XmlNamespaceAttribute("http://nmf.codeplex.com/nmeta/")]
    [XmlNamespacePrefixAttribute("nmeta")]
    [ModelRepresentationClassAttribute("http://nmf.codeplex.com/nmeta/#//Model/")]
    public class Model : ModelElement, IModel, IModelElement
    {
        
        /// <summary>
        /// The backing field for the ModelUri property
        /// </summary>
        private Uri _modelUri;
        
        /// <summary>
        /// The backing field for the RootElements property
        /// </summary>
        private ObservableCompositionList<NMF.Models.Meta.IModelElement> _rootElements;
        
        public Model()
        {
            this._rootElements = new ObservableCompositionList<NMF.Models.Meta.IModelElement>(this);
            this._rootElements.CollectionChanged += this.RootElementsCollectionChanged;
        }
        
        /// <summary>
        /// The ModelUri property
        /// </summary>
        [XmlAttributeAttribute(true)]
        public virtual Uri ModelUri
        {
            get
            {
                return this._modelUri;
            }
            set
            {
                if ((this._modelUri != value))
                {
                    Uri old = this._modelUri;
                    this._modelUri = value;
                    this.OnModelUriChanged(new ValueChangedEventArgs(old, value));
                    this.OnPropertyChanged("ModelUri");
                }
            }
        }
        
        /// <summary>
        /// The RootElements property
        /// </summary>
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Content)]
        [XmlAttributeAttribute(false)]
        [ContainmentAttribute()]
        [ConstantAttribute()]
        public virtual ICollectionExpression<NMF.Models.Meta.IModelElement> RootElements
        {
            get
            {
                return this._rootElements;
            }
        }
        
        /// <summary>
        /// Gets the child model elements of this model element
        /// </summary>
        public override IEnumerableExpression<IModelElement> Children
        {
            get
            {
                return base.Children.Concat(new ModelChildrenCollection(this));
            }
        }
        
        /// <summary>
        /// Gets the referenced model elements of this model element
        /// </summary>
        public override IEnumerableExpression<IModelElement> ReferencedElements
        {
            get
            {
                return base.ReferencedElements.Concat(new ModelReferencedElementsCollection(this));
            }
        }
        
        /// <summary>
        /// Gets the Class element that describes the structure of this type
        /// </summary>
        public new static NMF.Models.Meta.IClass ClassInstance
        {
            get
            {
                return NMF.Models.Repository.MetaRepository.Instance.ResolveClass("http://nmf.codeplex.com/nmeta/#//Model/");
            }
        }
        
        /// <summary>
        /// Gets fired when the ModelUri property changed its value
        /// </summary>
        public event EventHandler<ValueChangedEventArgs> ModelUriChanged;
        
        /// <summary>
        /// Raises the ModelUriChanged event
        /// </summary>
        /// <param name="eventArgs">The event data</param>
        protected virtual void OnModelUriChanged(ValueChangedEventArgs eventArgs)
        {
            EventHandler<ValueChangedEventArgs> handler = this.ModelUriChanged;
            if ((handler != null))
            {
                handler.Invoke(this, eventArgs);
            }
        }
        
        /// <summary>
        /// Forwards change notifications for the RootElements property to the parent model element
        /// </summary>
        /// <param name="sender">The collection that raised the change</param>
        /// <param name="e">The original event data</param>
        private void RootElementsCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            this.OnCollectionChanged("RootElements", e);
        }
        
        /// <summary>
        /// Resolves the given attribute name
        /// </summary>
        /// <returns>The attribute value or null if it could not be found</returns>
        /// <param name="attribute">The requested attribute name</param>
        /// <param name="index">The index of this attribute</param>
        protected override object GetAttributeValue(string attribute, int index)
        {
            if ((attribute == "MODELURI"))
            {
                return this.ModelUri;
            }
            return base.GetAttributeValue(attribute, index);
        }
        
        /// <summary>
        /// Gets the Model element collection for the given feature
        /// </summary>
        /// <returns>A non-generic list of elements</returns>
        /// <param name="feature">The requested feature</param>
        protected override System.Collections.IList GetCollectionForFeature(string feature)
        {
            if ((feature == "ROOTELEMENTS"))
            {
                return this._rootElements;
            }
            return base.GetCollectionForFeature(feature);
        }
        
        /// <summary>
        /// Sets a value to the given feature
        /// </summary>
        /// <param name="feature">The requested feature</param>
        /// <param name="value">The value that should be set to that feature</param>
        protected override void SetFeature(string feature, object value)
        {
            if ((feature == "MODELURI"))
            {
                this.ModelUri = ((Uri)(value));
                return;
            }
            base.SetFeature(feature, value);
        }
        
        /// <summary>
        /// Gets the Class for this model element
        /// </summary>
        public override IClass GetClass()
        {
            return ((IClass)(NMF.Models.Repository.MetaRepository.Instance.Resolve("http://nmf.codeplex.com/nmeta/#//Model/")));
        }
        
        /// <summary>
        /// The collection class to to represent the children of the Model class
        /// </summary>
        public class ModelChildrenCollection : ReferenceCollection, ICollectionExpression<IModelElement>, ICollection<IModelElement>
        {
            
            private Model _parent;
            
            /// <summary>
            /// Creates a new instance
            /// </summary>
            public ModelChildrenCollection(Model parent)
            {
                this._parent = parent;
            }
            
            /// <summary>
            /// Gets the amount of elements contained in this collection
            /// </summary>
            public override int Count
            {
                get
                {
                    int count = 0;
                    count = (count + this._parent.RootElements.Count);
                    return count;
                }
            }
            
            protected override void AttachCore()
            {
                this._parent.RootElements.AsNotifiable().CollectionChanged += this.PropagateCollectionChanges;
            }
            
            protected override void DetachCore()
            {
                this._parent.RootElements.AsNotifiable().CollectionChanged -= this.PropagateCollectionChanges;
            }
            
            /// <summary>
            /// Adds the given element to the collection
            /// </summary>
            /// <param name="item">The item to add</param>
            public override void Add(IModelElement item)
            {
                NMF.Models.Meta.IModelElement rootElementsCasted = item.As<NMF.Models.Meta.IModelElement>();
                if ((rootElementsCasted != null))
                {
                    this._parent.RootElements.Add(rootElementsCasted);
                }
            }
            
            /// <summary>
            /// Clears the collection and resets all references that implement it.
            /// </summary>
            public override void Clear()
            {
                this._parent.RootElements.Clear();
            }
            
            /// <summary>
            /// Gets a value indicating whether the given element is contained in the collection
            /// </summary>
            /// <returns>True, if it is contained, otherwise False</returns>
            /// <param name="item">The item that should be looked out for</param>
            public override bool Contains(IModelElement item)
            {
                if (this._parent.RootElements.Contains(item))
                {
                    return true;
                }
                return false;
            }
            
            /// <summary>
            /// Copies the contents of the collection to the given array starting from the given array index
            /// </summary>
            /// <param name="array">The array in which the elements should be copied</param>
            /// <param name="arrayIndex">The starting index</param>
            public override void CopyTo(IModelElement[] array, int arrayIndex)
            {
                IEnumerator<IModelElement> rootElementsEnumerator = this._parent.RootElements.GetEnumerator();
                try
                {
                    for (
                    ; rootElementsEnumerator.MoveNext(); 
                    )
                    {
                        array[arrayIndex] = rootElementsEnumerator.Current;
                        arrayIndex = (arrayIndex + 1);
                    }
                }
                finally
                {
                    rootElementsEnumerator.Dispose();
                }
            }
            
            /// <summary>
            /// Removes the given item from the collection
            /// </summary>
            /// <returns>True, if the item was removed, otherwise False</returns>
            /// <param name="item">The item that should be removed</param>
            public override bool Remove(IModelElement item)
            {
                NMF.Models.Meta.IModelElement modelElementItem = item.As<NMF.Models.Meta.IModelElement>();
                if (((modelElementItem != null) 
                            && this._parent.RootElements.Remove(modelElementItem)))
                {
                    return true;
                }
                return false;
            }
            
            /// <summary>
            /// Gets an enumerator that enumerates the collection
            /// </summary>
            /// <returns>A generic enumerator</returns>
            public override IEnumerator<IModelElement> GetEnumerator()
            {
                return Enumerable.Empty<IModelElement>().Concat(this._parent.RootElements).GetEnumerator();
            }
        }
        
        /// <summary>
        /// The collection class to to represent the children of the Model class
        /// </summary>
        public class ModelReferencedElementsCollection : ReferenceCollection, ICollectionExpression<IModelElement>, ICollection<IModelElement>
        {
            
            private Model _parent;
            
            /// <summary>
            /// Creates a new instance
            /// </summary>
            public ModelReferencedElementsCollection(Model parent)
            {
                this._parent = parent;
            }
            
            /// <summary>
            /// Gets the amount of elements contained in this collection
            /// </summary>
            public override int Count
            {
                get
                {
                    int count = 0;
                    count = (count + this._parent.RootElements.Count);
                    return count;
                }
            }
            
            protected override void AttachCore()
            {
                this._parent.RootElements.AsNotifiable().CollectionChanged += this.PropagateCollectionChanges;
            }
            
            protected override void DetachCore()
            {
                this._parent.RootElements.AsNotifiable().CollectionChanged -= this.PropagateCollectionChanges;
            }
            
            /// <summary>
            /// Adds the given element to the collection
            /// </summary>
            /// <param name="item">The item to add</param>
            public override void Add(IModelElement item)
            {
                NMF.Models.Meta.IModelElement rootElementsCasted = item.As<NMF.Models.Meta.IModelElement>();
                if ((rootElementsCasted != null))
                {
                    this._parent.RootElements.Add(rootElementsCasted);
                }
            }
            
            /// <summary>
            /// Clears the collection and resets all references that implement it.
            /// </summary>
            public override void Clear()
            {
                this._parent.RootElements.Clear();
            }
            
            /// <summary>
            /// Gets a value indicating whether the given element is contained in the collection
            /// </summary>
            /// <returns>True, if it is contained, otherwise False</returns>
            /// <param name="item">The item that should be looked out for</param>
            public override bool Contains(IModelElement item)
            {
                if (this._parent.RootElements.Contains(item))
                {
                    return true;
                }
                return false;
            }
            
            /// <summary>
            /// Copies the contents of the collection to the given array starting from the given array index
            /// </summary>
            /// <param name="array">The array in which the elements should be copied</param>
            /// <param name="arrayIndex">The starting index</param>
            public override void CopyTo(IModelElement[] array, int arrayIndex)
            {
                IEnumerator<IModelElement> rootElementsEnumerator = this._parent.RootElements.GetEnumerator();
                try
                {
                    for (
                    ; rootElementsEnumerator.MoveNext(); 
                    )
                    {
                        array[arrayIndex] = rootElementsEnumerator.Current;
                        arrayIndex = (arrayIndex + 1);
                    }
                }
                finally
                {
                    rootElementsEnumerator.Dispose();
                }
            }
            
            /// <summary>
            /// Removes the given item from the collection
            /// </summary>
            /// <returns>True, if the item was removed, otherwise False</returns>
            /// <param name="item">The item that should be removed</param>
            public override bool Remove(IModelElement item)
            {
                NMF.Models.Meta.IModelElement modelElementItem = item.As<NMF.Models.Meta.IModelElement>();
                if (((modelElementItem != null) 
                            && this._parent.RootElements.Remove(modelElementItem)))
                {
                    return true;
                }
                return false;
            }
            
            /// <summary>
            /// Gets an enumerator that enumerates the collection
            /// </summary>
            /// <returns>A generic enumerator</returns>
            public override IEnumerator<IModelElement> GetEnumerator()
            {
                return Enumerable.Empty<IModelElement>().Concat(this._parent.RootElements).GetEnumerator();
            }
        }
        
        /// <summary>
        /// Represents a proxy to represent an incremental access to the ModelUri property
        /// </summary>
        private sealed class ModelUriProxy : ModelPropertyChange<IModel, Uri>
        {
            
            /// <summary>
            /// Creates a new observable property access proxy
            /// </summary>
            /// <param name="modelElement">The model instance element for which to create the property access proxy</param>
            public ModelUriProxy(IModel modelElement) : 
                    base(modelElement)
            {
            }
            
            /// <summary>
            /// Gets or sets the value of this expression
            /// </summary>
            public override Uri Value
            {
                get
                {
                    return this.ModelElement.ModelUri;
                }
                set
                {
                    this.ModelElement.ModelUri = value;
                }
            }
            
            /// <summary>
            /// Registers an event handler to subscribe specifically on the changed event for this property
            /// </summary>
            /// <param name="handler">The handler that should be subscribed to the property change event</param>
            protected override void RegisterChangeEventHandler(System.EventHandler<NMF.Expressions.ValueChangedEventArgs> handler)
            {
                this.ModelElement.ModelUriChanged += handler;
            }
            
            /// <summary>
            /// Registers an event handler to subscribe specifically on the changed event for this property
            /// </summary>
            /// <param name="handler">The handler that should be unsubscribed from the property change event</param>
            protected override void UnregisterChangeEventHandler(System.EventHandler<NMF.Expressions.ValueChangedEventArgs> handler)
            {
                this.ModelElement.ModelUriChanged -= handler;
            }
        }
    }
}

