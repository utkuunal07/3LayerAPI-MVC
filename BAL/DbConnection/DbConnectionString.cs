using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DbConnection
{
    public class DbConnectionString
    {
        public static string GetConnString(string enviroment)
        {
            switch (enviroment)
            {
                case "UTKUDB":

                    return "Data Source = UTKU - BILGISAYAR\\MSSQLSERVER01; Initial Catalog = TranslationDb; Integrated Security = True";
                default:
                    return "Check Enviroment!";

            }
        }


    }
}
