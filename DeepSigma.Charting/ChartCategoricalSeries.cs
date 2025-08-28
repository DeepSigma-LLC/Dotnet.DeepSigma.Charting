using DeepSigma.Charting.Models;
using DeepSigma.Charting.Enum;
using DeepSigma.Charting.Interfaces;

namespace DeepSigma.Charting
{
    /// <summary>
    /// Represents a series of data points in a chart.
    /// </summary>
    public class ChartCategoricalSeries : ChartSeriesAbstract, IChartSeriesAbstract
    {
        /// <summary>
        /// Gets or sets the type of the chart series.
        /// </summary>
        public required CategoricalChartType ChartType { get; set; }
    }
}
