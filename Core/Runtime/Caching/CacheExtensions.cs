using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Runtime.Caching
{
    public static class CacheExtensions
    {
        /// <summary>
        /// 获取缓存值
        /// </summary>
        /// <param name="cache"></param>
        /// <param name="key"></param>
        /// <param name="factory"></param>
        /// <returns></returns>
        public static object Get(this ICache cache, string key, Func<object> factory)
        {
            return cache.Get(key, k => factory());
        }

        /// <summary>
        /// 将ICache转换成ITypedCache类型
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="cache"></param>
        /// <returns></returns>
        public static ITypedCache<TKey, TValue> AsTyped<TKey, TValue>(this ICache cache)
        {
            return new TypedCacheWrapper<TKey, TValue>(cache);
        }

        /// <summary>
        /// 获取缓存值
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="cache"></param>
        /// <param name="key"></param>
        /// <param name="factory"></param>
        /// <returns></returns>
        public static TValue Get<TKey, TValue>(this ICache cache, TKey key, Func<TKey, TValue> factory)
        {
            return (TValue)cache.Get(key.ToString(), k => factory(key));
        }

        /// <summary>
        /// 获取缓存值
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="cache"></param>
        /// <param name="key"></param>
        /// <param name="factory"></param>
        /// <returns></returns>
        public static TValue Get<TKey, TValue>(this ICache cache, TKey key, Func<TValue> factory)
        {
            return cache.Get(key, k => factory());
        }

        /// <summary>
        /// 获取缓存值，若不存在，则返回默认值
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="cache"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static TValue GetOrDefault<TKey, TValue>(this ICache cache, TKey key)
        {
            var value = cache.GetOrDefault(key.ToString());
            if (value == null)
            {
                return default(TValue);
            }
            return (TValue)value;
        }
    }
}
