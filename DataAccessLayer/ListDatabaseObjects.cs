﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Script.Serialization;

namespace DataAccessLayer
{

    public class ListDatabaseObjects
    {

        private SqlConnection getConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        }

        public DataTable getAllProperties(string tableName, string objType = "")
        {
            DataTable dtColumns = new DataTable();
            if (tableName != "" && tableName != null)
            {
                using (var connection = getConnection())
                {
                    connection.Open();
                    var command = new System.Data.SqlClient.SqlCommand();
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT c.column_id as ID, c.name FROM " + connection.Database + ".sys.tables T " +
                            "INNER JOIN sys.columns C ON C.object_id = T.object_id " +
                            "WHERE T.name = '" + tableName + "'";
                    if (objType == "view")
                    {
                        command.CommandText = "SELECT c.column_id as ID, c.name FROM " + connection.Database + ".sys.views V " +
                                "INNER JOIN sys.columns C ON C.object_id = V.object_id " +
                                "WHERE V.name = '" + tableName + "'";
                    }

                    var adapter = new System.Data.SqlClient.SqlDataAdapter(command);
                    var dataset = new DataSet();
                    adapter.Fill(dataset);
                    dtColumns = dataset.Tables[0];
                }
            }

            return dtColumns;
        }

        public DataTable getAllTables()
        {

            DataTable dtTables = new DataTable();
            //using (var connection = new System.Data.SqlClient.SqlConnection("GBN_DB"))
            using (var connection = getConnection())
            {
                connection.Open();
                var command = new System.Data.SqlClient.SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT object_id as ID, name FROM " + connection.Database + ".sys.tables";

                var adapter = new System.Data.SqlClient.SqlDataAdapter(command);
                var dataset = new DataSet();
                adapter.Fill(dataset);
                dtTables = dataset.Tables[0];
            }

            return dtTables;

        }

        public DataTable getAllViews()
        {

            DataTable dtViews = new DataTable();
            using (var connection = getConnection())
            {
                connection.Open();
                var command = new System.Data.SqlClient.SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT name, object_id as ID FROM " + connection.Database + ".sys.views";

                var adapter = new System.Data.SqlClient.SqlDataAdapter(command);
                var dataset = new DataSet();
                adapter.Fill(dataset);
                dtViews = dataset.Tables[0];
            }

            return dtViews;

        }


        public DataTable getReportView(string tableName)
        {

            DataTable dtViews = new DataTable();
            using (var connection = getConnection())
            {
                connection.Open();
                var command = new System.Data.SqlClient.SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM " + connection.Database + ".dbo." + tableName;

                var adapter = new System.Data.SqlClient.SqlDataAdapter(command);
                var dataset = new DataSet();
                adapter.Fill(dataset);
                dtViews = dataset.Tables[0];
            }

            return dtViews;

        }

