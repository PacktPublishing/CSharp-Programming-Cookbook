using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors;

namespace UtilitiesActor.Interfaces
{
    public interface IUtilitiesActor : IActor
    {
        Task<bool> ValidateEmailAsync(string emailToValidate);
    }
}
