using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{
    public static void Save(string dataPath, object saveData)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        if (Directory.Exists(dataPath))
        {
            Directory.CreateDirectory(dataPath);

        }
        string path = dataPath;

        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, saveData);

        stream.Close();
    }

    public static object Load(string dataPath)
    {
        string path = dataPath;

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

    public static void DeleteFolder(string path)
    {
        File.Delete(path);
    }

}
