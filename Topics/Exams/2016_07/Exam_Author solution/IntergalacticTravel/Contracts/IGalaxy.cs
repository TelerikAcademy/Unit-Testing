using System.Collections.Generic;

namespace IntergalacticTravel.Contracts
{
    public interface IGalaxy : INameable
    {
        ICollection<IPlanet> Planets { get; }
    }
}