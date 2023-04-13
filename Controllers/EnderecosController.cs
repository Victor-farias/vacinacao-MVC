using Microsoft.AspNetCore.Mvc;
using vacinacao.Data;
using vacinacao.DTO;
using vacinacao.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace vacinacao.Controllers
{   
    [Authorize]
    public class EnderecosController : Controller
    {
        private readonly ApplicationDbContext database;
        public EnderecosController(ApplicationDbContext database)
        {   
            this.database = database;
        }

        [HttpPost]
        public IActionResult Salvar(EnderecoDTO enderecoDTO) {
            if (ModelState.IsValid) {
                Endereco endereco = new Endereco();
                endereco.Id = enderecoDTO.Id;
                endereco.Cep = enderecoDTO.Cep;
                endereco.Logradouro = enderecoDTO.Logradouro;
                endereco.Numero = enderecoDTO.Numero;
                endereco.Complemento = enderecoDTO.Complemento;
                endereco.Municipio = enderecoDTO.Municipio;
                endereco.Estado = enderecoDTO.Estado.ToUpper();
                endereco.Status = true;
                database.Enderecos.Add(endereco);
                database.SaveChanges();
                return RedirectToAction("Enderecos", "Home");
            } else {
                return View("../Home/NovoEndereco");
            }
        }

        [HttpPost]
        public IActionResult Atualizar(EnderecoDTO enderecoDTO) {
            if (ModelState.IsValid) {
            var endereco = database.Enderecos.First(e => e.Id == enderecoDTO.Id);
            endereco.Cep = enderecoDTO.Cep;
            endereco.Logradouro = enderecoDTO.Logradouro;
            endereco.Numero = enderecoDTO.Numero;
            endereco.Complemento = enderecoDTO.Complemento;
            endereco.Municipio = enderecoDTO.Municipio;
            endereco.Estado = enderecoDTO.Estado;
            database.SaveChanges();
            return RedirectToAction("Enderecos", "Home");
            } else {
                return RedirectToAction("Enderecos", "Home");
            }
        }

        [HttpPost]
        public IActionResult Deletar(int id) {
            if (id > 0) {
                var endereco = database.Enderecos.First(e => e.Id == id);
                endereco.Status = false;
                database.SaveChanges();
            }
            return RedirectToAction("Enderecos", "Home");
        }
    }
}