using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ExampleProject.Database
{
    public class Helper
    {

        public enum Errors
        {
            FAILED,
            SUCCESS,
            DBCONNECTIONCLOSED,
            DBQUERYFAIL
        }

        public static string GetConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
