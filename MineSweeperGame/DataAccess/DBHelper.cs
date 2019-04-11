using MineSweeperGame.BusinessLogic;
using MineSweeperGame.Common.Constants;
using MineSweeperGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MineSweeperGame.DataAccess
{
    /// <summary>
    /// Manages the connectioin to the database
    /// </summary>
    public static class DBHelper
    { 
        /// <summary>
        /// Get the records from the database table and store them into a List, which is returned to the caller
        /// </summary>
        /// <returns></returns>
        public static List<IFieldSettings> GetRecords()
        {
            List<IFieldSettings> fs = new List<IFieldSettings>();
            using (SqlConnection connection = new SqlConnection(GetConnectionString(Constants.DBName)))
            {
                using (SqlCommand cmd = new SqlCommand(Constants.SP_GetMineFields, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();

                        da.Fill(dt);

                        if (dt == null || dt.Rows.Count == 0)
                        {
                            throw new Exception("No Mine fields found!");
                        }
                        foreach (DataRow row in dt.Rows)
                        {
                            IFieldSettings tempFs = new FieldSettings();
                            tempFs.FieldId = row.Field<int>("FieldId");
                            tempFs.RowsNo = row.Field<int>("RowsNo");
                            tempFs.ColumnsNo = row.Field<int>("ColumnsNo");
                            tempFs.MinesNo = row.Field<int>("MinesNo");
                            if (tempFs.RowsNo == 0 && tempFs.ColumnsNo == 0) break;
                            fs.Add(tempFs);
                        }
                    }
                }

                return fs;
            }
        }
        /// <summary>
        /// returs the connection string
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
