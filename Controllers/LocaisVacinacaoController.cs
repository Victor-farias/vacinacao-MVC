using Microsoft.AspNetCore.Mvc;
using vacinacao.Data;
using vacinacao.DTO;
using vacinacao.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace vacinacao.Controllers
{   
    [Authorize]
    public class LocaisVacinacaoController : Controller
    {
        private readonly ApplicationDbContext database;
        public LocaisVacinacaoController(ApplicationDbContext database)
        {   
            this.database = database;
        }

        [HttpPost]
        public IActionResult Salvar(LocalDeVacinacaoDTO localDeVacinacaoDTO) {
            if (ModelState.IsValid) {
                LocalDeVacinacao localDeVacinacao = new LocalDeVacinacao();
                localDeVacinacao.Id = localDeVacinacaoDTO.Id;
                localDeVacinacao.Nome = localDeVacinacaoDTO.Nome;
                localDeVacinacao.Endereco = database.Enderecos.First(e => e.Id == localDeVacinacaoDTO.EnderecoId);
                localDeVacinacao.Status = true;
                database.LocaisDeVacinacao.Add(localDeVacinacao);
                database.SaveChanges();
                return RedirectToAction("LocaisVacinacao", "Home");
            } else {
                ViewBag.Enderecos = database.Enderecos.ToList();
                return View("../Home/NovoLocalDeVacinacao");
            }
        }

        [HttpPost]
        public IActionResult Atualizar(LocalDeVacinacaoDTO localDeVacinacaoDTO) {
            if (ModelState.IsValid) {
                var localDeVacinacao = database.LocaisDeVacinacao.First(l => l.Id == localDeVacinacaoDTO.Id);
                localDeVacinacao.Nome = localDeVacinacaoDTO.Nome;
                localDeVacinacao.Endereco = database.Enderecos.First(e => e.Id == localDeVacinacaoDTO.EnderecoId);
                database.SaveChanges();
                return RedirectToAction("LocaisVacinacao", "Home");
            } else {
                return RedirectToAction("LocaisVacinacao", "Home");
            }
        }

        public IActionResult Deletar(int id) {
            if (id > 0) {
                var localDeVacinacao = database.LocaisDeVacinacao.First(l => l.Id == id);
                localDeVacinacao.Status = false;
                database.SaveChanges();
            }
            return RedirectToAction("LocaisVacinacao", "Home");
        }
    }
}