namespace IntergalacticTravel.Contracts
{
    public interface ILocation
    {
        IPlanet Planet { get; }

        IGPSCoordinates Coordinates { get; }
    }
}
