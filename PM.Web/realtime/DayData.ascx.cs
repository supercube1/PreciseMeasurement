﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using PM.Common;
using PM.Business;
using PM.Entity;
using PM.Business.Pages;
using System.Data;

namespace PM.Web.realtime
{
    public partial class DayData : RealtimeBaseControl
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                setMeasureMeasurePointInfo();
               BindDummyRow();
            }
        }



        private void setMeasureMeasurePointInfo()
        {
            if (MeasurePointInfo == null)
                return;
            ltDescription.Text = string.Format("[{0}]{1}", MeasurePointInfo.Pointnum, MeasurePointInfo.Description);
        }

        private void BindDummyRow()
        {
            DataTable dummy = new DataTable();
            dummy.Columns.Add("DESCRIPTION");
            dummy.Columns.Add("LEVEL");
            dummy.Columns.Add("Starttime");
            dummy.Columns.Add("STARTVALUE");
            dummy.Columns.Add("Endtime");
            dummy.Columns.Add("ENDVALUE");
            dummy.Columns.Add("DIFFVALUE");
            dummy.Rows.Add();

            gvDayMeasurement.DataSource = dummy;
            gvDayMeasurement.DataBind();
        }

    }
}