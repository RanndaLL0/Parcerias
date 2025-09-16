
using System.Threading.Tasks;
using Npgsql;

public class ParceriaRepository
{

    private readonly DbConnectionFactory _dbConnectionFactory;

    public ParceriaRepository(DbConnectionFactory dbConnectionFactory)
    {
        this._dbConnectionFactory = dbConnectionFactory;
    }

    public async void saveParceria(ParceriaRequestDto dto)
    {
        try
        {
            string query = @"
            CALL public.insert_parceria(
                @objetive,
                @startDate,
                @endDate,
                @professorId,
                @parceironome,
                @parceiroemail,
                @parceiroarea
            );
        ";

            await using NpgsqlConnection conn = _dbConnectionFactory.GetDbConnection();
            await conn.OpenAsync();

            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("objetive", dto.Objective);
            cmd.Parameters.AddWithValue("startDate", dto.StartDate);
            cmd.Parameters.AddWithValue("endDate", dto.EndDate);
            cmd.Parameters.AddWithValue("professorId", dto.professorID);
            cmd.Parameters.AddWithValue("parceironome", dto.parceiroName);
            cmd.Parameters.AddWithValue("parceiroemail", dto.parceiroEmail);
            cmd.Parameters.AddWithValue("parceiroarea", dto.parceiroArea);

            using var reader = await cmd.ExecuteReaderAsync();
            await reader.ReadAsync();
        }
        catch (NpgsqlException error)
        {
            throw new NpgsqlException("Erro ao cadastrar parceria: " + error.Message);
        }
    }
}