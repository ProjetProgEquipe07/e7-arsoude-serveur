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


       /* [HttpPost]
        public ActionResult<string> GetTranslate([FromBody]TranslateDTO translateDTO)
        {
            string transltedText = _serviceTranslate.TranslateText(translateDTO.text).Result;

            return Ok(transltedText);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<TraductionIndicator>>> GetLanguages([FromBody]RandonneeDTO translateDTO)
        {
            var languages = await _serviceTranslate.DetectLanguage(translateDTO);

            return Ok(languages);
        }*/
    }
}
