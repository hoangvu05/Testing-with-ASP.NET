namespace ContosoUniversity.Models;

using System.Text.Json.Serialization;
using ContosoUniversity.Models;

public class AuthenticateResponse
{
    public int UserId{ get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string JwtToken { get; set; }

    public string Url { get; set; }

    [JsonIgnore] // refresh token is returned in http only cookie
    public string RefreshToken { get; set; }

    public AuthenticateResponse(User user, string jwtToken, string refreshToken,string url)
    {
        UserId = user.UserId;
        FirstName = user.FirstName;
        LastName = user.LastName;
        Username = user.Username;
        JwtToken = jwtToken;
        RefreshToken = refreshToken;
        Url=url;
    }
}