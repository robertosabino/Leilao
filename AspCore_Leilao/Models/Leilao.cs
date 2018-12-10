using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCore_Roles.Models
{
  public class Leilao
  {
    public int LeilaoID { get; set; }

    public string Nome { get; set; }

    public decimal ValorInicial { get; set; }

    public bool Usado { get; set; }

    public string UserId { get; set; }

    public DateTime DataAbertura { get; set; }

    public DateTime DataFinalizacao { get; set; }

    public ApplicationUser User { get; set; }

    public ICollection<Lance> Lances { get; set; }
  }
}
