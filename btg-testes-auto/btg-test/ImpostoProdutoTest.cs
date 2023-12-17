using btg_testes_auto;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btg_test
{
    public class ImpostoProdutoTest
    {
        [Theory]
        [InlineData("MG", 100, 107)]
        [InlineData("SP", 100, 112)]
        [InlineData("RJ", 100, 115)]
        [InlineData("MS", 100, 108)]
        [InlineData("SC", 100, 118)]
        public void ValorProdutoComImposto_InformaEstado_RetornaValorComImposto(string estado, decimal valorInicial, decimal valorEsperado)
        {
            // Arrange
            var impostoProduto = new ImpostoProduto(valorInicial, estado);

            // Act
            var resultado = impostoProduto.ValorProdutoComImposto();

            // Assert
            resultado.Should().Be(valorEsperado);
        }

        [Fact]
        public void ValorProdutoComImposto_InformaEstadoInvalido_RetornaExcecao()
        {
            // Arrange
            var impostoProduto = new ImpostoProduto(100, "INVALIDO");

            // Act
            var resultado = new Action(() => impostoProduto.ValorProdutoComImposto());

            // Assert
            resultado.Should().Throw<Exception>().WithMessage("Estado inválido");
        }
    }
}
