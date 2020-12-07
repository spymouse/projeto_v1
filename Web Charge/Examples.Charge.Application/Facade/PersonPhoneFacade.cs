using Examples.Charge.Application.Interfaces;
using AutoMapper;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Examples.Charge.Application.Messages.Response;
using Examples.Charge.Application.Dtos;
using System.Linq;
using Examples.Charge.Application.Messages.Request;

namespace Examples.Charge.Application.Facade
{
    public class PersonPhoneFacade : IPersonPhoneFacade
    {
        private readonly IPersonPhoneService _personPhoneService;
        private readonly IMapper _mapper;

        public PersonPhoneFacade(IPersonPhoneService personPhoneService, IMapper mapper)
        {
            _personPhoneService = personPhoneService;
            _mapper = mapper;
        }


        public async Task<PersonPhoneResponse> FindAllAsync()
        {
            var result = await _personPhoneService.FindAllAsync();
            var resultType = await _personPhoneService.FindAllNumberTypeAsync();
            
            var response = new PersonPhoneResponse();
            response.PersonPhoneObjects = new List<PersonPhoneDto>();
            foreach (var item in result)
            {                
                response.PersonPhoneObjects.Add(new PersonPhoneDto() { 
                     BusinessEntityID = item.BusinessEntityID,
                     PhoneNumber = item.PhoneNumber,
                     PhoneNumberTypeID = item.PhoneNumberTypeID,
                     PhoneName = resultType.FirstOrDefault(x => x.PhoneNumberTypeID == item.PhoneNumberTypeID).Name,
 
                });
            }
            return response;
        }

        public async Task<PersonPhoneResponse> FindAllNumberTypeAsync()
        {
            var resultType = await _personPhoneService.FindAllNumberTypeAsync();
            var response = new PersonPhoneResponse();

            response.PhoneNumberTypeObjects = new List<PhoneNumberTypeDto>();
            foreach (var item in resultType)
            {
                response.PhoneNumberTypeObjects.Add(new PhoneNumberTypeDto()
                {
                     Name = item.Name,
                     PhoneNumberTypeID = item.PhoneNumberTypeID
                });
            }

            return response;
        }


        public async Task<PersonPhoneResponse> InserirAsync(PersonPhoneRequest entrada)
        {
            var response = new PersonPhoneResponse();
            response.Success = _personPhoneService.Inserir(ConvertDTO(entrada));

            return response;
        }

        public async Task<PersonPhoneResponse> AlterarAsync(PersonPhoneRequest entrada)
        {
            var response = new PersonPhoneResponse();
            var result = await FindAllAsync();

            var alterar = result.PersonPhoneObjects.FirstOrDefault(f => f.PhoneNumber == entrada.PhoneNumberOld);
            alterar.PhoneNumber = entrada.PhoneNumber;
            alterar.PhoneNumberTypeID = entrada.PhoneNumberTypeID;
            response.Success = _personPhoneService.Alterar(ConvertDTO(alterar));

            return response;
        }

        public async Task<PersonPhoneResponse> ExcluirAsync(PersonPhoneRequest entrada)
        {
            var response = new PersonPhoneResponse();
            response.Success =_personPhoneService.Excluir(ConvertDTO(entrada));

            return response;
        }

        public Domain.Aggregates.PersonAggregate.PersonPhone ConvertDTO(PersonPhoneRequest entrada)
        {
            return new Domain.Aggregates.PersonAggregate.PersonPhone()
            {
                BusinessEntityID = entrada.BusinessEntityID.Value,
                PhoneNumber = entrada.PhoneNumber,
                PhoneNumberTypeID = entrada.PhoneNumberTypeID
            };
        }

        private Domain.Aggregates.PersonAggregate.PersonPhone ConvertDTO(PersonPhoneDto entrada)
        {
            return new Domain.Aggregates.PersonAggregate.PersonPhone()
            {
                BusinessEntityID = entrada.BusinessEntityID,
                PhoneNumber = entrada.PhoneNumber,
                PhoneNumberTypeID = entrada.PhoneNumberTypeID
            };
        }

    }
}
