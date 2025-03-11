using ApiProdutosPessoas.Data;
using ApiProdutosPessoas.Models;
using ApiProdutosPessoas.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProdutosPessoas.Repositories
{
    public class MarcaRepositorio : InterfaceMarca
    {
        private readonly TESTE_API _dbContext;

        public MarcaRepositorio(TESTE_API produtosPessoasDBContext)
        {
            _dbContext = produtosPessoasDBContext;
        }

        public async Task<MarcaModel> AdicionarMarca(MarcaModel marca)
        {

            await _dbContext.Marcas.AddAsync(marca);
            await _dbContext.SaveChangesAsync();

            if (string.IsNullOrWhiteSpace(marca.DescricaoMarca))
            {
                throw new ArgumentException("A descrição da marca não pode ser nula ou vazia.");
            }


            return marca;
        }

        public async Task<MarcaModel> BuscarIDMarca(int id)
        {
            return await _dbContext.Marcas.FirstOrDefaultAsync(m => m.CodigoMarca == id);
        }

        public async Task<MarcaModel> AtualizarMarca(MarcaModel marca, int id)
        {
            var marcaExistente = await _dbContext.Marcas.FirstOrDefaultAsync(m => m.CodigoMarca == id);

            if (marcaExistente == null)
            {
                throw new Exception($"Marca com ID {id} não encontrada.");
            }

            marcaExistente.DescricaoMarca = marca.DescricaoMarca;

            _dbContext.Marcas.Update(marcaExistente);
            await _dbContext.SaveChangesAsync();

            return marcaExistente;
        }

        public async Task<bool> DeletarMarca(int id)
        {
            var produtos = _dbContext.Produtos.Where(p => p.CodigoMarca == id);
            _dbContext.Produtos.RemoveRange(produtos);

            var marca = await _dbContext.Marcas.FirstOrDefaultAsync(x => x.CodigoMarca == id);

            if (marca == null)
            {
                throw new Exception($"Marca com ID {id} não encontrada.");
            }

            _dbContext.Marcas.Remove(marca);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
