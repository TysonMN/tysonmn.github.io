open System
open System.Linq
open System.Threading

let busyWait () =
  for _ in Enumerable.Repeat(0, 150000000) do ()

let foo () = async {
  use! __ = Async.OnCancel(fun () -> Console.WriteLine "Canceled")
  Console.WriteLine "Starting"
  let mutable i = 0
  while (i < 3) do
    busyWait ()
    Console.WriteLine "Waiting"
    i <- i + 1
  busyWait ()
  Console.WriteLine "Completed"
}

[<EntryPoint>]
let main _ =
  use cts = new CancellationTokenSource ()
  Async.Start (foo (), cts.Token)
  Async.Sleep 1500 |> Async.RunSynchronously
  cts.Cancel ()
  Console.ReadKey () |> ignore
  0
