using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCore_Roles.Models
{
  public class Lance
  {
    public int LanceID { get; set; }
    
    public decimal Valor { get; set; }

    public string UserId { get; set; }

    public int LeilaoID { get; set; }

    public ApplicationUser User { get; set; }

    public Leilao Leilao { get; set; }
  }
}
