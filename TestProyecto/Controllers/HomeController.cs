using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TestProyecto.Data;
using TestProyecto.Models;


namespace TestProyecto.Controllers
{
    public class HomeController : Controller
    {
        //variable privada de solo lectura 
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index() //metodo Index
        {
            return View(await _context.Usuario.ToListAsync());
        }

        /// <summary>
        /// METODO DE INSERTAR USUARIO
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Usuario.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        /// <summary>
        /// METODO MODIFICAR USUARIO
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        public IActionResult Edit( int ? id)
        {
            if (id == null)
            {
                return NotFound(); //metodo para retornar un no encontrado 
            }
            var usuario = _context.Usuario.Find(id);

            if (usuario==null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Update(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(usuario);
        }

        /// <summary>
        /// METODO DETALLE DE USUARIO
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound(); //metodo para retornar un no encontrado 
            }
            var usuario = _context.Usuario.Find(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        /// <summary>
        /// METODO DE ELIMINAR USUARIO
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound(); //metodo para retornar un no encontrado 
            }
            var usuario = _context.Usuario.Find(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteRegistro(int ? id)
        {
            var usuario = await _context.Usuario.FindAsync(id);

            if (usuario == null)
            {
                return View();
            }
                _context.Usuario.Remove(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
