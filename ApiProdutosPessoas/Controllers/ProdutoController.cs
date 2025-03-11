using ApiProdutosPessoas.Data;
using ApiProdutosPessoas.Models;
using ApiProdutosPessoas.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace ApiProdutosPessoas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ProdutoController : ControllerBase
    {
        private readonly InterfaceProduto _produtoRepositorio;
        private readonly TESTE_API _dbContext;

        public ProdutoController(InterfaceProduto produtoRepositorio, TESTE_API dbContext)
        {
            _produtoRepositorio = produtoRepositorio ?? throw new ArgumentNullException(nameof(produtoRepositorio));
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        [HttpGet]
        public async Task<ActionResult<List<ProdutoModel>>> BuscarTodosProdutos()
        {
            var produtos = await _dbContext.Produtos.ToListAsync();
            return Ok(produtos);
        }

        [HttpGet("marca/{marcaId}")]
        public async Task<List<ProdutoModel>> BuscarProdutosPorMarca(int marcaId)
        {
            return await _dbContext.Produtos
                .Include(p => p.Marca)
                .Where(p => p.CodigoMarca == marcaId)
                .ToListAsync();
        }

        [HttpGet("descricao/{descricao}")]
        public async Task<List<ProdutoModel>> BuscarProdutosPorDescricao(string descricao)
        {
            return await _dbContext.Produtos
                .Include(p => p.Marca)
                .Where(p => p.DescricaoProduto.Contains(descricao))
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ProdutoModel> BuscarIDProduto(int id)
        {
            return await _dbContext.Produtos
                .Include(p => p.Marca)
                .FirstOrDefaultAsync(x => x.CodigoProduto == id);
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoModel>> AdicionarProduto([FromBody] ProdutoModel produtoModel)
        {
            ProdutoModel produto = await _produtoRepositorio.AdicionarProduto(produtoModel);
            return Ok(produto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProdutoModel>> AtualizarProduto([FromBody] ProdutoModel produtoModel, int id)
        {
            produtoModel.CodigoProduto = id;
            ProdutoModel produto = await _produtoRepositorio.AtualizarProduto(produtoModel, id);
            return Ok(produto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProdutoModel>> DeletarProduto(int id)
        {
            bool deletar = await _produtoRepositorio.DeletarProduto(id);
            return Ok(deletar);
        }
    }
}
