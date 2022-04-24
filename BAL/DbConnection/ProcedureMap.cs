using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DbConnection
{
    public class ProcedureMap
    {
        public static string Autherization { get { return "[TranslationDb].[dbo].[checkAccount]"; }}
    }
}
