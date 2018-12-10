using AspCore_Roles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCore_Roles.Data
{
  public class DbInitializer
  {
    public static void Initialize(LeilaoDbContext context)
    {
      context.Database.EnsureCreated();
      // procura por qualquer estudante
      if (context.Leiloes.Any())
      {
        return;  //O banco foi inicializado
      }

      var Leiloes = new Leilao[]
      {
          new Leilao{Nome="Notebook Dell",ValorInicial=500, Usado=true, DataAbertura=DateTime.Parse("2019-01-01"), DataFinalizacao=DateTime.Parse("2019-01-10")},
          new Leilao{Nome="Monitor Dell",ValorInicial=100, Usado=true, DataAbertura=DateTime.Parse("2019-01-01"), DataFinalizacao=DateTime.Parse("2019-01-10")}  
      };
      foreach (Leilao l in Leiloes)
      {
        context.Leiloes.Add(l);
      }
      context.SaveChanges();      
    }
  }
}
