namespace efcoreRestFull.Request;

public class TokenGenerationRequest
{
    public int Id { get; set; }
    public string? Email;

    public Dictionary<string, object> CustomClaims { get; set; }
}