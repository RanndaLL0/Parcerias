public class AnexoEntity
{
    public long Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Description { get; set; }

    public long IdParceria { get; set; }
    public ParceriaEntity Parceria { get; set; }
}