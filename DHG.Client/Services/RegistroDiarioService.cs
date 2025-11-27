using DHG.Client.Models;
using DHG.Client.ViewModel;
using System.Net.Http.Json;

namespace DHG.Client.Services
{
    public class RegistroDiarioService
    {

        private readonly HttpClient _httpClient;
        private const string ApiUrl = "https://localhost:44363/api/registrodiario"; 
        
        public RegistroDiarioService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        //**********************************************************************************
        //**********************************************************************************
        
        public async Task<List<RegistroDiarioViewModel>?> ObterTodosRegistrosAsync()
        {
            try
            {               
                var registros = await _httpClient.GetFromJsonAsync<List<RegistroDiarioViewModel>>(ApiUrl);

                return registros;
            }
            catch (HttpRequestException ex)
            {               
                Console.WriteLine($"Erro ao buscar registros: {ex.Message}");
                return new List<RegistroDiarioViewModel>();
            }
        
        }

        //**********************************************************************************
        //**********************************************************************************

        public async Task<HttpResponseMessage> AdicionarRegistroAPIAsync(RegistroDiarioViewModel registro)
        {           
            var response = await _httpClient.PostAsJsonAsync(ApiUrl, registro);
            return response;
        }

        //**********************************************************************************
        //**********************************************************************************

        public async Task<HttpResponseMessage> AtualizarRegistroAPIAsync(RegistroDiarioViewModel registro)
        {           
            var response = await _httpClient.PutAsJsonAsync($"{ApiUrl}/{registro.Id}", registro);

            return response;
        }

        //**********************************************************************************
        //**********************************************************************************

        public async Task<HttpResponseMessage> RemoverRegistroAPIAsync(int id)
        {       
            var response = await _httpClient.DeleteAsync($"{ApiUrl}/{id}");

            return response;
        }


    }

}
