

using System.Text.Json.Serialization;

public class AnexoRequestDto
{
    public long idRelacional { get; set; }
    public DateTime startDate { get; set; }
    public DateTime? finalDate { get; set; }
    [JsonRequired]
    public required string description { get; set; }
    public long idParceira { get; set; }
}