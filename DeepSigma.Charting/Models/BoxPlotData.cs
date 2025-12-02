
namespace DeepSigma.Charting.Models;

/// <summary>
/// Represents a data model for box plot charts.
/// </summary>
public class BoxPlotData(decimal X, decimal LowerWhisker, decimal BottomBox, decimal Median, decimal BoxTop, decimal UpperWhisker) : IDataModel
{
    /// <summary>
    /// The current observation of the box plot.
    /// </summary>
    public decimal X { get; set; } = X;
    /// <summary>
    /// The lower whisker value of the box plot.
    /// </summary>
    public decimal LowerWhisker { get; set; } = LowerWhisker;
    /// <summary>
    /// The bottom value of the box in the box plot.
    /// </summary>
    public decimal BoxBottom { get; set; } = BottomBox;
    /// <summary>
    /// The median value of the box plot.
    /// </summary>
    public decimal Median { get; set; } = Median;
    /// <summary>
    /// The top value of the box in the box plot.
    /// </summary>
    public decimal BoxTop { get; set; } = BoxTop;
    /// <summary>
    /// The upper whisker value of the box plot.
    /// </summary>
    public decimal UpperWhisker { get; set; } = UpperWhisker;
}
