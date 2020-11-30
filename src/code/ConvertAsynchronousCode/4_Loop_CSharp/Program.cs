using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyNamespace {
  class Program {
    static void BusyWait() {
      foreach (var _ in Enumerable.Repeat(0, 150000000)) { }
    }

    static void Foo(CancellationToken ct) {
      Console.WriteLine("Starting");
      var i = 0;
      while (!ct.IsCancellationRequested && i < 3) {
        BusyWait();
        Console.WriteLine("Waiting");
        i++;
      }
      BusyWait();
      if (ct.IsCancellationRequested)
        Console.WriteLine("Canceled");
      else
        Console.WriteLine("Completed");
    }

    static async Task<int> Main() {
      using var cts = new CancellationTokenSource();
      _ = Task.Run(() => Foo(cts.Token));
      await Task.Delay(1500);
      cts.Cancel();
      _ = Console.ReadKey();
      return 0;
    }
  }
}
