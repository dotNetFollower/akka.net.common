using System;
using Akka.Configuration;

namespace DotNetFollower.Akka.Common.Extensions
{
    public static class ConfigExtensions
    {
        public static Config SetPort(this Config config, int? port)
        {
            return port != null
                ? ConfigurationFactory.ParseString($"akka.remote.helios.tcp.port = {port}").WithFallback(config)
                : config;
        }

        public static Config SetHost(this Config config, string host)
        {
            return !string.IsNullOrWhiteSpace(host)
                ? ConfigurationFactory.ParseString($"akka.remote.helios.tcp.public-hostname = {host}").WithFallback(config)
                : config;
        }

        public static Config SetSeedNodes(this Config config, string seedNodes)
        {
            if (!string.IsNullOrWhiteSpace(seedNodes))
            {
                var seedsPatterns = seedNodes.Split(new [] {','}, StringSplitOptions.RemoveEmptyEntries);
                var decoratedSeeds = string.Empty;

                foreach (var seedStr in seedsPatterns)
                {
                    if (decoratedSeeds.Length > 0)
                        decoratedSeeds += ',';
                    decoratedSeeds += "\"" + seedStr.Trim() + "\"";
                }

                return ConfigurationFactory.ParseString($"akka.cluster.seed-nodes = [{decoratedSeeds}]").WithFallback(config);
            }

            return config;
        }
    }
}
