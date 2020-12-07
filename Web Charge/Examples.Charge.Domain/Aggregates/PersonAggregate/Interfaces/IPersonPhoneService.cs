using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPersonPhoneService
    {
        Task<List<PersonPhone>> FindAllAsync();
        bool Inserir(PersonPhone entrada);
        bool Alterar(PersonPhone entrada);
        bool Excluir(PersonPhone entrada);
        Task<List<PhoneNumberType>> FindAllNumberTypeAsync();
    }
}
