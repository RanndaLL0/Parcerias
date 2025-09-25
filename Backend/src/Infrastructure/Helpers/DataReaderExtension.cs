using Npgsql;

public static class DataReaderExtensions
{
    public static UserResponseDto MapUserToDto(this NpgsqlDataReader reader)
    {
        return new UserResponseDto
        {
            Name = reader.GetString(reader.GetOrdinal("name")),
            Email = reader.GetString(reader.GetOrdinal("email")),
            Contato = reader.GetString(reader.GetOrdinal("contato")),
            Role = reader.GetString(reader.GetOrdinal("role"))
        };
    }
}