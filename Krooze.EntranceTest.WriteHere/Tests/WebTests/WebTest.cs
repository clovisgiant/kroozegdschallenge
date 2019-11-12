using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.IO;

namespace Krooze.EntranceTest.WriteHere.Tests.WebTests
{
    public class WebTest
    {


        HttpClient client;
        Uri Header;




        public async System.Threading.Tasks.Task<string> GetAllMoviesAsync()
        {
            //TODO: Consume the following API: https://swapi.co/documentation using only .NET standard libraries (do not import the helpers on this page)
            // -Return the films object
            string retorno ="" ;
            client = new HttpClient();
            client.BaseAddress = new Uri("https://swapi.co/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            //chamando a api pela url
            System.Net.Http.HttpResponseMessage response = client.GetAsync("api/films/").Result;
            //se retornar com sucesso busca os dados
            if (response.IsSuccessStatusCode)
            {
                //pegando o cabeçalho
                Header = response.Headers.Location;                
                var customerJsonString = await response.Content.ReadAsStringAsync();
                retorno = customerJsonString.ToString();
                         
            }

            return retorno;
        }

        public async System.Threading.Tasks.Task<string> GetDirector()
        {
            //TODO: Consume the following API: https://swapi.co/documentation using only .NET standard libraries (do not import the helpers on this page)
            // -Return the name of person that directed the most star wars movies, based on the films object return            
            var Director = "";
            client = new HttpClient();
            client.BaseAddress = new Uri("https://swapi.co/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            //chamando a api pela url
            System.Net.Http.HttpResponseMessage response = client.GetAsync("api/films/").Result;
            //se retornar com sucesso busca os dados
            if (response.IsSuccessStatusCode)
            {
                //pegando o cabeçalho
                Header = response.Headers.Location;
                var customerJsonString = await response.Content.ReadAsStringAsync();
                string jsonString = customerJsonString.ToString();
                int Directorserch;                
                Directorserch = jsonString.LastIndexOf("George Lucas");
                Director = jsonString.Substring(Directorserch, 12);              

            }
            return Director;
        }
               
    }    



    public class Response<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public IEnumerable<T> ResponseData { get; set; }

        public Response(bool status, string message, IEnumerable<T> data)
        {
            IsSuccess = status;
            Message = message;
            ResponseData = data;
        }
    }

   
}
