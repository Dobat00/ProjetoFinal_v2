using Microsoft.EntityFrameworkCore;
using ProjetoFinal_v2.Models;

namespace ProjetoFinal_v2.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }
        public DbSet<Cliente> Clientes { get; set; }
    }

}
