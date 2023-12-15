using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NSubstitute;
using btg_testes_auto;

namespace btg_test
{
    public class VooTest
    {
        [Fact]
        public void ExibeInformacoesVoo_RetornaTexto()
        {
            //Arrange
            DateTime data = new DateTime(2023, 12, 08, 14, 30, 00);

            Voo voo = new Voo("Avião1", "123", data);

            //Act
            var resultado = voo.ExibeInformacoesVoo();

            //Assert
            resultado.Should().Be("Aeronave Avião1 registrada sob voo de número 123 para o dia e hora 08/12/2023 14:30:00"); ;
        }

        [Fact]
        public void AssentoDisponivel_VerificaDisponibilidade_RetornaTrue()
        {
            //Arrange
            var voo = new Voo("Avião1", "123", DateTime.Now);
            voo.OcupaAssento(0);

            //Act
            var resultado = voo.OcupaAssento(1);

            //Assert
            resultado.Should().BeTrue();
        }

        [Fact]
        public void AssentoDisponivel_VerificaDisponibilidade_RetornaFalse()
        {
            //Arrange
            var voo = new Voo("Avião1", "123", DateTime.Now);
            voo.OcupaAssento(0);

            //Act
            var resultado = voo.OcupaAssento(0);

            //Assert
            resultado.Should().BeFalse();
        }


        [Fact]
        public void OcupaAssento_AssentoDisponivel_RetornaTrue()
        {
            // Arrange
            var voo = new Voo("Avião1", "123", DateTime.Now);
            var posicao = 0;

            // Act
            var resultado = voo.OcupaAssento(posicao);

            // Assert
            resultado.Should().BeTrue();
        }

        [Fact]
        public void OcupaAssento_AssentoNaoDisponivel_RetornaFalse()
        {
            // Arrange
            var voo = new Voo("Avião1", "123", DateTime.Now);
            var posicao = 0;
            voo.OcupaAssento(posicao);

            // Act
            var resultado = voo.OcupaAssento(posicao);

            // Assert
            resultado.Should().BeFalse();

        }

        [Fact]
        public void ProximoLivre_SemAssentosDisponiveis_RetornaZero()
        {
            // Arrange
            var voo = new Voo("Avião1", "123", DateTime.Now);

            for (int i = 0; i < 100; i++)
            {
                voo.OcupaAssento(i);
            }

            voo.QuantidadeVagasDisponivel();

            // Act
            var resultado = voo.ProximoLivre();

            // Assert
            resultado.Should().Be(0);
        }

        [Fact]
        public void ProximoLivre_SemAssentosDisponiveisEAssentoDisponivelNulo_RetornaZero()
        {
            // Arrange
            var voo = new Voo("Avião1", "123", DateTime.Now);

            for (int i = 0; i < 100; i++)
            {
                voo.OcupaAssento(i);
            }

            voo.QuantidadeVagasDisponivel();

            // Act
            var resultado = voo.ProximoLivre();

            // Assert
            resultado.Should().Be(0);
        }

        [Fact]
        public void ProximoLivre_ComAssentosDisponiveis_RetornaProximoAssentoLivre()
        {
            // Arrange
            var voo = new Voo("Avião1", "123", DateTime.Now);
            voo.OcupaAssento(0);

            // Act
            var resultado = voo.ProximoLivre();

            // Assert
            resultado.Should().BeGreaterThan(0);
        }

        [Fact]
        public void QuantidadeVagasDisponivel_AposOcuparAssentos_DeveRetornarQuantidadeCorreta()
        {
            // Arrange
            var voo = new Voo("Avião1", "123", DateTime.Now);
            voo.OcupaAssento(0);
            voo.OcupaAssento(1);

            // Act
            var quantidadeEsperada = 100 - 2;
            var resultado = voo.QuantidadeVagasDisponivel();

            // Assert
            resultado.Should().Be(quantidadeEsperada);
        }


    }
}
