using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using vacinacao.Models;
using vacinacao.Data;
using vacinacao.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace vacinacao.Controllers
{   
    [Authorize]
    public class HomeController : Controller
    {   
        private readonly ApplicationDbContext database;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext database)
        {   
            this.database = database;
            _logger = logger;
        }

        public IActionResult Index()
        {   
            var vacinacoes = database.Vacinacoes
                .Include(v => v.Pessoa)
                .Include(v => v.LoteVacina)
                .Include(v => v.LocalDeVacinacao)
                .Where(v => v.Dose == 1 && v.Status == true);
            
            return View(vacinacoes);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //Endereços
        public IActionResult Enderecos() {
            var enderecos = database.Enderecos.Where(e => e.Status == true).ToList();
            return View(enderecos);
        }

        public IActionResult NovoEndereco() {
            return View();
        }

        public IActionResult EditarEndereco(int id) {
            var endereco = database.Enderecos.First(e => e.Id == id);
            EnderecoDTO enderecoDTO = new EnderecoDTO();
            enderecoDTO.Id = endereco.Id;
            enderecoDTO.Cep = endereco.Cep; 
            enderecoDTO.Logradouro = endereco.Logradouro;
            enderecoDTO.Numero = endereco.Numero;
            enderecoDTO.Complemento = endereco.Complemento;
            enderecoDTO.Municipio = endereco.Municipio;
            enderecoDTO.Estado = endereco.Estado;
            return View(enderecoDTO); 
        }

        //Pessoas
        public IActionResult Pessoas() {
            var pessoas = database.Pessoas.Include(p => p.Endereco).Where(p => p.Status == true).ToList();
            return View(pessoas);
        }

        public IActionResult NovaPessoa() {
            ViewBag.Enderecos = database.Enderecos.ToList();
            return View();
        }

        public IActionResult EditarPessoa(int id) {
            var pessoa = database.Pessoas.Include(p => p.Endereco).First(p => p.Id == id);
            PessoaDTO pessoaDTO = new PessoaDTO();
            pessoaDTO.Id = pessoa.Id;
            pessoaDTO.Cpf = pessoa.Cpf;
            pessoaDTO.NomeCompleto = pessoa.NomeCompleto;
            pessoaDTO.DataDeNascimento = pessoa.DataDeNascimento;
            pessoaDTO.EnderecoId = pessoa.Endereco.Id;
            ViewBag.Enderecos = database.Enderecos.ToList();
            return View(pessoaDTO);
        }
        
        //Locais de vacinação
        public IActionResult LocaisVacinacao() {
            var locaisDeVacinacao = database.LocaisDeVacinacao.Include(l => l.Endereco).Where(l => l.Status == true).ToList(); 
            return View(locaisDeVacinacao);
        }

        public IActionResult NovoLocalDeVacinacao() {
            ViewBag.Enderecos = database.Enderecos.ToList();
            return View();
        }

        public IActionResult EditarLocalDeVacinacao(int id) {
            var localDeVacinacao = database.LocaisDeVacinacao.Include(l => l.Endereco).First(l => l.Id == id);
            LocalDeVacinacaoDTO localDeVacinacaoDTO = new LocalDeVacinacaoDTO();
            localDeVacinacaoDTO.Id = localDeVacinacao.Id;
            localDeVacinacaoDTO.Nome = localDeVacinacao.Nome;
            localDeVacinacaoDTO.EnderecoId = localDeVacinacao.Endereco.Id;
            ViewBag.Enderecos = database.Enderecos.ToList();
            return View(localDeVacinacaoDTO);
        }

        //Vacinas
        public IActionResult Vacinas() {
            var vacinas = database.Vacinas.Where(v => v.Status == true).ToList();
            return View(vacinas);
        }

        public IActionResult NovaVacina() {
            return View();
        }

        public IActionResult EditarVacina(int id) {
            var vacina = database.Vacinas.First(v => v.Id == id);
            VacinaDTO vacinaDTO = new VacinaDTO();
            vacinaDTO.Id = vacina.Id;
            vacinaDTO.Nome = vacina.Nome;
            vacinaDTO.Laboratorio = vacina.Laboratorio;
            vacinaDTO.Posologia = vacina.Posologia;
            vacinaDTO.IntervaloEntreDoses = vacina.IntervaloEntreDoses;
            return View(vacinaDTO);
        }

        //Lotes de vacinas
        public IActionResult LotesVacinas() {
            var lotesVacinas = database.LotesVacinas.Include(l => l.Vacina).Where(l => l.Status == true).ToList();
            return View(lotesVacinas);
        }
        
        public IActionResult LotesParaVencer() {
            

            var lotesVacinas = database.LotesVacinas
                .Include(l => l.Vacina)
                .AsEnumerable()
                .Where(l => l.Status == true && (DateTime.Now.Subtract(l.DataDeValidade).Days < 30)).ToList();
            return View(lotesVacinas);
        }

        public IActionResult NovoLoteVacina() {
            ViewBag.Vacinas = database.Vacinas.ToList();
            return View();
        }

        public IActionResult EditarLoteVacina(int id) {
            var loteVacina = database.LotesVacinas.Include(l => l.Vacina).First(l => l.Id == id);
            LoteVacinaDTO loteVacinaDTO = new LoteVacinaDTO();
            loteVacinaDTO.Id = loteVacina.Id;
            loteVacinaDTO.VacinaId = loteVacina.Vacina.Id;
            loteVacinaDTO.IdentificacaoDoLote = loteVacina.IdentificacaoDoLote;
            loteVacinaDTO.QuantidadeRecebida = loteVacina.QuantidadeRecebida;
            loteVacinaDTO.QuantidadeRestante = loteVacina.QuantidadeRestante;
            loteVacinaDTO.DataDeRecebimento = loteVacina.DataDeRecebimento;
            loteVacinaDTO.DataDeValidade = loteVacina.DataDeValidade;
            ViewBag.Vacinas = database.Vacinas.ToList();
            return View(loteVacinaDTO);
            
        }

        //Vacinações
        public IActionResult Vacinacoes() {
            var vacinacoes = database.Vacinacoes
                .Include(v => v.Pessoa)
                .Include(v => v.LoteVacina)
                .Include(v => v.LocalDeVacinacao)
                .Where(v => v.Status == true /*&& v.LoteVacina.QuantidadeRestante != 0 && v.LoteVacina.DataDeValidade > DateTime.Today*/)
                .ToList();
            
            return View(vacinacoes);
        }

        public IActionResult NovaVacinacao() {

            ViewBag.Pessoas = database.Pessoas.Where(p => p.StatusVacinacao == false).ToList();
            ViewBag.LotesVacinas = database.LotesVacinas.Where(l => l.QuantidadeRestante != 0 && l.DataDeValidade > DateTime.Today && l.Status == true).ToList();
            ViewBag.LocaisDeVacinacao = database.LocaisDeVacinacao.ToList();
            //ViewBag.Vacinacoes = database.Vacinacoes.ToList();
            //Vamo ver no que dá
            return View();
        }

        public IActionResult EditarVacinacao(int id) {
            var vacinacao = database.Vacinacoes
            .Include(v => v.Pessoa)
            .Include(v => v.LoteVacina)
            .Include(v => v.LocalDeVacinacao)
            .First(v => v.Id == id);

            VacinacaoDTO vacinacaoDTO = new VacinacaoDTO();
            vacinacaoDTO.Id = vacinacao.Id;
            vacinacaoDTO.Data = vacinacao.Data;
            vacinacaoDTO.PessoaId = vacinacao.Pessoa.Id;
            vacinacaoDTO.LoteVacinaId = vacinacao.LoteVacina.Id;
            vacinacaoDTO.LocalDeVacinacaoId = vacinacao.LocalDeVacinacao.Id;
            vacinacaoDTO.Dose = vacinacao.Dose;
            ViewBag.Pessoas = database.Pessoas.ToList();
            //Todos os ids serão maior que zero, mas somente preucação
            if (vacinacaoDTO.LoteVacinaId > 0) {
                ViewBag.LotesVacinas = database.LotesVacinas.Where(l => l.IdentificacaoDoLote == vacinacao.LoteVacina.IdentificacaoDoLote).ToList();
            } else {
                ViewBag.LotesVacinas = database.LotesVacinas.ToList();
            }
            ViewBag.LocaisDeVacinacao = database.LocaisDeVacinacao.ToList();
            return View(vacinacaoDTO);
        }

        //Pessoas que ainda precisam tomar a segunda dose
       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
