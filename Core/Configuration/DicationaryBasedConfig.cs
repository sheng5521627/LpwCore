using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Core.Configuration
{
    /// <summary>
    /// 获取/设置自定义配置
    /// </summary>
    public class DicationaryBasedConfig : IDictionaryBasedConfig
    {
        /// <summary>
        /// 自定义配置字典
        /// </summary>
        protected IDictionary<string, object> CustomSettings { get; private set; }

        public DicationaryBasedConfig()
        {
            CustomSettings = new ConcurrentDictionary<string, object>();
        }

        /// <summary>
        /// 获取或设置配置信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public object this[string name]
        {
            get { return CustomSettings[name]; }
            set { CustomSettings[name] = value; }
        }

        public object Get(string name)
        {
            throw new NotImplementedException();
        }

        public object Get(string name, object defaultValue)
        {
            throw new NotImplementedException();
        }

        public T Get<T>(string name)
        {
            throw new NotImplementedException();
        }

        public T Get<T>(string name, T defaultValue)
        {
            throw new NotImplementedException();
        }

        public T GetOrCreate<T>(string name, Func<T> creator)
        {
            throw new NotImplementedException();
        }

        public void Set<T>(string name, T value)
        {
            throw new NotImplementedException();
        }
    }
}
