using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using btg_testes_auto;

namespace btg_test
{
    public class LucroTest
    {
        [Fact]
        public void calcularPercentualVenda_MenorQueVinte_RetornaVendaComLucro()
        {
            //Arrange
            Lucro lucro = new();

            //Act
            decimal resultado = lucro.Calcular(10M);

            //Assert
            Assert.Equal(14.5M, resultado);
        }

        [Fact]
        public void calcularPercentualVenda_MaiorQueVinte_RetornaVendaComLucro()
        {
            //Arrange
            Lucro lucro = new();

            //Act
            decimal resultado = lucro.Calcular(100M);

            //Assert
            Assert.Equal(130M, resultado);
        }

        [Fact]
        public void calcularPercentualVenda_IgualVinte_RetornaValorComLucro()
        {
            //Arrange
            Lucro lucro = new();

            //Act
            decimal resultado = lucro.Calcular(20M);

            //Assert
            Assert.Equal(26M, resultado);
        }
    }
}
