using Npgsql;

public class AnexoRepository
{

    public DbConnectionFactory _dbFactoryConnection { get; set; }

    public AnexoRepository(DbConnectionFactory dbConnectionFactory)
    {
        this._dbFactoryConnection = dbConnectionFactory;
    }

    public async void saveAnexo(AnexoRequestDto dto)
    {
        try
        {

            string query = @"
                CALL public.insert_anexo(
                    @data_inicio,
                    @data_final,
                    @descricao,
                    @p_id_parceria,
                    @p_id_relacional
                );
            ";

            await using NpgsqlConnection conn = _dbFactoryConnection.GetDbConnection();
            await conn.OpenAsync();

            using var command = new NpgsqlCommand(query,conn);

            command.Parameters.AddWithValue("data_inicio",dto.startDate);
            command.Parameters.AddWithValue("data_final",dto.finalDate);
            command.Parameters.AddWithValue("descricao",dto.description);
            command.Parameters.AddWithValue("p_id_parceria",dto.idParceira);
            command.Parameters.AddWithValue("p_id_relacional",dto.idRelacional);

            using var reader = await command.ExecuteReaderAsync();

            await reader.ReadAsync();
        }
        catch (Exception error)
        {
            throw new InvalidOperationException("Falha ao estabelecer conexão: " + error.Message);
        }
    }

}