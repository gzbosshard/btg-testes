using btg_testes_auto;
using FluentAssertions;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btg_test
{
    public class AnaliseSuspeitosTeste
    {
        [Theory]
        [InlineData(true, true, false, false, false)]
        [InlineData(true, false, true, false, false)]
        [InlineData(true, false, false, true, false)]
        [InlineData(true, false, false, false, true)]
        [InlineData(false, true, true, false, false)]
        [InlineData(false, true, false, true, false)]
        [InlineData(false, true, false, false, true)]
        [InlineData(false, false, true, true, false)]
        [InlineData(false, false, true, false, true)]
        [InlineData(false, false, false, true, true)]
        public void AnaliseSuspeitos_Suspeita_RetornaTrue(bool telefonouVitima, bool esteveNoLocal, bool moraPerto, bool devedor, bool trabalhaComVitima)
        {
            //Arrange
            AnaliseSuspeitos analiseSuspeitos = new();

            //Act
            var resultado = analiseSuspeitos.ExecutarQuestionarioSuspeito(
            telefonouVitima, esteveNoLocal, moraPerto, devedor, trabalhaComVitima);

            //Assert
            resultado.Should().Be("Suspeita");

        }

        [Theory]
        [InlineData(true, true, true, true, false)]
        [InlineData(true, true, true, false, true)]
        [InlineData(true, true, false, true, true)]
        [InlineData(true, false, true, true, true)]
        [InlineData(false, true, true, true, true)]
        public void AnaliseSuspeitos_Cumplice_RetornaTrue(bool telefonouVitima, bool esteveNoLocal, bool moraPerto, bool devedor, bool trabalhaComVitima)
        {
            //Arrange
            AnaliseSuspeitos analiseSuspeitos = new();

            //Act
            var resultado = analiseSuspeitos.ExecutarQuestionarioSuspeito(
            telefonouVitima, esteveNoLocal, moraPerto, devedor, trabalhaComVitima);

            //Assert
            resultado.Should().Be("Cúmplice");
        }

        [Theory]
        [InlineData(true, true, true, true, true)]
        public void AnaliseSuspeitos_Assassino_RetornaTrue(bool telefonouVitima, bool esteveNoLocal, bool moraPerto, bool devedor, bool trabalhaComVitima)
        {
            //Arrange
            AnaliseSuspeitos analiseSuspeitos = new();

            //Act
            var resultado = analiseSuspeitos.ExecutarQuestionarioSuspeito(
            telefonouVitima, esteveNoLocal, moraPerto, devedor, trabalhaComVitima);

            //Assert
            resultado.Should().Be("Assassino");
        }

        [Theory]
        [InlineData(true, false, false, false, false)]
        [InlineData(false, true, false, false, false)]
        [InlineData(false, false, true, false, false)]
        [InlineData(false, false, false, true, false)]
        [InlineData(false, false, false, false, true)]
        [InlineData(false, false, false, false, false)]
        public void AnaliseSuspeitos_Inocente_RetornaTrue(bool telefonouVitima, bool esteveNoLocal, bool moraPerto, bool devedor, bool trabalhaComVitima)
        {
            //Arrange
            AnaliseSuspeitos analiseSuspeitos = new();

            //Act
            var resultado = analiseSuspeitos.ExecutarQuestionarioSuspeito(
            telefonouVitima, esteveNoLocal, moraPerto, devedor, trabalhaComVitima);

            //Assert
            resultado.Should().Be("Inocente");
        }

    }
}
