namespace ExampleFA.Contract
{
    public interface ICostCalculator<T> where T : class
    {
        Task CalcCost (params T[] items);
    }
}
