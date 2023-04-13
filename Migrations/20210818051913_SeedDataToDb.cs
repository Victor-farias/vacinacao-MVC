using Microsoft.EntityFrameworkCore.Migrations;

namespace vacinacao.Migrations
{
    public partial class SeedDataToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Endereços
            migrationBuilder.Sql($"INSERT INTO `vacinacao`.`enderecos` (`Id`, `Cep`, `Logradouro`, `Numero`, `Complemento`, `Municipio`, `Estado`, `Status`) VALUES ('1', '42434200', 'fdsfsdf', '32', 'fsdfsf', 'dsfsf', 'tr', '1');");
            migrationBuilder.Sql($"INSERT INTO `vacinacao`.`enderecos` (`Id`, `Cep`, `Logradouro`, `Numero`, `Complemento`, `Municipio`, `Estado`, `Status`) VALUES ('2', '79902156', 'Travessa Panambí', '57', 'dsada', 'Ponta Porã', 'MS', '1');");
            migrationBuilder.Sql($"INSERT INTO `vacinacao`.`enderecos` (`Id`, `Cep`, `Logradouro`, `Numero`, `Complemento`, `Municipio`, `Estado`, `Status`) VALUES ('3', '87115040', 'Rua Vale Azul', '43', 'sadada', 'Sarandi', 'PR', '1');");
            migrationBuilder.Sql($"INSERT INTO `vacinacao`.`enderecos` (`Id`, `Cep`, `Logradouro`, `Numero`, `Complemento`, `Municipio`, `Estado`, `Status`) VALUES ('4', '33933660', 'Rua Antônio Zacarias dos Anjos', '43', 'sadada', 'Ribeirão das Neves', 'MG', '1');");
            migrationBuilder.Sql($"INSERT INTO `vacinacao`.`enderecos` (`Id`, `Cep`, `Logradouro`, `Numero`, `Complemento`, `Municipio`, `Estado`, `Status`) VALUES ('5', '69906622', 'Rua Praia do Iaco', '76', 'sadadaas', 'Rio Branco', 'AC', '1');");

            //Pessoas
            migrationBuilder.Sql($"INSERT INTO `vacinacao`.`pessoas` (`Id`, `Cpf`, `NomeCompleto`, `DataDeNascimento`, `EnderecoId`, `Status`, `StatusVacinacao`) VALUES ('1', '57439828054', 'Victor Farias', '1998-12-31', '1', '1', '1');");
            migrationBuilder.Sql($"INSERT INTO `vacinacao`.`pessoas` (`Id`, `Cpf`, `NomeCompleto`, `DataDeNascimento`, `EnderecoId`, `Status`, `StatusVacinacao`) VALUES ('2', '91522627073', 'Fábio José', '1965-04-25', '2', '1', '1');");
            migrationBuilder.Sql($"INSERT INTO `vacinacao`.`pessoas` (`Id`, `Cpf`, `NomeCompleto`, `DataDeNascimento`, `EnderecoId`, `Status`, `StatusVacinacao`) VALUES ('3', '33451351080', 'Augusto', '1990-01-01', '3', '1', '0');");
            migrationBuilder.Sql($"INSERT INTO `vacinacao`.`pessoas` (`Id`, `Cpf`, `NomeCompleto`, `DataDeNascimento`, `EnderecoId`, `Status`, `StatusVacinacao`) VALUES ('4', '44102113070', 'Jorge Augusto', '1980-07-23', '4', '1', '0');");

            //Locais de vacinação
            migrationBuilder.Sql($"INSERT INTO `vacinacao`.`locaisdevacinacao` (`Id`, `Nome`, `EnderecoId`, `Status`) VALUES ('1', 'Hospital da vacina', '1', '1');");
            migrationBuilder.Sql($"INSERT INTO `vacinacao`.`locaisdevacinacao` (`Id`, `Nome`, `EnderecoId`, `Status`) VALUES ('2', 'Posto de vacinação', '4', '1');");
            migrationBuilder.Sql($"INSERT INTO `vacinacao`.`locaisdevacinacao` (`Id`, `Nome`, `EnderecoId`, `Status`) VALUES ('3', 'Hospital dos guerreiros', '2', '1');");
            migrationBuilder.Sql($"INSERT INTO `vacinacao`.`locaisdevacinacao` (`Id`, `Nome`, `EnderecoId`, `Status`) VALUES ('4', 'Posto de vacinação covid', '5', '1');");

