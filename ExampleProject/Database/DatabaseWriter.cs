using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleProject.Database
{
    public class DatabaseWriter
    {
        private static DatabaseWriter _writer;

        public static DatabaseWriter Writer
        {
            get
            {
                if (_writer == null)
                {
                    _writer = new DatabaseWriter();
                }

                return _writer;
            }
        }

        public Helper.Errors RunQuery(string query)
        {
            string connetionString = null;
            connetionString = Helper.GetConnectionString("StockDB");
            using (SqlConnection cnn = new SqlConnection(connetionString))
            {
                cnn.Open();
                if (cnn.State == ConnectionState.Open)
                {
                    Console.WriteLine("OPEN!");
                    using (SqlCommand cmd = new SqlCommand(query, cnn))
                    {
                        int value = cmd.ExecuteNonQuery();
                        if (value == 0)
                        {
                            Console.WriteLine("FAILED!");
                            return Helper.Errors.DBQUERYFAIL;
                        }
                        else
                        {
                            Console.WriteLine("SUCCESS!");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("CLOSED!");
                    return Helper.Errors.DBCONNECTIONCLOSED;
                }
                cnn.Close();
                return Helper.Errors.SUCCESS;
            }
        }

        public Helper.Errors RunQueryList(List<string> query)
        {
            string connetionString = null;
            connetionString = Helper.GetConnectionString("StockDB");
            using (SqlConnection cnn = new SqlConnection(connetionString))
            {
                cnn.Open();
                if (cnn.State == ConnectionState.Open)
                {
                    Console.WriteLine("OPEN!");
                    foreach (string q in query)
                    {
                        using (SqlCommand cmd = new SqlCommand(q, cnn))
                        {
                            int value = cmd.ExecuteNonQuery();
                            if (value == 0)
                            {
                                Console.WriteLine("FAILED!");
                                return Helper.Errors.DBQUERYFAIL;
                            }
                            else
                            {
                                Console.WriteLine("SUCCESS!");
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("CLOSED!");
                    return Helper.Errors.DBCONNECTIONCLOSED;
                }
                cnn.Close();
                return Helper.Errors.SUCCESS;

            }
        }
    }
}
