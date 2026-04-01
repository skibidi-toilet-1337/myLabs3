using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandartInputOutput2 {
  internal class Memento {
    public string inputText { get; set; }
  }
  public interface IOriginator {
    object GetMemento();
    void SetMemento(object memento);
  }

  public class Caretacker {
    private object memento;

    public void SaveState(IOriginator originator) {
      memento = originator.GetMemento();
    }

    public void RestoreState(IOriginator originator) {
      originator.SetMemento(memento);
    }

  }

}
