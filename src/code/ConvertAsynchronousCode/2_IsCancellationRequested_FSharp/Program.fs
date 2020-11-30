open System
open System.Linq
open System.Threading

let busyWait () =
  for _ in Enumerable.Repeat(0, 150000000) do ()

let foo () = async {
  let! ct = Async.CancellationToken
  Console.WriteLine "Starting"
  busyWait ()
  Console.WriteLine "Waiting"
  if (ct.IsCancellationRequested) then
    Console.WriteLine "Canceled"
  else
    busyWait ()
    Console.WriteLine "Waiting"
    if (ct.IsCancellationRequested) then
      Console.WriteLine "Canceled"
    else
      busyWait ()
      Console.WriteLine "Waiting"
      if (ct.IsCancellationRequested) then
        Console.WriteLine "Canceled"
      else
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
