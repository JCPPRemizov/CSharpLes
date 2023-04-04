using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Accounting
{
    public class SavedNotes
    {
        const string NOTES_PATH = "notes.json";
        const string NOTES_TYPE_PATH = "types.json";

        public static void LoadNotes()
        {
            try
            {
                if (CheckFiles())
                {
                    string savedNotes = File.ReadAllText("notes.json");
                    Note.NotesList = JsonConvert.DeserializeObject<List<Note>>(savedNotes);
                    string savedNotesType = File.ReadAllText("types.json");
                    NoteType.notesTypesList = JsonConvert.DeserializeObject<List<string>>(savedNotesType);
                }
                else
                {
                    MessageBox.Show("Файл с сохраненными записями отсутствует!", "Ошибка");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static void SaveNotes()
        {
            using (StreamWriter writer = File.CreateText(NOTES_PATH))
            {
                string saveNotes = JsonConvert.SerializeObject(Note.NotesList);
                writer.Write(saveNotes);
            }
            using (StreamWriter writer = File.CreateText(NOTES_TYPE_PATH))
            {
                string saveNotesType = JsonConvert.SerializeObject(NoteType.notesTypesList);
                writer.Write(saveNotesType);
            }
            MessageBox.Show("Записи сохранены!");
        }

        private static bool CheckFiles()
        {
            return File.Exists(NOTES_PATH) && File.Exists(NOTES_TYPE_PATH);
        }
    }
}
