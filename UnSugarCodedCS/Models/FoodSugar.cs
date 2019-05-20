using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace UnSugarCodedCS.Models
{
public class FoodSugar

{
  private int _id;
  private string _name;
  private float _added_sugars;

  public FoodSugar (string name, float added_sugars, int id =0)
  {
    _name =name;
    _id = id;
    _added_sugars = added_sugars;
  }

  public string GetName()
  {
    return _name;
  }

  public int GetId()
  {
    return _id;
  }

  public float GetAddedSugars()
  {
    return  _added_sugars;
  }

public static List<FoodSugar> GetAll()
{
  List<FoodSugar> allDatas = new List<FoodSugar>{};
  MySqlConnection conn = DB.Connection();
  conn.Open();
  MySqlCommand cmd = conn.CreateCommand();
  cmd.CommandText = @"SELECT * FROM food_sugar;";
  MySqlDataReader rdr = cmd.ExecuteReader();
  while(rdr.Read())
  {
    int id = rdr.GetInt32(0);
    string name = rdr.GetString(1);
    float addedSugar = rdr.GetFloat(2);
    FoodSugar newFoodSugar = new FoodSugar (name,addedSugar,id);
    allDatas.Add(newFoodSugar);
  }
  conn.Close();
  if(conn != null) conn.Dispose();
  return allDatas;
}
public static List<string> GetAllFoodNames(string userInput)
{
  List<string> allSugarNames = new List<string>{};
  MySqlConnection conn = DB.Connection();
  conn.Open();
  MySqlCommand cmd = conn.CreateCommand();
  cmd.CommandText = @"SELECT name FROM food_sugar WHERE name LIKE '"+userInput+"%';";
  MySqlDataReader rdr = cmd.ExecuteReader();
  while(rdr.Read())
  {

    string nameFood = rdr.GetString(0);
    allSugarNames.Add(nameFood);
  }
  conn.Close();
  if(conn != null) conn.Dispose();
  return allSugarNames;
}






}

}
