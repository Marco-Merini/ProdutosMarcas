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
    public class MarcaController : ControllerBase
    {
        private readonly InterfaceMarca _marcaRepositorio;

        public MarcaController(InterfaceMarca marcaRepositorio)
        {
            _marcaRepositorio = marcaRepositorio;
        }

        [HttpPost]
        public async Task<ActionResult<MarcaModel>> AdicionarMarca([FromBody] MarcaModel marcaModel)
        {
            // Verifica se a marca já existe
            var marcaExistente = await _marcaRepositorio.BuscarIDMarca(marcaModel.CodigoMarca);

            if (marcaExistente != null)
            {
                return BadRequest($"Marca com código {marcaModel.CodigoMarca} já existe.");
            }

            // Adiciona a nova marca
            MarcaModel marca = await _marcaRepositorio.AdicionarMarca(marcaModel);
            return CreatedAtAction(nameof(BuscarIDMarca), new { id = marca.CodigoMarca }, marca);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<MarcaModel>> AtualizarMarca([FromBody] MarcaModel marcaModel, int id)
        {
            marcaModel.CodigoMarca = id;
            MarcaModel marca = await _marcaRepositorio.AtualizarMarca(marcaModel, id);
            return Ok(marca);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MarcaModel>> BuscarIDMarca(int id)
        {
            var marca = await _marcaRepositorio.BuscarIDMarca(id);
            if (marca == null)
            {
                return NotFound($"Marca com ID {id} não encontrada.");
            }
            return Ok(marca);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<MarcaModel>> DeletarMarca(int id)
        {
            bool deletar = await _marcaRepositorio.DeletarMarca(id);
            return Ok(deletar);
        }
    }
}
