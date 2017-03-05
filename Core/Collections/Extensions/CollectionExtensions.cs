using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Collections.Extensions
{
    /// <summary>
    /// 集合类扩展方法
    /// </summary>
    public static class CollectionExtensions
    {
        /// <summary>
        /// 判断集合是否为null或长度不大于0
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty<T>(this ICollection<T> source)
        {
            return source == null || source.Count <= 0;
        }

        /// <summary>
        /// 如果集合中不存在给定的项，则添加
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="item">如果添加返回true，否则返回false</param>
        /// <returns></returns>
        public static bool AddIfNotContains<T>(this ICollection<T> source, T item)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (source.Contains(item))
            {
                return false;
            }
            source.Add(item);
            return true;
        }
    }
}
