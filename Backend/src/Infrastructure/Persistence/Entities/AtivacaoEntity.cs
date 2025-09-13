
public class AtivacaoEntity
{
    public long Id { get; set; }
    public string Area { get; set; }
    public string Description { get; set; }

    public long IdParceria { get; set; }
    public long Responsavel { get; set; }

    public ParceriaEntity Parceria { get; set; }
    public UsuarioParceriaEntity UsuarioResponsavel { get; set; }
}