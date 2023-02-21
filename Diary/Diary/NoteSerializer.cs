using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary
{
    public static class NoteSerializer
    {
        public static List<T> Deserialize<T>(string fileName)
        {
            using (var streamReader = new StreamReader(fileName))
            {
                var serializer = new JsonSerializer();
                var notes = (List<T>)serializer.Deserialize(streamReader, typeof(List<T>));
                return notes;
            }
        }

        public static void Serialize<T>(T notes, string fileName)
        {
            using (var streamWriter = new StreamWriter(fileName))
            {
                var serializer = new JsonSerializer();
                serializer.Serialize(streamWriter, notes);
            }
        }
    }

}
