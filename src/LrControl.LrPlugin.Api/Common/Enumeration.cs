﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LrControl.LrPlugin.Api.Common
{
    public abstract class Enumeration<TEnum, TValue> : IEnumeration<TValue>, IEquatable<Enumeration<TEnum, TValue>>
        where TEnum : IEnumeration<TValue>
        where TValue : IComparable
    {
        private static readonly Lazy<List<TEnum>> AllEnumsCache = new Lazy<List<TEnum>>(() =>
        {
            var fields = typeof(TEnum).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);
            return fields.Select(info => info.GetValue(null)).OfType<TEnum>().ToList();
        });

        protected Enumeration(TValue value, string name)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; }

        public TValue Value { get; }

        public override string ToString() => Name;

        public static TEnum GetEnumForValue(TValue value)
        {
            return GetAll().FirstOrDefault(e => e.Value.Equals(value));
        }

        public static ICollection<TEnum> GetAll() => AllEnumsCache.Value;

        public int CompareTo(object other)
        {
            return Value.CompareTo(((TEnum) other).Value);
        }

        public static bool operator ==(Enumeration<TEnum, TValue> some, Enumeration<TEnum, TValue> other)
        {
            if (ReferenceEquals(some, null))
                return ReferenceEquals(other, null);

            if (ReferenceEquals(other, null))
                return false;

            return some.Equals(other);
        }

        public static bool operator !=(Enumeration<TEnum, TValue> some, Enumeration<TEnum, TValue> other)
        {
            return !(some == other);
        }
        
        public bool Equals(Enumeration<TEnum, TValue> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return EqualityComparer<TValue>.Default.Equals(Value, other.Value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Enumeration<TEnum, TValue>) obj);
        }

        public override int GetHashCode()
        {
            return EqualityComparer<TValue>.Default.GetHashCode(Value);
        }
    }
}