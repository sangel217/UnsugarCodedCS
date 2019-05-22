
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace UnSugarCodedCS.Models
{
public class Login
{
private string _userName;
private string _userEmail;
private int _userHeight;
private int _userWeight;
private int _id;

public Login(string userName, string userEmail, int userHeight, int userWeight, int id = 0)
{
	_userName = userName;
	_userEmail = userEmail;
	_userHeight = userHeight;
	_userWeight = userWeight;
	_id = id;
}

public string GetName()
{
	return _userName;
}

public string GetEmail()
{
	return _userEmail;
}

public int GetHeight()
{
	return _userHeight;
}

public int GetWeight()
{
	return _userWeight;
}

public int GetId()
{
	return _id;
}

public override int GetHashCode()
{
	return this.GetId().GetHashCode();
}

public override bool Equals(System.Object otherLogin)
{
	if (!(otherLogin is Login))
	{
		return false;
	}
	else
	{
		Login newLogin = (Login) otherLogin;
		bool idEquality = this.GetId().Equals(newLogin.GetId());
		bool nameEquality = this.GetName().Equals(newLogin.GetName());
		bool emailEquality = this.GetEmail().Equals(newLogin.GetEmail());
		bool heightEquality = this.GetHeight().Equals(newLogin.GetHeight());
		bool weightEquality = this.GetWeight().Equals(newLogin.GetWeight());
		return (idEquality && nameEquality && emailEquality && heightEquality && weightEquality);
	}
}

public static List<Login> GetAll()
{
	List<Login> allLogins = new List<Login> {
	};
	MySqlConnection conn = DB.Connection();
	conn.Open();
	var cmd = conn.CreateCommand() as MySqlCommand;
	cmd.CommandText = @"SELECT * FROM users;";
	var rdr = cmd.ExecuteReader() as MySqlDataReader;
	while(rdr.Read())
	{
		int LoginId = rdr.GetInt32(0);
		string LoginName = rdr.GetString(1);
		string LoginEmail = rdr.GetString(2);
		int LoginHeight = rdr.GetInt32(3);
		int LoginWeight = rdr.GetInt32(4);
		Login newLogin = new Login(LoginName, LoginEmail, LoginHeight, LoginWeight, LoginId);
		allLogins.Add(newLogin);
	}
	conn.Close();
	if (conn != null)
	{
		conn.Dispose();
	}
	return allLogins;
}


public static void ClearAll()
{
	MySqlConnection conn = DB.Connection();
	conn.Open();
	var cmd = conn.CreateCommand() as MySqlCommand;
	cmd.CommandText = @"DELETE FROM users;";
	cmd.ExecuteNonQuery();
	conn.Close();
	if (conn != null)
	{
		conn.Dispose();
	}
}

public void Save()
{
	MySqlConnection conn = DB.Connection();
	conn.Open();
	var cmd = conn.CreateCommand() as MySqlCommand;
	cmd.CommandText = @"INSERT INTO users (userName, userEmail, userHeight, userWeight) VALUES (@userName, @userEmail, @userHeight, @userWeight);";
	MySqlParameter userName = new MySqlParameter();
	userName.ParameterName = "@userName";
	userName.Value = this._userName;
	cmd.Parameters.Add(userName);
	MySqlParameter userEmail = new MySqlParameter();
	userEmail.ParameterName = "@userEmail";
	userEmail.Value = this._userEmail;
	cmd.Parameters.Add(userEmail);
	MySqlParameter userHeight = new MySqlParameter();
	userHeight.ParameterName = "@userHeight";
	userHeight.Value = this._userHeight;
	cmd.Parameters.Add(userHeight);
	MySqlParameter userWeight = new MySqlParameter();
	userWeight.ParameterName = "@userWeight";
	userWeight.Value = this._userWeight;
	cmd.Parameters.Add(userWeight);
	cmd.ExecuteNonQuery();
	_id = (int) cmd.LastInsertedId;
	conn.Close();
	if (conn != null)
	{
		conn.Dispose();
	}
}

public static Login Find(int id)
{
	MySqlConnection conn = DB.Connection();
	conn.Open();
	var cmd = conn.CreateCommand() as MySqlCommand;
	cmd.CommandText = @"SELECT * FROM users WHERE id = (@searchId);";
	MySqlParameter searchId = new MySqlParameter();
	searchId.ParameterName = "@searchId";
	searchId.Value = id;
	cmd.Parameters.Add(searchId);
	var rdr = cmd.ExecuteReader() as MySqlDataReader;
	int LoginId = 0;
	string LoginName = "";
	string LoginEmail = "";
	int LoginHeight = 0;
	int LoginWeight = 0;
	while(rdr.Read())
	{
		LoginId = rdr.GetInt32(0);
		LoginName = rdr.GetString(1);
		LoginEmail = rdr.GetString(2);
		LoginHeight = rdr.GetInt32(3);
		LoginWeight = rdr.GetInt32(4);
	}
	Login newLogin = new Login(LoginName, LoginEmail, LoginHeight, LoginWeight, LoginId);
	conn.Close();
	if (conn != null)
	{
		conn.Dispose();
	}
	return newLogin;
}

public void Edit(string newName, string newEmail, int newHeight, int newWeight)
{
	MySqlConnection conn = DB.Connection();
	conn.Open();
	var cmd = conn.CreateCommand() as MySqlCommand;
	cmd.CommandText = @"UPDATE users SET userName = @newName, userEmail = @newEmail, userHeight = @newHeight, userWeight = @newWeight WHERE id = @searchId;";
	MySqlParameter searchId = new MySqlParameter();
	searchId.ParameterName = "@searchId";
	searchId.Value = _id;
	cmd.Parameters.Add(searchId);
	MySqlParameter userName = new MySqlParameter();
	userName.ParameterName = "@newName";
	userName.Value = newName;
	cmd.Parameters.Add(userName);
	MySqlParameter userEmail = new MySqlParameter();
	userEmail.ParameterName = "@newEmail";
	userEmail.Value = newEmail;
	cmd.Parameters.Add(userEmail);
	MySqlParameter userHeight = new MySqlParameter();
	userHeight.ParameterName = "@newHeight";
	userHeight.Value = newHeight;
	cmd.Parameters.Add(userHeight);
	MySqlParameter userWeight = new MySqlParameter();
	userWeight.ParameterName = "@newWeight";
	userWeight.Value = newWeight;
	cmd.Parameters.Add(userWeight);
	cmd.ExecuteNonQuery();
	_userName = newName;
	_userEmail = newEmail;
	_userHeight = newHeight;
	_userWeight = newWeight;
	conn.Close();
	if (conn != null)
	{
		conn.Dispose();
	}
}

public void Delete()
{
	MySqlConnection conn = DB.Connection();
	conn.Open();
	MySqlCommand cmd = new MySqlCommand("DELETE FROM users WHERE id = @LoginId; DELETE FROM log_book WHERE user_id = @LoginId", conn);
	MySqlParameter loginIdParameter = new MySqlParameter();
	loginIdParameter.ParameterName = "@LoginId";
	loginIdParameter.Value = this.GetId();
	cmd.Parameters.Add(loginIdParameter);
	cmd.ExecuteNonQuery();
	if (conn != null)
	{
		conn.Close();
	}
}

public List<Breakfast> GetBreakfasts()
{
    List<Breakfast> allLoginBreakfasts = new List<Breakfast> {
    };
    MySqlConnection conn = DB.Connection();
    conn.Open();
    var cmd = conn.CreateCommand() as MySqlCommand;
    cmd.CommandText = @"SELECT * FROM breakfast WHERE user_id = @user_id;";
    MySqlParameter userId = new MySqlParameter();
    userId.ParameterName = "@user_id";
    userId.Value = this._id;
    cmd.Parameters.Add(userId);
    var rdr = cmd.ExecuteReader() as MySqlDataReader;
    while(rdr.Read())
    {
			int breakfastId = rdr.GetInt32(0);
			string food = rdr.GetString(1);
			DateTime stampTime = rdr.GetDateTime(2);
			float sugar = rdr.GetFloat(3);
			float carb = rdr.GetFloat(4);
			int user_id = rdr.GetInt32(5);
			Breakfast newBreakfast = new Breakfast(food, stampTime, sugar, carb, user_id);

      allLoginBreakfasts.Add(newBreakfast);
    }
    conn.Close();
    if (conn != null)
    {
            conn.Dispose();
    }
    return allLoginBreakfasts;
	}

	public List<Lunch> GetLunchs()
	{
	    List<Lunch> allLoginLunchs = new List<Lunch> {
	    };
	    MySqlConnection conn = DB.Connection();
	    conn.Open();
	    var cmd = conn.CreateCommand() as MySqlCommand;
	    cmd.CommandText = @"SELECT * FROM lunch WHERE user_id = @user_id;";
	    MySqlParameter userId = new MySqlParameter();
	    userId.ParameterName = "@user_id";
	    userId.Value = this._id;
	    cmd.Parameters.Add(userId);
	    var rdr = cmd.ExecuteReader() as MySqlDataReader;
	    while(rdr.Read())
	    {
				int lunchId = rdr.GetInt32(0);
				string food = rdr.GetString(1);
				DateTime stampTime = rdr.GetDateTime(2);
				float sugar = rdr.GetFloat(3);
				float carb = rdr.GetFloat(4);
				int user_id = rdr.GetInt32(5);
				Lunch newLunch = new Lunch(food, stampTime, sugar, carb, user_id);

	      allLoginLunchs.Add(newLunch);
	    }
	    conn.Close();
	    if (conn != null)
	    {
	            conn.Dispose();
	    }
	    return allLoginLunchs;
		}

		public List<Dinner> GetDinners()
		{
		    List<Dinner> allLoginDinners = new List<Dinner> {
		    };
		    MySqlConnection conn = DB.Connection();
		    conn.Open();
		    var cmd = conn.CreateCommand() as MySqlCommand;
		    cmd.CommandText = @"SELECT * FROM dinner WHERE user_id = @user_id;";
		    MySqlParameter userId = new MySqlParameter();
		    userId.ParameterName = "@user_id";
		    userId.Value = this._id;
		    cmd.Parameters.Add(userId);
		    var rdr = cmd.ExecuteReader() as MySqlDataReader;
		    while(rdr.Read())
		    {
					int dinnerId = rdr.GetInt32(0);
					string food = rdr.GetString(1);
					DateTime stampTime = rdr.GetDateTime(2);
					float sugar = rdr.GetFloat(3);
					float carb = rdr.GetFloat(4);
					int user_id = rdr.GetInt32(5);
					Dinner newDinner = new Dinner(food, stampTime, sugar, carb, user_id);

		      allLoginDinners.Add(newDinner);
		    }
		    conn.Close();
		    if (conn != null)
		    {
		            conn.Dispose();
		    }
		    return allLoginDinners;
			}

			public List<Snack> GetSnacks()
			{
			    List<Snack> allLoginSnacks = new List<Snack> {
			    };
			    MySqlConnection conn = DB.Connection();
			    conn.Open();
			    var cmd = conn.CreateCommand() as MySqlCommand;
			    cmd.CommandText = @"SELECT * FROM snack WHERE user_id = @user_id;";
			    MySqlParameter userId = new MySqlParameter();
			    userId.ParameterName = "@user_id";
			    userId.Value = this._id;
			    cmd.Parameters.Add(userId);
			    var rdr = cmd.ExecuteReader() as MySqlDataReader;
			    while(rdr.Read())
			    {
						int snackId = rdr.GetInt32(0);
						string food = rdr.GetString(1);
						DateTime stampTime = rdr.GetDateTime(2);
						float sugar = rdr.GetFloat(3);
						float carb = rdr.GetFloat(4);
						int user_id = rdr.GetInt32(5);
						Snack newSnack = new Snack(food, stampTime, sugar, carb, user_id);

			      allLoginSnacks.Add(newSnack);
			    }
			    conn.Close();
			    if (conn != null)
			    {
			            conn.Dispose();
			    }
			    return allLoginSnacks;
				}

}
}
