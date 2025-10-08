using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Achar.Domain.Reporting;
using Achar.Domain.Reporting.Enum;
using Achar.Interfaces.Reporting;

namespace Achar.Infrastructure.Reporting.Html
{
    public class HtmlTestOutcomeExporter : ITestOutcomeExporter
    {
        private const string HtmlRowFormat = "<tr><td>{0}</td><td>{1}</td></tr>";
        private const string HtmlCellFormat = "<td {1}>{0}</td>";

        public async Task PerformAsync(
            TestOutcome testOutcome,
            string resultsPath,
            DateTime startTime)
        {
            var exportPath =
                Path
                    .Combine(resultsPath, $"{startTime:yyyy_MM_dd_hh_mm_ss}_{testOutcome.TestKey}.html");

            var htmlBuilder = new StringBuilder();

            htmlBuilder.AppendLine("<html>");
            htmlBuilder.AppendLine("<head>");
            htmlBuilder.AppendLine(HtmlReportStyle.FontLink);
            htmlBuilder.AppendLine(HtmlReportStyle.FontAwesomeLink);
            htmlBuilder.AppendLine("<style>");
            htmlBuilder.AppendLine(HtmlReportStyle.StyleHeader);
            htmlBuilder.AppendLine("</style>");
            htmlBuilder.AppendLine("</head>");

            htmlBuilder.AppendLine("<body>");

            htmlBuilder
                .AppendLine("<h1>Test Results</h1>")
                .AppendLine("<table>");

            htmlBuilder.AppendFormat(HtmlRowFormat, "Test Name", testOutcome.TestName);
            htmlBuilder.AppendFormat(HtmlRowFormat, "Start time", testOutcome.StartDate.ToString("F"));
            htmlBuilder.AppendFormat(HtmlRowFormat, "End time", testOutcome.FinishDate.ToString("F"));
            htmlBuilder.AppendFormat(HtmlRowFormat, "Status", testOutcome.Status.ToString());

            htmlBuilder.AppendLine("</table>");
            htmlBuilder.AppendLine("<hr/>");
            htmlBuilder.AppendLine("<table>");

            foreach (var step in testOutcome.Steps)
            {
                htmlBuilder.AppendLine("<tr>");
                htmlBuilder.AppendFormat(HtmlCellFormat, $"<span class=\"t-keyword\">{step.StepKeyword}</span> {step.StepName}", RenderStatusClass(step.Status));
                htmlBuilder.AppendFormat(HtmlCellFormat, RenderStatusIcon(step.Status), RenderStatusClass(step.Status, 5));
                htmlBuilder.AppendFormat(HtmlCellFormat, step.Duration, RenderStatusClass(step.Status, 5));
                htmlBuilder.AppendLine("</tr>");
            }

            htmlBuilder.AppendLine("</table>");
            htmlBuilder.AppendLine("</body>");
            htmlBuilder.AppendLine("</html>");

            await
                File
                    .WriteAllTextAsync(exportPath, htmlBuilder.ToString());
        }

        public bool IsApplicable() => true;

        public int SortOrder { get; set; } = 1;

        private static string RenderStatusIcon(TestStatusEnum value)
        {
            switch (value)
            {
                case TestStatusEnum.Passed: return HtmlReportStyle.PassIcon;
                case TestStatusEnum.Failed: return HtmlReportStyle.FailIcon;
                default: return HtmlReportStyle.UnknownIcon;
            }
        }

        private static string RenderStatusClass(TestStatusEnum value, int? width = null)
        {
            var widthStyle = $"width=\"{(width.HasValue ? width + "%" : "auto")}\"";

            switch (value)
            {
                case TestStatusEnum.Passed: return widthStyle + " class=\"t-passing\"";
                case TestStatusEnum.Failed: return widthStyle + " class=\"t-failing\"";
                default: return null;
            }
        }
    }
}