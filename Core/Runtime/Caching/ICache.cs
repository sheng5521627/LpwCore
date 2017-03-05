using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Runtime.Caching
{
    /// <summary>
    /// 缓存接口
    /// </summary>
    public interface ICache : IDisposable
    {
        /// <summary>
        /// 缓存唯一名称
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 缓存相对过期时间
        /// </summary>
        TimeSpan DefaultSlidingExpireTime { get; set; }

        /// <summary>
        /// 缓存绝对过期时间
        /// </summary>
        TimeSpan DefaultAbsoluteExpireTime { get; set; }

        /// <summary>
        /// 根据key从缓存中获取值
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="factory">如果不存在，则根据工厂方法设置缓存值</param>
        /// <returns></returns>
        object Get(string key, Func<string, object> factory);

        /// <summary>
        /// 从缓存中获取值，如果不存在，则返回null
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        object GetOrDefault(string key);

        /// <summary>
        /// 设置缓存值
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="value">缓存值</param>
        /// <param name="slidingExpireTime">相对过期时间</param>
        /// <param name="absoluteExpireTime">绝对过期时间</param>
        void Set(string key, object value, TimeSpan? slidingExpireTime = null, TimeSpan? absoluteExpireTime = null);

        /// <summary>
        /// 移除缓存项
        /// </summary>
        /// <param name="key"></param>
        void Remove(string key);

        /// <summary>
        /// 清空缓存
        /// </summary>
        void Clear();
    }
}
