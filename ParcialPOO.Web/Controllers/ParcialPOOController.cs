using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ParcialPOO.Web.Models;


namespace ParcialPOO.Web.Controllers
{
    public class ParcialPOOController : Controller
    {
        static List<ParcialPOOs> dato = new List<ParcialPOOs>();
        
        
        [HttpGet]
        public ActionResult Tabla()
        {


            return View(dato);
        }

        [HttpGet]
        public ActionResult Index()
        {
            
            return View();
        }


        [HttpPost]
        public ActionResult Index(ParcialPOOs parcialPOOs)
        {
            
            if (!ModelState.IsValid)
                return View(parcialPOOs);

           

            var valorpresta = parcialPOOs.ValorPresta;
            var nrocuotas = parcialPOOs.Cuotas;
            var tasa = parcialPOOs.Tasa/100;
            var seguro = parcialPOOs.Seguro;
            
            double cuotaMensual = Math.Round(valorpresta * ((tasa * (Math.Pow((1 + tasa), nrocuotas))) / ((Math.Pow((1 + tasa), nrocuotas)) - 1)));
            double nuevoSaldo = valorpresta;
            double abonoCapital = 0;
            double abonoInteres = 0;
            double cuotaSeguro = 0;

            

            for (int i = 0; i <= nrocuotas; i++)
            {
                if(i == 0)
                {
                    dato.Add(new ParcialPOOs { NroCuotas = ViewBag.nrocuotas = i, AbonoInte = ViewBag.abonoInt = 0, AbonoCapi = ViewBag.abonoCap = 0, CuotaMensual = ViewBag.cuotaMensual = 0, Seguro = ViewBag.seguro = seguro, CuotaSeguro = ViewBag.cuotaseguro = 0, NuevoSaldo = ViewBag.nuevoSaldo = nuevoSaldo });

                }
                else if(i < nrocuotas)
                {
                    abonoInteres = Math.Round(nuevoSaldo * tasa);
                    abonoCapital = Math.Round(cuotaMensual - abonoInteres);
                    cuotaSeguro = Math.Round(cuotaMensual + seguro);
                    nuevoSaldo = Math.Round(nuevoSaldo - abonoCapital);



                    dato.Add(new ParcialPOOs { NroCuotas = ViewBag.nrocuotas = i, AbonoInte = ViewBag.abonoInt = abonoInteres, AbonoCapi = ViewBag.abonoCap = abonoCapital, CuotaMensual = ViewBag.cuotaMensual = cuotaMensual, Seguro = ViewBag.seguro = seguro, CuotaSeguro = ViewBag.cuotaseguro = cuotaSeguro, NuevoSaldo = ViewBag.nuevoSaldo = nuevoSaldo });

                }
                else
                {
                    abonoInteres = Math.Round(nuevoSaldo * tasa);
                    abonoCapital = Math.Round(cuotaMensual - abonoInteres);
                    cuotaSeguro = Math.Round(cuotaMensual);
                    nuevoSaldo = Math.Round(nuevoSaldo - abonoCapital);



                    dato.Add(new ParcialPOOs { NroCuotas = ViewBag.nrocuotas = i, AbonoInte = ViewBag.abonoInt = abonoInteres, AbonoCapi = ViewBag.abonoCap = abonoCapital, CuotaMensual = ViewBag.cuotaMensual = cuotaMensual, Seguro = ViewBag.seguro = 0, CuotaSeguro = ViewBag.cuotaseguro = cuotaSeguro, NuevoSaldo = ViewBag.nuevoSaldo = nuevoSaldo });

                }


            }

            return RedirectToAction("Tabla");
            
        }
    }
}