using System; 
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Linq;

class  MainClass{ 
  private static NCategoria ncategoria = NCategoria.Singleton;
  private static NProduto nproduto = NProduto.Singleton;
  private static NMesa nmesa = NMesa.Singleton;
  private static NVenda nvenda = NVenda.Singleton;

  private static Mesa mesaLogin = null;
  private static Venda mesaVenda = null;

  public static void Main() {
  Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");

    try {
      ncategoria.Abrir();
      nproduto.Abrir();
      nmesa.Abrir();
      nvenda.Abrir();
    }
    catch(Exception erro) {
			Console.WriteLine(erro.Message);
    }

    int op = 99;
    int opção = 0;
    int opInicial = 0;
    
    do {
      try{
        if (opInicial == 0){
          op = -1;
          opInicial = MenuUsuario();
        }
        if (opInicial == 1){
          opção = MenuVendedorOpcao();
          if (opção == 0){
            op = 0;
          }
          else if(opção == 1){
            op = MenuVendedorCategoria();
            switch (op){
              case 0  : op = 0; break;
              case 1  : CategoriaListar(); break;
              case 2  : CategoriaInserir(); break;
              case 3  : CategoriaAtualizar(); break;
              case 4  : CategoriaExcluir(); break;
            }
          }

          else if(opção == 2){
            op = MenuVendedorProduto();
            switch (op){
              case 0  : op = 0; break;
              case 1  : ProdutoListar(); break;
              case 2  : ProdutoInserir(); break;
              case 3  : ProdutoAtualizar(); break;
              case 4  : ProdutoExcluir(); break;
            }
          }

            else if(opção == 3){
              op = MenuVendedorMesa();
              switch (op){
                case 0 : op = 0; break;
                case 1 : MesaListar(); break;
                case 2 : MesaInserir(); break;
                case 3 : MesaExcluir(); break;
              }
            }
          
            else if(opção == 99){
              opInicial = 0;
            }
          }
        
        if (opInicial == 2 && mesaLogin == null){
          op = MenuMesaLogin();
          switch (op){
            case 1  : DefinirMesa(); break;
            case 99 : opInicial = 0; break;
          }
        }
        if (opInicial == 2 && mesaLogin != null){
          op = MenuMesaLogout();
          switch (op){
            case 1  : MesaProdutoListar(); break;
            case 2  : MesaProdutoInserir(); break;
            case 3  : MesaPedidoVisualizar(); break;
            case 4  : MesaPedidoLimpar(); break;
            case 99 : MesaLogout(); break;
          }
        }
  }
    catch (Exception erro) {
				Console.WriteLine(erro.Message);
        op = 100;
      }
    } while (op != 0); {
    Console.WriteLine("Obrigado! Volte sempre!");
  }

  try {
      ncategoria.Salvar();
      nproduto.Salvar();
      nmesa.Salvar();
      nvenda.Salvar();
      
    } 
    catch(Exception erro) {
      string E = erro.Message;
			Console.WriteLine(E);
    }
  }

