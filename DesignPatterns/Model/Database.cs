using System;
using System.Collections.Generic;

namespace DesignPatterns.Model
{
    public class Database
    {
        static Dictionary<int, Person> data;
        static Database oneInstance = null;

        static readonly object lockObject = new object();

        Database()
        {
            Id = 0;
            data = new Dictionary<int, Person>();
        }

        public int Id { get; set; }
        public static Database Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (oneInstance == null)
                    {
                        oneInstance = new Database();
                    }
                }

                return oneInstance;
            }
        }

        public void AddData(Person person)
        {
            data.Add(Id++, person);
        }

        public string ShowData()
        {
            string output = "";
            foreach (KeyValuePair<int, Person> item in data)
            {
                //Console.WriteLine(item.Key.ToString() + " " + item.Value.ToString());
                output += item.Value.ToString() + "\n";
            }

            return output;
        }
    }
}
