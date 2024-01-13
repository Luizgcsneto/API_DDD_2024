using Domain.InterfacesExternal;
using Entities.EntitiesExternal;
using Newtonsoft.Json;
using System.Text;


namespace Infrastructure.RepositoryExternal
{
    public class RepositoryProduto : IProduto
    {
        private readonly string urlApi = "http://localhost:4200";
        public RepositoryProduto()
        {

        }
        public Produto Create(Produto produto)
        {
            var produtoCriado = new Produto();
            try
            {
                using (var client = new HttpClient())
                {
                    string jsonObjeto = JsonConvert.SerializeObject(produto);
                    var content = new StringContent(jsonObjeto, Encoding.UTF8, "application/json");

                    var response = client.PostAsync(urlApi + "Create", content);
                    response.Wait();
                    if (response.Result.IsSuccessStatusCode)
                    {
                        var retorno = response.Result.Content.ReadAsStringAsync();
                        produtoCriado = JsonConvert.DeserializeObject<Produto>(retorno.Result);
                    }
                    return produtoCriado;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Produto Delete(int codigo)
        {
            var produtoCriado = new Produto();
            produtoCriado.Codigo = codigo;
            try
            {
                using (var client = new HttpClient())
                {
                    string jsonObjeto = JsonConvert.SerializeObject(produtoCriado);
                    var content = new StringContent(jsonObjeto, Encoding.UTF8, "application/json");

                    var response = client.PostAsync(urlApi + "Delete", content);
                    response.Wait();
                    if (response.Result.IsSuccessStatusCode)
                    {
                        var retorno = response.Result.Content.ReadAsStringAsync();
                        produtoCriado = JsonConvert.DeserializeObject<Produto>(retorno.Result);
                    }
                    return produtoCriado;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Produto GetOne(int codigo)
        {
            var produtoCriado = new Produto();
            produtoCriado.Codigo = codigo;
            try
            {
                using (var client = new HttpClient())
                {
                    string jsonObjeto = JsonConvert.SerializeObject(produtoCriado);
                    var content = new StringContent(jsonObjeto, Encoding.UTF8, "application/json");

                    var response = client.PostAsync(urlApi + "GetOne", content);
                    response.Wait();
                    if (response.Result.IsSuccessStatusCode)
                    {
                        var retorno = response.Result.Content.ReadAsStringAsync();
                        produtoCriado = JsonConvert.DeserializeObject<Produto>(retorno.Result);
                    }
                    return produtoCriado;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Produto> List()
        {
            var retorno = new List<Produto>();
            try
            {
                using (var client = new HttpClient())
                {
                    var resposta = client.GetStringAsync(urlApi + "List");
                    resposta.Wait();
                    retorno = JsonConvert.DeserializeObject<Produto[]>(resposta.Result).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return retorno;
        }

        public Produto Update(Produto produto)
        {
            var produtoCriado = new Produto();
            try
            {
                using (var client = new HttpClient())
                {
                    string jsonObjeto = JsonConvert.SerializeObject(produto);
                    var content = new StringContent(jsonObjeto, Encoding.UTF8, "application/json");

                    var response = client.PostAsync(urlApi + "Update", content);
                    response.Wait();
                    if (response.Result.IsSuccessStatusCode)
                    {
                        var retorno = response.Result.Content.ReadAsStringAsync();
                        produtoCriado = JsonConvert.DeserializeObject<Produto>(retorno.Result);
                    }
                    return produtoCriado;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
