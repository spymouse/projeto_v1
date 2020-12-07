using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using Examples.Charge.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Examples.Charge.Infra.Data.Repositories
{
    public class PersonPhoneRepository : IPersonPhoneRepository
    {
        private readonly ExampleContext _context;

        public PersonPhoneRepository(ExampleContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<PersonPhone>> FindAllAsync() => await Task.Run(() => _context.PersonPhone);
        
        public bool Inserir(PersonPhone entrada)
        {
            _context.PersonPhone.Add(entrada);
            return gravarDados();
        }

        public async Task<bool> Alterar(PersonPhone entrada)
        {
            _context.PersonPhone.Update(entrada);
            return gravarDados();
        }

        public async Task<bool> Excluir(PersonPhone entrada)
        {
            _context.PersonPhone.Remove(entrada);
            return gravarDados();

        }

        private bool gravarDados()
        {            
            return _context.SaveChanges() == 1;
        }
    }
}
