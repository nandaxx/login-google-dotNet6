using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using Service.Exceptions;
using Service.Interfaces;

namespace Service.Services
{
    public class PersonService : IPersonService
 
    {
        private readonly IPersonRepository _repository;
        private readonly IMapper _mapper;

        public async Task<ExceptionManager<Person>> LoginWithGoogle(Person person)
        {
            if (person == null) return ExceptionManager.NotFound<Person>();
            var user = await _repository.FindByEmail(person.Email);
            if (user == null)
            {
                var userRegister = _mapper.Map<Person>(person);
                await _repository.Create(userRegister);
                var userLogin = await _repository.LoginWithGoogle(userRegister.Email);
                if (userLogin == null) return ExceptionManager.NotFound<Person>();
                return ExceptionManager.Ok(_mapper.Map<Person>(person));
            }
            var userLogin1 = await _repository.LoginWithGoogle(person.Email);
            if (userLogin1 == null) return ExceptionManager.NotFound<Person>();
            user.Picture = person.Picture;
            user.Name = person.Name;
            var userUpdate = await _repository.Update(user);

            return ExceptionManager.Ok<Person>(_mapper.Map<Person>(person));
        }

    }
}