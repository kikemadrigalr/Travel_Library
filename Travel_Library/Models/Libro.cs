using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Travel_Library.Models;

public partial class Libro
{
    public int Isbn { get; set; }

    public int EditorialId { get; set; }

    [Required]
    public string? Titulo { get; set; }

    [Required]
    public string? Sinopsis { get; set; }

    [Required]
    public string? NPaginas { get; set; }

    public virtual Editorial Editorial { get; set; } = null!;
}
