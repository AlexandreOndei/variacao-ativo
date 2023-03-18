using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VariacaoAtivo.Service.Interfaces;
using VariacaoAtivo.VO;

namespace VariacaoAtivo.Service
{
    public class BuscaAtivoService : IBuscaAtivoService
    {
        private const string YAHOO_FINANCE_URL = "https://query2.finance.yahoo.com";
        private const string YAHOO_FINANCE_ENDPOINT = "/v8/finance/chart/{0}?interval=1d&period1={1}&period2={2}";

        public async Task<IList<QuotacaoVO>> GetDadosAtivoAsync(string ativo, long unixPeriodoIni, long unixPeriodoFin)
        {
            try
            {
                string endpoint = string.Format(YAHOO_FINANCE_ENDPOINT, ativo, unixPeriodoIni, unixPeriodoFin);
                IRestClient client = new RestClient(YAHOO_FINANCE_URL);
                RestRequest request = new RestRequest(endpoint);
                RestResponse response = await client.ExecuteGetAsync(request);

                return await Task.Run(() =>
                {
                    IList<QuotacaoVO> quotacoes = new List<QuotacaoVO>();
                    JObject properties = Newtonsoft.Json.JsonConvert.DeserializeObject<JObject>(response.Content);

                    int[] datasArray = properties["chart"]["result"][0]["timestamp"].ToObject<int[]>();
                    DateTime[] datas = datasArray.Select(d => DateTimeOffset.FromUnixTimeSeconds(d).DateTime)
                        .Skip(datasArray.Length - 30)
                        .ToArray();

                    double[] valores = properties["chart"]["result"][0]["indicators"]["quote"][0]["open"].ToObject<string[]>()
                        .Select(v => Convert.ToDouble(v, new CultureInfo("en-US")))
                        .ToArray();
                    valores = valores.Skip(valores.Length - 30).ToArray();

                    double primeiroValor = valores.FirstOrDefault();
                    for (int i = 0; i < datas.Length; i++)
                    {
                        QuotacaoVO quotacao = new QuotacaoVO
                        {
                            Data = datas[i],
                            Valor = valores[i],
                            VariacaoD1 = valores[i] != 0 ?
                                i == 0 ? 0 : ((valores[i] - valores[i - 1]) * 100) / valores[i]:
                                -100,
                            VariacaoPrimeiraData = valores[i] != 0 ?
                                i == 0 ? 0 : ((valores[i] - primeiroValor) * 100) / valores[i] :
                                -100
                        };
                        quotacoes.Add(quotacao);
                    }

                    return quotacoes;
                });
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao recuperar dados do ativo '{ativo}': Mensagem: {ex.Message}");
            }
        }
    }
}
