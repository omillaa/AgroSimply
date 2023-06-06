using AgroSimply.Data;
using AgroSimply.Models;
using AgroSimply.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AgroSimply.Repositorios
{
    public class PropriedadeRepositorio : IPropriedadeRepositorio

    {
        private readonly AgroSimplyDBcontext _dbContext;
        public PropriedadeRepositorio(AgroSimplyDBcontext propriedadeDBcontext)
        {
            _dbContext = propriedadeDBcontext;

        }
        public async Task<PropriedadeModels> BuscarPorId(int id)
        {
            return await _dbContext.Propriedade.FirstOrDefaultAsync(x => x.IdProdutor == id);
        }

        public async Task<List<PropriedadeModels>> BuscarPropriedade()
        {

            return await _dbContext.Propriedade.ToListAsync(); 
        }
        public async Task<PropriedadeModels> Adicionar(PropriedadeModels propriedade)
        {
           await _dbContext.Propriedade.AddAsync(propriedade);
          await  _dbContext.SaveChangesAsync();
            return propriedade;
        }
        public async Task<PropriedadeModels> Atualizar(PropriedadeModels propriedade, int id)
        {
            PropriedadeModels propriedadePorId = await BuscarPorId(id);
            if (propriedadePorId == null) 
            {
                throw new Exception($"Propriedade para o ID:{id} não foi encontrado no banco de dados.");
            }
            propriedadePorId.Nome = propriedade.Nome;
            propriedadePorId.Numero = propriedade.Numero;
            propriedadePorId.Cultura = propriedade.Cultura;
            propriedadePorId.Endereco   = propriedade.Endereco;
            propriedadePorId.Bairro = propriedade.Bairro;   
            propriedadePorId.Cidade = propriedade.Cidade;
            propriedadePorId.Extensão = propriedade.Extensão;
            propriedadePorId.Estado = propriedade.Estado;
            propriedadePorId.IdProdutor = propriedade.IdProdutor;   
         
               

           _dbContext.Propriedade.Update(propriedadePorId );
            await _dbContext.SaveChangesAsync();

            return propriedadePorId;   

        }
        public async Task<bool> Apagar(int id)
        {
            PropriedadeModels propriedadePorId = await BuscarPorId(id);
            if (propriedadePorId == null)
            {
                throw new Exception($"Usuário para o ID:{id} não foi encontrado no banco de dados.");
            }
            _dbContext.Propriedade.Remove(propriedadePorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        

     
    }
}
