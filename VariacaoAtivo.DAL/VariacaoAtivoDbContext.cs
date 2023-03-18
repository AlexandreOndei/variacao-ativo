using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using VariacaoAtivo.VO;

namespace VariacaoAtivo.DAL
{
    public class VariacaoAtivoDbContext : DbContext
    {
        public VariacaoAtivoDbContext(DbContextOptions options) : base(options) { }

        public DbSet<QuotacaoVO> Quotacao { get; set; }
    }
}
