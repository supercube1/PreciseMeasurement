﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using PM.Business.Pages;
using PM.Entity;

namespace PM.Web.report
{
    public partial class custom : BasePage
    {

        //层级计量点列表
        public Dictionary<string, List<MeasurePointInfo>> measurePointList = null;
        public List<string> SettingList = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            btnExport.Click += new EventHandler(btnExport_Click);
            if (!IsPostBack)
            {
                SettingList = GetReportSettingNameListByUser();
                BindMeasurePointData();
            }
        }

        private List<string> GetReportSettingNameListByUser() {
            return PM.Data.ReportSetting.GetReportSettingNameList(userid, orgid);
        }
       


        /// <summary>
        /// 获取所有计量点数据
        /// </summary>
        private void BindMeasurePointData()
        {
            //获取所有层级
            Dictionary<int, string> levels = Business.Locations.GetLevels(orgid, siteid);

            //获取层级对应的计量点数据
            Dictionary<string, List<MeasurePointInfo>> result = new Dictionary<string, List<MeasurePointInfo>>();

            int i = 0;
            foreach (KeyValuePair<int, string> pair in levels)
            {
                int level = pair.Key;
                string key = pair.Value;

                List<MeasurePointInfo> listByLevel = Business.MeasurePoint.FindMeasurePointsByLevel(level, orgid, siteid);

                result.Add(key, listByLevel);
                i++;
            }

            //层级计量点列表
            measurePointList = result;
        }


        private void btnExport_Click(object sender, EventArgs e)
        {
           
        }
    }
}