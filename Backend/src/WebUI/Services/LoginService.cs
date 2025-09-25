

using System.Threading.Tasks;

public class LoginService
{
    private readonly UserRepository _userRepository;

    public LoginService(UserRepository userRepository)
    {
        this._userRepository = userRepository;
    }

    public async Task<UserResponseDto> getUser(LoginDto dto)
    {
        try
        {
            return await _userRepository.getUser(dto);
        } catch (Exception ex) {
            throw new InvalidOperationException("Erro ao realizar login: " + ex.Message);
        }
    }
}