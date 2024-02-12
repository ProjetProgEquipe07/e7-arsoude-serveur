using arsoudeServeur.Models.DTOs;
using arsoudeServeur.Services;
using Microsoft.AspNetCore.Mvc;

namespace arsoudeServeur.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TranslateController : BaseController
    {

        ServiceTranslate _serviceTranslate;

        public TranslateController(UtilisateursService utilisateursService, ServiceTranslate translateService) : base(utilisateursService)
        {
            _serviceTranslate = translateService;
        }


        [HttpPost]
        public ActionResult<string> GetTranslate([FromBody]TranslateDTO translateDTO)
        {
            string transltedText = _serviceTranslate.TranslateText(translateDTO.text).Result;

            return Ok(transltedText);
        }

        [HttpPost]
        public ActionResult<string> GetLanguages([FromBody] TranslateDTO translateDTO)
        {
            var languages = _serviceTranslate.DetectLanguage(translateDTO.text);

            return Ok(languages);
        }
    }
}
