using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

public class Painting
{
    public int Id { get; set; }
    public string ArtistSurname { get; set; }
    public string Title { get; set; }
    public decimal Price { get; set; }
    public int Status { get; set; } // 1 – в експозиції, 2 – в запаснику, 3 – на виїзді
}
