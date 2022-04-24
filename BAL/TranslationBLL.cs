using BLL.DbConnection;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using TransaltorApi.Repository.Entities;
using static BLL.Models.TranslationModel;
using System.Configuration;


namespace BLL
{
    public class TranslationBLL
    {
        private DAL.TranslationDAL _DAL;

        public TranslationBLL()
        {
            _DAL = new DAL.TranslationDAL();
        }

        public List<TTranslationsLog> GetAllTranslations()
        {
            List<TTranslationsLog> log = _DAL.GetAllTranslations();
            return log;
        }

        public TTranslationsLog GetTranslations(string translationName)
        {
            TTranslationsLog log = _DAL.GetTranslations(translationName);
            return log;
        }

        public void PostTranslation(TTranslationsLog log)
        {
            _DAL.PostTranslation(log);
        }

        public DataTable CallProcedure(Dictionary<string, dynamic> dic , string procedureName)
        {
            return _DAL.CallProcedure(dic, procedureName, "Data Source=UTKU-BILGISAYAR\\MSSQLSERVER01;Initial Catalog=TranslationDb;Integrated Security=True");
        }

        public async Task<Root> TranslateText(string translationText, string translation)
        {
            var response = await _DAL.TranslateTextAsync(translationText, translation);

            string jsonString = await response.Content.ReadAsStringAsync();

            Root LeetspeakModelRoot = JsonConvert.DeserializeObject<Root>(jsonString);

            _DAL.PostTranslation(new TTranslationsLog
            {
                Total = LeetspeakModelRoot.success.total,
                Translated = LeetspeakModelRoot.contents.translated,
                Text = LeetspeakModelRoot.contents.translated,
                Translation = LeetspeakModelRoot.contents.translation
            });

            return LeetspeakModelRoot;
        }
    }
}