namespace PocMissionPush.Loan;

public class Loan
{
    public int Id { get; set; }
    public required string Label { get; set; }
    public required string Category { get; set; }
    public required string Account { get; set; }
    public required string Company { get; set; }
    public required string BankName { get; set; }
    public required decimal Capital { get; set; }
    public required decimal Rate { get; set; }
    public required int DurationInMonth { get; set; }
    public required DateTime StartDate { get; set; }


}