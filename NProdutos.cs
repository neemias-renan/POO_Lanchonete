using System;
using System.Xml.Serialization;
using System.Text;
using System.IO;

class NProduto{
  private NProduto() { }
  static NProduto obj = new NProduto();
  public static NProduto Singleton { get => obj; }
  
 	private Produto[] produtos = new Produto[10];
  private int contadorproduto;

  public void Abrir() {
    Arquivo<Produto[]> f = new Arquivo<Produto[]>();
    produtos = f.Abrir("produtos.xml");
    contadorproduto = produtos.Length;
    AtualizarCategoria();
  }

  private void AtualizarCategoria() {
    for(int i = 0; i < contadorproduto; i++) {
      Produto p = produtos[i];
      Categoria c =  NCategoria.Singleton.Listar(p.CategoriaId);
      if (c != null) {
        p.SetCategoria(c);
        c.ProdutoInserir(p);
      }
    }
  }
  
  public void Salvar() {
    Arquivo<Produto[]> f = new Arquivo<Produto[]>();
    f.Salvar("produtos.xml", Listar());
  }
  
  public Produto[] Listar() {
    Produto[] p = new Produto[contadorproduto];
    Array.Copy(produtos, p, contadorproduto);
    return p;
  }

  public Produto Listar(int id){
    for (int i = 0; i < contadorproduto; i++)
      if (produtos[i].GetId() == id) return produtos[i];
    return null;
  }

  public void Inserir(Produto p){
    if (contadorproduto == produtos.Length){
      Array.Resize(ref produtos, 2 * produtos.Length);
    }
		
    produtos[contadorproduto] = p;
		
    contadorproduto++;
    Categoria c = p.GetCategoria();
    if(c != null) c.ProdutoInserir(p);

  }
  public void Atualizar(Produto p){
    Produto p_atual = Listar(p.GetId());
    p_atual.SetDescricao(p.GetDescricao());
    p_atual.SetQtd(p.GetQtd());
    p_atual.SetPreco(p.GetPreco());
    if (p_atual.GetCategoria() != null){
      p_atual.GetCategoria().ProdutoExcluir(p_atual);
    }
    p_atual.SetCategoria(p.GetCategoria());
    if (p_atual.GetCategoria() != null)
      p_atual.GetCategoria().ProdutoInserir(p_atual);
  }
  private int Indice(Produto p){
    for (int i = 0; i < contadorproduto; i++)
      if(produtos[i] == p) return i;
    return -1; 
  }
  public void Excluir(Produto p){
    int n = Indice(p);
    if(n == -1) return; 
    for (int i = n; i < contadorproduto - 1; i++)
      produtos[i] = produtos[i + 1];
    contadorproduto--;
    Categoria c = p.GetCategoria();
    if (c != null) c.ProdutoExcluir(p);
  }
}