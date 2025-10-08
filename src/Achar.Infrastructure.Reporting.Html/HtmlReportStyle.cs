namespace Achar.Infrastructure.Reporting.Html
{
    internal static class HtmlReportStyle
    {
        public const string FontLink =
            "<link href=\"https://fonts.googleapis.com/css2?family=Sofia+Sans:ital,wght@0,1..1000;1,1..1000&display=swap\" rel=\"stylesheet\">\n";

        public const string FontAwesomeLink =
            "<link rel=\"stylesheet\" href=\"https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css\">";

        public const string PassIcon =
            "<i class=\"fa fa-check t-passing-text t-passing\" aria-hidden=\"true\"></i>";

        public const string FailIcon =
            "<i class=\"fa fa-times t-failing-text t-failing\" aria-hidden=\"true\"></i>";

        public const string UnknownIcon =
            "<i class=\"fa fa-question-circle-o\" aria-hidden=\"true\"></i>";

        public const string StyleHeader =
            """
                body {
                    font-family: "Sofia Sans", sans-serif;
                }
                
                table {
                    width: 100%;
                }
                
                td { 
                    padding: 10px;
                    overflow-wrap: anywhere;
                }
                
                .t-passing {
                    background-color: #e5fde4;
                }
                
                .t-passing-text {
                    color: #04aa6d;
                }
                
                .t-failing {
                    background-color: #fde4e7;
                }
                
                .t-failing-text {
                    color: #d53939;
                }
                
                .t-keyword {
                    color: #1e64af;
                    font-weight: 700;
                }
            """;
    }
}