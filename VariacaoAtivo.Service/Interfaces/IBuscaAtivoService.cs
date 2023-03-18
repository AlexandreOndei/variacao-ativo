using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VariacaoAtivo.VO;

namespace VariacaoAtivo.Service.Interfaces
{
    public interface IBuscaAtivoService
    {
        Task<IList<QuotacaoVO>> GetDadosAtivoAsync(string ativo, long unixPeriodoIni, long unixPeriodoFin);
    }
}
