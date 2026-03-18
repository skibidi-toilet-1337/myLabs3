using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StandartInputOutput2 {
  internal class FileSearcher {

    public List<string> SearchFiles(string path, List<string> keywords) {
      var result = new List<string>();
      var files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).Where(name => name.EndsWith(".txt") || name.EndsWith(".bin") || name.EndsWith(".xml"));

      foreach (var file in files) {
        string fileContent = File.ReadAllText(file);

        //тут хз либо Any, либо All.
        if (keywords.Any(keyword => fileContent.Contains(keyword))) {

          result.Add(file);
          Console.WriteLine(file);

        }

      }
      return result;
    }
  }

  public class Indexator {

    public Dictionary<string, List<string>> BuildIndexation(string path, List<string> keywords) {

      var result = new Dictionary<string, List<string>>();

      foreach (var keyword in keywords) {
        result[keyword] = new List<string>();
      }

      return result;


    }

  }


}

