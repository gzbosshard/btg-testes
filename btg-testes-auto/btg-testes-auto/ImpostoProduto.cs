using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btg_testes_auto
{
    /* ImpostoProduto
    * Uma empresa vende o mesmo produto para diferentes estados.
    * Cada estado possui uma taxa diferente de imposto sobre o produto
    * (MG 7%; SP 12%; RJ 15%; MS 8%; ES 12%; SC 18%;).
    * Faça um programa que retorne o preço final do produto acrescido do imposto do estado em que ele será vendido.
    * Se o estado digitado não for válido, estoure uma exception.
    */

    public class ImpostoProduto
    {

        public decimal Valor { get; set; }
        public string Estado { get; set; }

        public ImpostoProduto(decimal valor, string estado)
        {
            Valor = valor;
            Estado = estado;
        }

        public decimal ValorProdutoComImposto()
        {
            try
            {
                switch (Estado)
                {
                    case "MG":
                        return Valor * 1.07M;
                    case "SP":
                    case "ES":
                        return Valor * 1.12M;
                    case "RJ":
                        return Valor * 1.15M;
                    case "MS":
                        return Valor * 1.08M;
                    case "SC":
                        return Valor * 1.18M;
                    default:
                        throw new Exception("Estado inválido");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
