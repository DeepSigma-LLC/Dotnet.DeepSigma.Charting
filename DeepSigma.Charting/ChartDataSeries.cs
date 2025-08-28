using DeepSigma.Charting.DataModels;
using DeepSigma.Charting.Enum;
using DeepSigma.Charting.Interfaces;

namespace DeepSigma.Charting
{
    /// <summary>
    /// Represents a series of data points in a chart.
    /// </summary>
    public class ChartDataSeries : ChartSeriesAbstract, IChartSeriesAbstract
    {
        /// <summary>
        /// Gets or sets the type of the chart series.
        /// </summary>
        public required DataChartType ChartType { get; set; }
    }
}
