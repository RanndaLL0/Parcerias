
using Npgsql;

public class ParceriaService
{
    private readonly ParceriaRepository _parceriaRepository;

    public ParceriaService(ParceriaRepository parceriaRepository) {
        this._parceriaRepository = parceriaRepository;
    }

    public async void save(ParceriaRequestDto dto) {
        try
        {
            _parceriaRepository.saveParceria(dto);
        }
        catch (NpgsqlException error)
        {
            throw new NpgsqlException("Erro ao cadastrar parceria: " + error.Message);
        }
    }
}