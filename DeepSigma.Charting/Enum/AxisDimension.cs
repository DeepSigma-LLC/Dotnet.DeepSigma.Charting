
using System.ComponentModel;

namespace DeepSigma.Charting.Enum;

/// <summary>
/// Defines the axis dimensions available for charting.
/// </summary>
public enum AxisDimension
{
    /// <summary>
    /// The X axis.
    /// </summary>
    [Description("X")]
    X,
    /// <summary>
    /// The secondary X axis.
    /// </summary>
    [Description("X2")]
    X2,
    /// <summary>
    /// The Y axis.
    /// </summary>
    [Description("Y")]
    Y,
    /// <summary>
    /// The secondary Y axis.
    /// </summary>
    [Description("Y2")]
    Y2,
    /// <summary>
    /// The Z axis.
    /// </summary>
    [Description("Z")]
    Z
}
