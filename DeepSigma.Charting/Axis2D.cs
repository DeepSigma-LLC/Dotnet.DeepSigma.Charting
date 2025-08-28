using DeepSigma.Charting.Enum;

namespace DeepSigma.Charting
{
    /// <summary>
    /// Represents a 2D axis for charts, inheriting from AxisAbstract.
    /// </summary>
    public class Axis2D : AxisAbstract
    {
        /// <summary>
        /// The position of the axis on the chart (e.g., Left, Right, Top, Bottom).
        /// </summary>
        public required Chart2DAxisPosition AxisPosition { get; set; }
    }
}
