using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Runtime.Caching
{
    /// <summary>
    /// 以类型化方式的缓存接口。
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public interface ITypedCache<TKey, TValue> : IDisposable
    {
        /// <summary>
        /// 缓存唯一名称
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 默认的缓存过期时间
        /// </summary>
        TimeSpan DefaulSlidingExpireTime { get; set; }

        /// <summary>
        /// 内部缓存系统
        /// </summary>
        ICache InnerCache { get; }

        /// <summary>
        /// 获取缓存值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="factory"></param>
        /// <returns></returns>
        TValue Get(TKey key, Func<TKey, TValue> factory);

        /// <summary>
        /// 获取缓存值，如果不存在，则返回null
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        TValue GetOrDefault(TKey key);

        /// <summary>
        /// 设置缓存值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="slidingExpireTime"></param>
        void Set(TKey key, TValue value, TimeSpan? slidingExpireTime = null);

        /// <summary>
        /// 移除指定的缓存项
        /// </summary>
        /// <param name="key"></param>
        void Remove(TKey key);

        /// <summary>
        /// 清空所有的缓存值
        /// </summary>
        void Clear();
    }
}
