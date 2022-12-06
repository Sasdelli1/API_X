using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_X.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaCEP : ControllerBase
    {
        [HttpGet]
        public string CEP(string p_cep)
        {
            string ResultadoCEP = string.Empty;

            ResultadoCEP = "Retorno do processo definido";

            return ResultadoCEP;
        }
    
    }

}
