using AutoMapper;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonPhoneController : BaseController
    {
        private IPersonPhoneFacade _facade;


        public PersonPhoneController(IPersonPhoneFacade facade, IMapper mapper)
        {
            _facade = facade;
        }

        [HttpGet]
        public async Task<ActionResult<PersonPhoneResponse>> Get()
        {
            return Response(await this._facade.FindAllAsync());        
        }

        [HttpGet("GetPhoneNumberType")]
        public async Task<ActionResult<PersonPhoneResponse>> GetPhoneNumberType()
        {
            return Response(await this._facade.FindAllNumberTypeAsync());
        }

        [HttpPost("Inserir")]
        public async Task<ActionResult<PersonPhoneResponse>> PostPersonPhone(PersonPhoneRequest entrada)
        {
            return Response(await this._facade.InserirAsync(entrada));
            
        }


        [HttpPut("Alterar")]
        public async Task<ActionResult<PersonPhoneResponse>> PutPersonPhone(PersonPhoneRequest entrada)
        {
            return Response(await this._facade.AlterarAsync(entrada));
        }

        [HttpPost("Excluir")]
        public async Task<ActionResult<PersonPhoneResponse>> DeletePersonPhone(PersonPhoneRequest entrada)
        {

            return Response(await this._facade.ExcluirAsync(entrada));
        }

    }
}
