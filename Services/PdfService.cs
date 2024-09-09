using iTextSharp.text;
using iTextSharp.text.pdf;
using Estoque.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Estoque.Services
{
    public class PdfService
    {
        public byte[] GerarRelatorioTodosProdutos(IEnumerable<Produto> produtos)
        {
            using var ms = new MemoryStream();
            using (var document = new Document())
            {
                PdfWriter.GetInstance(document, ms);
                document.Open();

                var tabela = new PdfPTable(2)
                {
                    WidthPercentage = 100
                };
                tabela.AddCell("Produto");
                tabela.AddCell("Quantidade em Estoque");

                foreach (var produto in produtos)
                {
                    tabela.AddCell(produto.Nome);
                    tabela.AddCell(produto.Quantidade.ToString());
                }

                document.Add(tabela);
                document.Close();
            }

            return ms.ToArray();
        }

        public byte[] GerarRelatorioEstoqueBaixo(IEnumerable<Produto> produtos)
        {
            using var ms = new MemoryStream();
            using (var document = new Document())
            {
                PdfWriter.GetInstance(document, ms);
                document.Open();

                var tabela = new PdfPTable(2)
                {
                    WidthPercentage = 100
                };
                tabela.AddCell("Produto");
                tabela.AddCell("Quantidade em Estoque");

                foreach (var produto in produtos.Where(p => p.Quantidade <= 5))
                {
                    tabela.AddCell(produto.Nome);
                    tabela.AddCell(produto.Quantidade.ToString());
                }

                document.Add(tabela);
                document.Close();
            }

            return ms.ToArray();
        }

        public byte[] GerarRelatorioMovimentacao(IEnumerable<Produto> produtos, IEnumerable<Movimentacao> movimentacoes)
        {
            using var ms = new MemoryStream();
            using (var document = new Document())
            {
                PdfWriter.GetInstance(document, ms);
                document.Open();

                var tabela = new PdfPTable(2)
                {
                    WidthPercentage = 100
                };
                tabela.AddCell("Produto");
                tabela.AddCell("Quantidade Atual");

                var produtosComMovimentacao = movimentacoes
                    .Select(m => m.ProdutoId)
                    .Distinct();

                foreach (var produto in produtos.Where(p => produtosComMovimentacao.Contains(p.Id)))
                {
                    tabela.AddCell(produto.Nome);
                    tabela.AddCell(produto.Quantidade.ToString());
                }

                document.Add(tabela);
                document.Close();
            }

            return ms.ToArray();
        }

        public byte[] GerarRelatorioProdutosSemMovimentacao(IEnumerable<Produto> produtos, IEnumerable<Movimentacao> movimentacoes)
        {
            using var ms = new MemoryStream();
            using (var document = new Document())
            {
                PdfWriter.GetInstance(document, ms);
                document.Open();

                var tabela = new PdfPTable(2)
                {
                    WidthPercentage = 100
                };
                tabela.AddCell("Produto");
                tabela.AddCell("Quantidade em Estoque");

                var produtosComMovimentacao = movimentacoes
                    .Select(m => m.ProdutoId)
                    .Distinct();

                foreach (var produto in produtos.Where(p => !produtosComMovimentacao.Contains(p.Id)))
                {
                    tabela.AddCell(produto.Nome);
                    tabela.AddCell(produto.Quantidade.ToString());
                }

                document.Add(tabela);
                document.Close();
            }

            return ms.ToArray();
        }
    }
}
