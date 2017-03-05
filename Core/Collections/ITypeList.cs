using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Collections
{
    /// <summary>
    /// 对象基类型的捷径
    /// </summary>
    public interface ITypeList : ITypeList<object>
    {
    }

    public interface ITypeList<in TBaseType> : IList<Type>
    {
        /// <summary>
        /// 添加类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        void Add<T>() where T : TBaseType;

        /// <summary>
        /// 判断列表中是否包含给定的类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        bool Contains<T>() where T : TBaseType;

        /// <summary>
        /// 从列表中移除给定的类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        void Remove<T>() where T : TBaseType;
    }
}
