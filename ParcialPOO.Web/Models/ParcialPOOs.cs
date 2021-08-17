using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ParcialPOO.Web.Models
{
    public class ParcialPOOs
    {
        

        [Display(Name = "Valor de prestamo")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public int ValorPresta { get; set; }

        [Display(Name = "Numero de cuotas")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public double Cuotas { get; set; }

        [Display(Name = "Tasa de interes")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public double Tasa { get; set; }

        [Display(Name = "Seguro de vida asociado")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public double Seguro { get; set; }


        public int NroCuotas { get; set; }
        public double AbonoCapi { get; set; }
        public double NuevoSaldo { get; set; }
        public double AbonoInte { get; set; }
        public double CuotaSeguro { get; set; }
        public double CuotaMensual { get; set; }

        
    }

    
}