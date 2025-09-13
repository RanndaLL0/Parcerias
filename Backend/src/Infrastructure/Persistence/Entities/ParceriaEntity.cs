
public class ParceriaEntity
{
    public long Id { get; set; }
    public string Objective { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public long IdParceiro { get; set; }
    public List<UsuarioParceriaEntity> Usuarios { get; set; }
    public List<AtivacaoEntity> Ativacoes { get; set; }
    public List<Contrato> Contratos { get; set; }
    public List<AnexoEntity> Anexos { get; set; }
}