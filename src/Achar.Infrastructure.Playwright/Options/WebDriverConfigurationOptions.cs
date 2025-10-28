namespace Achar.Infrastructure.Playwright.Options
{
    public class WebDriverConfigurationOptions
    {
        public string BaseUrl { get; set; }
        
        public bool Headless { get; set; }
        
        public int LocatorTimeout { get; set; }
        
        public bool IgnoreHttpsErrors { get; set; }
        
        public string CustomBrowserExecutablePath { get; set; }
        
        public string ArtifactOutputPath { get; set; }
        
        public bool ArtifactsOnFailureOnly { get; set; }
        
        public bool UseApiMocks { get; set; }
    }
}