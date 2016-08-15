namespace IntergalacticTravel.Contracts
{
    public interface IUnit
    {
        int IdentificationNumber { get; }

        string NickName { get; }

        IResources Resources { get; }

        ILocation CurrentLocation { get; set; }

        ILocation PreviousLocation { get; set; }

        bool CanPay(IResources cost);

        IResources Pay(IResources cost);
    }
}
