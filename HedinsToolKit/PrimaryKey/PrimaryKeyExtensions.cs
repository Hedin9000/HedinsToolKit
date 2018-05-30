using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HedinsToolKit.PrimaryKey
{
    public static class PrimaryKeyExtensions
    {
        /// <summary>
        /// Find item by id. If item is not exist - return null;
        /// </summary>
        /// <typeparam name="TEntity">Type of item</typeparam>
        /// <typeparam name="TKey">Type of key</typeparam>
        /// <param name="list">Source collection</param>
        /// <param name="id">Key</param>
        /// <returns>Item (or null)</returns>
        public static TEntity GetById<TEntity, TKey>(this IEnumerable<TEntity> list,TKey id )
        where TEntity : IPrimaryKey<TKey> 
        where TKey : IEquatable<TKey>
        {
            var resultList = from item in list
                             where item.Id.Equals(id)
                             select item;

            return resultList.FirstOrDefault();
        }
    }


}
