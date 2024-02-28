public interface IProdutoRepository
{
    Produto GetById(int id);
    void Save(Produto produto);
    void Update(Produto produto);
    void Delete(int id);
    List<Produto> GetAll();
}
