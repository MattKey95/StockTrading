using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ExampleProject.Database
{
    class DatabaseReader
    {
        private static DatabaseReader _reader;

        public static DatabaseReader Reader
        {
            get
            {
                if (_reader == null)
                {
                    _reader = new DatabaseReader();
                }

                return _reader;
            }
        }

        public List<T> ReadFromDatabase<T>(string query) where T: class, new()
        {
            List<T> ResultList = new List<T>();
            string connetionString = Helper.GetConnectionString("StockDB");
            using (SqlConnection cnn = new SqlConnection(connetionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.FieldCount != 0)
                    {
                        while (reader.Read())
                        {
                            ResultList.Add(ConstructObject<T>((IDataRecord) reader));
                        }
                    }
                }
                cnn.Close();
            }
            return ResultList;
        }

        public T ConstructObject<T>(IDataRecord record) where T: class, new()
        {
            var TObject = new T();
            Type type = typeof(T);
            for (int i = 0; i < record.FieldCount; i++)
            {
                var cols = TObject.GetType().GetProperties();
                foreach (var c in cols)
                {
                    if (c.Name == record.GetName(i))
                    {
                        PropertyInfo prop = type.GetProperty(c.Name);
                        if (prop != null && !record.IsDBNull(i))
                        {
                            prop.SetValue(TObject, record[i]);
                        }
                    }
                }
            }
            return TObject;
        }

        public List<object[]> ReadFromDatabase(string query)
        {
            List<object[]> ResultList = new List<object[]>();

            string connetionString = Helper.GetConnectionString("StockDB");
            using (SqlConnection cnn = new SqlConnection(connetionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.FieldCount != 0)
                    {
                        while (reader.Read())
                        {
                            object[] d = new object[reader.FieldCount];
                            reader.GetValues(d);
                            ResultList.Add(d);
                        }
                    }
                }
                cnn.Close();
            }

            return ResultList;
        }
    }
}
