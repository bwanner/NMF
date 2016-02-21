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
    /// The public interface for Attribute
    /// </summary>
    [DefaultImplementationTypeAttribute(typeof(Attribute))]
    [XmlDefaultImplementationTypeAttribute(typeof(Attribute))]
    public interface IAttribute : IModelElement, ITypedElement
    {
        
        /// <summary>
        /// The default value for this attribute
        /// </summary>
        string DefaultValue
        {
            get;
            set;
        }
        
        /// <summary>
        /// The type that declared this attribute
        /// </summary>
        IStructuredType DeclaringType
        {
            get;
            set;
        }
        
        /// <summary>
        /// Gets or sets the attribute that is implemented by the current attribute
        /// </summary>
        IAttribute Refines
        {
            get;
            set;
        }
        
        /// <summary>
        /// Gets fired when the DefaultValue property changed its value
        /// </summary>
        event EventHandler<ValueChangedEventArgs> DefaultValueChanged;
        
        /// <summary>
        /// Gets fired when the DeclaringType property changed its value
        /// </summary>
        event EventHandler<ValueChangedEventArgs> DeclaringTypeChanged;
        
        /// <summary>
        /// Gets fired when the Refines property changed its value
        /// </summary>
        event EventHandler<ValueChangedEventArgs> RefinesChanged;
    }
}

