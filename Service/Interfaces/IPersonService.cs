using Domain.Entities;
using Service.Exceptions;

namespace Service.Interfaces
{
    public interface IPersonService
    {
        Task<ExceptionManager<Person>> GenerateToken(Person person);
        Task<ExceptionManager<Person>> Create(Person person);
        Task<ExceptionManager<dynamic>> LoginWithGoogle(Person person);
        Task<ExceptionManager<ICollection<Person>>> FindByAll();
        Task<ExceptionManager<Person>> FindById(int id);
        Task<ExceptionManager<Person>> FindByEmail(Person person);
        Task<ExceptionManager<Person>> Update(Person person);
        Task<ExceptionManager> Delete(int id);
        Task<string> Patch(int id, string attribute, string field);
    }
}
