namespace IntergalacticTravel.Contracts
{
    public interface IPath
    {
        ILocation TargetLocation { get; }

        IResources Cost { get; }
    }
}
