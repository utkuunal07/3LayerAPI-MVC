using BLL;
using BLL.DbConnection;
using DAL.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace TransaltorApi.Helpers.Services
{
    

    public class UserService : IUserService
    {
        private BLL.TranslationBLL _BLL = new BLL.TranslationBLL();

        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        

        public bool Authenticate(string username, string password)
        {
            // wrapped in "await Task.Run" to mimic fetching user from a db

            ////var user = await Task.Run(() => _users.SingleOrDefault(x => x.Username == username && x.Password == password));

            Dictionary<string, dynamic> Dict = new Dictionary<string, dynamic>
            {
                { "@Username", username },
                { "@Password", password }
            };

            DataTable user = _BLL.CallProcedure(Dict, ProcedureMap.Autherization);


            // return null if user not found
            if (user.Rows.Count==0)
                return false;

            // authentication successful so return user details
            return true;
        }

        
    }
}
