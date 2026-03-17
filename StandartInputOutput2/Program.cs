using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StandartInputOutput2 {
  internal class Program {
    static void Main(string[] args) {

      TextFile tf = new TextFile("Hello World");
      Caretacker caretacker = new Caretacker();

      tf.Print();
      caretacker.SaveState(tf);

      tf = new TextFile("Lorem Ipsum");
      tf.Print();

      caretacker.RestoreState(tf);
      tf.Print();

    }
    void testSerDeser() {

      string path = "D:\\newText";
      TextFile tf = new TextFile("Lorem Ipsum");

      using (FileStream fs = new FileStream(path + ".bin", FileMode.OpenOrCreate, FileAccess.ReadWrite)) {
        tf.SerializeBinary(fs);
        Console.WriteLine("Object has been binary serialized");
        fs.Seek(0, SeekOrigin.Begin);

        tf.DeserializeBinary(fs);
        Console.WriteLine("Object has been binary deserialized");
      }

      using (FileStream fs = new FileStream(path + ".xml", FileMode.OpenOrCreate, FileAccess.ReadWrite)) {
        tf.SerializeXML(fs);
        Console.WriteLine("Object has been XML serialized");
        fs.Seek(0, SeekOrigin.Begin);

        tf.DeserializeXML(fs);
        Console.WriteLine("Object has been XML deserialized");
      }
    }

  }
}
