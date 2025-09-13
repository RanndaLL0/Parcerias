using Microsoft.AspNetCore.Http.Metadata;
using Npgsql;

public class UserRepository
{
    private readonly DbConnectionFactory _dbConnectionFactory;

    public UserRepository(DbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    public async Task<int> saveUser(UserRequestDto dto)
    {
        try
        {
            string query = @"
                INSERT INTO Usuario
                (name,password,email,role,contato)
                VALUES
                (@name,@password,@email,@role,@contato)
            ";

            await using NpgsqlConnection conn = _dbConnectionFactory.GetDbConnection();
            await conn.OpenAsync();

            await using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", dto.name);
            cmd.Parameters.AddWithValue("@password", dto.password);
            cmd.Parameters.AddWithValue("@email", dto.email);
            cmd.Parameters.AddWithValue("@role", dto.role.ToString());
            cmd.Parameters.AddWithValue("@contato", dto.contato);

            int linhasAfetadas = await cmd.ExecuteNonQueryAsync();
            return linhasAfetadas;
        }
        catch (NpgsqlException error)
        {
            throw new NpgsqlException("Erro ao inserir usuario no banco: " + error.Message);
        }
    }
}