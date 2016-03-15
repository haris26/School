using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSeed
{
    static class Utility
    {
        public static string sourceRoot = @"C:\Projects\alfa\";

        public static DataTable OpenExcel(string path, string sheet)
        {
            var cs = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=Excel 8.0", path);
            OleDbConnection conn = new OleDbConnection(cs);
            conn.Open();

            OleDbCommand cmd = new OleDbCommand(string.Format("SELECT * FROM [{0}$]", sheet), conn);
            OleDbDataAdapter da = new OleDbDataAdapter();
            da.SelectCommand = cmd;

            System.Data.DataTable dt = new System.Data.DataTable();
            da.Fill(dt);
            conn.Close();

            return dt;
        }

        public static string getString(DataRow row, int index)
        {
            return row.ItemArray.GetValue(index).ToString();
        }

        public static int getInteger(DataRow row, int index)
        {
            return Convert.ToInt32(row.ItemArray.GetValue(index).ToString());
        }

        public static bool getBool(DataRow row, int index)
        {
            return (row.ItemArray.GetValue(index).ToString().ToLower() == "yes");
        }

        public static DateTime getDate(DataRow row, int index)
        {
            return Convert.ToDateTime(row.ItemArray.GetValue(index).ToString());
        }

        public static double getDouble(DataRow row, int index)
        {
            return Convert.ToDouble(row.ItemArray.GetValue(index).ToString());
        }
    }
}
