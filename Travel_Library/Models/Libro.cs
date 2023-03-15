using System;
using System.Collections.Generic;

namespace Travel_Library.Models;

public partial class Libro
{
    public int Isbn { get; set; }

    public int EditorialId { get; set; }

    public string? Titulo { get; set; }

    public string? Sinopsis { get; set; }

    public string? NPaginas { get; set; }

    public virtual Editorial Editorial { get; set; } = null!;
}
