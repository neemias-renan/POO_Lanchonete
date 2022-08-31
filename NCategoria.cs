using System;
using System.Xml.Serialization;
using System.Text;
using System.IO;
using System.Linq;
  
class NCategoria {
  
  private NCategoria() { }
  static NCategoria obj = new NCategoria();
  public static NCategoria Singleton { get => obj; }
  
  private Categoria[] categorias = new Categoria[10];
  private int contadorcategoria;

  public void Abrir() {
    Arquivo<Categoria[]> f = new Arquivo<Categoria[]>();
    categorias = f.Abrir("categorias.xml");
    contadorcategoria = categorias.Length;
  }
  
  public void Salvar() {
    Arquivo<Categoria[]> f = new Arquivo<Categoria[]>();
    f.Salvar("categorias.xml", Listar());
  }
  
  public Categoria[] Listar() {
      return categorias.Take(contadorcategoria).OrderBy(obj => obj.GetDescricao()).ToArray();
  }

  public Categoria Listar(int id){
    var r = categorias.Where(obj => obj.GetId() == id);
    if (r.Count()==0) return null;
    return r.First();
  }

  public void Inserir(Categoria c){
    if (contadorcategoria == categorias.Length){
      Array.Resize(ref categorias, 2 * categorias.Length);
    }  
    categorias[contadorcategoria] = c;
    contadorcategoria++;
  }

  public void Atualizar(Categoria c){
    Categoria c_atual = Listar(c.GetId());
    if(c_atual == null) return;
    c_atual.SetDescricao(c.GetDescricao());
  }

  private int Indice(Categoria c){
    for (int i = 0; i < contadorcategoria; i++)
      if(categorias[i] == c) return i;
    return -1; 
  }
  public void Excluir(Categoria c){
    int n = Indice(c);
    if(n == -1) return; 
    for (int i = n; i < contadorcategoria - 1; i++)
      categorias[i] = categorias[i + 1];
    contadorcategoria--;
    Produto[] ps = c.ProdutoListar();
    foreach (Produto p in ps) p.SetCategoria(null);
  }

}