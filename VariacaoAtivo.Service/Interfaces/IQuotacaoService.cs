using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VariacaoAtivo.VO;

namespace VariacaoAtivo.Service.Interfaces
{
    public interface IQuotacaoService
    {
        Task<IList<QuotacaoVO>> GetQuotacoes();
        Task SaveQuotacoes(IList<QuotacaoVO> quotacoes);
        Task DeleteQuotacoes();
    }
}
