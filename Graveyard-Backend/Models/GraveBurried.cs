﻿using System.ComponentModel.DataAnnotations;

namespace Graveyard_Backend.Models;

public class GraveBurried
{
    public GraveBurried()
    {
    }

    public GraveBurried(Burried burried, Grave grave, Gravedigger gravedigger)
    {
        this.Burried = burried;
        this.Grave = grave;
        Gravedigger = gravedigger;
    }

    [Key] public int BurriedGraveId { get; set; }

    public Burried Burried { get; set; }
    public int BurriedId { get; set; }
    public int GraveId { get; set; }
    public Grave Grave { get; set; }
    public Gravedigger Gravedigger { get; set; }
}