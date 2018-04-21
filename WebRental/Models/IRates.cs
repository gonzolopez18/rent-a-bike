namespace WebRental.Models
{
    public interface IRates
    {
        double GetRentCost(RentalType type);
        double GetDailyCost();
        int GetFamilyDiscount();
        int GetFamilyMax();
        int GetFamilyMin();
        double GetHourlyCost();
        double GetWeeklyCost();
    }
}