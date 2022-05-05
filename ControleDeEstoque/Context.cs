using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque
{
    internal class Context : DbContext
    {
        public Context() : base("BD")
        {

        }

        public DbSet<dtoUsuario> usuario { get; set; }
        public DbSet<dtoProduto> produto { get; set; }
        public DbSet<dtoVenda> venda { get; set; }

    }
}
