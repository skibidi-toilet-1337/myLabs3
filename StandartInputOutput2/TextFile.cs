using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace StandartInputOutput2 {

  [Serializable]
  public class TextFile {

    public string inputText { get; set; }
    public TextFile() {

    }

    public TextFile(string text) {
      inputText = text;
    }
    public void SerializeBinary(FileStream fs) {
      BinaryFormatter bf = new BinaryFormatter();
      bf.Serialize(fs, this);
      //fs.Flush();
      //fs.Close();
    }
    public void DeserializeBinary(FileStream fs) {
      BinaryFormatter bf = new BinaryFormatter();
      TextFile deserialized = (TextFile)bf.Deserialize(fs);
      inputText = deserialized.inputText;
      //fs.Close();
    }

    public void SerializeXML(FileStream fs) {
      XmlSerializer xmlS = new XmlSerializer(typeof(TextFile));
      xmlS.Serialize(fs, this);
      //fs.Flush();
      //fs.Close();
    }

    public void DeserializeXML(FileStream fs) {
      XmlSerializer xmlS = new XmlSerializer(typeof(TextFile));
      TextFile deserialized = (TextFile)xmlS.Deserialize(fs);
      inputText = deserialized.inputText;
      //fs.Close();
    }

    public void Print() {
      Console.WriteLine(inputText);
    }

  }
}
