

using Examples.Charge.Application.Common.Messages;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Interfaces
{
    public interface IPersonPhoneFacade
    {
        Task<PersonPhoneResponse> FindAllAsync();
        Task<PersonPhoneResponse> FindAllNumberTypeAsync();
        Task<PersonPhoneResponse> InserirAsync(PersonPhoneRequest entrada);
        Task<PersonPhoneResponse> AlterarAsync(PersonPhoneRequest entrada);
        Task<PersonPhoneResponse> ExcluirAsync(PersonPhoneRequest entrada);
    }
}