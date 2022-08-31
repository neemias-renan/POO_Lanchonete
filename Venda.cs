using System;
using System.Collections.Generic;

public class Venda {
  private int id;
  private DateTime data;
  private bool pedido;
  private Mesa mesa;
  private int mesaId;
  private List<VendaItem> itens = new List<VendaItem>();
  public int Id { get => id; set => id = value; }
  public DateTime Data { get => data; set => data = value; }
  public bool Pedido { get => pedido; set => pedido = value; }
  public int MesaId { get => mesaId; set => mesaId = value; }
  public List<VendaItem> Itens {get => itens; set => itens = value; }
  public Venda() { }
  
  public Venda(DateTime data, Mesa mesa) {
  this.data = data;
  this.pedido = true;
  this.mesa = mesa;
  this.mesaId = mesa.Id;
  }
  public void SetId(int id) {
   this.id = id;
  }
  public void SetData(DateTime data){
    this.data = data;
  }
  public void SetPedido(bool pedido){
    this.pedido = pedido;
  }
  public void SetMesa(Mesa mesa){
    this.mesa = mesa;
    this.mesaId = mesa.Id;
  }

  public int GetId() {
   return id;
  }
  public DateTime GetData(){
    return data;
  }
  public bool GetPedido(){
    return pedido;
  }
  public Mesa GetMesa(){
    return mesa;
  }
  public override string ToString(){
    if (pedido){
      return "Compra: " + id + " - " + data.ToString("dd/MM/yyyy") + " - mesa:" + mesa.Id + " - pedido";
    }
    else{
      return "Compra: " + id + " - " + data.ToString("dd/MM/yyyy") + "- mesa: " + mesa.Id;  
    }
  }

  private VendaItem ItemListar(Produto p){
    foreach(VendaItem vi in itens){
     if (vi.GetProduto() == p) return vi;
    }
    return null;
  }

  public List<VendaItem> ItemListar(){
    return itens;
  }

  public void ItemInserir(int qtd, Produto p){
    VendaItem item = ItemListar(p);
    if (item == null){
      item = new VendaItem(qtd, p);
      itens.Add(item);
    }
    else {
      item.SetQtd(item.GetQtd() + qtd);
    }
  }
  public void ItemExcluir(){
    itens.Clear();
  }
}