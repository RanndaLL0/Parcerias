
using System.Threading.Tasks;
using Npgsql;

public class ParceriaRepository
{

    private readonly DbConnectionFactory _dbConnectionFactory;

    public ParceriaRepository(DbConnectionFactory dbConnectionFactory)
    {
        this._dbConnectionFactory = dbConnectionFactory;
    }

    public async Task<int> saveParceria(ParceriaRequestDto dto)
    {
        string query = @"
            CALL insert_parceria(
                @objetive,
                @startDate,
                @endDate,
                @professorId,
                @parceiroNome,
                @parceiroEmail,
                @parceiroArea
            );
        ";

        await using NpgsqlConnection conn = _dbConnectionFactory.GetDbConnection();
        await conn.OpenAsync();

        using var cmd = new NpgsqlCommand(query);
        cmd.Parameters.AddWithValue("objetive", dto.Objective);
        cmd.Parameters.AddWithValue("startDate", dto.StartDate);
        cmd.Parameters.AddWithValue("endDate", dto.EndDate);
        cmd.Parameters.AddWithValue("professorId", dto.professorID);
        cmd.Parameters.AddWithValue("parceiroNome", dto.parceiroName);
        cmd.Parameters.AddWithValue("professorEmail", dto.parceiroEmail);
        cmd.Parameters.AddWithValue("parceiroArea", dto.parceiroArea);

    }
}