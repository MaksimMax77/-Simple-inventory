using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace DataProvider
{
    public static class Saver
    {
        public static void SaveData<T>(T value, string directory, string fileName)
        {
            var dir = Application.persistentDataPath + directory;
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            
            File.WriteAllText(dir + fileName,  JsonConvert.SerializeObject(value));
        }

        public static T LoadData<T>(string directory, string fileName)
        {
            var path = Application.persistentDataPath + directory + fileName;
            return !File.Exists(path) ? default : JsonConvert.DeserializeObject<T>(File.ReadAllText(path));
        }
    }
}