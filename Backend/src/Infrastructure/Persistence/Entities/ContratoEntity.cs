public class Contrato
{
    public long Id { get; set; }
    public DateTime SignDate { get; set; }
    public long IdParceria { get; set; }

    public ParceriaEntity Parceria { get; set; }
}