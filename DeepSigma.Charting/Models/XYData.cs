

namespace DeepSigma.Charting.Models;

/// <summary>
/// Represents a data model for XY data points.
/// </summary>
public class XYData(double X, double Y) : IDataModel
{
    /// <summary>
    /// The X coordinate of the data point.
    /// </summary>
    public double X { get; set; } = X;

    /// <summary>
    /// The Y coordinate of the data point.
    /// </summary>
    public double Y { get; set; } = Y;

}
