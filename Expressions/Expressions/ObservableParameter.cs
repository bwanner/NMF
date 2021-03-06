﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NMF.Expressions
{
    internal class ObservableParameter<T> : NotifyExpression<T>
    {
        public ObservableParameter(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        protected override T GetValue()
        {
            throw new InvalidOperationException(string.Format("No value for the argument {0} was provided.", Name));
        }

        protected override void DetachCore() { }

        protected override void AttachCore() { }

        public override bool IsParameterFree
        {
            get { return false; }
        }

        public override INotifyExpression<T> ApplyParameters(IDictionary<string, object> parameters)
        {
            object value;
            if (parameters != null && parameters.TryGetValue(Name, out value))
            {
                var notifyValue = value as INotifyValue<T>;
                if (notifyValue != null)
                {
                    var notifyReversableValue = value as INotifyReversableValue<T>;
                    if (notifyReversableValue != null)
                    {
                        return new ObservableProxyReversableExpression<T>(notifyReversableValue);
                    }
                    else
                    {
                        return new ObservableProxyExpression<T>(notifyValue);
                    }
                }
                else 
                {
                    return new ObservableConstant<T>((T)value);
                }
            }
            else
            {
                return this;
            }
        }
    }
}
