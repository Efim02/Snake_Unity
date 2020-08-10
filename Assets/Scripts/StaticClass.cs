using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class StaticClass
{
    
    public static void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/savedGames.gd");
        bf.Serialize(file, Snake.points);
        file.Close();
    }
    public static int Load()
    {
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);
            int x = (int)bf.Deserialize(file);
            file.Close();
            return x;
            
        }
        catch
        {
            return 0;
        }
    }
    
}
