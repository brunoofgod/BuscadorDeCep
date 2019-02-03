using ConsultarCep.Models;
using Newtonsoft.Json;
using System;
using System.Net;

namespace ConsultarCep.Services
{
    public class ViaCepServices : IDisposable
    {
        private static readonly string EnderecoURL = "http://viacep.com.br/ws/{0}/json";

        public Endereco BuscarEndereco(string cep)
        {
            var enderecoUrl = string.Format(EnderecoURL, cep);

            var wc = new WebClient();
            var endereco = JsonConvert.DeserializeObject<Endereco>(wc.DownloadString(enderecoUrl));
            if (endereco.Cep == null) return null;

            return endereco;
        }

        public void Dispose()
        {
        }
    }
}