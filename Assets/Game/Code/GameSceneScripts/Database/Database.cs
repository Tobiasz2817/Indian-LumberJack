using Mono.Data.Sqlite; 
using UnityEngine; 
public class Database : MonoBehaviour 
{
    private SqliteConnection sqliteConnection; 
    private string path = "gamecollector.sqlite"; 
    void Awake() 
    {
        CreateDatabase();
    } 
    private void InsertDatabaseValues(string commandExecute) 
    { 
        if (sqliteConnection == null) 
        { 
            Debug.Log("Sqlite null"); 
            return; 
        } 
        sqliteConnection.Open(); 
        SqliteCommand command = new SqliteCommand(commandExecute, sqliteConnection); 
        command.ExecuteNonQuery(); 
         
        sqliteConnection.Close(); 
    }

    public int GetScore(int currentDifficulty)
    {
        string commandExecute = $"select score_player_{((Difficulty)currentDifficulty).ToString()} from score";
        
        if (sqliteConnection == null) return -1; 
        sqliteConnection.Open(); 
        string text = ""; 
        SqliteCommand command = new SqliteCommand(commandExecute,sqliteConnection); 
        SqliteDataReader reader = command.ExecuteReader(); 
         
        while (reader.Read()) 
        { 
            text += reader[$"score_player_{((Difficulty)currentDifficulty).ToString()}"]; 
        } 
        
        reader.Close(); 
        sqliteConnection.Close();

        return int.Parse(text);
    }

    public void UpdateScore(int score, int currentDifficulty)
    {
        string commandExecute = $"update score set score_player_{((Difficulty)currentDifficulty).ToString()} = {score.ToString()} where id_score = '1'";
        
        if (sqliteConnection == null) return; 
        
        sqliteConnection.Open();
        SqliteCommand command = new SqliteCommand(commandExecute,sqliteConnection); 
        SqliteDataReader reader = command.ExecuteReader();

        reader.Close(); 
        sqliteConnection.Close();
    }
    private void CreateDatabase() 
    { 
        if (System.IO.File.Exists(path)) 
        { 
            sqliteConnection = new SqliteConnection($"Data Source={path};Version=3;"); 
             
            return; 
        } 
         
        SqliteConnection.CreateFile(path); 
         
        sqliteConnection = new SqliteConnection($"Data Source={path};Version=3;"); 
        sqliteConnection.Open(); 
             
        string addScore = @" 
        create table score ( 
        id_score              INTEGER              not null, 
        score_player_Easy                INTEGER              not null, 
        score_player_Medium                INTEGER              not null, 
        score_player_Hard                INTEGER              not null, 
        primary key (id_score) 
        );"; 
        SqliteCommand addClassesCommand = new SqliteCommand(addScore, sqliteConnection); 
        addClassesCommand.ExecuteNonQuery(); 
        sqliteConnection.Close(); 
         
         
        string sql = "insert into score values ('1','0','0','0')"; 
        InsertDatabaseValues(sql);
    } 
}