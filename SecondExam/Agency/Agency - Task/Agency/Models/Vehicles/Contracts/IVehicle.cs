namespace Agency.Models.Vehicles.Contracts
{
    public interface IVehicle
    {
        int PassangerCapacity { get; }
        decimal PricePerKilometer { get; }
        Type Type { get; }
    }
}