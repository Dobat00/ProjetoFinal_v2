using Microsoft.AspNetCore.Mvc;
using ProjetoFinal_v2.Data;
using ProjetoFinal_v2.Models;

namespace ProjetoFinal_v2.Controllers
{
    public class ClientesController : Controller
    {
        private readonly Contexto _db;
        public ClientesController(Contexto db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Cliente> objClientesList = _db.Clientes;
            return View(objClientesList);
        }
        //Criar
        public IActionResult Adicionar()
        {
  
            return View();
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Adicionar(Cliente obj)
        {
            if (ModelState.IsValid)
            {
                _db.Clientes.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if(id==null || id == 0)
            {   
                return NotFound();
            }

            var ClienteFromDb = _db.Clientes.Find(id);

            if (ClienteFromDb == null)
            {
                return NotFound();
            }

            return View(ClienteFromDb);
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Cliente obj)
        {
            if (ModelState.IsValid)
            {
                _db.Clientes.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var ClienteFromDb = _db.Clientes.Find(id);

            if (ClienteFromDb == null)
            {
                return NotFound();
            }

            return View(ClienteFromDb);
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Clientes.Find(id);
            if(obj == null)
            {
                return NotFound();
            }

            _db.Clientes.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
