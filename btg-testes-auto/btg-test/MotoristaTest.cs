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
    public class MotoristaTest
    {
        [Fact]
        public void EncontrarMotoristas_IdadeMenorQue18NaoPossuiHabilitacao_RetornaExcecao()
        {
            List<Pessoa> pessoas = new List<Pessoa>
        {
            new Pessoa { Nome = "Ana", Idade = 16, PossuiHabilitaçãoB = false },
            new Pessoa { Nome = "João", Idade = 10, PossuiHabilitaçãoB = false },
            new Pessoa { Nome = "Maria", Idade = 15, PossuiHabilitaçãoB = false }
        };

            //Arrange
            Motorista motorista = new();

            //Act
            Action resultado = () => motorista.EncontrarMotoristas(pessoas);

            //Assert
            resultado.Should().Throw<Exception>().WithMessage("A viagem não será realizada devido falta de motoristas!");
        }

        [Fact]
        public void EncontrarMotoristas_IdadeMenorQue18PossuiHabilitacao_RetornaExcecao()
        {
            List<Pessoa> pessoas = new List<Pessoa>
        {
            new Pessoa { Nome = "Ana", Idade = 16, PossuiHabilitaçãoB = true },
            new Pessoa { Nome = "João", Idade = 10, PossuiHabilitaçãoB = true },
            new Pessoa { Nome = "Maria", Idade = 15, PossuiHabilitaçãoB = true }
        };

            //Arrange
            Motorista motorista = new();

            //Act
            Action resultado = () => motorista.EncontrarMotoristas(pessoas);

            //Assert
            resultado.Should().Throw<Exception>().WithMessage("A viagem não será realizada devido falta de motoristas!");
        }


        [Fact]
        public void EncontrarMotoristas_IdadeMaiorQue18PossuiHabilitacao_CountMenorQue2_RetornaExcecao()
        {
            List<Pessoa> pessoas = new List<Pessoa>
        {
            new Pessoa { Nome = "Ana", Idade = 26, PossuiHabilitaçãoB = true },
            new Pessoa { Nome = "João", Idade = 30, PossuiHabilitaçãoB = false },
            new Pessoa { Nome = "Maria", Idade = 45, PossuiHabilitaçãoB = false }
        };

            //Arrange
            Motorista motorista = new();

            //Act
            Action resultado = () => motorista.EncontrarMotoristas(pessoas);

            //Assert
            resultado.Should().Throw<Exception>().WithMessage("A viagem não será realizada devido falta de motoristas!");

        }

        [Fact]
        public void EncontrarMotoristas_IdadeMaiorQue18PossuiHabilitacao_CountZero_RetornaExcecao()
        {
            List<Pessoa> pessoas = new List<Pessoa>
        {
            new Pessoa { Nome = "Ana", Idade = 26, PossuiHabilitaçãoB = false },
            new Pessoa { Nome = "João", Idade = 30, PossuiHabilitaçãoB = false },
            new Pessoa { Nome = "Maria", Idade = 45, PossuiHabilitaçãoB = false }
        };

            //Arrange
            Motorista motorista = new();

            //Act
            Action resultado = () => motorista.EncontrarMotoristas(pessoas);

            //Assert
            resultado.Should().Throw<Exception>().WithMessage("A viagem não será realizada devido falta de motoristas!");

        }

        [Fact]
        public void EncontrarMotoristas_IdadeMaiorQue18PossuiHabilitacao_CountMaiorQue2_RetornaSucesso()
        {
            List<Pessoa> pessoas = new List<Pessoa>
        {
            new Pessoa { Nome = "Ana", Idade = 26, PossuiHabilitaçãoB = true },
            new Pessoa { Nome = "João", Idade = 30, PossuiHabilitaçãoB = true },
            new Pessoa { Nome = "Maria", Idade = 45, PossuiHabilitaçãoB = true }
        };

            //Arrange
            Motorista motorista = new();

            //Act

            //Assert
            motorista.EncontrarMotoristas(pessoas).Should().Contain("Uhuu!");
        }

        [Fact]
        public void EncontrarMotoristas_IdadeMaiorQue18PossuiHabilitacao_CountIgual2_RetornaSucesso()
        {
            List<Pessoa> pessoas = new List<Pessoa>
        {
            new Pessoa { Nome = "Ana", Idade = 26, PossuiHabilitaçãoB = true },
            new Pessoa { Nome = "João", Idade = 30, PossuiHabilitaçãoB = true },
            new Pessoa { Nome = "Maria", Idade = 45, PossuiHabilitaçãoB = false }
        };

            //Arrange
            Motorista motorista = new();

            //Act

            //Assert
            motorista.EncontrarMotoristas(pessoas).Should().Contain("Uhuu!");
        }

        [Fact]
        public void EncontrarMotoristas_IdadeIgual18PossuiHabilitacao_CountMenorQue2_RetornaExcecao()
        {
            List<Pessoa> pessoas = new List<Pessoa>
        {
            new Pessoa { Nome = "Ana", Idade = 18, PossuiHabilitaçãoB = true },
            new Pessoa { Nome = "João", Idade = 18, PossuiHabilitaçãoB = false },
            new Pessoa { Nome = "Maria", Idade = 18, PossuiHabilitaçãoB = false }
        };

            //Arrange
            Motorista motorista = new();

            //Act
            Action resultado = () => motorista.EncontrarMotoristas(pessoas);

            //Assert
            resultado.Should().Throw<Exception>().WithMessage("A viagem não será realizada devido falta de motoristas!");

        }

        [Fact]
        public void EncontrarMotoristas_IdadeIgual18PossuiHabilitacao_CountZero_RetornaExcecao()
        {
            List<Pessoa> pessoas = new List<Pessoa>
        {
            new Pessoa { Nome = "Ana", Idade = 18, PossuiHabilitaçãoB = false },
            new Pessoa { Nome = "João", Idade = 18, PossuiHabilitaçãoB = false },
            new Pessoa { Nome = "Maria", Idade = 18, PossuiHabilitaçãoB = false }
        };

            //Arrange
            Motorista motorista = new();

            //Act
            Action resultado = () => motorista.EncontrarMotoristas(pessoas);

            //Assert
            resultado.Should().Throw<Exception>().WithMessage("A viagem não será realizada devido falta de motoristas!");

        }

        [Fact]
        public void EncontrarMotoristas_IdadeIgual18PossuiHabilitacao_CountMaiorQue2_RetornaSucesso()
        {
            List<Pessoa> pessoas = new List<Pessoa>
        {
            new Pessoa { Nome = "Ana", Idade = 18, PossuiHabilitaçãoB = true },
            new Pessoa { Nome = "João", Idade = 18, PossuiHabilitaçãoB = true },
            new Pessoa { Nome = "Maria", Idade = 18, PossuiHabilitaçãoB = true }
        };

            //Arrange
            Motorista motorista = new();

            //Act

            //Assert
            motorista.EncontrarMotoristas(pessoas).Should().Contain("Uhuu!");
        }

        [Fact]
        public void EncontrarMotoristas_IdadeIgual18PossuiHabilitacao_CountIgual2_RetornaSucesso()
        {
            List<Pessoa> pessoas = new List<Pessoa>
        {
            new Pessoa { Nome = "Ana", Idade = 18, PossuiHabilitaçãoB = true },
            new Pessoa { Nome = "João", Idade = 18, PossuiHabilitaçãoB = true },
            new Pessoa { Nome = "Maria", Idade = 18, PossuiHabilitaçãoB = false }
        };

            //Arrange
            Motorista motorista = new();

            //Act

            //Assert
            motorista.EncontrarMotoristas(pessoas).Should().Contain("Uhuu!");
        }
    }
}
