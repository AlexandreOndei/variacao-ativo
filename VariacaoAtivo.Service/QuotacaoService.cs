using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VariacaoAtivo.DAL;
using VariacaoAtivo.Service.Interfaces;
using VariacaoAtivo.VO;

namespace VariacaoAtivo.Service
{
    public class QuotacaoService : IQuotacaoService
    {
        private VariacaoAtivoDbContext _context;

        public QuotacaoService(VariacaoAtivoDbContext context)
        {
            _context = context;
        }

        public async Task DeleteQuotacoes()
        {
            try
            {
                _context.Quotacao.RemoveRange(_context.Quotacao);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao excluir Quotações. Mensagem: {ex.Message}");
            }
        }

        public async Task<IList<QuotacaoVO>> GetQuotacoes()
        {
            try
            {
                return await _context.Quotacao.OrderBy(q => q.Data).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao recuperar lista de Quotações. Mensagem: {ex.Message}");
            }
        }

        public async Task SaveQuotacoes(IList<QuotacaoVO> quotacoes)
        {
            try
            {
                _context.Quotacao.AddRange(quotacoes);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao inserir Quotações. Mensagem: {ex.Message}");
            }
        }
    }
}
