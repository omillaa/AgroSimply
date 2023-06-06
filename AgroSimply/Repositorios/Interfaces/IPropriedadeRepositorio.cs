using AgroSimply.Models;
using Microsoft.AspNetCore.Components.Web;

namespace AgroSimply.Repositorios.Interfaces
{
    public interface IPropriedadeRepositorio
    {
        Task<List<PropriedadeModels>> BuscarPropriedade();
        Task<PropriedadeModels> BuscarPorId(int id);
        Task<PropriedadeModels> Adicionar(PropriedadeModels propriedade);
        Task<PropriedadeModels> Atualizar(PropriedadeModels propriedade, int id);
        Task<bool> Apagar(int id);
    }
}
