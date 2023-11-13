using Blogs.Application.Identity.Services;
using BC = BCrypt.Net.BCrypt;

namespace Blogs.Infrastructure.Common.Identity.Services;

public class PasswordHasherService : IPasswordHasherService
{
    public string HashPassword(string password)
        => BC.HashPassword(password);

    public bool VerifyPassword(string password, string hashedPassword)
        => BC.Verify(password, hashedPassword);
}