using FluentAssertions;
using Moq;

namespace Exercicio.Tests.Services
{
    public class ProdutoService_GetProdutoTests
    {
        private readonly Mock<IProdutoRepository> _mockRepo;
        private readonly ProdutoService _produtoService;

        public ProdutoService_GetProdutoTests()
        {
            _mockRepo = new Mock<IProdutoRepository>();
            _produtoService = new ProdutoService(_mockRepo.Object);
        }

        [Fact(DisplayName = "GetProduto retorna produto para ID válido")]
        public void GetProduto_ComIDValido_RetornaProduto()
        {
            // Arrange
            var idValido = 1;
            var produtoEsperado = new Produto { Id = idValido, Nome = "Produto Teste", Preco = 100.00 };
            _mockRepo.Setup(repo => repo.GetById(idValido)).Returns(produtoEsperado);

            // Act
            var resultado = _produtoService.GetProduto(idValido);

            // Assert
            resultado.Should().BeEquivalentTo(produtoEsperado, options => options.ComparingByMembers<Produto>());
        }
    }
}
