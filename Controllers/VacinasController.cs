using Microsoft.AspNetCore.Mvc;
using vacinacao.Data;
using vacinacao.DTO;
using vacinacao.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace vacinacao.Controllers
{   
    [Authorize]
    public class VacinasController : Controller
    {
        private readonly ApplicationDbContext database;
        public VacinasController(ApplicationDbContext database)
        {   
            this.database = database;
        }

        public IActionResult Salvar(VacinaDTO vacinaDTO) {
            if (ModelState.IsValid) {
                Vacina vacina = new Vacina();
                vacina.Id = vacinaDTO.Id;
                vacina.Nome = vacinaDTO.Nome;
                vacina.Laboratorio = vacinaDTO.Laboratorio;
                vacina.Posologia = vacinaDTO.Posologia;
                vacina.IntervaloEntreDoses = vacinaDTO.IntervaloEntreDoses;
                vacina.Status = true;
                database.Vacinas.Add(vacina);
                database.SaveChanges();
                return RedirectToAction("Vacinas", "Home");
            } else {
                return View("../Home/NovaVacina");
            }
        }

        public IActionResult Atualizar(VacinaDTO vacinaDTO) {
            if (ModelState.IsValid) {
                var vacina = database.Vacinas.First(v => v.Id == vacinaDTO.Id);
                vacina.Nome = vacinaDTO.Nome;
                vacina.Laboratorio = vacinaDTO.Laboratorio;
                vacina.Posologia = vacinaDTO.Posologia;
                if (vacina.Posologia == 1) {
                    vacina.IntervaloEntreDoses = 0;
                } else {
                    vacina.IntervaloEntreDoses = vacinaDTO.IntervaloEntreDoses;
                }
                database.SaveChanges();
                return RedirectToAction("Vacinas", "Home");
            } else {
                return RedirectToAction("Vacinas", "Home");
            }
        }

        public IActionResult Deletar(int id) {
            if (id > 0) {
                var vacina = database.Vacinas.First(v => v.Id == id);
                vacina.Status = false;
                database.SaveChanges();
            }
            return RedirectToAction("Vacinas", "Home");
        }
    }
}