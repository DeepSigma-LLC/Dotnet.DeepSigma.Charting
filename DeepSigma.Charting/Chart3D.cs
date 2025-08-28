using DeepSigma.Charting.Models;
using DeepSigma.Charting.Interfaces;

namespace DeepSigma.Charting
{
    /// <summary>
    /// Represents a 3D chart with 3D axes.
    /// </summary>
    public class Chart3D : ChartAbstract<Axis3D>, IChart<Axis3D>
    {
        /// <summary>
        /// The collection of axes in the chart.
        /// </summary>
        public override IAxisCollectionAbstract<Axis3D> Axes { get; init; } = new Axis3DCollection();
    }
}
