using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myLab2 {
  public abstract class Animal {
    public string nickname = " ";
    public int age = 0;
    public string habitat = " ";
    public string foodType = " ";
    public string color = " ";
    public virtual void GetInfo() {
      Console.WriteLine($"Nickname: {nickname}, Age: {age}, Habitat: {habitat}, Food type: {foodType}, Color: {color}");
    }
    protected Animal(string nickname, int age, string habitat, string foodType, string color) {
      this.nickname = nickname;
      this.age = age;
      this.habitat = habitat;
      this.foodType = foodType;
      this.color = color;
    }
  }
}
