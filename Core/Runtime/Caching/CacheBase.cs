using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Runtime.Caching
{
    /// <summary>
    /// 缓存基类
    /// </summary>
    public abstract class CacheBase : ICache
    {
        private readonly object SyncObj = new object();

        public CacheBase(string name)
        {
            Name = name;
            DefaultSlidingExpireTime = TimeSpan.FromHours(1);
        }

        public TimeSpan DefaultAbsoluteExpireTime { get; set; }

        public TimeSpan DefaultSlidingExpireTime { get; set; }

        public string Name { get; }

        public object Get(string key, Func<string, object> factory)
        {
            object item = GetOrDefault(key);
            if (item == null)
            {
                lock (SyncObj)
                {
                    item = GetOrDefault(key);
                    if (item == null)
                    {
                        item = factory(key);
                        if (item == null)
                        {
                            return null;
                        }
                        Set(key, item);
                    }
                }
            }
            return item;
        }

        public abstract object GetOrDefault(string key);

        public abstract void Remove(string key);

        public abstract void Set(string key, object value, TimeSpan? slidingExpireTime = null,
            TimeSpan? absoluteExpireTime = null);

        public abstract void Clear();

        public virtual void Dispose()
        {

        }
    }
}
