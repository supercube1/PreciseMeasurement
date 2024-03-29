

using System;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

using PM.Data;
using PM.Config;
using PM.Common;
using PM.Entity;

namespace PM.Data.SqlServer {
    /// -----------------------------------------------------------------------------
    /// <summary>
    ///		The DataProvider class is an abstract class that provides the data layer
    ///		for the SqlServer module.
    /// </summary>
    /// <remarks></remarks>
    /// <history>
    ///		[CHENPING]	2013-12-18 22:32:00 Code file automatically generated from MeasureSystem
    /// </history>
    /// -----------------------------------------------------------------------------
    public partial class DataProvider : IDataProvider {

        public int CreateSynonymdomain(SynonymdomainInfo synonymdomainInfo) {
            DbParameter[] parms = { 
						DbHelper.MakeInParam("@DEFAULTS", (DbType)SqlDbType.Bit,1,synonymdomainInfo.Defaults),
                        DbHelper.MakeInParam("@DESCRIPTION", (DbType)SqlDbType.VarChar,256,synonymdomainInfo.Description)	,
                        DbHelper.MakeInParam("@DOMAINID", (DbType)SqlDbType.VarChar,18,synonymdomainInfo.Domainid)	,
                        DbHelper.MakeInParam("@ORGID", (DbType)SqlDbType.VarChar,8,synonymdomainInfo.Orgid)	,
                        DbHelper.MakeInParam("@SITEID", (DbType)SqlDbType.VarChar,8,synonymdomainInfo.Siteid)	,
                        DbHelper.MakeInParam("@VALUE", (DbType)SqlDbType.VarChar,50,synonymdomainInfo.Value)	,
                        DbHelper.MakeInParam("@VALUEID", (DbType)SqlDbType.VarChar,256,synonymdomainInfo.Valueid)

			};
            string commandText = string.Format("INSERT INTO [{0}SYNONYMDOMAIN] (DEFAULTS,DESCRIPTION,DOMAINID,ORGID,SITEID,VALUE,VALUEID)VALUES(@DEFAULTS,@DESCRIPTION,@DOMAINID,@ORGID,@SITEID,@VALUE,@VALUEID)", BaseConfigs.GetTablePrefix);
            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText, parms);


        }

        public bool UpdateSynonymdomain(SynonymdomainInfo synonymdomainInfo) {

            DbParameter[] parms = { 
  		            DbHelper.MakeInParam("@SYNONYMDOMAINID", (DbType)SqlDbType.BigInt,8,synonymdomainInfo.Synonymdomainid),
					DbHelper.MakeInParam("@DEFAULTS", (DbType)SqlDbType.Bit,1,synonymdomainInfo.Defaults),
                    DbHelper.MakeInParam("@DESCRIPTION", (DbType)SqlDbType.VarChar,256,synonymdomainInfo.Description)	,
                    DbHelper.MakeInParam("@DOMAINID", (DbType)SqlDbType.VarChar,18,synonymdomainInfo.Domainid)	,
                    DbHelper.MakeInParam("@ORGID", (DbType)SqlDbType.VarChar,8,synonymdomainInfo.Orgid)	,
                    DbHelper.MakeInParam("@SITEID", (DbType)SqlDbType.VarChar,8,synonymdomainInfo.Siteid)	,
                    DbHelper.MakeInParam("@VALUE", (DbType)SqlDbType.VarChar,50,synonymdomainInfo.Value)	,
                    DbHelper.MakeInParam("@VALUEID", (DbType)SqlDbType.VarChar,256,synonymdomainInfo.Valueid)
			};
            string commandText = string.Format("UPDATE [{0}SYNONYMDOMAIN] SET [DEFAULTS] = @DEFAULTS,[DESCRIPTION] = @DESCRIPTION,[DOMAINID] = @DOMAINID,[ORGID] = @ORGID,[SITEID] = @SITEID,[VALUE] = @VALUE,[VALUEID] = @VALUEID WHERE [SYNONYMDOMAINID]=@SYNONYMDOMAINID", BaseConfigs.GetTablePrefix);
            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText, parms) > 0;
        }

        public int DeleteSynonymdomain(string idList) {
            string commandText = string.Format("DELETE FROM [{0}SYNONYMDOMAIN] WHERE [MEASUREPOINTID] IN ({1})",
                                              BaseConfigs.GetTablePrefix,
                                              idList);
            return DbHelper.ExecuteNonQuery(CommandType.Text, commandText);
        }

        public DataTable FindSynonymdomainByCondition(string condition) {
            string commandText = string.Format("select {0}SYNONYMDOMAIN.* from [{0}SYNONYMDOMAIN] WHERE 1=1 {1}",
                                                BaseConfigs.GetTablePrefix,
                                                condition);
            return DbHelper.ExecuteDataset(CommandType.Text, commandText).Tables[0];
        }


        /// <summary>
        /// 查找同义数值域定义
        /// </summary>
        /// <param name="domainId">域ID</param>
        /// <returns></returns>
        public DataTable FindSynonymdomainByDomainId(string domainId) {
            string commandText = string.Format("select {0}SYNONYMDOMAIN.* from [{0}SYNONYMDOMAIN] WHERE DOMAINID='{1}'",
                                               BaseConfigs.GetTablePrefix,
                                               domainId);
            return DbHelper.ExecuteDataset(CommandType.Text, commandText).Tables[0];
        }


    }
}
