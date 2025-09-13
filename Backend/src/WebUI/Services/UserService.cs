

using Npgsql;

public class UserService
{
    private readonly UserRepository _userRepository;

    public UserService(UserRepository userRepository)
    {
        this._userRepository = userRepository;
    }

    public async void Save(UserRequestDto dto)
    {
        try
        {
            int rowsAffected = await _userRepository.saveUser(dto);

            if (rowsAffected < 1)
            {
                throw new NpgsqlException("Erro ao cadastrar usuario");
            }
        }
        catch (Exception)
        {
            throw new Exception("Erro ao salvar na base de dados");
        }
    }

}