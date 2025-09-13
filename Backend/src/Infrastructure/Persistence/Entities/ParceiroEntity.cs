public class Parceiro
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Area { get; set; }
    public string Email { get; set; }
    public List<ParceriaEntity> Parcerias { get; set; }
}