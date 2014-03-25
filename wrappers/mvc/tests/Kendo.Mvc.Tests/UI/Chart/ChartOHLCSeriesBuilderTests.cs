namespace Kendo.Mvc.UI.Tests.Chart
{
    using System;
    using Kendo.Mvc.UI;
    using Kendo.Mvc.UI.Fluent;
    using Xunit;

    public class ChartOHLCSeriesBuilderTests
    {
        private IChartOHLCSeries series;
        private ChartOHLCSeriesBuilder<OHLCData> builder;
        private readonly Func<object, object> nullFunc;

        public ChartOHLCSeriesBuilderTests()
        {
            var chart = ChartTestHelper.CreateChart<OHLCData>();
            series = new ChartOHLCSeries<OHLCData, decimal, string>(s => s.Open, s => s.High, s => s.Low, s => s.Close, s => s.Color, null, s => s.NoteText);
            builder = new ChartOHLCSeriesBuilder<OHLCData>(series);
            nullFunc = (o) => null;
        }

        [Fact]
        public void Aggregate_should_set_Aggregate()
        {
            builder.Aggregate(ChartSeriesAggregate.Max);
            series.Aggregates.Open.ShouldEqual(ChartSeriesAggregate.Max);
        }

        [Fact]
        public void Aggregate_should_return_builder()
        {
            builder.Aggregate(ChartSeriesAggregate.Max).ShouldBeSameAs(builder);
        }

        [Fact]
        public void Aggregate_should_set_Aggregate_handler_name()
        {
            builder.Aggregate("foo");
            series.AggregateHandler.HandlerName.ShouldEqual("foo");
        }

        [Fact]
        public void Aggregate_handler_name_should_return_builder()
        {
            builder.Aggregate("foo").ShouldBeSameAs(builder);
        }

        [Fact]
        public void Aggregate_should_set_Aggregate_template()
        {
            builder.Aggregate(nullFunc);
            series.AggregateHandler.TemplateDelegate.ShouldEqual(nullFunc);
        }

        [Fact]
        public void Aggregate_template_should_return_builder()
        {
            builder.Aggregate(nullFunc).ShouldBeSameAs(builder);
        }

        [Fact]
        public void Gap_should_set_gap()
        {
            builder.Gap(1);
            series.Gap.ShouldEqual(1);
        }

        [Fact]
        public void Spacing_should_set_spacing()
        {
            builder.Spacing(1);
            series.Spacing.ShouldEqual(1);
        }

        [Fact]
        public void Border_sets_border_properties()
        {
            builder.Border(1, "red", ChartDashType.Dot);
            series.Border.Color.ShouldEqual("red");
            series.Border.Width.ShouldEqual(1);
            series.Border.DashType.ShouldEqual(ChartDashType.Dot);
        }

        [Fact]
        public void Line_sets_line_properties()
        {
            builder.Line(1, "red", ChartDashType.Dot);
            series.Line.Color.ShouldEqual("red");
            series.Line.Width.ShouldEqual(1);
            series.Line.DashType.ShouldEqual(ChartDashType.Dot);
        }

        [Fact]
        public void Line_should_set_line_width()
        {
            builder.Line(1);
            series.Line.Width.ShouldEqual(1);
        }

        [Fact]
        public void Line_should_return_builder()
        {
            builder.Line(1).ShouldBeSameAs(builder);
        }

        [Fact]
        public void Line_color_should_set_line_width_and_color()
        {
            builder.Line(1, "red");
            series.Line.Color.ShouldEqual("red");
            series.Line.Width.ShouldEqual(1);
        }

        [Fact]
        public void Line_color_should_return_builder()
        {
            builder.Line(1, "red").ShouldBeSameAs(builder);
        }

        [Fact]
        public void Line_builder_should_configure_line()
        {
            builder.Line(l => l.Color("red")).ShouldBeSameAs(builder);
        }

        [Fact]
        public void Line_builder_should_return_builder()
        {
            builder.Line(l => l.Color("red")).ShouldBeSameAs(builder);
        }

        [Fact]
        public void Highlight_with_builder_should_configure_series()
        {
            builder.Highlight(s => { s.Line(1); });
            series.Highlight.Line.Width.ShouldEqual(1);
        }

        [Fact]
        public void Highlight_with_builder_should_return_builder()
        {
            builder.Highlight(series => { }).ShouldBeSameAs(builder);
        }

        [Fact]
        public void OpenField_should_set_open_member()
        {
            builder.OpenField("Open");
            series.OpenMember.ShouldEqual("Open");
        }

        [Fact]
        public void OpenField_should_return_builder()
        {
            builder.OpenField("Open").ShouldBeSameAs(builder);
        }

        [Fact]
        public void CloseField_should_set_close_member()
        {
            builder.CloseField("Close");
            series.CloseMember.ShouldEqual("Close");
        }

        [Fact]
        public void CloseField_should_return_builder()
        {
            builder.CloseField("Close").ShouldBeSameAs(builder);
        }

        [Fact]
        public void HighField_should_set_high_member()
        {
            builder.HighField("High");
            series.HighMember.ShouldEqual("High");
        }

        [Fact]
        public void HighField_should_return_builder()
        {
            builder.HighField("High").ShouldBeSameAs(builder);
        }

        [Fact]
        public void LowField_should_set_low_member()
        {
            builder.LowField("Low");
            series.LowMember.ShouldEqual("Low");
        }

        [Fact]
        public void LowField_should_return_builder()
        {
            builder.LowField("Low").ShouldBeSameAs(builder);
        }

        [Fact]
        public void Fields_should_set_members()
        {
            builder.Fields("o", "h", "l", "c");
            series.OpenMember.ShouldEqual("o");
            series.HighMember.ShouldEqual("h");
            series.LowMember.ShouldEqual("l");
            series.CloseMember.ShouldEqual("c");
        }

        [Fact]
        public void Fields_should_return_builder()
        {
            builder.Fields("o", "h", "l", "c").ShouldBeSameAs(builder);
        }

        [Fact]
        public void ColorField_should_set_color_member()
        {
            builder.ColorField("Color");
            series.ColorMember.ShouldEqual("Color");
        }

        [Fact]
        public void ColorField_should_return_builder()
        {
            builder.ColorField("Color").ShouldBeSameAs(builder);
        }

        [Fact]
        public void NoteTextField_should_set_note_text_member()
        {
            builder.NoteTextField("NoteText");
            series.NoteTextMember.ShouldEqual("NoteText");
        }

        [Fact]
        public void NoteTextField_should_return_builder()
        {
            builder.NoteTextField("NoteText").ShouldBeSameAs(builder);
        }
    }
}