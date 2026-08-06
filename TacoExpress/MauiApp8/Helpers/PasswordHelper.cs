using System.Security.Cryptography;
using System.Text;

namespace MauiApp8.Helpers;

public static class PasswordHelper
{
    public static string ComputeSha256(string password)
    {
        using SHA256 sha256 = SHA256.Create();

        byte[] bytes = Encoding.UTF8.GetBytes(password);

        byte[] hash = sha256.ComputeHash(bytes);

        StringBuilder builder = new StringBuilder();

        foreach (byte b in hash)
        {
            builder.Append(b.ToString("x2"));
        }

        return builder.ToString();
    }
}