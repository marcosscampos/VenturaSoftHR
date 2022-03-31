namespace VenturaSoftHR.ApplicationService;

public class GetAllJobsDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Salary { get; set; }
    public string Description { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime FinalDate { get; set; }
}
