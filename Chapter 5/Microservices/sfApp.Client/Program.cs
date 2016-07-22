using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilitiesActor.Interfaces;
using Microsoft.ServiceFabric.Actors;
using static System.Console;

namespace sfApp.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var actProxy = ActorProxy.Create<IUtilitiesActor>(new ActorId("Utilities"), "fabric:/sfApp");
            //var actProxy = ActorProxy.Create<IUtilitiesActor>(ActorId.NewId(), "fabric:/sfApp");

            WriteLine("Utilities Actor {0} - Valid Email?: {1}", actProxy.GetActorId(), actProxy.ValidateEmailAsync("validemail@gmail.com").Result);
            WriteLine("Utilities Actor {0} - Valid Email?: {1}", actProxy.GetActorId(), actProxy.ValidateEmailAsync("invalid@email@gmail.com").Result);
            ReadLine();
        }
    }
}
