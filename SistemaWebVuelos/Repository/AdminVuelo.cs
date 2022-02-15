using SistemaWebVuelos.Data;
using SistemaWebVuelos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SistemaWebVuelos.Repository
{

    public class AdminVuelo
    {
        private static VueloDbContext context = new VueloDbContext();

        //TRAER TODOS LOS VUELOS
        public static List<Vuelo> TraerVuelos()
        {
            return context.Vuelos.ToList();
        }

        //TRAER POR MATRICULA

        public static Vuelo TraerMatricula(string matricula)
        {
            Vuelo vuelo = (from v in context.Vuelos.ToList() where v.Matricula == matricula select v).FirstOrDefault();
            return vuelo;
        }

        //TraerPorDestino

        public static List<Vuelo> TraerPorDestino(string destino)
        {
            List<Vuelo> vuelo = (from v in context.Vuelos.ToList() where v.Destino == destino select v).ToList();
            return vuelo;
        }

        //AGREGAR VUELO

        public static int Agregar(Vuelo vuelo)
        {
            context.Vuelos.Add(vuelo);
            return context.SaveChanges();
        }

        //TRAER x ID

        public static Vuelo TraerId(int id)
        {
            return context.Vuelos.Find(id);
        }

        //eliminar x ID


        public static int Eliminar(Vuelo vuelo)
        {
            context.Vuelos.Remove(vuelo);
            return context.SaveChanges();
        }

        //editar x ID

        public static int Modificar(Vuelo vuelo)
        {
            context.Entry(vuelo).State = EntityState.Modified;
            return context.SaveChanges();
        }



    }



}
