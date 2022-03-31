namespace VenturaSoftHR.ApplicationService;

public class CreateJobDto
{
    public string Name { get; set; }
    public decimal Salary { get; set; }
    public string Description { get; set; }
    public DateTime FinalDate { get; set; }
}
