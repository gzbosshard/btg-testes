using btg_testes_auto;
using FluentAssertions;

namespace btg_test
{
    public class FuncionarioTest
    {

        [Fact(DisplayName = "Salario 1000")]
        [Trait("DefinirNivelProfissional", "ProfissionalJunior")]
        public void DefinirNivelProfissional_Salarios1000_RetornaNivelProfissionalJunior()
        {
            // Arrange
            // Act
            Funcionario funcionario = new("Amanda", 1000);

            // Assert
            Assert.Equal("Junior", funcionario.NivelProfissional);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1500)]
        [InlineData(1998)]
        [Trait("DefinirNivelProfissional", "ProfissionalPleno")]
        public void DefinirNivelProfissional_SalarioAbaixoDe1999_RetornaNivelProfissionalJunior(decimal salario)
        {
            // Arrange
            // Act
            Funcionario funcionario = new("Amanda", salario);

            // Assert
            Assert.Equal("Junior", funcionario.NivelProfissional);

        }

        [Theory]
        [InlineData(1999)]
        [InlineData(5000)]
        [InlineData(7998)]
        public void DefinirNivelProfissional_SalarioAbaixoDe7999_RetornaNivelProfissionalPleno(decimal salario)
        {
            // Arrange
            // Act
            Funcionario funcionario = new("Amanda", salario);

            // Assert
            Assert.Equal("Pleno", funcionario.NivelProfissional);

        }

        //podemos adicionar quantos parametros necessario
        [Theory(DisplayName = "Salario Acima de 7998")]
        [InlineData(7999)]
        [InlineData(10000)]
        public void DefinirNivelProfissional_SalarioAcimaDe7998_RetornaNivelProfissionalSenior(decimal salario)
        {
            // Arrange
            // Act
            Funcionario funcionario = new("Amanda", salario);

            // Assert
            Assert.Equal("Senior", funcionario.NivelProfissional);
            funcionario.NivelProfissional.Should().Be("Senior");
        }

        

    }
}
