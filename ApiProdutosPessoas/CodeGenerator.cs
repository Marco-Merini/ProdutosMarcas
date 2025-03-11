// Utilities/CodeGenerator.cs
using ApiProdutosPessoas.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

public static class CodeGenerator
{
    private static readonly Random _random = new Random();

    // Gera um código aleatório de 6 dígitos
    public static int GenerateRandomCode()
    {
        return _random.Next(100000, 1000000);
    }

    // Verifica se o código já existe no banco de dados
    public static async Task<int> GenerateUniqueProductCode(TESTE_API dbContext)
    {
        int code;
        bool exists;

        do
        {
            code = GenerateRandomCode();
            exists = await dbContext.Produtos.AnyAsync(p => p.CodigoProduto == code);
        } while (exists);

        return code;
    }

    // Verifica se o código de marca já existe no banco de dados
    public static async Task<int> GenerateUniqueBrandCode(TESTE_API dbContext)
    {
        int code;
        bool exists;

        do
        {
            code = GenerateRandomCode();
            exists = await dbContext.Marcas.AnyAsync(m => m.CodigoMarca == code);
        } while (exists);

        return code;
    }
}