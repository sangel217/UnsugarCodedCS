using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace UnSugarCodedCS.Models
{
public class LogBook
{
private string _breakfastFood;
private string _lunchFood;
private string _dinnerFood;
private string _snackFood;
private float _breakfastSugar;
private float _lunchSugar;
private float _dinnerSugar;
private float _snackSugar;
private DateTime _stampTime;
private int _id;
private int _userId;

public LogBook (string breakfastFood, string lunchFood, string dinnerFood, string snackFood, DateTime stampTime,float breakfastSugar, float lunchSugar, float dinnerSugar, float snackSugar, int userId, int id=0)
{
	_breakfastFood = breakfastFood;
	_lunchFood = lunchFood;
	_dinnerFood = dinnerFood;
	_snackFood = snackFood;
	_breakfastSugar = breakfastSugar;
	_lunchSugar = lunchSugar;
	_dinnerSugar = dinnerSugar;
	_snackSugar = snackSugar;
	_stampTime = stampTime;
	_userId = userId;
	_id =id;
}

public string GetBreakfastFood()
{
	return _breakfastFood;
}

public string GetLunchFood()
{
	return _lunchFood;
}

public string GetDinnerFood()
{
	return _dinnerFood;
}

public string GetSnackFood()
{
	return _snackFood;
}

public float GetBreakfastSugar()
{
	return _breakfastSugar;
}

public float GetLunchSugar()
{
	return _lunchSugar;
}

public float GetDinnerSugar()
{
	return _dinnerSugar;
}

public float GetSnackSugar()
{
	return _snackSugar;
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
	List<LogBook> allDatas = new List<LogBook> {};
	MySqlConnection conn = DB.Connection();
	conn.Open();
	MySqlCommand cmd = conn.CreateCommand();
	cmd.CommandText = @"SELECT * FROM log_book;";
	MySqlDataReader rdr = cmd.ExecuteReader();
	while(rdr.Read())
	{
		int loogBookId = rdr.GetInt32(0);
		string breakfastFood = rdr.GetString(1);
		string lunchFood = rdr.GetString(2);
		string dinnerFood = rdr.GetString(3);
		string snackFood = rdr.GetString(4);
		DateTime stampTime = rdr.GetDateTime(5);
		float breakfastSugar = rdr.GetFloat(6);
		float lunchSugar = rdr.GetFloat(7);
		float dinnerSugar = rdr.GetFloat(8);
		float snackSugar = rdr.GetFloat(9);
		int user_id = rdr.GetInt32(10);
		LogBook newlogBook = new LogBook(breakfastFood, lunchFood, dinnerFood, snackFood, stampTime, breakfastSugar, lunchSugar, dinnerSugar, snackSugar, user_id);
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
	cmd.CommandText = @"INSERT INTO log_book (breakfastFood, lunchFood, dinnerFood, snackFood, stampTime, breakfastSugar, lunchSugar, dinnerSugar, snackSugar, user_id) VALUES (@breakfastFood, @lunchFood, @dinnerFood, @snackFood, @stampTime, @breakfastSugar, @lunchSugar, @dinnerSugar, @snackSugar, @user_id);";
	MySqlParameter breakfastFoodParameter = new MySqlParameter ("@breakfastFood",this._breakfastFood);
	cmd.Parameters.Add(breakfastFoodParameter);
	MySqlParameter lunchFoodParameter = new MySqlParameter ("@lunchFood",this._lunchFood);
	cmd.Parameters.Add(lunchFoodParameter);
	MySqlParameter dinnerFoodParameter = new MySqlParameter ("@dinnerFood",this._dinnerFood);
	cmd.Parameters.Add(dinnerFoodParameter);
	MySqlParameter snackFoodParameter = new MySqlParameter ("@snackFood",this._snackFood);
	cmd.Parameters.Add(snackFoodParameter);
	MySqlParameter stampTimeParameter = new MySqlParameter ("@stampTime",this._stampTime);
	cmd.Parameters.Add(stampTimeParameter);
	MySqlParameter breakfastSugarParameter = new MySqlParameter ("@breakfastSugar",this._breakfastSugar);
	cmd.Parameters.Add(breakfastSugarParameter);
	MySqlParameter lunchSugarParameter = new MySqlParameter ("@lunchSugar",this._lunchSugar);
	cmd.Parameters.Add(lunchSugarParameter);
	MySqlParameter dinnerSugarParameter = new MySqlParameter ("@dinnerSugar",this._dinnerSugar);
	cmd.Parameters.Add(dinnerSugarParameter);
	MySqlParameter snackSugarParameter = new MySqlParameter ("@snackSugar",this._snackSugar);
	cmd.Parameters.Add(snackSugarParameter);
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
