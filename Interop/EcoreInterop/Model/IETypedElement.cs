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

namespace NMF.Interop.Ecore
{
    
    
    /// <summary>
    /// The public interface for ETypedElement
    /// </summary>
    [DefaultImplementationTypeAttribute(typeof(ETypedElement))]
    [XmlDefaultImplementationTypeAttribute(typeof(ETypedElement))]
    public interface IETypedElement : IModelElement, IENamedElement
    {
        
        /// <summary>
        /// The ordered property
        /// </summary>
        Nullable<bool> Ordered
        {
            get;
            set;
        }
        
        /// <summary>
        /// The unique property
        /// </summary>
        Nullable<bool> Unique
        {
            get;
            set;
        }
        
        /// <summary>
        /// The lowerBound property
        /// </summary>
        Nullable<int> LowerBound
        {
            get;
            set;
        }
        
        /// <summary>
        /// The upperBound property
        /// </summary>
        Nullable<int> UpperBound
        {
            get;
            set;
        }
        
        /// <summary>
        /// The eType property
        /// </summary>
        IEClassifier EType
        {
            get;
            set;
        }
        
        /// <summary>
        /// The eGenericType property
        /// </summary>
        IEGenericType EGenericType
        {
            get;
            set;
        }
        
        /// <summary>
        /// Gets fired when the Ordered property changed its value
        /// </summary>
        event EventHandler<ValueChangedEventArgs> OrderedChanged;
        
        /// <summary>
        /// Gets fired when the Unique property changed its value
        /// </summary>
        event EventHandler<ValueChangedEventArgs> UniqueChanged;
        
        /// <summary>
        /// Gets fired when the LowerBound property changed its value
        /// </summary>
        event EventHandler<ValueChangedEventArgs> LowerBoundChanged;
        
        /// <summary>
        /// Gets fired when the UpperBound property changed its value
        /// </summary>
        event EventHandler<ValueChangedEventArgs> UpperBoundChanged;
        
        /// <summary>
        /// Gets fired when the EType property changed its value
        /// </summary>
        event EventHandler<ValueChangedEventArgs> ETypeChanged;
        
        /// <summary>
        /// Gets fired when the EGenericType property changed its value
        /// </summary>
        event EventHandler<ValueChangedEventArgs> EGenericTypeChanged;
    }
}

