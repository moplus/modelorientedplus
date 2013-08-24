using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoPlus.ViewModel.Tests.MSSQLReverseEngineering
{
    public static class NorthwindUtility
    {
        public static void Create(string dbName, string filename, string logFileName)
        {
            using (var conn = new SqlConnection(@"Data Source=(localdb)\v11.0;Integrated Security=true"))
            {
                conn.Open();

                // path to your db files:
                // ensure that the directory exists and you have read write permission.
                string[] files = { filename, 
                   logFileName};

                // db creation query:
                // note that the data file and log file have different logical names
                var query = "CREATE DATABASE [" + dbName + "]" +
                    " ON PRIMARY" +
                    " (NAME = [" + dbName + "_data]," +
                    " FILENAME = '" + files[0] + "'," +
                    " SIZE = 5MB," +
                    " MAXSIZE = 50MB," +
                    " FILEGROWTH = 10%)" +

                    " LOG ON" +
                    " (NAME = [" + dbName + "_log]," +
                    " FILENAME = '" + files[1] + "'," +
                    " SIZE = 1MB," +
                    " MAXSIZE = 5MB," +
                    " FILEGROWTH = 10%)" +
                    ";";

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "use [" + dbName + "];";
                    cmd.ExecuteNonQuery();

                    using (var stream = GetNorthwindStream())
                    {
                        using (var reader = new StreamReader(stream, Encoding.Unicode))
                        {
                            cmd.CommandText = "";

                            string line;
                            while ((line = reader.ReadLine()) != null)
                            {
                                if (line.Trim().Equals("GO", StringComparison.InvariantCultureIgnoreCase))
                                {
                                    cmd.ExecuteNonQuery();
                                    cmd.CommandText = "";
                                }
                                else
                                {
                                    cmd.CommandText += Environment.NewLine + line;
                                }
                            }
                            if (!String.IsNullOrWhiteSpace(cmd.CommandText))
                            {
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    
                    cmd.CommandText = "use master";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "exec master.dbo.sp_detach_db @dbname = N'" + dbName + "'";
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        private static Stream GetNorthwindStream()
        {
            var stream = typeof(NorthwindUtility).Assembly.GetManifestResourceStream(typeof(NorthwindUtility), "northwind.sql");
            if (stream == null)
            {
                throw new Exception("Cannot find northwind.sql resource!");
            }

            return stream;
        }
    }
}