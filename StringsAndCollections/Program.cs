using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StringsAndCollections {
  internal class Program {
    static void Main(string[] args) {
      string path;
      string wordFind = "[а-яёЁА-Яa-zA-Z]+";
      Regex regex = new Regex(wordFind);
      
      Console.Write(@"Enter directory path (D:\test): ");
      //path = Console.ReadLine();
      path = "D:\\Test\\";

      var fileNames = Directory.GetFiles(path, "*.txt", SearchOption.AllDirectories);

      var wrongWordsDict = GetWrongDictionary(); 

      Console.WriteLine("\nFounded files: ");
      foreach (var fileName in fileNames) {
        string fileContent = File.ReadAllText(fileName);
        Console.WriteLine(fileName);

        MatchCollection matches = regex.Matches(fileContent);
        Console.WriteLine();
        foreach (Match match in matches) {
          Console.Write(" "+match);
        }

        foreach (var wrongWord in wrongWordsDict) {
          
        }
        Console.WriteLine();
      }


    }

    public static Dictionary<string, string> GetWrongDictionary() {
      var wrongWithWords = new Dictionary<string, string>() {
    {"првиет","привет"},
    {"пирвет","привет"},
    {"приветт","привет"},

    {"здравстуйте","здравствуйте"},
    {"здраствуйте","здравствуйте"},
    {"здравствуйтe","здравствуйте"},

    {"спсибо","спасибо"},
    {"спасиба","спасибо"},
    {"спосибо","спасибо"},

    {"пожалуста","пожалуйста"},
    {"пажалуйста","пожалуйста"},
    {"пожайлуста","пожалуйста"},

    {"извените","извините"},
    {"извинити","извините"},
    {"извенити","извините"},

    {"досвидания","до свидания"},
    {"досвиданя","до свидания"},
    {"досвиданье","до свидания"},

    {"севодня","сегодня"},
    {"сигодня","сегодня"},
    {"сегодняя","сегодня"},

    {"чиловек","человек"},
    {"челавек","человек"},
    {"человик","человек"},

    {"робота","работа"},
    {"рабта","работа"},
    {"работта","работа"},

    {"магазиин","магазин"},
    {"магазн","магазин"},
    {"магозин","магазин"}
};
      return wrongWithWords;
    }

  }
}
