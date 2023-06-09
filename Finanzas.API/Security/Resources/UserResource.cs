﻿namespace Finanzas.API.Security.Resources;

public class UserResource
{
    public int Id { get; set; } 
    public string Name { get; set; } 
    public string LastName { get; set; } 
    public int Age { get; set; } 
    public string? Image { get; set; }
    public string Email { get; set; }
}