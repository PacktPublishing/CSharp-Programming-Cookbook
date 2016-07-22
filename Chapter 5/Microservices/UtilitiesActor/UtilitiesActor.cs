using UtilitiesActor.Interfaces;
using Microsoft.ServiceFabric.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace UtilitiesActor
{
    /// <remarks>
    /// Each ActorID maps to an instance of this class.
    /// The IUtilitiesActor interface (in a separate DLL that client code can
    /// reference) defines the operations exposed by UtilitiesActor objects.
    /// </remarks>
    internal class UtilitiesActor : StatelessActor, IUtilitiesActor
    {
        public async Task<bool> ValidateEmailAsync(string emailToValidate)
        {
            ActorEventSource.Current.ActorMessage(this, "Email Validation");

            return await Task.FromResult(Regex.IsMatch(emailToValidate, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase));
        }        
    }
}
