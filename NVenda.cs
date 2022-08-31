using System;
using System.Collections.Generic;
using System.Linq;

class NVenda {
  private NVenda() { }
  static NVenda obj = new NVenda();
  public static NVenda Singleton { get => obj; }
  
  private List<Venda> vendas = new List<Venda>();

  public void Abrir() {
    Arquivo<List<Venda>> f = new Arquivo<List<Venda>>();
    vendas= f.Abrir("vendas.xml");
    AtualizarMesa();
    AtualizarProduto();
  }

  public void AtualizarMesa() {
    foreach(Venda v in vendas) {
      Mesa c = NMesa.Singleton.Listar(v.MesaId);
      if (c != null) v.SetMesa(c);
    }
  }
  public void AtualizarProduto() {
    foreach(Venda v in vendas) {
      foreach(VendaItem vi in v.ItemListar()) {
      Produto p = NProduto.Singleton.Listar(vi.ProdutoId);
      if (p != null) vi.SetProduto(p);
    }
  }
}
  
  public void Salvar() {
    Arquivo<List<Venda>> f = new Arquivo<List<Venda>>();
    f.Salvar("vendas.xml", Listar());
  }
  
  public List<Venda> Listar(){
    return vendas;
  }

  public List<Venda> Listar (Mesa c){
    return vendas.Where(v => v.GetMesa() == c).ToList();
  }
	
  public Venda ListarPedido(Mesa c){
    foreach(Venda v in vendas)
      if (v.GetMesa() == c && v.GetPedido()) return v;
    return null;
  }
	
  public void  Inserir(Venda v, bool pedido){
		int max = 0;
		max = vendas.Max(obj => obj.GetId());
		v.SetId(max + 1);
		vendas.Add(v);
		v.SetPedido(pedido);
  }
	
  
   public  List<VendaItem> ItemListar(Venda v) {
     return v.ItemListar();
   }

  public void ItemInserir(Venda v, int qtd, Produto p) {
    v.ItemInserir(qtd, p);
  }

  public void ItemExcluir(Venda v) {
    v.ItemExcluir();
  }
}