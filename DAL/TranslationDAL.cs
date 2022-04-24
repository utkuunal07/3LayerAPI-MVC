using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TransaltorApi.Api.Repository;
using TransaltorApi.Repository.Entities;

namespace DAL
{
    public class TranslationDAL
    {
        public List<TTranslationsLog> GetAllTranslations()
        {
            var db = new TranslationDbContext();
            return db.TTranslationsLogs.ToList();
        }

        public TTranslationsLog GetTranslations(string translationName)
        {
            var db = new TranslationDbContext();
            TTranslationsLog logs = new TTranslationsLog();

            logs = db.TTranslationsLogs.FirstOrDefault(x => x.Translation == translationName);

            return logs;
        }

        public void PostTranslation(TTranslationsLog log)
        {
            var db = new TranslationDbContext();
            db.Add(log);
            db.SaveChanges();
        }
        public DataTable CallProcedure(Dictionary<string, dynamic> dic, string procedureName,string conString)
        {
            var db = new TranslationDbContext();

            return db.CallProcedure(dic, procedureName, conString);
        }

        

        public async Task<HttpResponseMessage> TranslateTextAsync(string translationText, string translation)
        {
            var httpClient = new HttpClient();

            var request = new HttpRequestMessage(new HttpMethod("POST"), "https://api.funtranslations.com/translate/" + translation + ".json");

            request.Headers.TryAddWithoutValidation("X-Funtranslations-Api-Secret", "<api_key>");

            request.Content = new StringContent("text=" + translationText);
            request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");

            var response = await httpClient.SendAsync(request);

            //string jsonString = await response.Content.ReadAsStringAsync();

            return response;
        }



    }
}