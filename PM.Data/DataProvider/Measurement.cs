﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using PM.Data;
using PM.Config;
using PM.Common;
using PM.Entity;

namespace PM.Data
{
    /// <summary>
    /// 计量器读表数
    /// </summary>
    public class Measurement
    {
        /// <summary>
        /// 获取指定计量器的最后记录值
        /// </summary>
        /// <param name="pointnum">记录器编号</param>
        /// <returns></returns>
        public static IDataReader FindLastMeasurement(string pointnum)
        {
            return DatabaseProvider.GetInstance().FindLastMeasurement(pointnum);
        }

        /// <summary>
        /// 返回指定计量器的最后记录对象
        /// </summary>
        /// <param name="pointnum">计量器编号</param>
        /// <returns></returns>
        public static MeasurementInfo GetLastMeasurement(string pointnum) {

            MeasurementInfo measurement = new MeasurementInfo();
            IDataReader reader = FindLastMeasurement(pointnum);
            if (reader.Read())
            {
                measurement = LoadMeasurementInfo(reader);
                reader.Close();
            }
            return measurement;

        }

        /// <summary>
        /// 加载读数对象
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static MeasurementInfo LoadMeasurementInfo(IDataReader reader)
        {
            MeasurementInfo measurement = new MeasurementInfo();
            measurement.Measurementid = reader.GetInt64(reader.GetOrdinal("MEASUREMENTID"));
            measurement.Pointnum = reader["POINTNUM"].ToString();
            measurement.DeviceNum = reader["DEVICENUM"].ToString();
            measurement.Inspector = reader["INSPECTOR"].ToString();
            measurement.Measuretime = TypeConverter.StrToDateTime(reader["MEASURETIME"].ToString(), DateTime.Parse("1900-01-01"));
            measurement.AiDensity = reader.GetDecimal(reader.GetOrdinal("AI_DENSITY"));
            measurement.SwTemperature = reader.GetDecimal(reader.GetOrdinal("SW_TEMPERATURE"));
            measurement.AfFlowinstant = reader.GetDecimal(reader.GetOrdinal("AF_FLOWINSTANT"));
            measurement.SwPressure = reader.GetDecimal(reader.GetOrdinal("SW_PRESSURE"));
            measurement.AtFlow = reader.GetDecimal(reader.GetOrdinal("AT_FLOW"));
            measurement.MV1 = reader.GetDecimal(reader.GetOrdinal("MV1"));
            measurement.MV2 = reader.GetDecimal(reader.GetOrdinal("MV2"));
            measurement.MV3 = reader.GetDecimal(reader.GetOrdinal("MV3"));
            measurement.MV4 = reader.GetDecimal(reader.GetOrdinal("MV4"));
            measurement.MV5 = reader.GetOrdinal("MV5").ToString();

            return measurement;
        }


        /// <summary>
        /// 获取指定查询条件的读表数据
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="pageindex">当前页</param>
        /// <param name="pagesize">每页显示数</param>
        /// <param name="recordcount">总条数</param>
        /// <returns></returns>
        public static DataTable FindMeasurementByCondition(string condition, string type,int pageindex, int pagesize, out int recordcount)
        {
            return DatabaseProvider.GetInstance().FindMeasurementByCondition(condition, type,pageindex, pagesize, out recordcount);
        }

        /// <summary>
        /// 获取指定测点的读表数据
        /// </summary>
        /// <param name="pointnum">测点编号</param>
        /// <param name="startdate">开始时间</param>
        /// <param name="enddate">结束时间</param>
        /// <param name="type">查询类型</param>
        /// <param name="pageindex">当前页</param>
        /// <param name="pagesize">每页显示数</param>
        /// <param name="recordcount">总条数</param>
        /// <returns></returns>
        public static DataSet FindMeasurementByPointnum(string pointnum, string startdate, string enddate, string type, int pageindex, int pagesize) {
            return DatabaseProvider.GetInstance().FindMeasurementByPointnum(pointnum, startdate, enddate, type, pageindex, pagesize);
        }

        /// <summary>
        /// 获取指定时间内所有计量器的读表数据
        /// </summary>
        /// <param name="startdate">开始时间</param>
        /// <param name="enddate">结束时间</param>
        /// <param name="type">查询方式： ALL全部 DAY日报 WEEK周报 MONTH月报 </param>
        /// <param name="pageindex">当前页</param>
        /// <param name="pagesize">每页显示数</param>
        /// <returns></returns>
        public static DataSet FindMeasurementByAllPoint(string startdate, string enddate, string type, int pageindex, int pagesize) {
            return DatabaseProvider.GetInstance().FindMeasurementByAllPoint(startdate, enddate, type, pageindex, pagesize);
        }
    }
}
