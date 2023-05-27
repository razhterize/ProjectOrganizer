using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading.Tasks;
using System.Windows.Forms;

class Database
{
    private SQLiteConnection connection;
    public Database()
    {
        this.connection = createConnection();
    }
    
    static SQLiteConnection createConnection()
    {
        SQLiteConnection connection;
        connection = new SQLiteConnection("Data Source=database.db;Version=3;New=True;Compress=True");
        try
        {
            connection.Open();
        }
        catch (SQLiteException e)
        {
            Console.WriteLine(e.Message);
        }
        return connection;
    }

    private bool ExecuteNonReturn(string command)
    {
        try
        {
            SQLiteCommand cmd;
            cmd = connection.CreateCommand();
            cmd.CommandText = command;
            cmd.ExecuteNonQuery();
            return true;
        }
        catch (SQLiteException e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }

    private void NewDatabase()
    {
        // main table to store projects and it's path
        string command = "CREATE TABLE projects (name TEXT, path TEXT)";
        ExecuteNonReturn(command);
        // another table to store TODOs and the file
        command = "CREATE TABLE tasks (project TEXT, file TEXT, todo TEXT)";
        ExecuteNonReturn(command);
    }

    private void AddProjectTask(string projectName, string file, string todo)
    {
        string command = $"INSERT INTO task (project, file, todo) ({projectName}, {file}, {todo})";
        ExecuteNonReturn(command);
    }

    private void CreateProjectTask(string projectName, string file, string task)
    {
        string createTask = $"INSERT INTO {projectName} (file, task) VALUES ({file}, {task})";
        ExecuteNonReturn(createTask);
    }

    public Array GetProjectTask(string projectName)
    {
        SQLiteDataReader reader;
        SQLiteCommand cmd;
        cmd = connection.CreateCommand();
        cmd.CommandText = $"SELECT * from task WHERE project = {projectName}";
        reader = cmd.ExecuteReader();
        string project, file, task;
        string[] values;
        while (reader.Read())
        {
            project = reader.GetString(0);
            file = reader.GetString(1);
            task = reader.GetString(2);
            values = new string[] { project, file, task };
            Console.WriteLine($"project: {project}\nfile: {file}\ntask: {task}");
        }
        return values = new string[] { project, file, task }; ;
    }
}