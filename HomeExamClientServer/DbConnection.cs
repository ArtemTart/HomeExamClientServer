using log4net;
using log4net.Config;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HomeExamClientServer
{
    public class DbConnection
    {
        private  SQLiteConnection myConnection;
        int returnValue = 0;
        string query = null;
        
        public  SQLiteConnection MyConnection()
        {
            if (!File.Exists("./database.sqlite3"))
            {
                try
                {
                    MyLogger.Log("trying to create DB ");
                    SQLiteConnection.CreateFile("database.sqlite3");//creating the DB   
                    MyLogger.Log("trying to create table ");
                    CreateTable();  // creating the table ''
                }
                catch (SQLiteException exc)
                {
                    SQLiteErrorCode sqliteError = (SQLiteErrorCode)exc.ErrorCode;
                    MyLogger.Log(exc.ToString());
                }

                MyLogger.Log("DB created ! ");
            }

            try
            {
                MyLogger.Log("trying connect to DB ");
                myConnection = new SQLiteConnection("Data Source=database.sqlite3");
            }
            catch (SQLiteException exc)
            {
                SQLiteErrorCode sqliteError = (SQLiteErrorCode)exc.ErrorCode;
                MyLogger.Log(exc.ToString());

            }
            return myConnection;
        }

        public void OpenConnection()
        {
            MyLogger.Log("checking if connection open");
            if (myConnection.State != ConnectionState.Open)
            {
                MyLogger.Log("opening connection");
                myConnection.Open();
            }
        }

        public int checkAdmin(string name,string password) // check if use is admin 
        {
            int result = 0;
            string query = "select count(*) from users where name =@name and password =@password and isAdmin='yes'";
            try
            {
                using (SQLiteCommand myCommand = new SQLiteCommand(query, MyConnection()))
                {
                    OpenConnection();
                    myCommand.Parameters.AddWithValue("@name", name);
                    myCommand.Parameters.AddWithValue("@password", password);
                    result = Convert.ToInt32(myCommand.ExecuteScalar());
                    return result;
                }
            }
            catch (SQLiteException exc)
            {
                SQLiteErrorCode sqliteError = (SQLiteErrorCode)exc.ErrorCode;
                MyLogger.Log(exc.ToString());
            }
            return result;
           
        }
       

        public  void CloseConnection()
        {
            MyLogger.Log("checking if connection closed");
            if (myConnection.State != ConnectionState.Closed)
            {
                MyLogger.Log("closing connection");
                myConnection.Close();
            }
        }
        public async void CreateTable()
        {
           await MyLogger.Log("creating table if not exist");
            // CREATE NEW TABLE
            query = @"CREATE TABLE IF NOT EXISTS
                             [users] (
                             [id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                             [name] TEXT,
                             [password] TEXT,
                             [pathToDir] TEXT)";
            try
            {
                using (SQLiteCommand myCommand = new SQLiteCommand(query,MyConnection()))
                {
                    OpenConnection();
                    myCommand.CommandText = query;
                    myCommand.ExecuteNonQuery();
                    CloseConnection();
                }
                MyLogger.Log("Table Created ");
            }
            catch (SQLiteException exc)
            {
                SQLiteErrorCode sqliteError = (SQLiteErrorCode)exc.ErrorCode;
                MyLogger.Log(exc.ToString());
            }

        }
        public void InsertNewUsers(string name, string password, string path)
        {
            MyLogger.Log($"inserting new user name : {name} password : {password} path : {path}");
            // INSERT INTO DATABASE
            query = "INSERT INTO users (name, password, pathToDir) VALUES (@name, @password, @path)";

            try
            {
                using (SQLiteCommand myCommand = new SQLiteCommand(query, MyConnection()))
                {
                    OpenConnection();
                    myCommand.Parameters.AddWithValue("@name", name);
                    myCommand.Parameters.AddWithValue("@password", password);
                    myCommand.Parameters.AddWithValue("@path", path);
                    returnValue = myCommand.ExecuteNonQuery();
                    CloseConnection();
                    Console.WriteLine("Rows Added : {0}", returnValue);
                }
                MyLogger.Log($"Inserting of {name} and {password} and {path} is completed");
            }
            catch (SQLiteException exc)
            {
                SQLiteErrorCode sqliteError = (SQLiteErrorCode)exc.ErrorCode;
                MyLogger.Log(exc.ToString());
            }
        }
        public async void DeleteByUserName(string userName) // delete user by provided user name 
        {
           await MyLogger.Log("Deleting from table by username");
            query = "DELETE FROM users Where name = @name";
            try
            {
                using (SQLiteCommand myCommand = new SQLiteCommand(query, MyConnection()))
                {
                    OpenConnection();
                    myCommand.Parameters.AddWithValue("@name", userName);
                    myCommand.ExecuteNonQuery();
                    Debug.WriteLine("user deleted");
                    CloseConnection();
                }
            }
            catch (SQLiteException exc)
            {
                SQLiteErrorCode sqliteError = (SQLiteErrorCode)exc.ErrorCode;
                MyLogger.Log(exc.ToString());
            }
        }
        public async void updatePwd(string userName ,string newPass)// update user password 
        {
            await MyLogger.Log($"updating PWD by username : {userName} and PWD {newPass}");
            query = "UPDATE users SET password = @password WHERE name = @name";
            try
            {
                using (SQLiteCommand myCommand = new SQLiteCommand(query, MyConnection()))
                {
                    OpenConnection();
                    myCommand.Parameters.AddWithValue("@password", newPass);
                    myCommand.Parameters.AddWithValue("@name", userName);
                    try
                    {
                        returnValue = myCommand.ExecuteNonQuery();
                    }
                    catch (SQLiteException exc)
                    {
                        SQLiteErrorCode sqliteError = (SQLiteErrorCode)exc.ErrorCode;
                    }
                  
                    MyLogger.Log("pwd updated");
                    CloseConnection();
                }
            }
            catch (SQLiteException exc)
            {
                SQLiteErrorCode sqliteError = (SQLiteErrorCode)exc.ErrorCode;
                MyLogger.Log(exc.ToString());
            }
        }
    

        public string findUserForAuth(string username,string password)//check if the user exissts  and retrive his path to directory
        {
            MyLogger.Log($"qeuring by user name and password for authorization");
            string result = null;
            query = "SELECT pathToDir FROM users WHERE name = @name and password=@password" ;
            try
            {
                using (SQLiteCommand myCommand = new SQLiteCommand(query, MyConnection()))
                {
                    OpenConnection();
                    myCommand.Parameters.AddWithValue("@name", username);
                    myCommand.Parameters.AddWithValue("@password", password);
                    result = myCommand.ExecuteScalar().ToString();
                    return result;
                }
            }
            catch (SQLiteException exc)
            {
                SQLiteErrorCode sqliteError = (SQLiteErrorCode)exc.ErrorCode;
                MyLogger.Log(exc.ToString());
            }
            return result;
        }
    }

}

