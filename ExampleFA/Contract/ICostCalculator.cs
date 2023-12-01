namespace ExampleFA.Contract
{
    public interface ICostCalculator<T, TCost>
        where T : class
        where TCost : struct, Enum
    {
        TCost CostType { get; }
        Task CalcCost (params T[] items);
    }
}
