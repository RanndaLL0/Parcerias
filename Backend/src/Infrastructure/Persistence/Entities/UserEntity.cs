
public class UserEntity()
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public string Contato { get; set; }
    public List<UsuarioParceriaEntity> Parcerias { get; set; }
}