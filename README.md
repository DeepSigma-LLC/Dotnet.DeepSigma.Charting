# DeepSigma.Charting

A lightweight C# chart domain model for building chart definitions independently of any specific rendering library.

`DeepSigma.Charting` gives you a common object model for describing charts, axes, series, and data so you can standardize chart construction across different visualization backends. The library currently targets `.NET 10.0` and is published under the MIT license.

## Why this library?

When chart generation is tied directly to a UI toolkit or plotting package, swapping renderers becomes painful. This project separates **chart intent** from **chart rendering** by modeling:

- charts (`Chart2D`, `Chart3D`)
- axes (`Axis2D`, `Axis3D`)
- axis collections
- series definitions
- strongly-typed data models

That makes it easier to build once and render through a backend-specific adapter or builder later.

## Features

- Unified chart abstraction for 2D and 3D charts
- Axis configuration with support for:
  - linear
  - logarithmic
  - datetime
  - categorical axes
- Multiple series families:
  - XY/data series
  - categorical series
  - financial series
- Built-in data models for:
  - XY points
  - categorical values
  - candlesticks
  - box plots
- Optional legend support
- Automatic extraction of categorical labels from categorical axes
- Renderer-agnostic design that can be used with builder/adapter patterns

## Project structure

```text
DeepSigma.Charting/
├── Axis*.cs
├── Chart*.cs
├── DataSeries.cs
├── Enum/
├── Examples/
├── Interfaces/
├── Models/
└── DeepSigma.Charting.csproj
```

## Core concepts

### Charts

The library exposes two chart roots:

- `Chart2D`
- `Chart3D`

Both derive from a shared abstract base and expose:

- `Title`
- `ShowLegend`
- `Axes`
- `Series`

### Axes

Axes are configured independently and then registered with the chart’s axis collection.

Common axis settings include:

- `Key`
- `Title`
- `AxisType`
- `Minimum` / `Maximum`
- `AxisFormatString`
- gridline options
- zoom/pan flags
- `StartLocation` / `EndLocation`

2D axes also define an `AxisPosition` such as `Left`, `Right`, `Top`, or `Bottom`.

### Series

Series inherit from a shared base and contain:

- `SeriesName`
- `Color`
- `Interpolated`
- `Axes`
- `Data`

Concrete series types include:

- `ChartDataSeries`
- `ChartCategoricalSeries`
- `ChartFinancialSeries`

### Data models

Included data models:

- `XYData`
- `CategoricalData`
- `CandleData`
- `BoxPlotData`

All models implement the `IDataModel` marker interface.

## Supported chart types

### Data series

`ChartDataSeries` supports:

- `Line`
- `StepLine`
- `Spline`
- `Area`
- `Scatter`
- `Gauge`
- `Histogram`

### Categorical series

`ChartCategoricalSeries` supports:

- `Bar`
- `Column`
- `Pie`
- `Donut`
- `Radar`
- `Gauge`

### Financial series

`ChartFinancialSeries` supports:

- `CandleStick`
- `Volume`

## Installation

Add the project as a reference in your solution, or install the package if you publish it internally or to a package feed.

### Project reference

```xml
<ItemGroup>
  <ProjectReference Include="path/to/DeepSigma.Charting.csproj" />
</ItemGroup>
```

## Quick start

### Build a 2D chart

```csharp
using DeepSigma.Charting;
using DeepSigma.Charting.Enum;
using DeepSigma.Charting.Models;
using System.Drawing;

var chart = new Chart2D
{
    Title = "Revenue vs Time",
    ShowLegend = true
};

var xAxis = new Axis2D
{
    Key = AxisDimension.X,
    Title = "Date",
    AxisPosition = Chart2DAxisPosition.Bottom,
    AxisType = AxisType.DateTime,
    AxisFormatString = "MM-dd-yyyy",
    IsZoomEnabled = false
};

var yAxis = new Axis2D
{
    Key = AxisDimension.Y,
    Title = "Revenue",
    AxisPosition = Chart2DAxisPosition.Left,
    AxisType = AxisType.Linear,
    ShowMajorGridLines = true
};

chart.Axes.AddAxis(xAxis);
chart.Axes.AddAxis(yAxis);

var data = new DataSeries<XYData>();
data.AddRange(new[]
{
    new XYData(1, 120),
    new XYData(2, 150),
    new XYData(3, 135),
    new XYData(4, 180)
});

var series = new ChartDataSeries
{
    SeriesName = "Revenue",
    Color = Color.Blue,
    ChartType = DataSeriesChartType.Line,
    Data = data
};

series.Axes.Add(0, xAxis);
series.Axes.Add(1, yAxis);

chart.Series.Add(series);
```

