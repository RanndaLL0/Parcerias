

public class ResponsaveisEntity
{
    public long Id { get; set; }
    public long IdUsuario { get; set; }
    public long IdParceria { get; set; }

    public UsuarioParceriaEntity Usuario { get; set; }
    public ParceriaEntity Parceria { get; set; }
}