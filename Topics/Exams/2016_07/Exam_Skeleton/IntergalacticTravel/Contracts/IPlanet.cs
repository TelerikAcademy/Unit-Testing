using System.Collections.Generic;

namespace IntergalacticTravel.Contracts
{
    public interface IPlanet : INameable
    {
        IGalaxy Galaxy { get; }

        ICollection<IUnit> Units { get; }
    }
}