using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myLab2 {
  internal class Program {
    static void Main(string[] args) {
      string option, strIndex;
      //Test animals
      Fish animal = new Fish("Skibidi", 1, "water", "coral","red","salt");
      AnimalManager.Instance.addAnimal(animal);

      Mammal mammal = new Mammal("Lala", 10, "plains", "fern", "brown", true);
      AnimalManager.Instance.addAnimal(mammal);

      while (true) {
        AnimalManager.Instance.showMenu();
        option = Console.ReadLine();
        Console.WriteLine("");

        switch (option) {
          case "0":
            AnimalManager.Instance.showAnimals();
            break;

          case "1":
            Console.Write("Enter index: ");
            strIndex = Console.ReadLine();
            if (int.TryParse(strIndex, out int index)) {
              AnimalManager.Instance.showAnimalByIndex(index);
            } else {
              Console.WriteLine("Wrong index!!!");
            }
              break;

          case "2":
            AnimalManager.Instance.addAnimalManually();
            break;

          case "3":
            return;
        }
      }
    }
  }
}
