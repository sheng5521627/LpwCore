using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Collections
{
    /// <summary>
    ///  类型列表
    /// </summary>
    public class TypeList : TypeList<object>, ITypeList
    {
    }

    /// <summary>
    /// 添加限制特定的基类型
    /// </summary>
    /// <typeparam name="TBaseType"></typeparam>
    public class TypeList<TBaseType> : ITypeList<TBaseType>
    {
        private readonly List<Type> _typeList;

        public TypeList()
        {
            _typeList = new List<Type>();
        }

        public IEnumerator<Type> GetEnumerator()
        {
            return _typeList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _typeList.GetEnumerator();
        }

        public void Add(Type item)
        {
            CheckType(item);
            _typeList.Add(item);
        }

        public void Clear()
        {
            _typeList.Clear();
        }

        public bool Contains(Type item)
        {
            return _typeList.Contains(item);
        }

        public void CopyTo(Type[] array, int arrayIndex)
        {
            _typeList.CopyTo(array, arrayIndex);
        }

        public bool Remove(Type item)
        {
            return _typeList.Remove(item);
        }

        public int Count { get { return _typeList.Count; } }

        public bool IsReadOnly { get { return false; } }

        public int IndexOf(Type item)
        {
            return _typeList.IndexOf(item);
        }

        public void Insert(int index, Type item)
        {
            _typeList.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            _typeList.RemoveAt(index);
        }

        public Type this[int index]
        {
            get { return _typeList[index]; }
            set
            {
                CheckType(value);
                _typeList[index] = value;
            }
        }

        public void Add<T>() where T : TBaseType
        {
            _typeList.Add(typeof(T));
        }

        public bool Contains<T>() where T : TBaseType
        {
            return _typeList.Contains(typeof(T));
        }

        public void Remove<T>() where T : TBaseType
        {
            _typeList.Remove(typeof(T));
        }

        private static void CheckType(Type item)
        {
            if (!typeof(TBaseType).IsAssignableFrom(item))
            {
                throw new ArgumentException("给定的类型不是" + typeof(TBaseType).AssemblyQualifiedName, "item");
            }
        }
    }
}
