namespace BOI.BOIApplications.Application.Model.ConfigurationModels
{
    public class ServiceConfigurationSettings
    {
        public int RunningPeriod { get; set; }
        public string? EmployeeFolderPath { get; set; }
        public string BonitaServerIPAddress { get; set; }
        public string BonitaWebUrl { get; set; }
        public string SendBonitaAvailabilityTo { get; set; }
        public bool ActivateEnqueueEmail { get; set; }
    }
}
