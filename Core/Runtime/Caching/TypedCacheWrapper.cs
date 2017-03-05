using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Runtime.Caching
{
    public class TypedCacheWrapper<TKey, TValue> : ITypedCache<TKey, TValue>
    {
        public TypedCacheWrapper(ICache cache)
        {
            InnerCache = cache;
        }

        public ICache InnerCache { get; private set; }

        public TimeSpan DefaulSlidingExpireTime
        {
            get { return InnerCache.DefaultSlidingExpireTime; }
            set { InnerCache.DefaultSlidingExpireTime = value; }
        }

        public string Name
        {
            get { return InnerCache.Name; }
        }

        public void Clear()
        {
            InnerCache.Clear();
        }

        public void Dispose()
        {
            InnerCache.Dispose();
        }

        public TValue Get(TKey key, Func<TKey, TValue> factory)
        {
            return InnerCache.Get(key, factory);
        }

        public TValue GetOrDefault(TKey key)
        {
            return InnerCache.GetOrDefault<TKey, TValue>(key);
        }

        public void Remove(TKey key)
        {
            InnerCache.Remove(key.ToString());
        }

        public void Set(TKey key, TValue value, TimeSpan? slidingExpireTime = default(TimeSpan?))
        {
            InnerCache.Set(key.ToString(), value, slidingExpireTime);
        }
    }
}
