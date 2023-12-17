using btg_testes_auto;
using FluentAssertions;
using System;

namespace btg_test
{
    public class CalculadoraTest
    {
        [Fact]
        public void Somar_NumerosValidos_RetornaNumerosSomados()
        {
            // Arrange
            Calculadora calculadora = new(2, 2);

            // Act
            double resultado = calculadora.Somar();

            // Assert
            Assert.Equal(4, resultado);
        }

        [Fact]
        public void Somar_ListaValida_RetornaNumerosSomados()
        {
            // Arrange
            List<double> listaValores = new() { 5, 5, 2, 3 };

            Calculadora calculadora = new();

            // Act
            double resultado = calculadora.Somar(listaValores);

            // Assert
            Assert.Equal(15, resultado);
        }

        [Fact]
        public void Subtrair_NumerosValidos_RetornaNumerosSubstraidos()
        {
            // Arrange
            Calculadora calculadora = new()
            {
                numero1 = 5,
                numero2 = 2
            };

            // Act
            double resultado = calculadora.Subtrair();

            // Assert
            Assert.Equal(3, resultado);
        }

        [Fact]
        public void Multiplicar_NumerosValidos_RetornaNumerosMultiplicados()
        {
            // Arrange
            Calculadora calculadora = new(2, 2);

            // Act
            double resultado = calculadora.Multiplicar();

            // Assert
            Assert.Equal(4, resultado);
        }

        [Fact]
        public void Dividir_NumerosValidos_RetornaNumeroDividido()
        {
            // Given
            Calculadora calculadora = new(2, 2);

            // When
            double? resultado = calculadora.Dividir();

            // Then
            Assert.Equal(1, resultado);
        }

        [Fact]
        public void Dividir_NumeroInvalido_RetornaExcecao()
        {
            //Arrange
            Calculadora calculadora = new(2, 0);            

            //Act
            Action resultado = () => calculadora.Dividir();
            
            //Assert
            Assert.Throws<Exception>(resultado);
            resultado.Should().Throw<Exception>().WithMessage("Mensagem exception");

        }
    }
}