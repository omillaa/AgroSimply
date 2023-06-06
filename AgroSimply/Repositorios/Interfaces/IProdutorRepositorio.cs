using AgroSimply.Models;
using Microsoft.AspNetCore.Components.Web;

namespace AgroSimply.Repositorios.Interfaces
{
    public interface IProdutorRepositorio
    {
        Task<List<ProdutorModels>> BuscarProdutor();
        Task<ProdutorModels> BuscarPorId(int id);
        Task<ProdutorModels> Adicionar(ProdutorModels produtor);
        Task<ProdutorModels> Atualizar(ProdutorModels produtor, int id);
        Task<bool> Apagar(int id);
    }
}
