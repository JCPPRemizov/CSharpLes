using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TypingTest
{
    public static class Serializer
    {
        public static string text;
        public static string LoadText()
        {
            try
            {
                if (File.Exists("TypingText.txt"))
                {
                    text = File.ReadAllText("TypingText.txt");
                    if (text.Length > 0) return text;
                    else return string.Empty;
                }
                else
                {
                    File.Create("TypingText.txt").Close();
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }
        public static void Serialize(List<PlayerInfo> list)
        {
            string json = JsonConvert.SerializeObject(list);
            File.WriteAllText("RecordTable.json", json);
        }
    }
}
