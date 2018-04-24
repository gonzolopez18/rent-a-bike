namespace WebRental.Models
{
    public interface IRates
    {
        double GetRentCost(RentalType type);
        double GetFamilyDiscount();
        int GetFamilyMax();
        int GetFamilyMin();

    }
}