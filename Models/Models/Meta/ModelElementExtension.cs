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
    /// The default implementation of the ModelElementExtension class
    /// </summary>
    [XmlNamespaceAttribute("http://nmf.codeplex.com/nmeta/")]
    [XmlNamespacePrefixAttribute("nmeta")]
    [ModelRepresentationClassAttribute("http://nmf.codeplex.com/nmeta/#//ModelElementExtension/")]
    public abstract class ModelElementExtension : ModelElement, IModelElementExtension, IModelElement
    {
        
        /// <summary>
        /// The ExtendedElement property
        /// </summary>
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
        [XmlAttributeAttribute(true)]
        [XmlOppositeAttribute("Extensions")]
        public virtual NMF.Models.Meta.IModelElement ExtendedElement
        {
            get
            {
                return ModelHelper.CastAs<NMF.Models.Meta.IModelElement>(this.Parent);
            }
            set
            {
                this.Parent = value;
            }
        }
        
        /// <summary>
        /// Gets the referenced model elements of this model element
        /// </summary>
        public override IEnumerableExpression<IModelElement> ReferencedElements
        {
            get
            {
                return base.ReferencedElements.Concat(new ModelElementExtensionReferencedElementsCollection(this));
            }
        }
        
        /// <summary>
        /// Gets the Class element that describes the structure of this type
        /// </summary>
        public new static NMF.Models.Meta.IClass ClassInstance
        {
            get
            {
                return NMF.Models.Repository.MetaRepository.Instance.ResolveClass("http://nmf.codeplex.com/nmeta/#//ModelElementExtension/");
            }
        }
        
        /// <summary>
        /// Gets fired when the ExtendedElement property changed its value
        /// </summary>
        public event EventHandler<ValueChangedEventArgs> ExtendedElementChanged;
        
        /// <summary>
        /// Gets the Extension for this model element
        /// </summary>
        public abstract IExtension GetExtension();
        
        /// <summary>
        /// Raises the ExtendedElementChanged event
        /// </summary>
        /// <param name="eventArgs">The event data</param>
        protected virtual void OnExtendedElementChanged(ValueChangedEventArgs eventArgs)
        {
            EventHandler<ValueChangedEventArgs> handler = this.ExtendedElementChanged;
            if ((handler != null))
            {
                handler.Invoke(this, eventArgs);
            }
        }
        
        /// <summary>
        /// Gets called when the parent model element of the current model element changes
        /// </summary>
        /// <param name="oldParent">The old parent model element</param>
        /// <param name="newParent">The new parent model element</param>
        protected override void OnParentChanged(IModelElement newParent, IModelElement oldParent)
        {
            NMF.Models.Meta.IModelElement oldExtendedElement = ModelHelper.CastAs<NMF.Models.Meta.IModelElement>(oldParent);
            NMF.Models.Meta.IModelElement newExtendedElement = ModelHelper.CastAs<NMF.Models.Meta.IModelElement>(newParent);
            if ((oldExtendedElement != null))
            {
                oldExtendedElement.Extensions.Remove(this);
            }
            if ((newExtendedElement != null))
            {
                newExtendedElement.Extensions.Add(this);
            }
            ValueChangedEventArgs e = new ValueChangedEventArgs(oldExtendedElement, newExtendedElement);
            this.OnExtendedElementChanged(e);
            this.OnPropertyChanged("ExtendedElement", e);
        }
        
        /// <summary>
        /// Sets a value to the given feature
        /// </summary>
        /// <param name="feature">The requested feature</param>
        /// <param name="value">The value that should be set to that feature</param>
        protected override void SetFeature(string feature, object value)
        {
            if ((feature == "EXTENDEDELEMENT"))
            {
                this.ExtendedElement = ((NMF.Models.Meta.IModelElement)(value));
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
            if ((attribute == "EXTENDEDELEMENT"))
            {
                return new ExtendedElementProxy(this);
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
            if ((reference == "EXTENDEDELEMENT"))
            {
                return new ExtendedElementProxy(this);
            }
            return base.GetExpressionForReference(reference);
        }
        
        /// <summary>
        /// Gets the Class for this model element
        /// </summary>
        public override IClass GetClass()
        {
            return ((IClass)(NMF.Models.Repository.MetaRepository.Instance.Resolve("http://nmf.codeplex.com/nmeta/#//ModelElementExtension/")));
        }
        
        /// <summary>
        /// The collection class to to represent the children of the ModelElementExtension class
        /// </summary>
        public class ModelElementExtensionReferencedElementsCollection : ReferenceCollection, ICollectionExpression<IModelElement>, ICollection<IModelElement>
        {
            
            private ModelElementExtension _parent;
            
            /// <summary>
            /// Creates a new instance
            /// </summary>
            public ModelElementExtensionReferencedElementsCollection(ModelElementExtension parent)
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
                    if ((this._parent.ExtendedElement != null))
                    {
                        count = (count + 1);
                    }
                    return count;
                }
            }
            
            protected override void AttachCore()
            {
                this._parent.ExtendedElementChanged += this.PropagateValueChanges;
            }
            
            protected override void DetachCore()
            {
                this._parent.ExtendedElementChanged -= this.PropagateValueChanges;
            }
            
            /// <summary>
            /// Adds the given element to the collection
            /// </summary>
            /// <param name="item">The item to add</param>
            public override void Add(IModelElement item)
            {
                if ((this._parent.ExtendedElement == null))
                {
                    NMF.Models.Meta.IModelElement extendedElementCasted = item.As<NMF.Models.Meta.IModelElement>();
                    if ((extendedElementCasted != null))
                    {
                        this._parent.ExtendedElement = extendedElementCasted;
                        return;
                    }
                }
            }
            
            /// <summary>
            /// Clears the collection and resets all references that implement it.
            /// </summary>
            public override void Clear()
            {
                this._parent.ExtendedElement = null;
            }
            
            /// <summary>
            /// Gets a value indicating whether the given element is contained in the collection
            /// </summary>
            /// <returns>True, if it is contained, otherwise False</returns>
            /// <param name="item">The item that should be looked out for</param>
            public override bool Contains(IModelElement item)
            {
                if ((item == this._parent.ExtendedElement))
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
                if ((this._parent.ExtendedElement != null))
                {
                    array[arrayIndex] = this._parent.ExtendedElement;
                    arrayIndex = (arrayIndex + 1);
                }
            }
            
            /// <summary>
            /// Removes the given item from the collection
            /// </summary>
            /// <returns>True, if the item was removed, otherwise False</returns>
            /// <param name="item">The item that should be removed</param>
            public override bool Remove(IModelElement item)
            {
                if ((this._parent.ExtendedElement == item))
                {
                    this._parent.ExtendedElement = null;
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
                return Enumerable.Empty<IModelElement>().Concat(this._parent.ExtendedElement).GetEnumerator();
            }
        }
        
        /// <summary>
        /// Represents a proxy to represent an incremental access to the ExtendedElement property
        /// </summary>
        private sealed class ExtendedElementProxy : ModelPropertyChange<IModelElementExtension, NMF.Models.Meta.IModelElement>
        {
            
            /// <summary>
            /// Creates a new observable property access proxy
            /// </summary>
            /// <param name="modelElement">The model instance element for which to create the property access proxy</param>
            public ExtendedElementProxy(IModelElementExtension modelElement) : 
                    base(modelElement)
            {
            }
            
            /// <summary>
            /// Gets or sets the value of this expression
            /// </summary>
            public override NMF.Models.Meta.IModelElement Value
            {
                get
                {
                    return this.ModelElement.ExtendedElement;
                }
                set
                {
                    this.ModelElement.ExtendedElement = value;
                }
            }
            
            /// <summary>
            /// Registers an event handler to subscribe specifically on the changed event for this property
            /// </summary>
            /// <param name="handler">The handler that should be subscribed to the property change event</param>
            protected override void RegisterChangeEventHandler(System.EventHandler<NMF.Expressions.ValueChangedEventArgs> handler)
            {
                this.ModelElement.ExtendedElementChanged += handler;
            }
            
            /// <summary>
            /// Registers an event handler to subscribe specifically on the changed event for this property
            /// </summary>
            /// <param name="handler">The handler that should be unsubscribed from the property change event</param>
            protected override void UnregisterChangeEventHandler(System.EventHandler<NMF.Expressions.ValueChangedEventArgs> handler)
            {
                this.ModelElement.ExtendedElementChanged -= handler;
            }
        }
    }
}

