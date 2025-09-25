using System.Text;
using Achar.Domain.Reporting;
using Achar.Interfaces.Reporting;

namespace Achar.Infrastructure.Reporting.Html
{
    public class HtmlTestOutcomeExporter : ITestOutcomeExporter
    {
        private const string HtmlRowFormat = "<tr><td>{0}</td><td>{1}</td></tr>";
        private const string HtmlCellFormat = "<td>{0}</td>";

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
            htmlBuilder.AppendLine("<style>");
            htmlBuilder.AppendLine("table, tr, th, td { border: 1px solid grey; }");
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
            htmlBuilder.AppendLine("<table>");

            foreach (var step in testOutcome.Steps)
            {
                htmlBuilder.AppendLine("<tr>");
                htmlBuilder.AppendFormat(HtmlCellFormat, $"<b>{step.StepKeyword}</b> {step.StepName}");
                htmlBuilder.AppendFormat(HtmlCellFormat, step.Status);
                htmlBuilder.AppendFormat(HtmlCellFormat, step.Duration);
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
    }
}