            //Vacina
            migrationBuilder.Sql($"INSERT INTO `vacinacao`.`vacinas` (`Id`, `Nome`, `Laboratorio`, `Posologia`, `IntervaloEntreDoses`, `Status`) VALUES ('1', 'Pfizer', 'Labortório pfizer', '2', '60', '1');");
            migrationBuilder.Sql($"INSERT INTO `vacinacao`.`vacinas` (`Id`, `Nome`, `Laboratorio`, `Posologia`, `IntervaloEntreDoses`, `Status`) VALUES ('2', 'Janssen', 'Jonhson', '1', '0', '1');");
            migrationBuilder.Sql($"INSERT INTO `vacinacao`.`vacinas` (`Id`, `Nome`, `Laboratorio`, `Posologia`, `IntervaloEntreDoses`, `Status`) VALUES ('3', 'Astrazênica', 'Oxford', '2', '65', '1');");
            migrationBuilder.Sql($"INSERT INTO `vacinacao`.`vacinas` (`Id`, `Nome`, `Laboratorio`, `Posologia`, `IntervaloEntreDoses`, `Status`) VALUES ('4', 'Covac', 'Butantan', '2', '67', '1');");
        
            //Lote vacina
            migrationBuilder.Sql($"INSERT INTO `vacinacao`.`lotesvacinas` (`Id`, `VacinaId`, `IdentificacaoDoLote`, `QuantidadeRecebida`, `QuantidadeRestante`, `DataDeRecebimento`, `DataDeValidade`, `Status`) VALUES ('1', '1', 'Lote para vencer', '1000', '500', '2021-08-01', '2021-08-26', '1');");
            migrationBuilder.Sql($"INSERT INTO `vacinacao`.`lotesvacinas` (`Id`, `VacinaId`, `IdentificacaoDoLote`, `QuantidadeRecebida`, `QuantidadeRestante`, `DataDeRecebimento`, `DataDeValidade`, `Status`) VALUES ('2', '2', 'Lote para vencer2', '1500', '1000', '2021-08-01', '2021-08-26', '1');");
            migrationBuilder.Sql($"INSERT INTO `vacinacao`.`lotesvacinas` (`Id`, `VacinaId`, `IdentificacaoDoLote`, `QuantidadeRecebida`, `QuantidadeRestante`, `DataDeRecebimento`, `DataDeValidade`, `Status`) VALUES ('3', '3', 'Lote 1', '1200', '200', '2021-08-01', '2021-12-26', '1');");
            migrationBuilder.Sql($"INSERT INTO `vacinacao`.`lotesvacinas` (`Id`, `VacinaId`, `IdentificacaoDoLote`, `QuantidadeRecebida`, `QuantidadeRestante`, `DataDeRecebimento`, `DataDeValidade`, `Status`) VALUES ('4', '4', 'Lote 2', '1700', '700', '2021-08-01', '2021-12-26', '1');");
            migrationBuilder.Sql($"INSERT INTO `vacinacao`.`lotesvacinas` (`Id`, `VacinaId`, `IdentificacaoDoLote`, `QuantidadeRecebida`, `QuantidadeRestante`, `DataDeRecebimento`, `DataDeValidade`, `Status`) VALUES ('5', '1', 'Lote 3', '1300', '300', '2021-08-30', '2021-12-26', '1');");
            
            //Vacinação
            migrationBuilder.Sql($"INSERT INTO `vacinacao`.`vacinacoes` (`Id`, `Data`, `PessoaId`, `LoteVacinaId`, `LocalDeVacinacaoId`, `Dose`, `Status`) VALUES ('1', '2021-08-17', '1', '2', '1', '11', '1');");
            migrationBuilder.Sql($"INSERT INTO `vacinacao`.`vacinacoes` (`Id`, `Data`, `PessoaId`, `LoteVacinaId`, `LocalDeVacinacaoId`, `Dose`, `Status`) VALUES ('2', '2021-08-17', '2', '1', '2', '1', '1');");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
