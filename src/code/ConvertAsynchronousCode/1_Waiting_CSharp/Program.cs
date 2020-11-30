using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyNamespace {
  class Program {
    static async Task Foo(CancellationToken ct) {
      try {
        Console.WriteLine("Starting");
        await Task.Delay(1000, ct);
        Console.WriteLine("Waiting");
        await Task.Delay(1000, ct);
        Console.WriteLine("Waiting");
        await Task.Delay(1000, ct);
        Console.WriteLine("Waiting");
        await Task.Delay(1000, ct);
        Console.WriteLine("Completed");
      } catch (TaskCanceledException) {
        Console.WriteLine("Canceled");
      }
    }

    static async Task<int> Main() {
      using var cts = new CancellationTokenSource();
      _ = Foo(cts.Token);
      await Task.Delay(2500);
      cts.Cancel();
      _ = Console.ReadKey();
      return 0;
    }
  }
}
