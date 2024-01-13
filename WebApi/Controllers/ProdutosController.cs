using Domain.InterfacesExternal;
using Entities.EntitiesExternal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProduto _Iproduto;
        public ProdutosController(IProduto Iproduto)
        {
            _Iproduto = Iproduto;
        }

        [Produces("application/json")]
        [HttpPost("/api/ListProd")]
        public List<Produto> ListProd()
        {
            return _Iproduto.List();
        }

        [Produces("application/json")]
        [HttpPost("/api/GetOne")]
        public Produto GetOne(int id)
        {
            return _Iproduto.GetOne(id);
        }

        [Produces("application/json")]
        [HttpPost("/api/CreateProduct")]
        public bool CreateProduct(Produto prod)
        {
            try
            {
                _Iproduto.Create(prod);

                return true;
            }
            catch
            {

                return false;
            }
        }

        [Produces("application/json")]
        [HttpPost("/api/UpdateProduct")]
        public bool UpdateProduct(Produto prod)
        {
            try
            {
                _Iproduto.Update(prod);

                return true;
            }
            catch
            {

                return false;
            }
        }

        [Produces("application/json")]
        [HttpPost("/api/DeleteProduct")]
        public bool DeleteProduct(int codigo)
        {
            try
            {
                _Iproduto.Delete(codigo);

                return true;
            }
            catch
            {

                return false;
            }
        }
    }
}
