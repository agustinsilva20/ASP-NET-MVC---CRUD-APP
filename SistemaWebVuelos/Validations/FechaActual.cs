using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaWebVuelos.Validations
{
    public class FechaActual:ValidationAttribute
    {
        public FechaActual()
        {
            ErrorMessage = "La fecha ingresada debe ser mayor o igual a la fecha actual";
        }
        public override bool IsValid(object value)
        {
            DateTime fecha = Convert.ToDateTime(value);
            DateTime actual = DateTime.Today;

            if (fecha >= actual){
                return true;
            }
            else
            {
                return false;
            }



        }


    }

 
}