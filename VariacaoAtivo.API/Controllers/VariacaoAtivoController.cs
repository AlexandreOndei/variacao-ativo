using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using VariacaoAtivo.Service.Interfaces;
using VariacaoAtivo.VO;

namespace VariacaoAtivo.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VariacaoAtivoController : ControllerBase
    {
        private IBuscaAtivoService _buscaAtivoService;
        private IQuotacaoService _quotacaoService;
        private readonly AppSettings _appSettings;

        public VariacaoAtivoController(IBuscaAtivoService buscaAtivoService, IQuotacaoService quotacaoService, IOptions<AppSettings> appSettings)
        {
            _buscaAtivoService = buscaAtivoService;
            _quotacaoService = quotacaoService;
            _appSettings = appSettings.Value;
        }

        /// <summary>
        /// Consultar Variações do Ativo dos últimos 30 dias.
        /// </summary>
        /// <returns>Lista de Ativos.</returns>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            ResponseMessageVO response = new ResponseMessageVO();

            try
            {
                IList<QuotacaoVO> quotacoes = await _quotacaoService.GetQuotacoes();
                CultureInfo enUS = new CultureInfo("en-US");
                return Ok(quotacoes.Select(q =>
                {
                    return new
                    {
                        Data = q.Data.ToString("MM/dd/yyyy", enUS),
                        Valor = q.Valor.ToString("C", enUS),
                        VariacaoD1 = q.VariacaoD1 == 0 ? "-" : $"{q.VariacaoD1.ToString("#,0.00", enUS)} %",
                        VariacaoPrimeiraData = q.VariacaoPrimeiraData == 0 ? "-" : $"{q.VariacaoPrimeiraData.ToString("#,0.00", enUS)} %"
                    };
                }).ToList());
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
                return BadRequest(response);
            }
        }

        /// <summary>
        /// Atualizar Lista de Variações do Ativo.
        /// </summary>
        /// <returns></returns>
        [HttpPost("update")]
        public async Task<ResponseMessageVO> Post()
        {
            ResponseMessageVO response = new ResponseMessageVO();
            
            string ativo = _appSettings.Ativo;
            long unixPeriodoIni = new DateTimeOffset(DateTime.Now.AddDays(-30)).ToUnixTimeSeconds();
            long unixPeriodoFin = new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds();

            try
            {
                IList<QuotacaoVO> quotacoes = await _buscaAtivoService.GetDadosAtivoAsync(ativo, unixPeriodoIni, unixPeriodoFin);
                await _quotacaoService.DeleteQuotacoes();
                await _quotacaoService.SaveQuotacoes(quotacoes);

                response.Message = "Quotações atualizadas com sucesso.";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }
    }
}