  public static int MenuUsuario() {
    Console.WriteLine("|=======   Lanchonete   =======|");
    Console.WriteLine("|                              |");
    Console.WriteLine("| 1 - Gerenciador              |");
    Console.WriteLine("| 2 - Realizar pedido          |");
    Console.WriteLine("|                              |");
    Console.WriteLine("|==============================|");
    Console.Write("Informe a opção desejada: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
		Console.Clear();
    return op;
  }
  

  public static int MenuVendedorOpcao(){
    ncategoria.Salvar();
    nproduto.Salvar();
    nmesa.Salvar();
    nvenda.Salvar();
  
    Console.WriteLine("|==== Área de Gerenciamento =====|");
    Console.WriteLine("|                                |");
    Console.WriteLine("| 0 - Sair do sistema!           |");
    Console.WriteLine("| 1 - Categoria                  |");
    Console.WriteLine("| 2 - Produto                    |");
    Console.WriteLine("| 3 - Mesa                       |");
    Console.WriteLine("|                                |");
    Console.WriteLine("| 99 - Voltar ao menu anterior   |");
    Console.WriteLine("|================================|");
    Console.Write("Informe a opção desejada: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
		Console.Clear();
    return op;
  }
  public static int MenuVendedorCategoria(){
    ncategoria.Salvar();
    nproduto.Salvar();
    nmesa.Salvar();
    nvenda.Salvar();
    
    Console.WriteLine();
    Console.WriteLine("|================================|");
    Console.WriteLine("|            CATEGORIA           |");
    Console.WriteLine("| 0 - Sair do sistema!           |");
    Console.WriteLine("|                                |");
    Console.WriteLine("| 1 - Listar                     |");
    Console.WriteLine("| 2 - Inserir                    |");
    Console.WriteLine("| 3 - Atualizar                  |");
    Console.WriteLine("| 4 - Excluir                    |");
    Console.WriteLine("|                                |");
    Console.WriteLine("| 99 - Voltar ao menu anterior   |");
    Console.WriteLine("|================================|");
    Console.Write("Informe a opção desejada: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
		Console.Clear();
    return op;
  }

    public static int MenuVendedorProduto(){
    ncategoria.Salvar();
    nproduto.Salvar();
    nmesa.Salvar();
    nvenda.Salvar();
  
    Console.WriteLine("|================================|");
    Console.WriteLine("|            PRODUTO             |");
    Console.WriteLine("| 0 - Sair do sistema!           |");
    Console.WriteLine("|                                |");
    Console.WriteLine("| 1 - Listar                     |");
    Console.WriteLine("| 2 - Inserir                    |");
    Console.WriteLine("| 3 - Atualizar                  |");
    Console.WriteLine("| 4 - Excluir                    |");
    Console.WriteLine("|                                |");
    Console.WriteLine("| 99 - Voltar ao menu anterior   |");
    Console.WriteLine("|================================|");
    Console.Write("Informe a opção desejada: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
		Console.Clear();
    return op;
  }


  public static int MenuVendedorMesa(){
    ncategoria.Salvar();
    nproduto.Salvar();
    nmesa.Salvar();
    nvenda.Salvar();
    
    Console.WriteLine("|================================|");
    Console.WriteLine("|              MESA              |");
    Console.WriteLine("| 0 - Sair do sistema!           |");
    Console.WriteLine("|                                |");
    Console.WriteLine("| 1 - Listar                     |");
    Console.WriteLine("| 2 - Inserir                    |");
    Console.WriteLine("| 3 - Excluir                    |");
    Console.WriteLine("|                                |");
    Console.WriteLine("| 99 - Voltar ao menu anterior   |");
    Console.WriteLine("|================================|");
    Console.Write("Informe a opção desejada: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
		Console.Clear();
    return op;
  }

  public static int MenuMesaLogin(){
    ncategoria.Salvar();
    nproduto.Salvar();
    nmesa.Salvar();
    nvenda.Salvar();
    
    Console.WriteLine("|==============================|");
    Console.WriteLine("|                              |");
    Console.WriteLine("|  0 - Sair do sistema!        |");
    Console.WriteLine("|                              |");
    Console.WriteLine("|  1 - Definir Mesa            |");
    Console.WriteLine("| 99 - Voltar ao menu anterior |");
    Console.WriteLine("|                              |");
    Console.WriteLine("|==============================|");
    Console.Write("Informe a opção desejada: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
		Console.Clear();
    return op;
  }

  public static int MenuMesaLogout(){
    ncategoria.Salvar();
    nproduto.Salvar();
    nmesa.Salvar();
    nvenda.Salvar();
    
    Console.WriteLine();
    Console.WriteLine("|==================================|");
    Console.WriteLine("|                                  |");
    Console.WriteLine("|  0 - Sair do sistema!            |");
    Console.WriteLine("|                                  |");
    Console.WriteLine("|  1 - Exibir cardápio             |");
    Console.WriteLine("|  2 - Realizar pedido             |");
    Console.WriteLine("|  3 - Visualizar o pedido         |");
    Console.WriteLine("|  4 - Limpar o pedido             |");
    Console.WriteLine("|                                  |");
    Console.WriteLine("| 99 - Voltar ao menu anterior     |");
    Console.WriteLine("|==================================|");
    Console.Write("Informe a opção desejada: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
		Thread.Sleep(3000);
		Console.Clear();
    return op;
  }
  public static void CategoriaListar(){
    Console.WriteLine("|====== Lista de Categorias ======|");
    Console.WriteLine();
    Categoria[] cs = ncategoria.Listar();
    if (cs.Length == 0){
      Console.WriteLine("Nenhuma categoria cadastrada");
      Console.WriteLine();
      return;
    }
    foreach (Categoria c in cs) Console.WriteLine(c);
    Console.WriteLine();
  }
  public static void CategoriaInserir(){
    Console.WriteLine("|==== Inserção de Categorias ====|");
    Console.WriteLine();
    Console.Write("Informe um código para a categoria: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe uma descrição: ");
    string descricao = Console.ReadLine();
    Categoria c = new Categoria(id, descricao);
    ncategoria.Inserir(c);
    Console.WriteLine();
    Console.Write("Categoria inserida com sucesso!");
    Console.WriteLine();
  }
  public static void CategoriaAtualizar(){
    Console.WriteLine("|=== Atualização de Categorias ===|");
    CategoriaListar();
    Console.Write("Informe o nº da categoria que deseja atualizar: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe uma nova descrição para a categoria: ");
    string descricao = Console.ReadLine();
    Categoria c = new Categoria(id, descricao);
    ncategoria.Atualizar(c);
    Console.WriteLine();
    Console.WriteLine("Categoria atualiada com sucesso!!");
		Thread.Sleep(3000);
		Console.Clear();

  }
  public static void CategoriaExcluir(){
    Console.WriteLine("|===== Exclusão de Categorias ====|");
    CategoriaListar();
    Console.Write("Informe o nº da categoria que deseja excluir: ");
    int id = int.Parse(Console.ReadLine());
    Categoria c = ncategoria.Listar(id);
    ncategoria.Excluir(c);
    Console.WriteLine();
    Console.WriteLine("Categoria excluída com sucesso!");
		Thread.Sleep(3000);
		Console.Clear();
  }
	
  public static void ProdutoListar(){
    Console.WriteLine("|====== Lista de Produtos ======|");
    Console.WriteLine();
    Produto[] ps = nproduto.Listar();
    if (ps.Length == 0){
      Console.WriteLine("Nenhum produto cadastrado");
      Console.WriteLine();
      return;
    }
    foreach (Produto p in ps) Console.WriteLine(p);
    Console.WriteLine();
  }
	
  public static void ProdutoInserir(){
    Console.WriteLine("|===== Inserção de Produtos =====|");
    Console.WriteLine();
    Console.Write("Informe um código para o produto: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe uma descrição: ");
    string descricao = Console.ReadLine();
    Console.Write("Informe a quantidade do produto no estoque: ");
    int qtd = int.Parse(Console.ReadLine());
    Console.Write("Informe o preço do produto: ");
    double preco = double.Parse(Console.ReadLine());
    CategoriaListar();
    Console.Write("informe o nº de uma das categorias listadas acima: ");
    int idcategoria = int.Parse(Console.ReadLine());
    Categoria c = ncategoria.Listar(idcategoria);
    Produto p = new Produto(id, descricao, qtd, preco, c);
    nproduto.Inserir(p);


		
    Console.WriteLine();
    Console.Write("Produto inserido com sucesso!");
    Console.WriteLine();
  }
  public static void ProdutoAtualizar(){
    Console.WriteLine("|=== Atualização de Produtos ===|");
    Console.WriteLine();
    ProdutoListar();
    Console.Write("Informe o nº do produto que deseja atualizar: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe uma descrição: ");
    string descricao = Console.ReadLine();
    Console.Write("Informe a quantidade do produto no estoque: ");
    int qtd = int.Parse(Console.ReadLine());
    Console.Write("Informe o preço do produto: ");
    double preco = double.Parse(Console.ReadLine());
    CategoriaListar();
    Console.Write("informe o nº de uma das categorias listadas acima: ");
    int idcategoria = int.Parse(Console.ReadLine());
    Categoria c = ncategoria.Listar(idcategoria);
    Produto p = new Produto(id, descricao, qtd, preco, c);
    nproduto.Atualizar(p);
    Console.WriteLine();
    Console.Write("Produto atualizado com sucesso!");
    Console.WriteLine();
		Thread.Sleep(3000);
		Console.Clear();
  }
  public static void ProdutoExcluir(){
    Console.WriteLine("|===== Exclusão de Produtos =====|");
    Console.WriteLine();
    ProdutoListar();
    Console.Write("Informe o nº do produto que deseja excluir: ");
    int id = int.Parse(Console.ReadLine());
    Produto p = nproduto.Listar(id);
    nproduto.Excluir(p);
    Console.WriteLine();
    Console.Write("Produto excluído com sucesso!");
    Console.WriteLine();
		Thread.Sleep(3000);
		Console.Clear();Console.Clear();
  }
 
	
  public static void MesaListar(){
    Console.WriteLine();
    List<Mesa> cs = nmesa.Listar();
    if (cs.Count == 0){
      Console.WriteLine("Nenhuma mesa cadastrada");
      Console.WriteLine();
      return;
    }
    foreach (Mesa c in cs) Console.WriteLine(c);
		Console.WriteLine();
  }

	
  public static void MesaInserir(){
    Console.WriteLine("|===== Cadastro de Mesa =====|");
    Console.WriteLine();
    Mesa c = new Mesa();
    nmesa.Inserir(c);
    Console.WriteLine();
    Console.Write("Mesa cadastrada com sucesso!");
    Console.WriteLine();
  }
	
  public static void MesaExcluir(){
    Console.WriteLine("|===== Exclusão de mesa =====|");
    MesaListar();
    Console.Write("Informe o código do mesa que deseja excluir: ");
    int id = int.Parse(Console.ReadLine());
    Mesa c = nmesa.Listar(id);
    nmesa.Excluir(c);
    Console.WriteLine();
    Console.Write("Mesa excluído com sucesso!");
    Console.WriteLine();
		Thread.Sleep(3000);
		Console.Clear();
  }
  public static void VendaListar() {
    Console.WriteLine("|======= Lista de Vendas =======|");
    Console.WriteLine();
    List<Venda> vs = nvenda.Listar();
    if (vs.Count == 0) {
      Console.WriteLine("Nenhuma venda foi cadastrada");
      Console.WriteLine();
       return;
    }
    foreach(Venda v in vs) {
      double total = 0;
      Console.WriteLine(v);
      foreach (VendaItem item in nvenda.ItemListar(v)){
        Console.WriteLine(" " + item);
          total += (item.GetPreco() * item.GetQtd());
      }
    Console.WriteLine(" Total da compra: R$" + total.ToString("0.00") + "\n");
    Console.WriteLine();
    }
   
    var r1 = vs.Select(v => new {
      MesAno = v.Data.Month + "/" + v.Data.Year,
      Total = v.Itens.Sum(vi => vi.Qtd * vi.Preco) 
    });

    var r2 = r1.GroupBy(item => item.MesAno,
      (key, items) => new {
        MesAno = key,
        Total = items.Sum(item => item.Total) });    
    foreach(var item in r2) Console.WriteLine(item);
    Thread.Sleep(3000);
		Console.Clear();
  }
  
  public static void DefinirMesa(){
    Console.WriteLine("|======= Defina a Mesa =======|");
    Console.WriteLine();
    MesaListar();
    Console.Write("Informe o código da mesa: ");
    int id = int.Parse(Console.ReadLine());
    mesaLogin = nmesa.Listar(id);
    mesaVenda = nvenda.ListarPedido(mesaLogin);
    Console.WriteLine();
  }
  
  public static void MesaLogout(){
    Console.WriteLine("|====== Saindo da Mesa ======|");
    Console.WriteLine();
    if (mesaVenda != null) nvenda.Inserir(mesaVenda, true);
    mesaLogin = null;
    mesaVenda = null;
  }
  
  
  public static void MesaProdutoListar(){
    ProdutoListar();
  }

  
  public static void MesaProdutoInserir(){
    ProdutoListar();
    Console.Write("Informe o código do produto a ser comprado: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe a quantidade: ");
    int qtd = int.Parse(Console.ReadLine());
    Produto p = nproduto.Listar(id);
    if(p != null){
      if (mesaVenda == null){  
        mesaVenda = new Venda(DateTime.Now, mesaLogin);}
      nvenda.ItemInserir(mesaVenda, qtd, p);
    }
    Console.WriteLine();
    Console.WriteLine("Produto inserido no pedido");
    Console.WriteLine();
  }
  
  public static void MesaPedidoVisualizar(){
    if (mesaVenda == null){
      Console.WriteLine("Nenhum produto no pedido");
      Console.WriteLine();
      return;
    }

    double total = 0;
    
    List<VendaItem> itens = nvenda.ItemListar(mesaVenda);
    foreach(VendaItem item in itens){
        total += (item.GetPreco() * item.GetQtd());
        Console.WriteLine(item);
    }
    Console.WriteLine();
    Console.WriteLine("Total do pedido: R$ " + total.ToString("0.00") + "\n");
  }
  
  public static void MesaPedidoLimpar(){
    if (mesaVenda != null){
      nvenda.ItemExcluir(mesaVenda);
      Console.WriteLine();
      Console.WriteLine("Pedido esvaziado com sucesso");
      Console.WriteLine();
    }
  }



}