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
private DateTime _stampTimeBreakfast;
private DateTime _stampTimeLunch;
private DateTime _stampTimeDinner;
private DateTime _stampTimeSnack;
private float _carbBreakfast;
private float _carbLunch;
private float _carbDinner;
private float _carbSnack;

private int _id;
private int _userId;

public LogBook (string breakfastFood, string lunchFood, string dinnerFood, string snackFood, DateTime stampTimeBreakfast, DateTime stampTimeLunch, DateTime stampTimeDinner, DateTime stampTimeSnack, float breakfastSugar, float lunchSugar, float dinnerSugar, float snackSugar, float carbBreakfast, float carbLunch, float carbDinner, float carbSnack, int userId, int id=0)
{
	_breakfastFood = breakfastFood;
	_lunchFood = lunchFood;
	_dinnerFood = dinnerFood;
	_snackFood = snackFood;
	_stampTimeBreakfast = stampTimeBreakfast;
	_stampTimeLunch = stampTimeLunch;
	_stampTimeDinner= stampTimeDinner;
	_stampTimeSnack = stampTimeSnack;
	_breakfastSugar = breakfastSugar;
	_lunchSugar = lunchSugar;
	_dinnerSugar = dinnerSugar;
	_snackSugar = snackSugar;
	_carbBreakfast = carbBreakfast;
	_carbLunch = carbLunch;
	_carbDinner = carbDinner;
	_carbSnack = carbSnack;
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

public float GetBreakfastCarb()
{
	return _carbBreakfast;
}

public float GetLunchCarb()
{
	return _carbLunch;
}

public float GetDinnerCarb()
{
	return _carbDinner;
}

public float GetSnackCarb()
{
	return _carbSnack;
}

public DateTime GetBreakfastStampTime()
{
	return _stampTimeBreakfast;
}

public DateTime GetLunchStampTime()
{
	return _stampTimeLunch;
}

public DateTime GetDinnerStampTime()
{
	return _stampTimeDinner;
}

public DateTime GetSnackStampTime()
{
	return _stampTimeSnack;
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
		string breakfastFood = rdr.GetString(1);
		string lunchFood = rdr.GetString(2);
		string dinnerFood = rdr.GetString(3);
		string snackFood = rdr.GetString(4);
		DateTime stampTimeB = rdr.GetDateTime(5);
		DateTime stampTimeL = rdr.GetDateTime(6);
		DateTime stampTimeD = rdr.GetDateTime(7);
		DateTime stampTimeS = rdr.GetDateTime(8);
		float breakfastSugar = rdr.GetFloat(9);
		float lunchSugar = rdr.GetFloat(10);
		float dinnerSugar = rdr.GetFloat(11);
		float snackSugar = rdr.GetFloat(12);
		float breakfastCarb = rdr.GetFloat(13);
		float lunchCarb = rdr.GetFloat(14);
		float dinnerCarb = rdr.GetFloat(15);
		float snackCarb = rdr.GetFloat(16);
		int user_id = rdr.GetInt32(17);
		LogBook newlogBook = new LogBook(breakfastFood, lunchFood, dinnerFood, snackFood, stampTimeB, stampTimeL, stampTimeD, stampTimeS, breakfastSugar, lunchSugar, dinnerSugar, snackSugar, breakfastCarb, lunchCarb, dinnerCarb, snackCarb, user_id);
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
	cmd.CommandText = @"INSERT INTO log_book (breakfastFood, lunchFood, dinnerFood, snackFood, stampTimeBreakfast, stampTimeLunch, stampTimeDinner, stampTimeSnack, breakfastSugar, lunchSugar, dinnerSugar, snackSugar, carbBreakfast, carbLunch, carbDinner, carbSnack, user_id) VALUES (@breakfastFood, @lunchFood, @dinnerFood, @snackFood, @stampTimeBreakfast, @stampTimeLunch, @stampTimeDinner, @stampTimeSnack, @breakfastSugar, @lunchSugar, @dinnerSugar, @snackSugar, @carbBreakfast, @carbLunch, @carbDinner, @carbSnack, @user_id);";
	MySqlParameter breakfastFoodParameter = new MySqlParameter ("@breakfastFood",this._breakfastFood);
	cmd.Parameters.Add(breakfastFoodParameter);
	MySqlParameter lunchFoodParameter = new MySqlParameter ("@lunchFood",this._lunchFood);
	cmd.Parameters.Add(lunchFoodParameter);
	MySqlParameter dinnerFoodParameter = new MySqlParameter ("@dinnerFood",this._dinnerFood);
	cmd.Parameters.Add(dinnerFoodParameter);
	MySqlParameter snackFoodParameter = new MySqlParameter ("@snackFood",this._snackFood);
	cmd.Parameters.Add(snackFoodParameter);
	MySqlParameter stampTimeBreakfastParameter = new MySqlParameter ("@stampTimeBreakfast",this._stampTimeBreakfast);
	cmd.Parameters.Add(stampTimeBreakfastParameter);
	MySqlParameter stampTimeLunchParameter = new MySqlParameter ("@stampTimeLunch",this._stampTimeLunch);
	cmd.Parameters.Add(stampTimeLunchParameter);
	MySqlParameter stampTimeDinnerParameter = new MySqlParameter ("@stampTimeDinner",this._stampTimeDinner);
	cmd.Parameters.Add(stampTimeDinnerParameter);
	MySqlParameter stampTimeSnackParameter = new MySqlParameter ("@stampTimeSnack",this._stampTimeSnack);
	cmd.Parameters.Add(stampTimeSnackParameter);
	MySqlParameter breakfastSugarParameter = new MySqlParameter ("@breakfastSugar",this._breakfastSugar);
	cmd.Parameters.Add(breakfastSugarParameter);
	MySqlParameter lunchSugarParameter = new MySqlParameter ("@lunchSugar",this._lunchSugar);
	cmd.Parameters.Add(lunchSugarParameter);
	MySqlParameter dinnerSugarParameter = new MySqlParameter ("@dinnerSugar",this._dinnerSugar);
	cmd.Parameters.Add(dinnerSugarParameter);
	MySqlParameter snackSugarParameter = new MySqlParameter ("@snackSugar",this._snackSugar);
	cmd.Parameters.Add(snackSugarParameter);
	MySqlParameter carbBreakfastParameter = new MySqlParameter ("@carbBreakfast",this._carbBreakfast);
	cmd.Parameters.Add(carbBreakfastParameter);
	MySqlParameter carbLunchParameter = new MySqlParameter ("@carbLunch",this._carbLunch);
	cmd.Parameters.Add(carbLunchParameter);
	MySqlParameter carbDinnerParameter = new MySqlParameter ("@carbDinner",this._carbDinner);
	cmd.Parameters.Add(carbDinnerParameter);
	MySqlParameter carbSnackParameter = new MySqlParameter ("@carbSnack",this._carbSnack);
	cmd.Parameters.Add(carbSnackParameter);
	MySqlParameter userParameter = new MySqlParameter ("@user_id",this._userId);
	cmd.Parameters.Add(userParameter);
	cmd.ExecuteNonQuery();
	_id = (int)cmd.LastInsertedId;
	conn.Close();
	if( conn != null) conn.Dispose();
}

public void Delete()
{
	MySqlConnection conn = DB.Connection();
	conn.Open();
	MySqlCommand cmd = new MySqlCommand("DELETE FROM log_book WHERE user_id = @SearchId;", conn);
	MySqlParameter SearchIdParameter = new MySqlParameter();
	SearchIdParameter.ParameterName = "@SearchId";
	SearchIdParameter.Value = this.GetId();
	cmd.Parameters.Add(SearchIdParameter);
	cmd.ExecuteNonQuery();
	if (conn != null)
	{
		conn.Close();
	}
}

public void DeleteBreakfast()
{
	MySqlConnection conn = DB.Connection();
	conn.Open();
	MySqlCommand cmd = new MySqlCommand("DELETE FROM log_book WHERE user_id = @SearchId , breakfastFood = @breakfastFood , stampTimeBreakfast = @stampTimeBreakfast , breakfastSugar = @breakfastSugar , carbBreakfast = @carbBreakfast;", conn);
	MySqlParameter SearchIdParameter = new MySqlParameter();
	SearchIdParameter.ParameterName = "@SearchId";
	SearchIdParameter.Value = this.GetId();
	cmd.Parameters.Add(SearchIdParameter);
	MySqlParameter breakfastFoodParameter = new MySqlParameter();
	breakfastFoodParameter.ParameterName = "@breakfastFood";
	breakfastFoodParameter.Value = this.GetBreakfastFood();
	cmd.Parameters.Add(breakfastFoodParameter);
	MySqlParameter stampTimeBreakfastParameter = new MySqlParameter();
	stampTimeBreakfastParameter.ParameterName = "@stampTimeBreakfast";
	stampTimeBreakfastParameter.Value = this.GetBreakfastStampTime();
	cmd.Parameters.Add(stampTimeBreakfastParameter);
	MySqlParameter breakfastSugarParameter = new MySqlParameter();
	breakfastSugarParameter.ParameterName = "@breakfastSugar";
	breakfastSugarParameter.Value = this.GetBreakfastSugar();
	cmd.Parameters.Add(breakfastSugarParameter);
	MySqlParameter carbBreakfastParameter = new MySqlParameter();
	carbBreakfastParameter.ParameterName = "@carbBreakfast";
	carbBreakfastParameter.Value = this.GetBreakfastCarb();
	cmd.Parameters.Add(carbBreakfastParameter);
	cmd.ExecuteNonQuery();
	if (conn != null)
	{
		conn.Close();
	}
}

public void DeleteLunch()
{
	MySqlConnection conn = DB.Connection();
	conn.Open();
	MySqlCommand cmd = new MySqlCommand("DELETE FROM log_book WHERE user_id = @SearchId , lunchFood = @lunchFood , stampTimeLunch = @stampTimeLunch , lunchSugar = @lunchSugar , carbLunch = @carbLunch;", conn);
	MySqlParameter SearchIdParameter = new MySqlParameter();
	SearchIdParameter.ParameterName = "@SearchId";
	SearchIdParameter.Value = this.GetId();
	cmd.Parameters.Add(SearchIdParameter);
	MySqlParameter lunchFoodParameter = new MySqlParameter();
	lunchFoodParameter.ParameterName = "@lunchFood";
	lunchFoodParameter.Value = this.GetLunchFood();
	cmd.Parameters.Add(lunchFoodParameter);
	MySqlParameter stampTimeLunchParameter = new MySqlParameter();
	stampTimeLunchParameter.ParameterName = "@stampTimeLunch";
	stampTimeLunchParameter.Value = this.GetLunchStampTime();
	cmd.Parameters.Add(stampTimeLunchParameter);
	MySqlParameter lunchSugarParameter = new MySqlParameter();
	lunchSugarParameter.ParameterName = "@lunchSugar";
	lunchSugarParameter.Value = this.GetLunchSugar();
	cmd.Parameters.Add(lunchSugarParameter);
	MySqlParameter carbLunchParameter = new MySqlParameter();
	carbLunchParameter.ParameterName = "@carbLunch";
	carbLunchParameter.Value = this.GetLunchCarb();
	cmd.Parameters.Add(carbLunchParameter);
	cmd.ExecuteNonQuery();
	if (conn != null)
	{
		conn.Close();
	}
}

public void DeleteDinner()
{
	MySqlConnection conn = DB.Connection();
	conn.Open();
	MySqlCommand cmd = new MySqlCommand("DELETE FROM log_book WHERE user_id = @SearchId , dinnerFood = @dinnerFood , stampTimeDinner = @stampTimeDinner , dinnerSugar = @dinnerSugar , carbDinner = @carbDinner;", conn);
	MySqlParameter SearchIdParameter = new MySqlParameter();
	SearchIdParameter.ParameterName = "@SearchId";
	SearchIdParameter.Value = this.GetId();
	cmd.Parameters.Add(SearchIdParameter);
	MySqlParameter dinnerFoodParameter = new MySqlParameter();
	dinnerFoodParameter.ParameterName = "@dinnerFood";
	dinnerFoodParameter.Value = this.GetDinnerFood();
	cmd.Parameters.Add(dinnerFoodParameter);
	MySqlParameter stampTimeDinnerParameter = new MySqlParameter();
	stampTimeDinnerParameter.ParameterName = "@stampTimeDinner";
	stampTimeDinnerParameter.Value = this.GetDinnerStampTime();
	cmd.Parameters.Add(stampTimeDinnerParameter);
	MySqlParameter dinnerSugarParameter = new MySqlParameter();
	dinnerSugarParameter.ParameterName = "@dinnerSugar";
	dinnerSugarParameter.Value = this.GetDinnerSugar();
	cmd.Parameters.Add(dinnerSugarParameter);
	MySqlParameter carbDinnerParameter = new MySqlParameter();
	carbDinnerParameter.ParameterName = "@carbDinner";
	carbDinnerParameter.Value = this.GetDinnerCarb();
	cmd.Parameters.Add(carbDinnerParameter);
	cmd.ExecuteNonQuery();
	if (conn != null)
	{
		conn.Close();
	}
}

public void DeleteSnack()
{
	MySqlConnection conn = DB.Connection();
	conn.Open();
	MySqlCommand cmd = new MySqlCommand("DELETE FROM log_book WHERE user_id = @SearchId , snackFood = @snackFood , stampTimeSnack = @stampTimeSnack , snackSugar = @snackSugar , carbSnack = @carbSnack;", conn);
	MySqlParameter SearchIdParameter = new MySqlParameter();
	SearchIdParameter.ParameterName = "@SearchId";
	SearchIdParameter.Value = this.GetId();
	cmd.Parameters.Add(SearchIdParameter);
	MySqlParameter snackFoodParameter = new MySqlParameter();
	snackFoodParameter.ParameterName = "@snackFood";
	snackFoodParameter.Value = this.GetSnackFood();
	cmd.Parameters.Add(snackFoodParameter);
	MySqlParameter stampTimeSnackParameter = new MySqlParameter();
	stampTimeSnackParameter.ParameterName = "@stampTimeSnack";
	stampTimeSnackParameter.Value = this.GetSnackStampTime();
	cmd.Parameters.Add(stampTimeSnackParameter);
	MySqlParameter snackSugarParameter = new MySqlParameter();
	snackSugarParameter.ParameterName = "@snackSugar";
	snackSugarParameter.Value = this.GetSnackSugar();
	cmd.Parameters.Add(snackSugarParameter);
	MySqlParameter carbSnackParameter = new MySqlParameter();
	carbSnackParameter.ParameterName = "@carbSnack";
	carbSnackParameter.Value = this.GetSnackCarb();
	cmd.Parameters.Add(carbSnackParameter);
	cmd.ExecuteNonQuery();
	if (conn != null)
	{
		conn.Close();
	}
}


/* public void Edit(string newFood, DateTime newStampTime)
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

   }*/

}
}
