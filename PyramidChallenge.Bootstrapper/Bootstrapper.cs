using Microsoft.Extensions.DependencyInjection;
using PyramidChallenge.Domain.Acquaintances;
using PyramidChallenge.Domain.Graphs;
using PyramidChallenge.Domain.Models.Node;
using PyramidChallenge.Domain.Parsers;
using System.Collections.Generic;

namespace PyramidChallenge.Bootstrapper
{
    public static class Bootstrapper
    {
        public static void Bootstrap(IServiceCollection services)
        {
            services.AddSingleton<IParser<IEnumerable<string>, BinaryNode>, StringPyramidParser>();
            services.AddSingleton<ITraverser, PyramidTraverser>();
        }
    }
}
