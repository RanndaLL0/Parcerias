
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class UserRequestDto
{
    public string name { get; set; }
    public string password { get; set; }
    public string email { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public USERROLE role { get; set; }
    
    public string contato { get; set; }
}