        public DataTable getReportView(int ReportID, string whereClause)
        {

            try
            {
                DataSet dsReport = getReportDetails(ReportID);
                DataTable dtViews = new DataTable();
                string query = "";
                string fields = "";
                string groupBy = "";
                string orderBy = "";
                DataTable dtReport = dsReport.Tables[0];
                DataTable dtFields = new DataTable();
                if(dsReport.Tables.Count > 0)
                {
                    dtFields = dsReport.Tables[1];

                    for (int i = 0; i < dtFields.Rows.Count; i++)
                    {
                        var aggregation = dtFields.Rows[i]["Aggregation"].ToString();
                        var reportField = dtFields.Rows[i]["ReportField"].ToString();
                        if (fields == "")
                        {
                            fields = (aggregation != "") ? aggregation + "(" + reportField + ") " + reportField : reportField;
                            //fields = (aggregation != "") ? aggregation + "(" + reportField + ") as sumOf_"+ reportField : reportField;
                        }
                        else
                        {
                            //var strTemp = (aggregation != "") ? aggregation + "(" + reportField + ") as sumOf_" + reportField : reportField;
                            var strTemp = (aggregation != "") ? aggregation + "(" + reportField + ") " + reportField : reportField;
                            fields = fields + ", " + strTemp;
                        }

                        if (groupBy == "" && Convert.ToBoolean(dtFields.Rows[i]["GroupBy"]) == true)
                        {
                            groupBy = dtFields.Rows[i]["ReportField"].ToString();
                        }
                        else if (Convert.ToBoolean(dtFields.Rows[i]["GroupBy"]) == true)
                        {
                            groupBy = groupBy + "," +dtFields.Rows[i]["ReportField"].ToString();
                        }
                        if (orderBy == "" && Convert.ToBoolean(dtFields.Rows[i]["OrderBy"]) == true)
                        {
                            orderBy = dtFields.Rows[i]["ReportField"].ToString();
                        }
                        else if (Convert.ToBoolean(dtFields.Rows[i]["OrderBy"]) == true)
                        {
                            orderBy = orderBy+"," + dtFields.Rows[i]["ReportField"].ToString();
                        }
                    }

                }
                if (fields != "")
                {
                    query = "SELECT top(100)" + fields + " FROM " + dtReport.Rows[0]["TableName"].ToString();
                    if (whereClause != "")
                    {
                        query = query + " where "+ whereClause;
                    }
                    if (groupBy != "")
                    {
                        query = query + " Group By " + groupBy;
                    }
                    if (orderBy != "")
                    {
                        query = query + " Order By " + orderBy;
                    }

                }
                if (query != "")
                {
                    using (var connection = getConnection())
                    {
                        connection.Open();
                        var command = new System.Data.SqlClient.SqlCommand();
                        command.Connection = connection;
                        command.CommandType = CommandType.Text;
                        command.CommandText = query;

                        var adapter = new System.Data.SqlClient.SqlDataAdapter(command);
                        var dataset = new DataSet();
                        adapter.Fill(dataset);
                        dtViews = dataset.Tables[0];
                    }
                }
                return dtViews;
            } 
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }



            

        }

        public DataTable getFieldDetails(string TableName)
        {
            var connection = getConnection();
            SqlParameter[] ReportParam = new SqlParameter[1];
            ReportParam[0] = new SqlParameter("@TableName", SqlDbType.VarChar, 50);
            ReportParam[0].Value = TableName;
            try
            {
                return SqlHelper.ExecuteDataTable(connection, CommandType.StoredProcedure, "GetFieldDetails", ReportParam);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public DataSet getReportDetails(int reportId)
        {
            var connection = getConnection();
            SqlParameter[] ReportParam = new SqlParameter[1];
            ReportParam[0] = new SqlParameter("@ReportID", SqlDbType.Int, 50);
            ReportParam[0].Value = reportId;
            try
            {
                return SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure, "GetDynamicReport", ReportParam);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public DataTable getFilterDetails(int reportId, string reportFieldName)
        {
            var connection = getConnection();
            SqlParameter[] ReportParam = new SqlParameter[2];
            ReportParam[0] = new SqlParameter("@ReportID", SqlDbType.Int, 50);
            ReportParam[0].Value = reportId;
            ReportParam[1] = new SqlParameter("@ReportField", SqlDbType.NVarChar, 150);
            ReportParam[1].Value = reportFieldName;
            try
            {
                return SqlHelper.ExecuteDataTable(connection, CommandType.StoredProcedure, "GetFilterFieldDetails", ReportParam);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public int AddReportDetails(ReportsProfileHandler report)
        {

            var connection = getConnection();
            SqlParameter[] ReportParam = new SqlParameter[16];
            ReportParam[0] = new SqlParameter("@ReportID", SqlDbType.Int, 50);
            ReportParam[0].Value = report.ReportID;
            ReportParam[0].Direction = ParameterDirection.InputOutput;
            ReportParam[1] = new SqlParameter("@ReportName", SqlDbType.VarChar, 150);
            ReportParam[1].Value = report.ReportName;
            ReportParam[2] = new SqlParameter("@Description", SqlDbType.VarChar, 300);
            ReportParam[2].Value = report.ReportDescription;
            ReportParam[3] = new SqlParameter("@TableName", SqlDbType.VarChar, 300);
            ReportParam[3].Value = report.TableName;
            ReportParam[4] = new SqlParameter("@Fields", SqlDbType.VarChar, 300);
            ReportParam[4].Value = (report.Fields != null && report.Fields != "") ? report.Fields : " ";
            ReportParam[5] = new SqlParameter("@GroupByFields", SqlDbType.VarChar, 300);
            ReportParam[5].Value = (report.GroupByFields != null && report.GroupByFields != "") ? report.GroupByFields : " ";
            ReportParam[6] = new SqlParameter("@OrderByFields", SqlDbType.VarChar, 300);
            ReportParam[6].Value = (report.OrderByFields != null && report.OrderByFields != "") ? report.OrderByFields : " ";
            ReportParam[7] = new SqlParameter("@IsActive", SqlDbType.Bit);
            ReportParam[7].Value = report.IsActive;
            ReportParam[8] = new SqlParameter("@UserId", SqlDbType.Int);
            ReportParam[8].Value = report.UserId;
            ReportParam[9] = new SqlParameter("@RoleId", SqlDbType.Int);
            ReportParam[9].Value = report.RoleId;
            ReportParam[10] = new SqlParameter("@ModuleId", SqlDbType.Int);
            ReportParam[10].Value = report.ModuleId;
            ReportParam[11] = new SqlParameter("@IsDeleted", SqlDbType.Bit);
            ReportParam[11].Value = report.IsDeleted;
            ReportParam[12] = new SqlParameter("@dtSummary", SqlDbType.Structured);
            ReportParam[12].Value = report.dtReportFields;
            ReportParam[13] = new SqlParameter("@dtFilter", SqlDbType.Structured);
            ReportParam[13].Value = report.dtFilterFields;
            ReportParam[14] = new SqlParameter("@dtRoles", SqlDbType.Structured);
            ReportParam[14].Value = report.dtRoles;

            ReportParam[15] = new SqlParameter("@Status", SqlDbType.VarChar, 100);
            ReportParam[15].Direction = ParameterDirection.Output;
            ReportParam[15].Value = "";
            try
            {
                SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, "DynamicReportsIU", ReportParam);
                return Convert.ToInt32(ReportParam[0].Value);
            }
            catch (Exception ex)
            {
                return -1;
            }

        }

    }

    public class ReportsProfileHandler
    {

        #region Private Variables
        private int reportID;
        private string reportName;
        private string reportDescription;
        private string fields;
        private string groupByFields;
        private string orderByFields;
        private string tableName;
        private bool isActive;
        private bool isDeleted;
        private int userId;
        private int roleId;
        private int moduleId;
        private DataTable _dtReportFields;
        private DataTable _dtFilterFields;
        private DataTable _dtRoles;
        #endregion

        #region Public Properties

        public int ReportID
        {
            get { return reportID; }
            set { reportID = value; }
        }
        public String ReportName
        {
            get { return reportName; }
            set { reportName = value; }
        }
        public String ReportDescription
        {
            get { return reportDescription; }
            set { reportDescription = value; }
        }
        public String Fields
        {
            get { return fields; }
            set { fields = value; }
        }
        public String GroupByFields
        {
            get { return groupByFields; }
            set { groupByFields = value; }
        }
        public String OrderByFields
        {
            get { return orderByFields; }
            set { orderByFields = value; }
        }
        public String TableName
        {
            get { return tableName; }
            set { tableName = value; }
        }
        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }
        public bool IsDeleted
        {
            get { return isDeleted; }
            set { isDeleted = value; }
        }
        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        public int RoleId
        {
            get { return roleId; }
            set { roleId = value; }
        }

        public int ModuleId
        {
            get { return moduleId; }
            set { moduleId = value; }
        }

        public DataTable dtReportFields
        {
            get { return _dtReportFields; }
            set { _dtReportFields = value; }
        }

        public DataTable dtFilterFields
        {
            get { return _dtFilterFields; }
            set { _dtFilterFields = value; }
        }

        public DataTable dtRoles
        {
            get { return _dtRoles; }
            set { _dtRoles = value; }
        }
        #endregion
    }
}
