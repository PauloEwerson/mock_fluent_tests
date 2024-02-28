using FluentAssertions;
using Moq;

namespace Exercicio.Tests.Services
{
    public class ProdutoService_AtualizarProdutoTests
    {
        private readonly Mock<IProdutoRepository> _mockRepo;
        private readonly ProdutoService _produtoService;

        public ProdutoService_AtualizarProdutoTests()
        {
            _mockRepo = new Mock<IProdutoRepository>();
            _produtoService = new ProdutoService(_mockRepo.Object);
        }

        [Fact(DisplayName = "AtualizarProduto atualiza produto existente com dados válidos")]
        public void AtualizarProduto_ComDadosValidos_AtualizaProduto()
        {
            // Arrange
            var produtoExistente = new Produto { Id = 1, Nome = "Produto Original", Preco = 100.00 };
            var produtoParaAtualizar = new Produto { Id = 1, Nome = "Produto Atualizado", Preco = 150.00 };
            _mockRepo.Setup(repo => repo.GetById(produtoExistente.Id)).Returns(produtoExistente);

            // Act
            Action act = () => _produtoService.AtualizarProduto(produtoParaAtualizar);

            // Assert
            act.Should().NotThrow();
            _mockRepo.Verify(repo => repo.Update(produtoParaAtualizar), Times.Once);
        }
    }
}
