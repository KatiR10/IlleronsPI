using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Illerons.Models;

namespace Illerons.Controllers
{
    public class UsuarioController : Controller
    {
        
        public IActionResult Login()
        {
            return View();

        }


        [HttpPost]

        public IActionResult Login(Usuario usuario)
        {
            UsuarioRepository ur = new UsuarioRepository();
            Usuario usuarioSessao = ur.ValidarLogin(usuario);


            if (usuarioSessao != null)
            {
                ViewBag.Mensagem = "Você está logado!";
                HttpContext.Session.SetInt32("IdUsuario", usuarioSessao.Id);
                HttpContext.Session.SetString("NomeUsuario", usuarioSessao.Nome);

                return RedirectToAction("ListaUsuario");
            }
            else
            {
                ViewBag.Mensagem = "Falha no login!";
                return View();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Login");
        }
    public IActionResult ListaUsuario()
        {
            if (HttpContext.Session.GetInt32("IdUsuario") == null)
                return RedirectToAction("Login");

            UsuarioRepository ur = new UsuarioRepository();
            List<Usuario> Listagem = ur.listar();
            return View(Listagem);
        }

     public IActionResult CadastroUsuario()
        {

            return View();
        }

        [HttpPost]
        public IActionResult CadastroUsuario(Usuario usuario)
        {

            UsuarioRepository ur = new UsuarioRepository();
            ur.inserir(usuario);
            ViewBag.Mensagem = "Cadastro concluído! ";

            return View();

        }
    
     public IActionResult RemoverUsuario(int Id)
        {
            if (HttpContext.Session.GetInt32("IdUsuario") == null)
                return RedirectToAction("Login");
            UsuarioRepository ur = new UsuarioRepository();
            Usuario usuariobuscado = ur.buscarPorId(Id);

            ur.remover(usuariobuscado);

            return RedirectToAction("ListaUsuario");

        }

        public IActionResult EditarUsuario(int Id)
        {
            if (HttpContext.Session.GetInt32("IdUsuario") == null)
                return RedirectToAction("Login");
            UsuarioRepository ur = new UsuarioRepository();
            Usuario usuariobuscado = ur.buscarPorId(Id);
            return View(usuariobuscado);

        }
        [HttpPost]
        public IActionResult EditarUsuario(Usuario usuario)
        {
            if (HttpContext.Session.GetInt32("IdUsuario") == null)
                return RedirectToAction("Login");

            UsuarioRepository ur = new UsuarioRepository();
            ur.editar(usuario);

            return RedirectToAction("ListaUsuario");

        }
    
    
    }
}