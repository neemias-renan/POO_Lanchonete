using System;
using System.Collections.Generic;

class NMesa{
  private NMesa() { }
  static NMesa obj = new NMesa();
  public static NMesa Singleton { get => obj; }
  
  private List<Mesa> mesas = new List<Mesa>();

   public void Abrir() {
    Arquivo<List<Mesa>> f = new Arquivo<List<Mesa>>();
    mesas = f.Abrir("mesas.xml");
     
  }
  
  public void Salvar() {
    Arquivo<List<Mesa>> f = new Arquivo<List<Mesa>>();
    f.Salvar("mesas.xml", Listar());
  }
  
  public List<Mesa> Listar(){
    mesas.Sort();
    return mesas;
  }

  public Mesa Listar(int id){
    for (int i = 0; i < mesas.Count; i++)
      if (mesas[i].Id == id) return mesas[i];
    return null;
  }

  public void Inserir(Mesa c){
    int max = 0;
    foreach(Mesa obj in mesas)
      if (obj.Id > max) max = obj.Id;
    c.Id = max + 1;
    mesas.Add(c);
  }

  
  public void Excluir(Mesa c){
    if (c != null) mesas.Remove(c);
  }

}