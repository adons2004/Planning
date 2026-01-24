namespace Planning.Domain.Contracts;

public interface ISku
{
    Parameters GetHistoryY0Parameters();
    Parameters GetPlanningY1Parameters();
    decimal GetContributionGrowth();
    //void Add(ISku sku);
}