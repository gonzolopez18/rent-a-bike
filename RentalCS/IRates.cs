namespace RentalCS
{
    public interface IRates
    {
        double GetDailyCost();
        int GetFamilyDiscount();
        int GetFamilyMax();
        int GetFamilyMin();
        double GetHourlyCost();
        double GetWeeklyCost();
    }
}