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

    private Dictionary<string, List<string>> indexes;

    public List<string> SearchFiles(string path, List<string> keywords) {
      var result = new List<string>();
      var files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).Where(name => name.EndsWith(".txt") || name.EndsWith(".bin") || name.EndsWith(".xml"));

      foreach (var file in files) {
        string fileContent = File.ReadAllText(file);

        if (keywords.Any(keyword => fileContent.Contains(keyword))) {

          result.Add(file);

        }
      }
      return result;
    }

    public void BuildIndexation(string path, List<string> keywords) {

      indexes = new Dictionary<string, List<string>>();

      foreach (var keyword in keywords) {
        var oneKeywordButList = new List<string>();
        oneKeywordButList.Add(keyword);
        indexes[keyword] = SearchFiles(path, oneKeywordButList);

      }
    }

    public void Print() {

      foreach (var index in indexes) {
        Console.WriteLine($"{index.Key}: ");

        foreach (var value in index.Value) {
          Console.WriteLine("\t" + value);
        }
      }
    }
  }
}

