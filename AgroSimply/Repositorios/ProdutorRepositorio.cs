using AgroSimply.Data;
using AgroSimply.Models;
using AgroSimply.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AgroSimply.Repositorios
{
    public class ProdutorRepositorio : IProdutorRepositorio

    {
        private readonly AgroSimplyDBcontext _dbContext;
        public ProdutorRepositorio(AgroSimplyDBcontext produtorDBcontext)
        {
            _dbContext = produtorDBcontext;

        }
        public async Task<ProdutorModels> BuscarPorId(int id)
        {
            return await _dbContext.Produtor.FirstOrDefaultAsync(x => x.IdProdutor == id);
        }

        public async Task<List<ProdutorModels>> BuscarProdutor()
        {

            return await _dbContext.Produtor.ToListAsync(); 
        }
        public async Task<ProdutorModels> Adicionar(ProdutorModels produtor)
        {
           await _dbContext.Produtor.AddAsync(produtor);
           await  _dbContext.SaveChangesAsync();
            return produtor;
        }
        public async Task<ProdutorModels> Atualizar(ProdutorModels produtor, int id)
        { 
           ProdutorModels produtorPorId = await BuscarPorId(id);
            if (produtorPorId == null) 
            {
                throw new Exception($"Usuário para o ID:{id} não foi encontrado no banco de dados.");
            }
            produtorPorId.Nome = produtor.Nome;
            produtorPorId.Email = produtor.Email;   
            produtorPorId.Atividade = produtor.Atividade;   
            produtorPorId.Telefone = produtor.Telefone; 
            produtorPorId.CPF = produtor.CPF;   
            produtorPorId.CNPJ = produtor.CNPJ; 
            produtorPorId.Senha = produtor.Senha;   

            _dbContext.Produtor.Update(produtorPorId );
            await _dbContext.SaveChangesAsync();
            return produtorPorId;   

        }
        public async Task<bool> Apagar(int id)
        {
            ProdutorModels produtorPorId = await BuscarPorId(id);
            if (produtorPorId == null)
            {
                throw new Exception($"Usuário para o ID:{id} não foi encontrado no banco de dados.");
            }
            _dbContext.Produtor.Remove(produtorPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        

     
    }
}
