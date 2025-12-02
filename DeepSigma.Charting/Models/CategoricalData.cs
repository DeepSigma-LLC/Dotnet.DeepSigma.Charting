using System.Diagnostics.CodeAnalysis;

namespace DeepSigma.Charting.Models;

/// <summary>
/// Represents a data model for categorical data points.
/// </summary>
public class CategoricalData(string category, double value) : IDataModel
{
    /// <summary>
    /// The category label of the data point.
    /// </summary>
    public required string Category { get; set; } = category;
    /// <summary>
    /// The numerical value associated with the category.
    /// </summary>
    public required double Value { get; set; } = value;

}
