using FluentAssertions;
using Moq;

namespace Exercicio.Tests.Services
{
    public class ProdutoService_ExcluirProdutoTests
    {
        private readonly Mock<IProdutoRepository> _mockRepo;
        private readonly ProdutoService _produtoService;

        public ProdutoService_ExcluirProdutoTests()
        {
            _mockRepo = new Mock<IProdutoRepository>();
            _produtoService = new ProdutoService(_mockRepo.Object);
        }

        [Fact(DisplayName = "ExcluirProduto exclui produto existente com ID válido")]
        public void ExcluirProduto_ComIDValido_ExcluiProduto()
        {
            // Arrange
            var produtoExistente = new Produto { Id = 1, Nome = "Produto Exclusão", Preco = 100.00 };
            _mockRepo.Setup(repo => repo.GetById(produtoExistente.Id)).Returns(produtoExistente);

            // Act
            Action act = () => _produtoService.ExcluirProduto(produtoExistente.Id);

            // Assert
            act.Should().NotThrow();
            _mockRepo.Verify(repo => repo.Delete(produtoExistente.Id), Times.Once);
        }
    }
}
