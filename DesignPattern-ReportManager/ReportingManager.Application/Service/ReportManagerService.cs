using Microsoft.Extensions.DependencyInjection;

public class ReportManagerService : IReportManagerService
{
    private readonly IReportManagerBO _reportService;

    public int ReportId { get; set; }
    public string ReportName { get; set; }
    public DateTime CreatedDate { get; set; }
    public string CreatedBy { get; set; }

    protected ReportManagerService(IReportManagerBO reportService)
    {
        _reportService = reportService;
    }

    public ReportManagerService() { }


    public string GenerateReport()
    {
        var serviceProvider = new ServiceCollection()
            .AddSingleton<IReportManagerBO, ReportManagerBO>() // Registering    
           .BuildServiceProvider();

        var reportManager = serviceProvider.GetService<IReportManagerBO>();
            var result = reportManager.GenerateReport(); // Calling the method to generate the report        

        return result;
    }

    public void PrintReport()
    {
        // Logic to print the report
        //Console.WriteLine(GenerateReport());
    }
}