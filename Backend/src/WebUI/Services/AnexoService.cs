

public class AnexoService
{
    public AnexoRepository _anexoRepository { get; set; }

    public AnexoService(AnexoRepository anexoRepository)
    {
        this._anexoRepository = anexoRepository;
    }

    public void registryAnexo(AnexoRequestDto dto)
    {
        try
        {
            dto.finalDate = dto.startDate.AddYears(1);
            _anexoRepository.saveAnexo(dto);
        } catch (Exception error) {
            throw new InvalidOperationException("Erro ao cadastrar anexo: " + error.Message);
        }
    }
}