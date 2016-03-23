﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Chloe.Mapper
{
    public class EntityConstructor
    {
        EntityConstructor(ConstructorInfo constructorInfo)
        {
            this.ConstructorInfo = constructorInfo;
            this.Init();
        }

        void Init()
        {
            throw new NotImplementedException();
        }

        public ConstructorInfo ConstructorInfo { get; private set; }
        public Func<IDataReader, ReaderOrdinalEnumerator, ObjectActivtorEnumerator, object> InstanceCreator { get; private set; }

        static readonly System.Collections.Concurrent.ConcurrentDictionary<ConstructorInfo, EntityConstructor> _instanceCache = new System.Collections.Concurrent.ConcurrentDictionary<ConstructorInfo, EntityConstructor>();

        public static EntityConstructor GetInstance(ConstructorInfo constructorInfo)
        {
            EntityConstructor instance;
            if (!_instanceCache.TryGetValue(constructorInfo, out instance))
            {
                instance = new EntityConstructor(constructorInfo);
                instance = _instanceCache.GetOrAdd(constructorInfo, instance);
            }

            return instance;
        }
    }

    public struct ReaderOrdinalEnumerator
    {
        List<int> _readerOrdinals;
        int _next;
        public ReaderOrdinalEnumerator(List<int> readerOrdinals)
        {
            this._readerOrdinals = readerOrdinals;
            this._next = 0;
        }
        public int Next()
        {
            if (this._next < this._readerOrdinals.Count - 1)
                throw new Exception();

            int ret = this._readerOrdinals[this._next];
            this._next++;
            return ret;
        }
    }
    public struct ObjectActivtorEnumerator
    {
        List<IObjectActivtor> _objectActivtors;
        int _next;
        public ObjectActivtorEnumerator(List<IObjectActivtor> objectActivtors)
        {
            this._objectActivtors = objectActivtors;
            this._next = 0;
        }
        public IObjectActivtor Next()
        {
            if (this._next < this._objectActivtors.Count - 1)
                throw new Exception();

            IObjectActivtor ret = this._objectActivtors[this._next];
            this._next++;
            return ret;
        }
    }

}
