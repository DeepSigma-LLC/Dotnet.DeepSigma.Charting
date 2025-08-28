using DeepSigma.Charting.Enum;

namespace DeepSigma.Charting
{
    /// <summary>
    /// A 3D axis for charts, extending the abstract axis functionality.
    /// </summary>
    public class Axis3D : AxisAbstract
    {
        /// <summary>
        /// Gets or sets the type of the 3D axis.
        /// </summary>
        public required Chart3DAxis AxisPosition { get; set; }
    }
}
