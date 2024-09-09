using Microsoft.AspNetCore.Mvc;
using Estoque.Services;
using Estoque.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Estoque.Controllers
{
    public class RelatoriosController : Controller
    {
        private readonly EstoqueContext _context;
        private readonly PdfService _pdfService;

        public RelatoriosController(EstoqueContext context, PdfService pdfService)
        {
            _context = context;
            _pdfService = pdfService;
        }

        public async Task<IActionResult> RelatorioTodosProdutos()
        {
            var produtos = await _context.Produtos.ToListAsync();
            var pdf = _pdfService.GerarRelatorioTodosProdutos(produtos);
            return File(pdf, "application/pdf", "Relatorio_Todos_Produtos.pdf");
        }

        public async Task<IActionResult> RelatorioEstoqueBaixo()
        {
            var produtos = await _context.Produtos.ToListAsync();
            var pdf = _pdfService.GerarRelatorioEstoqueBaixo(produtos);
            return File(pdf, "application/pdf", "Relatorio_Estoque_Baixo.pdf");
        }

        public async Task<IActionResult> RelatorioMovimentacao()
        {
            var produtos = await _context.Produtos.ToListAsync();
            var movimentacoes = await _context.Movimentacoes.ToListAsync();
            var pdf = _pdfService.GerarRelatorioMovimentacao(produtos, movimentacoes);
            return File(pdf, "application/pdf", "Relatorio_Movimentacao.pdf");
        }

        public async Task<IActionResult> RelatorioProdutosSemMovimentacao()
        {
            var produtos = await _context.Produtos.ToListAsync();
            var movimentacoes = await _context.Movimentacoes.ToListAsync();
            var pdf = _pdfService.GerarRelatorioProdutosSemMovimentacao(produtos, movimentacoes);
            return File(pdf, "application/pdf", "Relatorio_Produtos_Sem_Movimentacao.pdf");
        }
    }
}
