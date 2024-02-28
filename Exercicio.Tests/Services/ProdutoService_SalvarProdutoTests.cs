using FluentAssertions;
using Moq;

namespace Exercicio.Tests.Services
{
    public class ProdutoService_SalvarProdutoTests
    {
        private readonly Mock<IProdutoRepository> _mockRepo;
        private readonly ProdutoService _produtoService;

        public ProdutoService_SalvarProdutoTests()
        {
            _mockRepo = new Mock<IProdutoRepository>();
            _produtoService = new ProdutoService(_mockRepo.Object);
        }

        [Fact(DisplayName = "SalvarProduto salva produto com dados válidos")]
        public void SalvarProduto_ComDadosValidos_SalvaProduto()
        {
            // Arrange
            var produtoNovo = new Produto { Id = 0, Nome = "Produto Novo", Preco = 100.00 };

            // Act
            Action act = () => _produtoService.SalvarProduto(produtoNovo);

            // Assert
            act.Should().NotThrow();
            _mockRepo.Verify(repo => repo.Save(produtoNovo), Times.Once);
        }
    }
}
