using System.Text.Json.Serialization;

namespace Ecommerce.Models;

public class Login
{
    public string Username { get; set; }

    public string Password { get; set; }

    // testing 
    public override string ToString()
    {
        return $"Username:{Username}, Password:{Password}";
    }
}