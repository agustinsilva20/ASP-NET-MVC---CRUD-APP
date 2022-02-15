using SistemaWebVuelos.Data;
using SistemaWebVuelos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SistemaWebVuelos.Initializer
{
    public class VueloDBInitializer : DropCreateDatabaseAlways<VueloDbContext>
    {
        protected override void Seed(VueloDbContext context)
        {

            var vuelos = new List<Vuelo>()
            {
                new Vuelo()
                {
                  Fecha=Convert.ToDateTime("2022-12-12").Date, Destino="Madrid", Origen="Argentina", Matricula="12a31"
                },

                new Vuelo()
                {
                    Fecha = Convert.ToDateTime("2022-11-12").Date, Destino = "Londres", Origen = "Argentina", Matricula = "731a"
                },

                new Vuelo()
                {
                    Fecha = Convert.ToDateTime("2022-10-12").Date, Destino = "EEUU", Origen = "Mexico", Matricula = "a4"
                },

            };

            vuelos.ForEach(s => context.Vuelos.Add(s));
            context.SaveChanges();


        }
    }
}
