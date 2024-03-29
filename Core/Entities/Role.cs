﻿namespace Core.Entities;

public class Role
{
    public int Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<User> Users { get; set; } 
        = new List<User>();  
}