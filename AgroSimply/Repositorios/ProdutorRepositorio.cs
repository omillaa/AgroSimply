﻿using AgroSimply.Data;
using AgroSimply.Models;
using AgroSimply.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;

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

        public async Task<bool> ValidarLogin(double cpf, string senha)
        {
            
            // Verificar se o CPF e a senha correspondem a um produtor válido no banco de dados
            var produtor = await _dbContext.Produtor.FirstOrDefaultAsync(p => p.CPF == cpf && p.Senha == senha );    
            
            // Se o produtor for encontrado, o login é válido
            return produtor != null;
        }

        public async Task<int> ObterIdPorCPF(double cpf)
        {
            var produtor = await _dbContext.Produtor.FirstOrDefaultAsync(p => p.CPF == cpf);
            if (produtor != null)
            {
                return produtor.IdProdutor;
            }
            return 0; // ou algum valor padrão caso não encontre o produtor
        }

    }
}
