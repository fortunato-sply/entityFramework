using System;
using System.Collections.Generic;

namespace naosei.Model;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public DateTime DataNascimento { get; set; }

    public byte[]? Foto { get; set; }

    public virtual ICollection<Ofertum> Oferta { get; set; } = new List<Ofertum>();
}
