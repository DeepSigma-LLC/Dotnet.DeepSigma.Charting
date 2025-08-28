using System.Diagnostics.CodeAnalysis;

namespace DeepSigma.Charting.Models
{
    /// <summary>
    /// Represents a data model for categorical data points.
    /// </summary>
    public class CategoricalData : IDataModel
    {
        /// <summary>
        /// The category label of the data point.
        /// </summary>
        public required string Category { get; set; }
        /// <summary>
        /// The numerical value associated with the category.
        /// </summary>
        public required double Value { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoricalData"/> class with specified values.
        /// </summary>
        /// <param name="category"></param>
        /// <param name="value"></param>
        [SetsRequiredMembers]
        public CategoricalData(string category, double value)
        {
            Category = category;
            Value = value;
        }
    }
}
