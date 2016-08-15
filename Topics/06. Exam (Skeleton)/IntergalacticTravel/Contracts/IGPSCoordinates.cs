namespace IntergalacticTravel.Contracts
{
    /// <summary>
    /// Represents the Global Positioning System Coordinates
    /// </summary>
    public interface IGPSCoordinates
    {
        double Longtitude { get; }

        double Latitude { get; }
    }
}
