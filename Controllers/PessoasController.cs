using Microsoft.AspNetCore.Mvc;
using vacinacao.Data;
using vacinacao.DTO;
using vacinacao.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace vacinacao.Controllers
{   
    [Authorize]
    public class PessoasController : Controller
    {   
        private readonly ApplicationDbContext database;
        public PessoasController(ApplicationDbContext database)
        {   
            this.database = database;
        }

        [HttpPost]
        public IActionResult Salvar(PessoaDTO pessoaDTO) {
            if (ModelState.IsValid) {
            Pessoa pessoa = new Pessoa();
            pessoa.Id = pessoaDTO.Id;
            pessoa.Cpf = pessoaDTO.Cpf;
            pessoa.NomeCompleto = pessoaDTO.NomeCompleto;
            pessoa.DataDeNascimento = pessoaDTO.DataDeNascimento.Date;
            pessoa.Endereco = database.Enderecos.First(e => e.Id == pessoaDTO.EnderecoId);
            pessoa.Status = true;
            pessoa.StatusVacinacao = false;
            database.Pessoas.Add(pessoa);
            database.SaveChanges();
            return RedirectToAction("Pessoas", "Home");
            } else {
                ViewBag.Enderecos = database.Enderecos.ToList();
                return View("../Home/NovaPessoa");
            }
        }

        public IActionResult Atualizar(PessoaDTO pessoaDTO) {
            if (ModelState.IsValid) {
                var pessoa = database.Pessoas.First(p => p.Id == pessoaDTO.Id);
                pessoa.Cpf = pessoaDTO.Cpf;
                pessoa.NomeCompleto = pessoaDTO.NomeCompleto;
                pessoa.DataDeNascimento = pessoaDTO.DataDeNascimento;
                pessoa.Endereco = database.Enderecos.First(e => e.Id == pessoaDTO.EnderecoId);
                database.SaveChanges();
                return RedirectToAction("Pessoas", "Home");
            } else {
                return RedirectToAction("Pessoas", "Home");
            }
        }

        public IActionResult Deletar(int id) {
            if (id > 0) {
                var pessoa = database.Pessoas.First(p => p.Id == id);
                pessoa.Status = false;
                database.SaveChanges();
            }
            return RedirectToAction ("Pessoas", "Home");
        } 
    }   
}