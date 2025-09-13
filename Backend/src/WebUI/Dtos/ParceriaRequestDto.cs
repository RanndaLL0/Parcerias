public class ParceriaRequestDto
{
    public string Objective { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public long professorID { get; set; }
    public string parceiroName { get; set; }
    public string parceiroEmail { get; set; }
    public string parceiroArea { get; set; }
}