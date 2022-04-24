using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TransaltorApi.Repository.Entities;
using static BLL.Models.TranslationModel;

namespace TransaltorApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TranslatorController : ControllerBase
    {
        private BLL.TranslationBLL _BLL;

        public TranslatorController()
        {
            _BLL = new BLL.TranslationBLL();
        }

        [HttpGet]
        [Route("getAllTranslations")]
        public List<TTranslationsLog> GetAllTranslations()
        {
            return _BLL.GetAllTranslations();
        }

        [HttpGet]
        [Route("getTranslations")]
        public TTranslationsLog GetTranslations(string translationName)
        {
            return _BLL.GetTranslations(translationName);
        }

        [HttpPost]
        [Route("postTranslation")]
        public void PostTranslation([FromBody] TTranslationsLog log)
        {
            _BLL.PostTranslation(log);
        }

        [HttpGet]
        [Route("translateText")]
        public async Task<Root> TranslateText(string translationText, string translation)
        {
            return await _BLL.TranslateText(translationText, translation);
        }
    }
}