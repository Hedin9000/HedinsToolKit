using System;
using System.Collections.Generic;
using System.Text;

namespace HedinsToolKit.PrimaryKey
{
    public interface IPrimaryKey<out TKey>
    where TKey : IEquatable<TKey>
    {
        TKey Id { get; }
    }
}
