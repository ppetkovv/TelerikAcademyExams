namespace Agency.Models.Contracts
{
    public interface ITicket
    {
        IJourney Journey { get; }
        decimal AdministrativeCosts { get; }
        decimal CalculatePrice();
    }
}