﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Staycation.Data.Entities;

public class Accommodation : BaseEntity
{
    public string Title { get; set; }
    public string? Subtitle { get; set; }
    public string? Description { get; set; }
    public string Type { get; set; }
    public int Categorisation { get; set; }
    public int PersonCount { get; set; }
    public string ImageUrl { get; set; }
    public bool FreeCancellation { get; set; }
    public decimal Price { get; set; }

    [ForeignKey(nameof(Location))]
    public int LocationId { get; set; }

    public virtual Location Location { get; set; }
}
