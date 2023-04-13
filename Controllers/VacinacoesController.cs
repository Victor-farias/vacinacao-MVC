using Microsoft.AspNetCore.Mvc;
using vacinacao.Data;
using vacinacao.DTO;
using vacinacao.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace vacinacao.Controllers
{   
    [Authorize]
    public class VacinacoesController : Controller
    {
        private readonly ApplicationDbContext database;
        public VacinacoesController(ApplicationDbContext database)
        {   
            this.database = database;
        }

        [HttpPost]
        public IActionResult Salvar(VacinacaoDTO vacinacaoDTO) {
            if (ModelState.IsValid) {
                Vacinacao vacinacao = new Vacinacao();
                vacinacao.Id = vacinacaoDTO.Id;
                vacinacao.Data = vacinacaoDTO.Data;
                vacinacao.Pessoa = database.Pessoas.First(p => p.Id == vacinacaoDTO.PessoaId);
                vacinacao.LoteVacina = database.LotesVacinas.Include(v => v.Vacina).First(l => l.Id == vacinacaoDTO.LoteVacinaId);
                vacinacao.LoteVacina.QuantidadeRestante--;
                vacinacao.Dose = vacinacaoDTO.Dose;

                if (vacinacao.LoteVacina.Vacina.Posologia == 2 && vacinacao.Dose == 11) {
                    vacinacao.Dose = 1;
                }
        
                vacinacao.LocalDeVacinacao = database.LocaisDeVacinacao.First(l => l.Id == vacinacaoDTO.LocalDeVacinacaoId);
                vacinacao.Status = true;
                vacinacao.Pessoa.StatusVacinacao = true;
                database.Vacinacoes.Add(vacinacao);
                database.SaveChanges();
                return RedirectToAction("Vacinacoes", "Home");
            } else {
                ViewBag.Pessoas = database.Pessoas.ToList();
                ViewBag.LotesVacinas = database.LotesVacinas.ToList();
                ViewBag.LocaisDeVacinacao = database.LocaisDeVacinacao.ToList();
                return View("../Home/NovaVacinacao");
            }
        }

        [HttpPost]
        public IActionResult Atualizar(VacinacaoDTO vacinacaoDTO) {
            if (ModelState.IsValid) {
                var vacinacao = database.Vacinacoes.First(v => v.Id == vacinacaoDTO.Id);
                vacinacao.Data = vacinacaoDTO.Data;
                vacinacao.Pessoa = database.Pessoas.First(p => p.Id == vacinacaoDTO.PessoaId);
                vacinacao.LoteVacina = database.LotesVacinas.First(l => l.Id == vacinacaoDTO.LoteVacinaId);
                vacinacao.LocalDeVacinacao = database.LocaisDeVacinacao.First(l => l.Id == vacinacaoDTO.LocalDeVacinacaoId);
                vacinacao.Dose = vacinacaoDTO.Dose;
                database.SaveChanges();
                return RedirectToAction("Vacinacoes", "Home");
            } else {
                return RedirectToAction("Vacinacoes", "Home");
            }
        }

        public IActionResult Deletar(int id) {
            if (id > 0) {
                var vacinacao = database.Vacinacoes.Include(v => v.Pessoa).First(v => v.Id == id);
                vacinacao.Status = false;
                vacinacao.Pessoa.StatusVacinacao = false;
                database.SaveChanges();
                return RedirectToAction("Vacinacoes", "Home");
            } 
            return RedirectToAction("Vacinacoes", "Home");
        }

        [HttpPost]
        public IActionResult Vacinacao(int id) {
            //return Json("Esses são os dados, o status é só o indicativo");
            if (id > 0) {
                var vacinacao = database.Vacinacoes
                .Include(v => v.Pessoa)
                .Include(v => v.LoteVacina)
                .Include(v => v.LocalDeVacinacao)
                .First(v => v.Pessoa.Id == id);

                if (vacinacao != null) {
                    return Json(vacinacao);
                } else {
                    return Json(null);
                }
            } else {
                return Json(null);
            }
        }
    }
}