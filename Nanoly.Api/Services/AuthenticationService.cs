namespace Nanoly.Services;

using Nanoly.Dto;
using Nanoly.Entities;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using System;


public class AuthenticationService
{
    private readonly UserService _userService;
    private readonly TokenService _tokenService;

    public AuthenticationService(UserService userService, TokenService tokenService)
    {
        _userService = userService;
        _tokenService = tokenService;
    }

    public async Task<string> Login(LoginRequestDTO body)
    {
        var user = await _userService.GetUserByEmail(body.Email);
        return _tokenService.GenerateToken(user);
    }

    public async Task<User> Register(RegisterRequestDTO body)
    {
        var exsist = await _userService.GetUserByEmail(body.Email);

        if (exsist != null) throw new Exception("user with this email already exists");

        var user = new User() { email = body.Email, password = HashPassword(body.Password) };
        await _userService.CreateUser(user);
        return user;
    }

    public string HashPassword(string password)
    {
        byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);
        string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(password: password, salt: salt, prf: KeyDerivationPrf.HMACSHA256, iterationCount: 100000, numBytesRequested: 256 / 8));
        return hashed;
    }
}