using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Illerons.Models;

namespace Illerons.Controllers
{
    public class PersonalizadosController : Controller
    {
        public IActionResult ListaPersonalizados()
        {
            if (HttpContext.Session.GetInt32("IdUsuario") == null)
                return RedirectToAction("Login", "Usuario");

            PersonalizadosRepository psr = new PersonalizadosRepository();
            List<Personalizados> ListaPersonalizados = psr.listar();
            return View(ListaPersonalizados);
        }

        public IActionResult CadastroPersonalizados()
        {
            if (HttpContext.Session.GetInt32("IdUsuario") == null)
                return RedirectToAction("Login", "Usuario");

            return View();
        }

        [HttpPost]
        public IActionResult CadastroPersonalizados(Personalizados perso)
        {

            if (HttpContext.Session.GetInt32("IdUsuario") == null)
                return RedirectToAction("Login", "Usuario");

            PersonalizadosRepository psr = new PersonalizadosRepository();
            psr.inserir(perso);
            ViewBag.Mensagem = "Cadastro do pedido concluído!";

            return View();

        }
        public IActionResult RemoverPersonalizados(int Id)
        {
            if (HttpContext.Session.GetInt32("IdUsuario") == null)
                return RedirectToAction("Login", "Usuario");

            PersonalizadosRepository psr = new PersonalizadosRepository();
            Personalizados PersonalizadosBuscado = psr.buscarPorId(Id);

            psr.remover(PersonalizadosBuscado);

            return RedirectToAction("ListaPersonalizados");

        }


        public IActionResult EditarPersonalizados(int Id)
        {
            if (HttpContext.Session.GetInt32("IdUsuario") == null)
                return RedirectToAction("Login", "Usuario");

            PersonalizadosRepository psr = new PersonalizadosRepository();
            Personalizados PersonalizadosBuscado = psr.buscarPorId(Id);


            return View(PersonalizadosBuscado);

        }


        [HttpPost]
        public IActionResult EditarPersonalizados(Personalizados perso)
        {
            if (HttpContext.Session.GetInt32("IdUsuario") == null)
                return RedirectToAction("Login", "Usuario");


            PersonalizadosRepository psr = new PersonalizadosRepository();
            psr.editar(perso);

            return RedirectToAction("ListaPersonalizados");

        }



    }
}