using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Galvanic.Model;

namespace Galvanic.Service.Interface
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        void Add(User user);
    }
}
