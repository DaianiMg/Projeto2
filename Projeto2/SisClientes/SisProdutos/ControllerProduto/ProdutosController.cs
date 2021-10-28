using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SisProdutos.Date;
using SisProdutos.Date.DtosProduto;
using SisProdutos.Model;
using System.Collections.Generic;
using System.Linq;

namespace SisProdutos.ControllerProduto
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutosController : ControllerBase
    {
        private ProdutoContext _context;
        private IMapper _mapper;
        public ProdutosController(ProdutoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaProduto([FromQuery] CreateProdutoDto produtoDto) 
        {
            Produtos produto = _mapper.Map<Produtos>(produtoDto);
            List<CidadeResponse> CidadeList = new List<CidadeResponse>();
          
            if (produto != null)
            {
                _context.Produtos.Add(produto);
                _context.CidadeResponse.AddRange(CidadeList);
                _context.SaveChanges();
            }
            if (produto == null) return NotFound();

            return CreatedAtAction(nameof(RecuperaProduto), new { id = produto.Id, nome = produto.Nome, chave = produto.Palavra_Chave, descricao = produto.Descricao }, produto);
        }

        [HttpGet]
        public IActionResult RecuperaProduto()
        {
            var produtoDto = _mapper.Map<List<Produtos>, List<ReadProdutoDto>>(_context.Produtos.ToList());
            return Ok(produtoDto);
        }

        //Quero que meus usuários possam buscar produtos por texto que inclua tanto nome, palavras-chave e descrição

        [HttpGet("/{filtro}")]
        public IActionResult MostraProdutoNome([FromQuery] string nome = null, string palavraChave = null, string descricao = null, string categoria = null, bool preco = true)
        {
            //se o bool for true ele vai ordenar do menor preço, o filtro eu tentei dar uma utilidade pra ele...
            //como fazer ser a ordem primária para filtrar, mas não rolou

            var Filtro = new List<Produtos>()
            {
              
                
            };

            Filtro = _context.Produtos.Where(produto => produto.Nome == nome || produto.Palavra_Chave == palavraChave || produto.Descricao == descricao || produto.Categoria == categoria )
                                        .ToList();

            if (preco == true) 
            { 
                Filtro = Filtro.OrderBy(produto => produto.Preco).ToList(); 
            }
            if (preco == false ) 
            { 
                Filtro = Filtro.OrderByDescending(produto => produto.Preco).ToList(); 
            }

            if (Filtro != null)
            {
                return Ok(Filtro);
            }
            return NotFound();
        }

        [HttpPut("{Id}")]
        public IActionResult AtualizaCliente(int id, [FromBody] UpdateProdutoDto produtoDto)
        {
            Produtos produto = _context.Produtos.FirstOrDefault(p => p.Id == id);
            if (produto == null)
            {
                return NotFound();
            }
            _mapper.Map(produtoDto, produto);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{Id}")]
        public IActionResult DeletaCliente(int id)
        {
            Produtos produto = _context.Produtos.FirstOrDefault(p => p.Id == id);
            if (produto == null)
            {
                return NotFound();
            }
            _context.Remove(produto);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
