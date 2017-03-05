using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Configuration
{
    /// <summary>
    /// 定义一个字典接口类型管理配置
    /// </summary>
    public interface IDictionaryBasedConfig
    {
        /// <summary>
        /// 设置字符串配置
        /// 如果已存在该配置，则覆盖
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <param name="value"></param>
        void Set<T>(string name, T value);

        /// <summary>
        /// 根据名称获取配置信息
        /// </summary>
        /// <param name="name">配置的唯一名称</param>
        /// <returns>配置值，不存在返回null</returns>
        object Get(string name);

        /// <summary>
        /// 根据名称获取配置信息
        /// </summary>
        /// <typeparam name="T">配置值的类型</typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        T Get<T>(string name);

        /// <summary>
        /// 根据名称获取配置信息
        /// </summary>
        /// <param name="name"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        object Get(string name, object defaultValue);

        /// <summary>
        /// 根据名称获取配置信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        T Get<T>(string name, T defaultValue);

        /// <summary>
        /// 根据名称获取配置信息
        /// </summary>
        /// <typeparam name="T">配置信息类型</typeparam>
        /// <param name="name"></param>
        /// <param name="creator">若找不到配置信息，则执行委托返回配置信息</param>
        /// <returns></returns>
        T GetOrCreate<T>(string name, Func<T> creator);
    }
}
