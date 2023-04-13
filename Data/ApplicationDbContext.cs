using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using vacinacao.Models;


namespace vacinacao.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {   
        public DbSet<Endereco> Enderecos {get; set;}
        public DbSet<Pessoa> Pessoas {get; set;}
        public DbSet<Vacina> Vacinas {get; set;}
        public DbSet<LoteVacina> LotesVacinas {get; set;}
        public DbSet<LocalDeVacinacao> LocaisDeVacinacao {get; set;}
        public DbSet<Vacinacao> Vacinacoes {get; set;}

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
