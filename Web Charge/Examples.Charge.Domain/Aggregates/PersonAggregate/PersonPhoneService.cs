using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate
{
    public class PersonPhoneService : IPersonPhoneService
    {
        private readonly IPersonPhoneRepository _personPhoneRepository;
        private readonly IPhoneNumberTypeRepository _phoneNumberTypeRepository;
        public PersonPhoneService(IPersonPhoneRepository personPhoneRepository, IPhoneNumberTypeRepository phoneNumberTypeRepository)
        {
            _personPhoneRepository = personPhoneRepository;
            _phoneNumberTypeRepository = phoneNumberTypeRepository;
        }

        public bool Alterar(PersonPhone entrada)
        {

            try
            {
                this._personPhoneRepository.Alterar(entrada);
                return true;
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
                        
        }

        public bool Excluir(PersonPhone entrada)
        {
            
            try
            {
                this._personPhoneRepository.Excluir(entrada);
                return true;
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }

        }

        public async Task<List<PersonPhone>> FindAllAsync() => (await _personPhoneRepository.FindAllAsync()).ToList();

        public bool Inserir(PersonPhone entrada)
        {
            try
            {
                this._personPhoneRepository.Inserir(entrada);
                return true;
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
                      
        }
        public async Task<List<PhoneNumberType>> FindAllNumberTypeAsync()
        {
            return (await _phoneNumberTypeRepository.FindAllAsync()).ToList();
        }
    }
}
