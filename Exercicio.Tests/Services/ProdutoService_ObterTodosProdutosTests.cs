using FluentAssertions;
using Moq;

namespace Exercicio.Tests.Services
{
    public class ProdutoService_ObterTodosProdutosTests
    {
        private readonly Mock<IProdutoRepository> _mockRepo;
        private readonly ProdutoService _produtoService;

        public ProdutoService_ObterTodosProdutosTests()
        {
            _mockRepo = new Mock<IProdutoRepository>();
            _produtoService = new ProdutoService(_mockRepo.Object);
        }

        [Fact(DisplayName = "ObterTodosProdutos retorna lista não vazia quando existem produtos")]
        public void ObterTodosProdutos_ExistemProdutos_RetornaListaNaoVazia()
        {
            // Arrange
            var produtosEsperados = new List<Produto>
            {
                new Produto { Id = 1, Nome = "Produto 1", Preco = 100.00 },
                new Produto { Id = 2, Nome = "Produto 2", Preco = 200.00 }
            };
            _mockRepo.Setup(repo => repo.GetAll()).Returns(produtosEsperados);

            // Act
            var resultado = _produtoService.ObterTodosProdutos();

            // Assert
            resultado.Should().HaveCountGreaterThan(0);
            resultado.Should().BeEquivalentTo(produtosEsperados, options => options.ComparingByMembers<Produto>());
        }
    }
}
