using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace StandartInputOutput2 {

  [Serializable]
  internal class TextFile {

    public string Name { get; set; }
    public string Surname { get; set; }
    public string MiddleName { get; set; }
    public TextFile(string name, string surname, string middle) {
      Name = name; Surname = surname; MiddleName = middle;
    }
    public void Serialize(FileStream fs) {
      BinaryFormatter bf = new BinaryFormatter();
      bf.Serialize(fs, this);
      fs.Flush();
      fs.Close();
    }
    public void Deserialize(FileStream fs) {
      BinaryFormatter bf = new BinaryFormatter();
      TextFile deserialized = (TextFile)bf.Deserialize(fs);
      Name = deserialized.Name;
      Surname = deserialized.Surname;
      MiddleName = deserialized.MiddleName;
      fs.Close();
    }
    public void Print() {
      Console.WriteLine("Name={0} Surname={1} Middle={2}", Name, Surname, MiddleName);
    }

  }
}
