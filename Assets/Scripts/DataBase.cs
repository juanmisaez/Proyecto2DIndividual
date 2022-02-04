using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;

public static class DataBase
{
    private static string dbName = "URI=file:WinnersDataBase.db";

    public static void CreateDB()
    {
        using (SqliteConnection connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (SqliteCommand command = connection.CreateCommand())
            {
                command.CommandText = "CREATE TABLE IF NOT EXISTS winners (name VARCHAR(10));";
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
    }

    public static void AddToDB(string playerName)
    {
        using (SqliteConnection connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (SqliteCommand command = connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO winners (name) VALUES ('" + playerName + "');";
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
    }

    public static string WriteNames()
    {
        string names = "";

        using (SqliteConnection connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (SqliteCommand command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM winners;";

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        names += reader["name"] + "\n";
                    }
                    reader.Close();
                }                
            }
            connection.Close();
        }
        return names;
    }
}