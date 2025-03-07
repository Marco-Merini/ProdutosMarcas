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
        private readonly TesteApidbContext _dbContext;

        public MarcaRepositorio(TesteApidbContext produtosPessoasDBContext)
        {
            _dbContext = produtosPessoasDBContext;
        }

        public async Task<MarcaModel> AdicionarMarca(MarcaModel marca)
        {
            var marcaExistente = await _dbContext.Marcas
                                                 .FirstOrDefaultAsync(m => m.CodigoMarca == marca.CodigoMarca);

            if (marcaExistente != null)
            {
                throw new Exception($"Marca com código {marca.CodigoMarca} já existe.");
            }

            await _dbContext.Marcas.AddAsync(marca);
            await _dbContext.SaveChangesAsync();

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
            var produtos = _dbContext.Produtos.Where(p => p.Codigo == id);
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
