﻿using System;
using System.Collections.Generic;

namespace Travel_Library.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string? Correo { get; set; }

    public string? Contrasena { get; set; }
}
