using btg_testes_auto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NSubstitute;

namespace btg_test
{
    public class MeiaCinemaTest
    {
        [Theory]
        [InlineData(true, true, true, true)]
        [InlineData(true, true, false, false)]
        [InlineData(true, false, true, true)]
        [InlineData(true, false, false, false)]
        [InlineData(false, true, false, false)]
        [InlineData(false, false, true, true)]
        public void VerificarMeiaCinema_RetornaTrue(bool estudante, bool doadorDeSangue, bool trabalhadorPrefeitura, bool contratoPrefeitura)
        {
            //Arrange
            MeiaCinema meiaCinema = new();

            //Act
            var resultado = meiaCinema.VerificarMeiaCinema(estudante, doadorDeSangue, trabalhadorPrefeitura, contratoPrefeitura);

            //Assert
            resultado.Should().BeTrue();
        }

        [Theory]
        [InlineData(false, false, false, false)]
        [InlineData(false, false, true, false)]
        [InlineData(false, false, false, true)]

        public void VerificarMeiaCinema_RetornaFalse(bool estudante, bool doadorDeSangue, bool trabalhadorPrefeitura, bool contratoPrefeitura)
        {
            //Arrange
            MeiaCinema meiaCinema = new();

            //Act
            var resultado = meiaCinema.VerificarMeiaCinema(estudante, doadorDeSangue, trabalhadorPrefeitura, contratoPrefeitura);

            //Assert
            resultado.Should().BeFalse();
        }

    }
}
