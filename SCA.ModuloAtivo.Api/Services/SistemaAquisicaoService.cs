using Newtonsoft.Json;
using RestSharp;
using SCA.ModuloAtivo.Api.Models;
using SCA.ModuloAtivo.Api.ViewModels;
using System.Net;

namespace SCA.ModuloAtivo.Api.Services
{
    public class SistemaAquisicaoService
    {
        public ResultViewModel PostAtivo(Ativo ativo)
        {
            var urlApiSistemaAquisicao = GetValueJsonAppSettings.GetValue("APIUrls:APISistemaAquisicaoUrlBase");
            var client = new RestClient(urlApiSistemaAquisicao);
            client.Proxy = new WebProxy(urlApiSistemaAquisicao, false);
            var request = new RestRequest("v1/", Method.POST);
            request.Timeout = 300000;
            request.AddJsonBody(ativo);

            IRestResponse<ResultViewModel> response = client.Execute<ResultViewModel>(request);
            var estoqueResponse = JsonConvert.DeserializeObject<ResultViewModel>(response.Content);

            if (!estoqueResponse.Success.Equals(true))
            {
                return new ResultViewModel { Success = false, ErrorMessage = estoqueResponse.ErrorMessage }; //BaseResponseDomain<Usuario>(TipoStatusRetornoEnum.FALHA.ToString(), _notifications);
            }

            return estoqueResponse;
        }
    }
}
