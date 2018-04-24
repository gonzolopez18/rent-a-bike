namespace WebRental.Models
{
    public interface IRates
    {
        double GetRentCost(RentalType type);
        int GetFamilyDiscount();
        int GetFamilyMax();
        int GetFamilyMin();

    }
}