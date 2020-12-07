open System
open System.Threading

let foo () = async {
  //use! __ = Async.OnCancel(fun () -> Console.WriteLine "Canceled")
  Console.WriteLine "Starting"
  do! Async.Sleep 1000
  Console.WriteLine "Waiting"
  do! Async.Sleep 1000
  Console.WriteLine "Waiting"
  do! Async.Sleep 1000
  Console.WriteLine "Waiting"
  do! Async.Sleep 1000
  Console.WriteLine "Completed"
}

[<EntryPoint>]
let main _ =
  Async.Start (foo (), CancellationToken.None)
  //Async.Start (foo ())
  //Async.Sleep 2500 |> Async.RunSynchronously
  //Async.CancelDefaultToken ()
  Console.ReadKey () |> ignore
  0
