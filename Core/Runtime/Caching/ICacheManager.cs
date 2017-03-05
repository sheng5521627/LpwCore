using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Runtime.Caching
{
    /// <summary>
    /// 管理缓存接口
    /// 作为单例模式管理跟踪缓存
    /// </summary>
    public interface ICacheManager : IDisposable
    {
        /// <summary>
        /// 获取所有的缓存系统
        /// </summary>
        /// <returns></returns>
        IReadOnlyList<ICache> GetAllCaches();

        /// <summary>
        /// 根据缓存名称获取缓存系统
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        ICache GetCache(string name);
    }
}
