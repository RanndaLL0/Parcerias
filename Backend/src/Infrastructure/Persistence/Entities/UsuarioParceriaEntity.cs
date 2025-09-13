
public class UsuarioParceriaEntity
{
    public long Id { get; set; }
    public long IdUsuario { get; set; }
    public long IdParceria { get; set; }

    public string Tipo { get; set; }
    public STATUS Status { get; set; }

    public UsuarioParceriaEntity Usuario { get; set; }
    public ParceriaEntity Parceria { get; set; }
}