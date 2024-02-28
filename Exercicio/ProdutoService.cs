public class ProdutoService
{
    private readonly IProdutoRepository _produtoRepository;

    // Construtor com injeção de dependência
    public ProdutoService(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    // Método para obter um produto por ID
    public Produto GetProduto(int id)
    {
        return _produtoRepository.GetById(id);
    }

    // Método para salvar um produto com validações
    public void SalvarProduto(Produto produto)
    {
        if (produto == null)
        {
            throw new ArgumentNullException(nameof(produto), "O produto não pode ser nulo.");
        }

        if (string.IsNullOrWhiteSpace(produto.Nome))
        {
            throw new ArgumentException("O nome do produto não pode ser vazio ou nulo.", nameof(produto.Nome));
        }

        if (produto.Preco <= 0)
        {
            throw new ArgumentException("O preço do produto deve ser maior que zero.", nameof(produto.Preco));
        }

        _produtoRepository.Save(produto);
    }

    // Método para atualizar um produto com validações
    public void AtualizarProduto(Produto produto)
    {
        if (produto == null)
        {
            throw new ArgumentNullException(nameof(produto), "O produto não pode ser nulo.");
        }

        var existingProduto = _produtoRepository.GetById(produto.Id);
        if (existingProduto == null)
        {
            throw new InvalidOperationException($"Não é possível atualizar o produto com ID {produto.Id} porque não foi encontrado.");
        }

        if (string.IsNullOrWhiteSpace(produto.Nome))
        {
            throw new ArgumentException("O nome do produto não pode ser vazio ou nulo.", nameof(produto.Nome));
        }

        if (produto.Preco <= 0)
        {
            throw new ArgumentException("O preço do produto deve ser maior que zero.", nameof(produto.Preco));
        }

        _produtoRepository.Update(produto);
    }

    // Método para excluir um produto
    public void ExcluirProduto(int id)
    {
        var existingProduto = _produtoRepository.GetById(id);
        if (existingProduto == null)
        {
            throw new InvalidOperationException($"Não é possível excluir o produto com ID {id} porque não foi encontrado.");
        }

        _produtoRepository.Delete(id);
    }

    // Método para obter todos os produtos
    public List<Produto> ObterTodosProdutos()
    {
        return _produtoRepository.GetAll();
    }
}