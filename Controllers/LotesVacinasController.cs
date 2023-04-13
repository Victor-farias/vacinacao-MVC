using Microsoft.AspNetCore.Mvc;
using vacinacao.Data;
using vacinacao.DTO;
using vacinacao.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace vacinacao.Controllers
{   
    [Authorize]
    public class LotesVacinasController : Controller
    {
        private readonly ApplicationDbContext database;
        public LotesVacinasController(ApplicationDbContext database)
        {   
            this.database = database;
        }

        [HttpPost]
        public IActionResult Salvar(LoteVacinaDTO loteVacinaDTO) {
            if (ModelState.IsValid) {   
                LoteVacina loteVacina = new LoteVacina();
                loteVacina.Id = loteVacinaDTO.Id;
                loteVacina.Vacina = database.Vacinas.First(v => v.Id == loteVacinaDTO.VacinaId);
                loteVacina.IdentificacaoDoLote = loteVacinaDTO.IdentificacaoDoLote;
                loteVacina.QuantidadeRecebida = loteVacinaDTO.QuantidadeRecebida;
                loteVacina.QuantidadeRestante = loteVacinaDTO.QuantidadeRestante;
                loteVacina.DataDeRecebimento = loteVacinaDTO.DataDeRecebimento;
                loteVacina.DataDeValidade = loteVacinaDTO.DataDeValidade;
                loteVacina.Status = true;
                database.LotesVacinas.Add(loteVacina);
                database.SaveChanges();
                return RedirectToAction("LotesVacinas", "Home");
            } else {
                ViewBag.Vacinas = database.Vacinas.ToList();
                return View("../Home/NovoLoteVacina");
            }
        }

        [HttpPost]
        public IActionResult Atualizar(LoteVacinaDTO loteVacinaDTO) {
            if (ModelState.IsValid) {
                var loteVacina = database.LotesVacinas.First(l => l.Id == loteVacinaDTO.Id);
                loteVacina.Vacina = database.Vacinas.First(v => v.Id == loteVacinaDTO.VacinaId);
                loteVacina.IdentificacaoDoLote = loteVacinaDTO.IdentificacaoDoLote;
                loteVacina.QuantidadeRecebida = loteVacinaDTO.QuantidadeRecebida;
                loteVacina.QuantidadeRestante = loteVacinaDTO.QuantidadeRestante;
                loteVacina.DataDeRecebimento = loteVacinaDTO.DataDeRecebimento;
                loteVacina.DataDeValidade = loteVacinaDTO.DataDeValidade;
                database.SaveChanges();
                return RedirectToAction("LotesVacinas", "Home");
            } else {
                return RedirectToAction("LotesVacinas", "Home");
            }
        }

        public IActionResult Deletar(int id) {
            if (id > 0) {
                var loteVacina = database.LotesVacinas.First(l => l.Id == id);
                loteVacina.Status = false;
                database.SaveChanges();
            }
            return RedirectToAction("LotesVacinas", "Home");
        }
    }
}