using System;
using System.Collections.Generic;

namespace naosei.Model;

public partial class Produto
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Descricao { get; set; } = null!;

    public byte[]? Foto { get; set; }

    public virtual ICollection<Ofertum> Oferta { get; set; } = new List<Ofertum>();
}
