using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace StandartInputOutput2 {
  internal class Program {

    private TextFile file;
    private Caretacker caretacker = new Caretacker();

    static void Main(string[] args) {

      /*TextFile tf = new TextFile("Hello World");
      Caretacker caretacker = new Caretacker();

      tf.Print();
      caretacker.SaveState(tf);

      tf = new TextFile("Lorem Ipsum");
      tf.Print();

      caretacker.RestoreState(tf);
      tf.Print();*/

      string option;
      string path;
      TextFile file;

      while (true) {

        Console.WriteLine("\nMenu:\n" +
         "----------------\n" +
         "1: Open file (enter path)\n" +
         "2: Find file by keywords\n" +
         "3: Create file\n" +
         "4: Show text of file\n" +
         "5: Edit file\n" +
         "6: Save as bin\n" +
         "7: Save as xml\n" +
         "----------------\n" +
         "Special:\n" +
         "----------------\n" +
         "Z: Undo changes\n" +
         "----------------\n" +
         "0: Exit\n");
        Console.Write("Select option: ");
        option = Console.ReadLine();

        switch (option) {

          case "1":
            Console.Write("Enter path (D:\\test): ");
            path = Console.ReadLine();
            break;

          case "2":
            path = Console.ReadLine();
            break;

          case "3":
            Console.Write("Enter path (D:\\test): ");
            path = Console.ReadLine();
            string inputText = Console.ReadLine();
            file = new TextFile(inputText);
            break;

          case "4":
            path = Console.ReadLine();
            break;

          case "5":
            path = Console.ReadLine();
            break;

          case "6":
            path = Console.ReadLine();
            break;

          case "7":
            path = Console.ReadLine();
            break;

          case "Z":
            path = Console.ReadLine();
            break;

          case "0":
            return;
        }

      }
    


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

    void testSearchAndIndex() {
      FileSearcher searcher = new FileSearcher();
      List<string> keywords = new List<string>() { "Lorem", "skibidi" };
      string path = "D:\\Test";
      var searchedFiles = searcher.SearchFiles(path, keywords);

      Console.WriteLine("Your keywords: ");
      foreach (var keyword in keywords) {
        Console.WriteLine($"\t{keyword}");
      }

      Console.WriteLine("Matching files: ");
      foreach (var file in searchedFiles) {
        Console.WriteLine($"\t{file}");
      }

      Console.WriteLine();

      searcher.BuildIndexation(path, keywords);
      searcher.Print();
    }

  }
}
