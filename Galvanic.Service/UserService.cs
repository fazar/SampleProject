using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Galvanic.Service.Interface;
using Galvanic.Data;
using Galvanic.Model;

namespace Galvanic.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public void Add(User user)
        {
            _userRepository.Add(user);
        }
    }
}
