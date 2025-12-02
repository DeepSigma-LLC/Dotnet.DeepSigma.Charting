using DeepSigma.Charting.Models;
using DeepSigma.Charting.Enum;
using DeepSigma.Charting.Interfaces;

namespace DeepSigma.Charting;

/// <summary>
/// Represents a chart with various properties and configurations.
/// </summary>
public abstract class ChartAbstract<T> : IChart<T> where T : IAxis 
{
    /// <inheritdoc/>
    public string Title { get; set; } = String.Empty;

    /// <inheritdoc/>
    public List<IChartSeriesAbstract> Series { get; init; } = [];

    /// <inheritdoc/>
    public List<IChartSeriesAbstract> GetSeries() => Series;

    /// <inheritdoc/>
    public Dictionary<string, string[]> GetCategoricalLabels()
    {
        Dictionary<string, string[]> results = [];
        Axes.GetAllAxes().ForEach(a => results.Add(a.Key, []));

        foreach(IChartSeriesAbstract data_series in GetSeries())
        {
            foreach(var axis in data_series.Axes)
            {
                if(axis.Value.AxisType == AxisType.Categorical && results.ContainsKey(axis.Value.Key))
                {
                    results[axis.Value.Key] = data_series.Data.GetAllDataPoints()
                        .OfType<CategoricalData>()
                        .Select(d => d.Category)
                        .Distinct()
                        .ToArray();
                }
            }
        }
        return results;
    }

    /// <inheritdoc/>
    public bool ShowLegend { get; set; } = true;

    /// <inheritdoc/>
    public abstract IAxisCollectionAbstract<T> Axes { get; init; }
}
