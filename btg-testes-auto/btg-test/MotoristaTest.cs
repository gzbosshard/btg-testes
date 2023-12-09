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
        public void EncontrarMotoristas_IdadeMenorQue18_RetornaExcecao()
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

            //Assert
            Assert.Throws<Exception>(() => motorista.EncontrarMotoristas(pessoas));
        }

        [Fact]
        public void EncontrarMotoristas_IdadeMaiorQue18_PossuiHabilitacao_CountMenorQue2()
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

            //Assert
            Assert.Throws<Exception>(() => motorista.EncontrarMotoristas(pessoas));
        }

        [Fact]
        public void EncontrarMotoristas_IdadeMaiorQue18_PossuiHabilitacao_CountMaiorQue2()
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
        public void EncontrarMotoristas_IdadeMaiorQue18_PossuiHabilitacao_CountIgual2()
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
    }
}
