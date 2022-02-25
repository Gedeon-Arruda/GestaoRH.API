using GestaoRH.Servicos;
using Microsoft.EntityFrameworkCore;

namespace GestaoRH.Infraestrutura
{
    public class DbFuncionarioContexto : DbContext
    {
        public DbFuncionarioContexto(DbContextOptions<DbFuncionarioContexto> options) : base(options)
        {

        }

        public DbSet<Funcionario> Funcionarios { get; set; }
    }
}
