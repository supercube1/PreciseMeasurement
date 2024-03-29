﻿using System;
using System.Text;
using System.Reflection;
using PM.Config;

namespace PM.Data
{
    /// <summary>
    /// 数据库连接提供类
    /// </summary>
    public class DatabaseProvider
    {
        private DatabaseProvider()
        { }

        private static IDataProvider _instance = null;
        private static object lockHelper = new object();

        static DatabaseProvider()
        {
            GetProvider();
        }

        private static void GetProvider()
        {
            try
            {
                //意思检查bin下必须有相磁 BaseConfigs.GetDbType 的依赖
                _instance = (IDataProvider)Activator.CreateInstance(Type.GetType(string.Format("PM.Data.{0}.DataProvider, PM.Data.{0}", BaseConfigs.GetDbType), false, true));
            }
            catch
            {
                throw new Exception("请检查PM.config中Dbtype节点数据库类型是否正确，例如：SqlServer、Access、MySql");
            }
        }

        public static IDataProvider GetInstance()
        {
            if (_instance == null)
            {
                lock (lockHelper)
                {
                    if (_instance == null)
                    {
                        GetProvider();
                    }
                }
            }
            return _instance;
        }

        public static void ResetDbProvider()
        {
            _instance = null;
        }
    }
}
