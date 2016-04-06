using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics.Demo
{
    /// <summary>
    ///  Cheap imitation of the System.Nullable &lt;T&gt; 
    ///  class for demonstration purposes"/>"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public struct Nillable<T>
    {
        private bool _hasValue;
        private T _internalValue;

        public bool HasValue
        {
            get { return _hasValue; }
        }

        public T Value
        {
            get
            {
                if (!this.HasValue)
                    throw new InvalidOperationException(
                        "Cannot get value of Nillable<T> when HasValue is false.");
                return _internalValue;
            }
        }

        public Nillable(T internalValue)
        {
            _internalValue = internalValue;
            _hasValue = true;
        }

        public T GetValueOrDefault()
        {
            return this.HasValue ? this.Value : default(T);
        }

    }
}

