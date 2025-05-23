﻿namespace MartenDemo.Entities;

public sealed class Cat
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Breed { get; set; } = string.Empty;

    public string Color { get; set; } = string.Empty;
}