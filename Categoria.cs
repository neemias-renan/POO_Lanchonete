using System; 

  public class Categoria{
    private int id;
    private string descricao;
    private Produto[] produtos = new Produto[10];
    private int contadorproduto;

    public int Id { get => id; set => id = value; } 
    public string Descricao { get => descricao; set => descricao = value; }
    public Categoria() { }

    public Categoria(int id, string descricao){
      this.id = id;
      this.descricao = descricao;
    }

    public void SetId(int id){
      this.id = id;
    }
    
    public void SetDescricao(string descricao){
      this.descricao = descricao;
    }
    
    public int GetId(){
      return id;
    }
    
    public string GetDescricao(){
      return descricao;
    }
    
    public Produto[] ProdutoListar(){
      Produto[] c = new Produto[contadorproduto];
      Array.Copy(produtos, c, contadorproduto);
      return c;
    }
    
    public void ProdutoInserir(Produto p){
      if(contadorproduto == produtos.Length){
        Array.Resize(ref produtos, 2 * produtos.Length);
      }
      produtos[contadorproduto] = p;
      contadorproduto++;
    }
    
    private int ProdutoIndice(Produto p){
      for (int i = 0; i < contadorproduto; i++)
        if (produtos[i] == p) return i;
      return -1;
    }
		
    public void ProdutoExcluir(Produto p){
      int n = ProdutoIndice(p);
      for (int i = n; i < contadorproduto; i++)
        produtos[i] = produtos[i + 1];
      contadorproduto--;
    }
		
    public override string ToString(){
      return id + " - " + descricao + " - Nº produtos: " + contadorproduto;
    }
  }
