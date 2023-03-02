using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
namespace WebApplication2.Models
{
    public class Telephon_DB
    {
        public int Id { get; set; }
        public string Surname { get; set; }

        public string TelephoneNumber { get; set; }


        public Telephon_DB(int id, string surname, string telephoneNumber)
        {
            Id = id;
            Surname = surname;
            TelephoneNumber = telephoneNumber;
        }
    }
    public class TelephoneBook
    {
        public List<Telephon_DB> Rows { get; set; }

        private int id;

        public TelephoneBook()
        {
            Rows = new List<Telephon_DB>();

            Initialize();
        }

        private void Initialize()
        {

            string json = File.ReadAllText(@"C:\lab3\Telef.json", Encoding.Default);


            var bookRows = JsonConvert.DeserializeObject<List<Telephon_DB>>(json);

            if (bookRows.Count != null)
            {
                Rows.AddRange(bookRows);
                id = Rows.Max<Telephon_DB>(el => el.Id);
            }
        }

        public List<Telephon_DB> GetAll()
        {
            return Rows.OrderBy(tr => tr.Surname).ToList();
        }

        public void AddRow(string surname, string phoneNumber)
        {
            Rows.Add(new Telephon_DB(++id, surname, phoneNumber));
            SaveInFile();
        }

        public bool Update(int id, string surname, string phoneNumber)
        {
            for (int i = 0; i < Rows.Count; i++)
            {
                if (Rows[i].Id == id)
                {
                    if (surname != "")
                    {
                        Rows[i].Surname = surname;
                    }

                    if (phoneNumber != "")
                    {
                        Rows[i].TelephoneNumber = phoneNumber;
                    }

                    SaveInFile();
                    return true;
                }
            }

            return false;
        }

        public bool Delete(int id)
        {
            var deletedRow = Rows.Find(row => row.Id == id);
            if (deletedRow == null)
            {
                return false;
            }

            Rows.Remove(deletedRow);

            SaveInFile();

            return true;
        }

        private void SaveInFile()
        {
            string json = JsonConvert.SerializeObject(Rows);

            File.WriteAllText(@"C:\lab3\Telef.json", json, Encoding.Default);
        }
    }
}