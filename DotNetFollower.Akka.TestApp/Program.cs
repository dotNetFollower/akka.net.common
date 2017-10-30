using System.Configuration;

using Akka.Actor;
using Akka.Configuration;

using DotNetFollower.Akka.Common.Extensions;

namespace DotNetFollower.Akka.TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var actorSystemName      = ConfigurationManager.AppSettings["ACTOR_SYSTEM_NAME"];
            var actorSystemPort      = int.Parse(ConfigurationManager.AppSettings["ACTOR_SYSTEM_PORT"]);
            var actorSystemHost      = ConfigurationManager.AppSettings["ACTOR_SYSTEM_HOST"];
            var actorSystemSeedNodes = ConfigurationManager.AppSettings["ACTOR_SYSTEM_SEED_NODES"];

            var config = ConfigurationFactory.Load()
                .SetPort(actorSystemPort)
                .SetHost(actorSystemHost)
                .SetSeedNodes(actorSystemSeedNodes);

            var res = ActorSystem.Create(actorSystemName, config);
        }
    }
}
