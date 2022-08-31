using System;

public class Mesa : IComparable<Mesa>{
  public int Id { get; set; }  

	public int CompareTo(Mesa obj) {
    return this.Id.CompareTo(obj.Id);
  }
	
	public override string ToString(){
	  return "Mesa: " + Id;
	}
}