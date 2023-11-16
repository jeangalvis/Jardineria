using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class GamaProducto
{
    public int IdGama { get; set; }

    public string DescripcionTexto { get; set; }

    public string DescripcionHtml { get; set; }

    public string Imagen { get; set; }

    public ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
