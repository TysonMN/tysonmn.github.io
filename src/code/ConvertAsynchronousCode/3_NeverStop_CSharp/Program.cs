using System;
using System.Threading.Tasks;

namespace MyNamespace {
  class Program {
    static async Task Foo() {
      Console.WriteLine("Starting");
      await Task.Delay(1000);
      Console.WriteLine("Waiting");
      await Task.Delay(1000);
      Console.WriteLine("Waiting");
      await Task.Delay(1000);
      Console.WriteLine("Waiting");
      await Task.Delay(1000);
      Console.WriteLine("Completed");
    }

    static int Main() {
      _ = Foo();
      _ = Console.ReadKey();
      return 0;
    }
  }
}
