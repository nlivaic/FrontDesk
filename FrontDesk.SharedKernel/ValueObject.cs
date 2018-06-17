using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FrontDesk.SharedKernel {
    public abstract class ValueObject<T> : IEquatable<T>
        where T : ValueObject<T>
    {
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            T other = obj as T;
            if (other != null)
            {
                return Equals(other);
            }
            return base.Equals(obj);
        }
        
        public virtual bool Equals(T other)
        {
            if (other == null)
                return false;
            
            Type thisType = this.GetType();
            Type otherType = other.GetType();
            if (thisType != otherType)
                return false;
            
            IEnumerable<FieldInfo> fields = GetFields();
            foreach (FieldInfo field in fields)
            {
                if (!object.Equals(field.GetValue(this), field.GetValue(other)))
                {
                    return false;
                }
            }
            return true;
        }
        public override int GetHashCode()
        {
            int hashCode = 17;
            int multiplier = 59;
            IEnumerable<FieldInfo> fields = GetFields();
            
            foreach (FieldInfo property in fields)
            {
                object value = property.GetValue(this);
                if (value != null)
                    hashCode = hashCode * multiplier + value.GetHashCode();
            }
            return hashCode;
        }
        private IEnumerable<FieldInfo> GetFields()
        {
            List<FieldInfo> fields = new List<FieldInfo>();
            Type type = this.GetType();
            while (type != typeof(object))
            {            
                fields.AddRange(type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public));
                type = type.BaseType;
            }
            return fields;
        }

        public static bool operator == (ValueObject<T> x, ValueObject<T> y)
        {
            return x.Equals(y);
        }

        public static bool operator != (ValueObject<T> x, ValueObject<T> y)
        {
            return !(x == y);
        }        
    }
}