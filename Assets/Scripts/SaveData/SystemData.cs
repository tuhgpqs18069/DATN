using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SystemData 
{
    //Lưu
    public static void Saving(Player player)
    {
        var formatter = new BinaryFormatter();
        var path = Application.persistentDataPath + "/player.info";
        var stream = new FileStream(path, FileMode.Create);
        var data = new PlayerSaveData(player);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    //Đọc
    public static PlayerSaveData Loading()
    {
        var path = Application.persistentDataPath + "/player.info";
        Debug.Log("Path: " + path);
        if(File.Exists(path))
        {
            var formatter = new BinaryFormatter();
            var stream = new FileStream(path, FileMode.Open);
            var data = formatter.Deserialize(stream) as PlayerSaveData;
            return data;
        }
        return null;
    }
}
