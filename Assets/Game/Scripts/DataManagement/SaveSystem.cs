using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public static class SaveSystem 
{
    public static void Save(object saveData)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        if (Directory.Exists("Assets/Resources/PlayerData"))
        {
            Directory.CreateDirectory("Assets/Resources/PlayerData");

        }
        string path = "Assets/Resources/PlayerData";

        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, saveData);

        stream.Close();
    }

    public static object Load()
    {
        string path = "Assets/Resources/PlayerData";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();

            FileStream stream = new FileStream(path, FileMode.Open);

            object data = formatter.Deserialize(stream);

            stream.Close();

            return data;
        }
        else
        {
            return null;
        }
    }
}
