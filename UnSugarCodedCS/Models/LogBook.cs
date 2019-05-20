using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace UnSugarCodedCS.Models
{
public class LogBook
{
private string _food;
private float _sugar;
private DateTime _stampTime;
private int _id;
private int _userId;

public LogBook (string food, DateTime stampTime,float sugar, int userId, int id=0)
{
	_food = food;
	_sugar = sugar;
	_stampTime = stampTime;
	_userId = userId;
	_id =id;
}

public string GetFood()
{
	return _food;
}

public float GetSugar()
{
	return _sugar;
}

public DateTime GetStampTime()
{
	return _stampTime;
}
public int GetId()
{
	return _id;
}

public int GetUserId()
{
	return _userId;
}

public static List<LogBook> GetAll()
{
	List<LogBook> allDatas = new List<LogBook> {
	};
	MySqlConnection conn = DB.Connection();
	conn.Open();
	MySqlCommand cmd = conn.CreateCommand();
	cmd.CommandText = @"SELECT * FROM log_book;";
	MySqlDataReader rdr = cmd.ExecuteReader();
	while(rdr.Read())
	{
		int loogBookId = rdr.GetInt32(0);
		string food = rdr.GetString(1);
		DateTime stampTime = rdr.GetDateTime(2);
		float sugar = rdr.GetFloat(3);
		int user_id = rdr.GetInt32(4);
		LogBook newlogBook = new LogBook(food,stampTime,sugar,user_id);
		allDatas.Add(newlogBook);
	}

	conn.Close();
	if ( conn != null) conn.Dispose();
	return allDatas;
}
public void Save()
{
	MySqlConnection conn =DB.Connection();
	conn.Open();
	MySqlCommand cmd = conn.CreateCommand();
	cmd.CommandText = @"INSERT INTO log_book (food, stampTime,sugar, user_id) VALUES (@food,@stampTime,@sugar,@userid);";
	MySqlParameter foodParameter = new MySqlParameter ("@food",this._food);
	cmd.Parameters.Add(foodParameter);
	MySqlParameter stampTimeParameter = new MySqlParameter ("@stampTime",this._stampTime);
	cmd.Parameters.Add(stampTimeParameter);
	MySqlParameter sugarParameter = new MySqlParameter ("@sugar",this._sugar);
	cmd.Parameters.Add(sugarParameter);
	MySqlParameter userParameter = new MySqlParameter ("@userid",this._userId);
	cmd.Parameters.Add(userParameter);
	cmd.ExecuteNonQuery();
	_id = (int)cmd.LastInsertedId;
	conn.Close();
	if( conn != null) conn.Dispose();
}
public void Edit(string newFood, DateTime newStampTime)
{
	MySqlConnection conn = DB.Connection();
	conn.Open();
	MySqlCommand cmd = conn.CreateCommand();
	cmd.CommandText = @"UPDATE log_book SET food = @newfood WHERE id = @searchId;";

	MySqlParameter searchId = new MySqlParameter();
	searchId.ParameterName = "@searchId";
	searchId.Value = _id;
	cmd.Parameters.Add(searchId);

	MySqlParameter food = new MySqlParameter("@newfood",newFood);
	cmd.Parameters.Add(food);
	cmd.ExecuteNonQuery();

	MySqlCommand mycmd = conn.CreateCommand();
	mycmd.CommandText = @"UPDATE log_book SET stampTime = @newStampTime WHERE id = @searchId;";

	searchId = new MySqlParameter();
	searchId.ParameterName = "@searchId";
	searchId.Value = _id;
	mycmd.Parameters.Add(searchId);

	MySqlParameter stampTime = new MySqlParameter("@newStampTime",newStampTime);
	cmd.Parameters.Add(stampTime);
	mycmd.ExecuteNonQuery();

	_food = newFood;
	_stampTime = newStampTime;


	conn.Close();
	if (conn != null) conn.Dispose();

}

}
}