## Financial chart example

```csharp
using DeepSigma.Charting;
using DeepSigma.Charting.Enum;
using DeepSigma.Charting.Models;
using System.Drawing;

var chart = new Chart2D
{
    Title = "Price and Volume",
    ShowLegend = true
};

var xAxis = new Axis2D
{
    Title = "Date",
    Key = AxisDimension.X,
    AxisPosition = Chart2DAxisPosition.Bottom,
    AxisType = AxisType.DateTime,
    AxisFormatString = "MM-dd-yyyy"
};

var priceAxis = new Axis2D
{
    Title = "Price",
    Key = AxisDimension.Y,
    AxisPosition = Chart2DAxisPosition.Left,
    AxisType = AxisType.Linear,
    StartLocation = 0.25,
    EndLocation = 1.0
};

var volumeAxis = new Axis2D
{
    Title = "Volume",
    Key = AxisDimension.Y2,
    AxisPosition = Chart2DAxisPosition.Left,
    AxisType = AxisType.Linear,
    StartLocation = 0.0,
    EndLocation = 0.20,
    IsZoomEnabled = false
};

chart.Axes.AddAxis(xAxis);
chart.Axes.AddAxis(priceAxis);
chart.Axes.AddAxis(volumeAxis);

var candles = new DataSeries<CandleData>();
candles.AddRange(new[]
{
    new CandleData(DateTime.Parse("2025-01-01"), 100, 110, 95, 104, 10000, 12000),
    new CandleData(DateTime.Parse("2025-01-02"), 104, 112, 99, 108, 10500, 11800),
    new CandleData(DateTime.Parse("2025-01-03"), 108, 115, 103, 111, 11200, 12100)
});

var priceSeries = new ChartFinancialSeries
{
    SeriesName = "Price",
    Color = Color.Red,
    ChartType = FinancialSeriesChartType.CandleStick,
    Data = candles
};

priceSeries.Axes.Add(0, xAxis);
priceSeries.Axes.Add(1, priceAxis);

var volumeSeries = new ChartFinancialSeries
{
    SeriesName = "Volume",
    Color = Color.Gray,
    ChartType = FinancialSeriesChartType.Volume,
    Data = candles
};

volumeSeries.Axes.Add(0, xAxis);
volumeSeries.Axes.Add(1, volumeAxis);

chart.Series.Add(priceSeries);
chart.Series.Add(volumeSeries);
```

## Categorical labels

If a series is attached to a categorical axis, the chart can derive categorical labels automatically through `GetCategoricalLabels()`.

```csharp
var labelsByAxis = chart.GetCategoricalLabels();
```

This returns a dictionary keyed by `AxisDimension`.

## Integration pattern

This library models chart definitions; it does not render charts by itself. The example code in the repository suggests using a builder/registry approach to transform `Chart2D` / `Chart3D` objects into renderer-specific models.

Typical architecture:

1. Build a `Chart2D` or `Chart3D`
2. Add axes and series
3. Pass the chart object to a backend-specific builder
4. Render using your preferred charting package

That makes this library a good fit for:

- shared analytics/domain layers
- multi-platform chart generation
- renderer abstraction
- internal chart specification pipelines

## Notes

- Axis keys in an axis collection must be unique.
- For multi-axis 2D charts, use `X`, `X2`, `Y`, and `Y2` as appropriate.
- The repository currently includes an `Examples/Example.cs` file but no dedicated automated test project.

## Target framework

The project file currently targets:

- `.NET 10.0`

## License

MIT

## Contributing

Contributions are welcome. Helpful additions would include:

- backend renderer adapters
- more example charts
- validation helpers
- automated tests
- NuGet packaging and release notes
