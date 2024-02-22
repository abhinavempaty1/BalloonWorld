using BalloonWorld.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BalloonWorld.Models;

public class balloonoccasionviewmodel
{
    public List<Balloon>? Balloons { get; set; }
    public SelectList? occasion { get; set; }
    public string? balloonoccasion { get; set; }
    public string? SearchString { get; set; }
}