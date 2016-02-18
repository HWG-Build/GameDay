using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GameDay.Services.Interfaces;

namespace GameDay.Services
{
    public class ConcreteDependency : IDependency
    {
        public string SayHello()
        {
            throw new NotImplementedException();
        }
    }
}