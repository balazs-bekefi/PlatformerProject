using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer
{
    class Persistance
    {
        public List<Leaderbard> Load()
        {
            List<Leaderbard> players = new List<Leaderbard>();
            System.IO.StreamReader read = new System.IO.StreamReader("data.txt");
            while (!read.EndOfStream)
            {
                string[] temp = read.ReadLine().Split(';');
                Leaderbard asd = new Leaderbard();
                asd.Name = temp[0];
                asd.Score = temp[1];
                players.Add(asd);
            }
            read.Close();
            return players;
        }
        public void Save(string name, string score)
        {
            System.IO.StreamWriter write = new System.IO.StreamWriter("data.txt", true);
            write.WriteLine(name + ';' + score);
            write.Close();
        }
    }
    class Leaderbard
    {
        private string _name;
        private string _score;
        public string Name
        {
            get { return _name; }
            set
            {
                if (value == null)
                {
                    _name = "test";
                }
                else
                {
                    _name = value;
                }
            }
        }
        public string Score
        {
            get { return _score; }
            set { _score = value; }
        }

    }
}
