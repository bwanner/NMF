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
    /// The default implementation of the Route class
    /// </summary>
    [XmlNamespaceAttribute("http://www.semanticweb.org/ontologies/2015/ttc/trainbenchmark")]
    [XmlNamespacePrefixAttribute("hu.bme.mit.trainbenchmark")]
    [ModelRepresentationClassAttribute("http://www.semanticweb.org/ontologies/2015/ttc/trainbenchmark#//Route/")]
    public class Route : RailwayElement, IRoute, IModelElement
    {
        
        /// <summary>
        /// The backing field for the Entry property
        /// </summary>
        private ISemaphore _entry;
        
        /// <summary>
        /// The backing field for the Follows property
        /// </summary>
        private RouteFollowsCollection _follows;
        
        /// <summary>
        /// The backing field for the Exit property
        /// </summary>
        private ISemaphore _exit;
        
        /// <summary>
        /// The backing field for the DefinedBy property
        /// </summary>
        private ObservableCompositionList<ISensor> _definedBy;
        
        public Route()
        {
            this._follows = new RouteFollowsCollection(this);
            this._follows.CollectionChanged += this.FollowsCollectionChanged;
            this._definedBy = new ObservableCompositionList<ISensor>(this);
            this._definedBy.CollectionChanged += this.DefinedByCollectionChanged;
        }
        
        /// <summary>
        /// The entry property
        /// </summary>
        [XmlElementNameAttribute("entry")]
        [XmlAttributeAttribute(true)]
        public virtual ISemaphore Entry
        {
            get
            {
                return this._entry;
            }
            set
            {
                if ((this._entry != value))
                {
                    ISemaphore old = this._entry;
                    this._entry = value;
                    if ((old != null))
                    {
                        old.Deleted -= this.OnResetEntry;
                    }
                    if ((value != null))
                    {
                        value.Deleted += this.OnResetEntry;
                    }
                    ValueChangedEventArgs e = new ValueChangedEventArgs(old, value);
                    this.OnEntryChanged(e);
                    this.OnPropertyChanged("Entry", e);
                }
            }
        }
        
        /// <summary>
        /// The follows property
        /// </summary>
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Content)]
        [XmlElementNameAttribute("follows")]
        [XmlAttributeAttribute(false)]
        [ContainmentAttribute()]
        [XmlOppositeAttribute("route")]
        [ConstantAttribute()]
        public virtual IListExpression<ISwitchPosition> Follows
        {
            get
            {
                return this._follows;
            }
        }
        
        /// <summary>
        /// The exit property
        /// </summary>
        [XmlElementNameAttribute("exit")]
        [XmlAttributeAttribute(true)]
        public virtual ISemaphore Exit
        {
            get
            {
                return this._exit;
            }
            set
            {
                if ((this._exit != value))
                {
                    ISemaphore old = this._exit;
                    this._exit = value;
                    if ((old != null))
                    {
                        old.Deleted -= this.OnResetExit;
                    }
                    if ((value != null))
                    {
                        value.Deleted += this.OnResetExit;
                    }
                    ValueChangedEventArgs e = new ValueChangedEventArgs(old, value);
                    this.OnExitChanged(e);
                    this.OnPropertyChanged("Exit", e);
                }
            }
        }
        
        /// <summary>
        /// The definedBy property
        /// </summary>
        [LowerBoundAttribute(2)]
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Content)]
        [XmlElementNameAttribute("definedBy")]
        [XmlAttributeAttribute(false)]
        [ContainmentAttribute()]
        [ConstantAttribute()]
        public virtual IListExpression<ISensor> DefinedBy
        {
            get
            {
                return this._definedBy;
            }
        }
        
        /// <summary>
        /// Gets the child model elements of this model element
        /// </summary>
        public override IEnumerableExpression<IModelElement> Children
        {
            get
            {
                return base.Children.Concat(new RouteChildrenCollection(this));
            }
        }
        
        /// <summary>
        /// Gets the referenced model elements of this model element
        /// </summary>
        public override IEnumerableExpression<IModelElement> ReferencedElements
        {
            get
            {
                return base.ReferencedElements.Concat(new RouteReferencedElementsCollection(this));
            }
        }
        
        /// <summary>
        /// Gets the Class element that describes the structure of this type
        /// </summary>
        public new static NMF.Models.Meta.IClass ClassInstance
        {
            get
            {
                return NMF.Models.Repository.MetaRepository.Instance.ResolveClass("http://www.semanticweb.org/ontologies/2015/ttc/trainbenchmark#//Route/");
            }
        }
        
        /// <summary>
        /// Gets fired when the Entry property changed its value
        /// </summary>
        public event EventHandler<ValueChangedEventArgs> EntryChanged;
        
        /// <summary>
        /// Gets fired when the Exit property changed its value
        /// </summary>
        public event EventHandler<ValueChangedEventArgs> ExitChanged;
        
        /// <summary>
        /// Raises the EntryChanged event
        /// </summary>
        /// <param name="eventArgs">The event data</param>
        protected virtual void OnEntryChanged(ValueChangedEventArgs eventArgs)
        {
            EventHandler<ValueChangedEventArgs> handler = this.EntryChanged;
            if ((handler != null))
            {
                handler.Invoke(this, eventArgs);
            }
        }
        
        /// <summary>
        /// Handles the event that the Entry property must reset
        /// </summary>
        /// <param name="sender">The object that sent this reset request</param>
        /// <param name="eventArgs">The event data for the reset event</param>
        private void OnResetEntry(object sender, EventArgs eventArgs)
        {
            this.Entry = null;
        }
        
        /// <summary>
        /// Forwards change notifications for the Follows property to the parent model element
        /// </summary>
        /// <param name="sender">The collection that raised the change</param>
        /// <param name="e">The original event data</param>
        private void FollowsCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            this.OnCollectionChanged("Follows", e);
        }
        
        /// <summary>
        /// Raises the ExitChanged event
        /// </summary>
        /// <param name="eventArgs">The event data</param>
        protected virtual void OnExitChanged(ValueChangedEventArgs eventArgs)
        {
            EventHandler<ValueChangedEventArgs> handler = this.ExitChanged;
            if ((handler != null))
            {
                handler.Invoke(this, eventArgs);
            }
        }
        
        /// <summary>
        /// Handles the event that the Exit property must reset
        /// </summary>
        /// <param name="sender">The object that sent this reset request</param>
        /// <param name="eventArgs">The event data for the reset event</param>
        private void OnResetExit(object sender, EventArgs eventArgs)
        {
            this.Exit = null;
        }
        
        /// <summary>
        /// Forwards change notifications for the DefinedBy property to the parent model element
        /// </summary>
        /// <param name="sender">The collection that raised the change</param>
        /// <param name="e">The original event data</param>
        private void DefinedByCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            this.OnCollectionChanged("DefinedBy", e);
        }
        
        /// <summary>
        /// Gets the relative URI fragment for the given child model element
        /// </summary>
        /// <returns>A fragment of the relative URI</returns>
        /// <param name="element">The element that should be looked for</param>
        protected override string GetRelativePathForNonIdentifiedChild(IModelElement element)
        {
            int followsIndex = ModelHelper.IndexOfReference(this.Follows, element);
            if ((followsIndex != -1))
            {
                return ModelHelper.CreatePath("follows", followsIndex);
            }
            int definedByIndex = ModelHelper.IndexOfReference(this.DefinedBy, element);
            if ((definedByIndex != -1))
            {
                return ModelHelper.CreatePath("definedBy", definedByIndex);
            }
            return base.GetRelativePathForNonIdentifiedChild(element);
        }
        
        /// <summary>
        /// Resolves the given URI to a child model element
        /// </summary>
        /// <returns>The model element or null if it could not be found</returns>
        /// <param name="reference">The requested reference name</param>
        /// <param name="index">The index of this reference</param>
        protected override IModelElement GetModelElementForReference(string reference, int index)
        {
            if ((reference == "FOLLOWS"))
            {
                if ((index < this.Follows.Count))
                {
                    return this.Follows[index];
                }
                else
                {
                    return null;
                }
            }
            if ((reference == "DEFINEDBY"))
            {
                if ((index < this.DefinedBy.Count))
                {
                    return this.DefinedBy[index];
                }
                else
                {
                    return null;
                }
            }
            return base.GetModelElementForReference(reference, index);
        }
        
        /// <summary>
        /// Gets the Model element collection for the given feature
        /// </summary>
        /// <returns>A non-generic list of elements</returns>
        /// <param name="feature">The requested feature</param>
        protected override System.Collections.IList GetCollectionForFeature(string feature)
        {
            if ((feature == "FOLLOWS"))
            {
                return this._follows;
            }
            if ((feature == "DEFINEDBY"))
            {
                return this._definedBy;
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
            if ((feature == "ENTRY"))
            {
                this.Entry = ((ISemaphore)(value));
                return;
            }
            if ((feature == "EXIT"))
            {
                this.Exit = ((ISemaphore)(value));
                return;
            }
            base.SetFeature(feature, value);
        }
        
        /// <summary>
        /// Gets the property expression for the given attribute
        /// </summary>
        /// <returns>An incremental property expression</returns>
        /// <param name="attribute">The requested attribute in upper case</param>
        protected override NMF.Expressions.INotifyExpression<object> GetExpressionForAttribute(string attribute)
        {
            if ((attribute == "ENTRY"))
            {
                return new EntryProxy(this);
            }
            if ((attribute == "EXIT"))
            {
                return new ExitProxy(this);
            }
            return base.GetExpressionForAttribute(attribute);
        }
        
        /// <summary>
        /// Gets the property expression for the given reference
        /// </summary>
        /// <returns>An incremental property expression</returns>
        /// <param name="reference">The requested reference in upper case</param>
        protected override NMF.Expressions.INotifyExpression<NMF.Models.IModelElement> GetExpressionForReference(string reference)
        {
            if ((reference == "ENTRY"))
            {
                return new EntryProxy(this);
            }
            if ((reference == "EXIT"))
            {
                return new ExitProxy(this);
            }
            return base.GetExpressionForReference(reference);
        }
        
        /// <summary>
        /// Gets the Class for this model element
        /// </summary>
        public override IClass GetClass()
        {
            return ((IClass)(NMF.Models.Repository.MetaRepository.Instance.Resolve("http://www.semanticweb.org/ontologies/2015/ttc/trainbenchmark#//Route/")));
        }
        
        /// <summary>
        /// The collection class to to represent the children of the Route class
        /// </summary>
        public class RouteChildrenCollection : ReferenceCollection, ICollectionExpression<IModelElement>, ICollection<IModelElement>
        {
            
            private Route _parent;
            
            /// <summary>
            /// Creates a new instance
            /// </summary>
            public RouteChildrenCollection(Route parent)
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
                    count = (count + this._parent.Follows.Count);
                    count = (count + this._parent.DefinedBy.Count);
                    return count;
                }
            }
            
            protected override void AttachCore()
            {
                this._parent.Follows.AsNotifiable().CollectionChanged += this.PropagateCollectionChanges;
                this._parent.DefinedBy.AsNotifiable().CollectionChanged += this.PropagateCollectionChanges;
            }
            
            protected override void DetachCore()
            {
                this._parent.Follows.AsNotifiable().CollectionChanged -= this.PropagateCollectionChanges;
                this._parent.DefinedBy.AsNotifiable().CollectionChanged -= this.PropagateCollectionChanges;
            }
            
            /// <summary>
            /// Adds the given element to the collection
            /// </summary>
            /// <param name="item">The item to add</param>
            public override void Add(IModelElement item)
            {
                ISwitchPosition followsCasted = item.As<ISwitchPosition>();
                if ((followsCasted != null))
                {
                    this._parent.Follows.Add(followsCasted);
                }
                ISensor definedByCasted = item.As<ISensor>();
                if ((definedByCasted != null))
                {
                    this._parent.DefinedBy.Add(definedByCasted);
                }
            }
            
            /// <summary>
            /// Clears the collection and resets all references that implement it.
            /// </summary>
            public override void Clear()
            {
                this._parent.Follows.Clear();
                this._parent.DefinedBy.Clear();
            }
            
            /// <summary>
            /// Gets a value indicating whether the given element is contained in the collection
            /// </summary>
            /// <returns>True, if it is contained, otherwise False</returns>
            /// <param name="item">The item that should be looked out for</param>
            public override bool Contains(IModelElement item)
            {
                if (this._parent.Follows.Contains(item))
                {
                    return true;
                }
                if (this._parent.DefinedBy.Contains(item))
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
                IEnumerator<IModelElement> followsEnumerator = this._parent.Follows.GetEnumerator();
                try
                {
                    for (
                    ; followsEnumerator.MoveNext(); 
                    )
                    {
                        array[arrayIndex] = followsEnumerator.Current;
                        arrayIndex = (arrayIndex + 1);
                    }
                }
                finally
                {
                    followsEnumerator.Dispose();
                }
                IEnumerator<IModelElement> definedByEnumerator = this._parent.DefinedBy.GetEnumerator();
                try
                {
                    for (
                    ; definedByEnumerator.MoveNext(); 
                    )
                    {
                        array[arrayIndex] = definedByEnumerator.Current;
                        arrayIndex = (arrayIndex + 1);
                    }
                }
                finally
                {
                    definedByEnumerator.Dispose();
                }
            }
            
            /// <summary>
            /// Removes the given item from the collection
            /// </summary>
            /// <returns>True, if the item was removed, otherwise False</returns>
            /// <param name="item">The item that should be removed</param>
            public override bool Remove(IModelElement item)
            {
                ISwitchPosition switchPositionItem = item.As<ISwitchPosition>();
                if (((switchPositionItem != null) 
                            && this._parent.Follows.Remove(switchPositionItem)))
                {
                    return true;
                }
                ISensor sensorItem = item.As<ISensor>();
                if (((sensorItem != null) 
                            && this._parent.DefinedBy.Remove(sensorItem)))
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
                return Enumerable.Empty<IModelElement>().Concat(this._parent.Follows).Concat(this._parent.DefinedBy).GetEnumerator();
            }
        }
        
        /// <summary>
        /// The collection class to to represent the children of the Route class
        /// </summary>
        public class RouteReferencedElementsCollection : ReferenceCollection, ICollectionExpression<IModelElement>, ICollection<IModelElement>
        {
            
            private Route _parent;
            
            /// <summary>
            /// Creates a new instance
            /// </summary>
            public RouteReferencedElementsCollection(Route parent)
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
                    if ((this._parent.Entry != null))
                    {
                        count = (count + 1);
                    }
                    count = (count + this._parent.Follows.Count);
                    if ((this._parent.Exit != null))
                    {
                        count = (count + 1);
                    }
                    count = (count + this._parent.DefinedBy.Count);
                    return count;
                }
            }
            
            protected override void AttachCore()
            {
                this._parent.EntryChanged += this.PropagateValueChanges;
                this._parent.Follows.AsNotifiable().CollectionChanged += this.PropagateCollectionChanges;
                this._parent.ExitChanged += this.PropagateValueChanges;
                this._parent.DefinedBy.AsNotifiable().CollectionChanged += this.PropagateCollectionChanges;
            }
            
            protected override void DetachCore()
            {
                this._parent.EntryChanged -= this.PropagateValueChanges;
                this._parent.Follows.AsNotifiable().CollectionChanged -= this.PropagateCollectionChanges;
                this._parent.ExitChanged -= this.PropagateValueChanges;
                this._parent.DefinedBy.AsNotifiable().CollectionChanged -= this.PropagateCollectionChanges;
            }
            
            /// <summary>
            /// Adds the given element to the collection
            /// </summary>
            /// <param name="item">The item to add</param>
            public override void Add(IModelElement item)
            {
                if ((this._parent.Entry == null))
                {
                    ISemaphore entryCasted = item.As<ISemaphore>();
                    if ((entryCasted != null))
                    {
                        this._parent.Entry = entryCasted;
                        return;
                    }
                }
                ISwitchPosition followsCasted = item.As<ISwitchPosition>();
                if ((followsCasted != null))
                {
                    this._parent.Follows.Add(followsCasted);
                }
                if ((this._parent.Exit == null))
                {
                    ISemaphore exitCasted = item.As<ISemaphore>();
                    if ((exitCasted != null))
                    {
                        this._parent.Exit = exitCasted;
                        return;
                    }
                }
                ISensor definedByCasted = item.As<ISensor>();
                if ((definedByCasted != null))
                {
                    this._parent.DefinedBy.Add(definedByCasted);
                }
            }
            
            /// <summary>
            /// Clears the collection and resets all references that implement it.
            /// </summary>
            public override void Clear()
            {
                this._parent.Entry = null;
                this._parent.Follows.Clear();
                this._parent.Exit = null;
                this._parent.DefinedBy.Clear();
            }
            
            /// <summary>
            /// Gets a value indicating whether the given element is contained in the collection
            /// </summary>
            /// <returns>True, if it is contained, otherwise False</returns>
            /// <param name="item">The item that should be looked out for</param>
            public override bool Contains(IModelElement item)
            {
                if ((item == this._parent.Entry))
                {
                    return true;
                }
                if (this._parent.Follows.Contains(item))
                {
                    return true;
                }
                if ((item == this._parent.Exit))
                {
                    return true;
                }
                if (this._parent.DefinedBy.Contains(item))
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
                if ((this._parent.Entry != null))
                {
                    array[arrayIndex] = this._parent.Entry;
                    arrayIndex = (arrayIndex + 1);
                }
                IEnumerator<IModelElement> followsEnumerator = this._parent.Follows.GetEnumerator();
                try
                {
                    for (
                    ; followsEnumerator.MoveNext(); 
                    )
                    {
                        array[arrayIndex] = followsEnumerator.Current;
                        arrayIndex = (arrayIndex + 1);
                    }
                }
                finally
                {
                    followsEnumerator.Dispose();
                }
                if ((this._parent.Exit != null))
                {
                    array[arrayIndex] = this._parent.Exit;
                    arrayIndex = (arrayIndex + 1);
                }
                IEnumerator<IModelElement> definedByEnumerator = this._parent.DefinedBy.GetEnumerator();
                try
                {
                    for (
                    ; definedByEnumerator.MoveNext(); 
                    )
                    {
                        array[arrayIndex] = definedByEnumerator.Current;
                        arrayIndex = (arrayIndex + 1);
                    }
                }
                finally
                {
                    definedByEnumerator.Dispose();
                }
            }
            
            /// <summary>
            /// Removes the given item from the collection
            /// </summary>
            /// <returns>True, if the item was removed, otherwise False</returns>
            /// <param name="item">The item that should be removed</param>
            public override bool Remove(IModelElement item)
            {
                if ((this._parent.Entry == item))
                {
                    this._parent.Entry = null;
                    return true;
                }
                ISwitchPosition switchPositionItem = item.As<ISwitchPosition>();
                if (((switchPositionItem != null) 
                            && this._parent.Follows.Remove(switchPositionItem)))
                {
                    return true;
                }
                if ((this._parent.Exit == item))
                {
                    this._parent.Exit = null;
                    return true;
                }
                ISensor sensorItem = item.As<ISensor>();
                if (((sensorItem != null) 
                            && this._parent.DefinedBy.Remove(sensorItem)))
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
                return Enumerable.Empty<IModelElement>().Concat(this._parent.Entry).Concat(this._parent.Follows).Concat(this._parent.Exit).Concat(this._parent.DefinedBy).GetEnumerator();
            }
        }
        
        /// <summary>
        /// Represents a proxy to represent an incremental access to the entry property
        /// </summary>
        private sealed class EntryProxy : ModelPropertyChange<IRoute, ISemaphore>
        {
            
            /// <summary>
            /// Creates a new observable property access proxy
            /// </summary>
            /// <param name="modelElement">The model instance element for which to create the property access proxy</param>
            public EntryProxy(IRoute modelElement) : 
                    base(modelElement)
            {
            }
            
            /// <summary>
            /// Gets or sets the value of this expression
            /// </summary>
            public override ISemaphore Value
            {
                get
                {
                    return this.ModelElement.Entry;
                }
                set
                {
                    this.ModelElement.Entry = value;
                }
            }
            
            /// <summary>
            /// Registers an event handler to subscribe specifically on the changed event for this property
            /// </summary>
            /// <param name="handler">The handler that should be subscribed to the property change event</param>
            protected override void RegisterChangeEventHandler(System.EventHandler<NMF.Expressions.ValueChangedEventArgs> handler)
            {
                this.ModelElement.EntryChanged += handler;
            }
            
            /// <summary>
            /// Registers an event handler to subscribe specifically on the changed event for this property
            /// </summary>
            /// <param name="handler">The handler that should be unsubscribed from the property change event</param>
            protected override void UnregisterChangeEventHandler(System.EventHandler<NMF.Expressions.ValueChangedEventArgs> handler)
            {
                this.ModelElement.EntryChanged -= handler;
            }
        }
        
        /// <summary>
        /// Represents a proxy to represent an incremental access to the exit property
        /// </summary>
        private sealed class ExitProxy : ModelPropertyChange<IRoute, ISemaphore>
        {
            
            /// <summary>
            /// Creates a new observable property access proxy
            /// </summary>
            /// <param name="modelElement">The model instance element for which to create the property access proxy</param>
            public ExitProxy(IRoute modelElement) : 
                    base(modelElement)
            {
            }
            
            /// <summary>
            /// Gets or sets the value of this expression
            /// </summary>
            public override ISemaphore Value
            {
                get
                {
                    return this.ModelElement.Exit;
                }
                set
                {
                    this.ModelElement.Exit = value;
                }
            }
            
            /// <summary>
            /// Registers an event handler to subscribe specifically on the changed event for this property
            /// </summary>
            /// <param name="handler">The handler that should be subscribed to the property change event</param>
            protected override void RegisterChangeEventHandler(System.EventHandler<NMF.Expressions.ValueChangedEventArgs> handler)
            {
                this.ModelElement.ExitChanged += handler;
            }
            
            /// <summary>
            /// Registers an event handler to subscribe specifically on the changed event for this property
            /// </summary>
            /// <param name="handler">The handler that should be unsubscribed from the property change event</param>
            protected override void UnregisterChangeEventHandler(System.EventHandler<NMF.Expressions.ValueChangedEventArgs> handler)
            {
                this.ModelElement.ExitChanged -= handler;
            }
        }
    }
}

