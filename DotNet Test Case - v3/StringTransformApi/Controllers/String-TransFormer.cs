using Microsoft.AspNetCore.Mvc;
using StrigTransForm.Interfaces;

namespace StringTransformApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class String_TransFormer : Controller
    {
        private readonly IStringTransformer _stringTransformer;
        public String_TransFormer(IStringTransformer stringTransformer)
        {
            _stringTransformer = stringTransformer;
        }

        [HttpGet]
        public string GetTransFirmedString(string input)
        {
            var result = _stringTransformer.Transformer(input);

            if (String.IsNullOrWhiteSpace(result))
            {
                return null;
            }
            else
            {
                return result;
            }

        }
    }
}
