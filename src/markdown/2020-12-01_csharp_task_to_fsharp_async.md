> :Title
>
> Converting asynchronous cancellation from C# to F#

> :Author name=Tyson Williams,
>         date=2020-12-01,
>         avatar=src/assets/images/TysonWilliams.jpg

_Examples of how to convert asynchronous code involving cancellation from C# to F#._

Recently I was converting some asynchronous code from C# to F#.  I knew that cancellation tokens were treated differently, that F# "implicitly" handles the cancellation token, but it still took me longer than I expected to figure out the correct code.

Below are four typical examples of asynchronous code in C#.  Each is paired its behavioral equivalent (or nearly so) in F#, especially as it relates to cancellation.

This post is my contribution to the [F# Advent Calendar in English 2020](https://sergeytihon.com/2020/10/22/f-advent-calendar-in-english-2020/).  This holiday season, treat yourself by reading all the other great posts about F# by all the other great authors.

All code examples are available in their full and executable form [here](https://github.com/TysonMN/tyson-williams-blog/tree/master/src/code/ConvertAsynchronousCode).

# Waiting

A non-blocking wait is typically achieved by calling [Task.Delay](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task.delay) in C# and
[Async.Sleep](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-control-fsharpasync.html#Sleep) in F#.  To stop the asynchronous computation while waiting, the `CancellationToken` token must be explicitly passed to `Task.Delay`.  In contrast, the `CancellationToken` token is implicitly passed to `Async.Sleep`.

> :Tabs
>
> > :Tab title=C#
> > ```csharp | Program.cs
> > static async Task Foo(CancellationToken ct) {
> >   try {
> >     Console.WriteLine("Starting");
> >     await Task.Delay(1000, ct);
> >     Console.WriteLine("Waiting");
> >     await Task.Delay(1000, ct);
> >     Console.WriteLine("Waiting");
> >     await Task.Delay(1000, ct);
> >     Console.WriteLine("Waiting");
> >     await Task.Delay(1000, ct);
> >     Console.WriteLine("Completed");
> >   } catch (TaskCanceledException) {
> >     Console.WriteLine("Canceled");
> >   }
> > }
> > 
> > static async Task<int> Main() {
> >   using var cts = new CancellationTokenSource();
> >   _ = Foo(cts.Token);
> >   await Task.Delay(2500);
> >   cts.Cancel();
> >   _ = Console.ReadKey();
> >   return 0;
> > }
> > ```
>
> > :Tab title=F#
> > ```fsharp | Program.fs
> > let foo () = async {
> >   use! __ = Async.OnCancel(fun () -> Console.WriteLine "Canceled")
> >   Console.WriteLine "Starting"
> >   do! Async.Sleep 1000
> >   Console.WriteLine "Waiting"
> >   do! Async.Sleep 1000
> >   Console.WriteLine "Waiting"
> >   do! Async.Sleep 1000
> >   Console.WriteLine "Waiting"
> >   do! Async.Sleep 1000
> >   Console.WriteLine "Completed"
> > }
> > 
> > [<EntryPoint>]
> > let main _ =
> >   use cts = new CancellationTokenSource ()
> >   Async.Start (foo (), cts.Token)
> >   Async.Sleep 2500 |> Async.RunSynchronously
> >   cts.Cancel ()
> >   Console.ReadKey () |> ignore
> >   0
> > ```

(Normally I would use the [wildcard pattern](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/pattern-matching#wildcard-pattern) `_` in in place of `__` in the F# code, but [that is not currently supported](https://github.com/dotnet/fsharp/issues/7775#issuecomment-735512911).)

In both languages, this is the output.

> :Center
>
> ![Waiting output](src/assets/images/cancellation_wait_wait_canceled.gif)

If the call to `CancellationTokenSource.Cancel` is removed, then this is the output in both languages.

> :Center
>
> ![Waiting output](src/assets/images/cancellation_completed.gif)

# IsCancellationRequested

It is possible to explicitly check if some asynchronous computation should be stopped via the instance property [`CancellationToken.IsCancellationRequested`](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken.iscancellationrequested).  Of course an instance of [`CancellationToken`](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) is required in order to call that property.  It is obvious how to do this in C# because the `CancellationToken` instance is explicitly available as a method argument.  In F#, the `CancellationToken` instance is obtained by calling [`Async.CancellationToken`](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-control-fsharpasync.html#CancellationToken).

> :Tabs
>
> > :Tab title=C#
> > ```csharp | Program.cs
> > static void BusyWait() {
> >   foreach (var _ in Enumerable.Repeat(0, 150000000)) { }
> > }
> > 
> > static void Foo(CancellationToken ct) {
> >   Console.WriteLine("Starting");
> >   BusyWait();
> >   Console.WriteLine("Waiting");
> >   if (ct.IsCancellationRequested) {
> >     Console.WriteLine("Canceled");
> >     return;
> >   }
> >   BusyWait();
> >   Console.WriteLine("Waiting");
> >   if (ct.IsCancellationRequested) {
> >     Console.WriteLine("Canceled");
> >     return;
> >   }
> >   BusyWait();
> >   Console.WriteLine("Waiting");
> >   if (ct.IsCancellationRequested) {
> >     Console.WriteLine("Canceled");
> >     return;
> >   }
> >   BusyWait();
> >   Console.WriteLine("Completed");
> > }
> > 
> > static async Task<int> Main() {
> >   using var cts = new CancellationTokenSource();
> >   _ = Task.Run(() => Foo(cts.Token));
> >   await Task.Delay(1500);
> >   cts.Cancel();
> >   _ = Console.ReadKey();
> >   return 0;
> > }
> > ```
>
> > :Tab title=F#
> > ```fsharp | Program.fs
> > let busyWait () =
> >   for _ in Enumerable.Repeat(0, 150000000) do ()
> > 
> > let foo () = async {
> >   let! ct = Async.CancellationToken
> >   Console.WriteLine "Starting"
> >   busyWait ()
> >   Console.WriteLine "Waiting"
> >   if (ct.IsCancellationRequested) then
> >     Console.WriteLine "Canceled"
> >   else
> >     busyWait ()
> >     Console.WriteLine "Waiting"
> >     if (ct.IsCancellationRequested) then
> >       Console.WriteLine "Canceled"
> >     else
> >       busyWait ()
> >       Console.WriteLine "Waiting"
> >       if (ct.IsCancellationRequested) then
> >         Console.WriteLine "Canceled"
> >       else
> >         busyWait ()
> >         Console.WriteLine "Completed"
> > }
> > 
> > [<EntryPoint>]
> > let main _ =
> >   use cts = new CancellationTokenSource ()
> >   Async.Start (foo (), cts.Token)
> >   Async.Sleep 1500 |> Async.RunSynchronously
> >   cts.Cancel ()
> >   Console.ReadKey () |> ignore
> >   0
> > ```

(The exact number of iterations in the busy wait is not so special.  I adjusted it until I felt like it took about a second to execute on my machine.)

In both languages, this is the output.

> :Center
>
> ![Waiting output](src/assets/images/cancellation_wait_wait_canceled.gif)

If the call to `CancellationTokenSource.Cancel` is removed, then this is the output in both languages.

> :Center
>
> ![Waiting output](src/assets/images/cancellation_completed.gif)

# Never stop

Asynchronous code might not have a way to be stopped.  In C#, this is the default behavior.  When no `CancellationToken` is given to `Task.Delay`, it is as though [`CancellationToken.None`](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken.none) [is](https://github.com/dotnet/runtime/blob/1edc35f8517bbb2fae8c0152de14bd105f9bac06/src/libraries/System.Private.CoreLib/src/System/Threading/Tasks/Task.cs#L5356) [given](https://github.com/dotnet/runtime/blob/1edc35f8517bbb2fae8c0152de14bd105f9bac06/src/libraries/System.Private.CoreLib/src/System/Threading/Tasks/Task.cs#L5397) (since [it is the default for its type](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken.none?view=net-5.0#remarks:~:text=You%20can%20also%20use%20the%20C%23%20default(CancellationToken)%20statement%20to%20create%20an%20empty%20cancellation%20token.)), which is a `CancellationToken` that cannot be canceled.  This is not the default behavior in F#, so `CancellationToken.None` must be explicitly given to [`Async.Start`](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-control-fsharpasync.html#Start).

> :Tabs
>
> > :Tab title=C#
> > ```csharp | Program.cs
> > static async Task Foo() {
> >   Console.WriteLine("Starting");
> >   await Task.Delay(1000);
> >   Console.WriteLine("Waiting");
> >   await Task.Delay(1000);
> >   Console.WriteLine("Waiting");
> >   await Task.Delay(1000);
> >   Console.WriteLine("Waiting");
> >   await Task.Delay(1000);
> >   Console.WriteLine("Completed");
> > }
> > 
> > static int Main() {
> >   _ = Foo();
> >   _ = Console.ReadKey();
> >   return 0;
> > }
> > ```
>
> > :Tab title=F#
> > ```fsharp | Program.fs
> > let foo () = async {
> >   Console.WriteLine "Starting"
> >   do! Async.Sleep 1000
> >   Console.WriteLine "Waiting"
> >   do! Async.Sleep 1000
> >   Console.WriteLine "Waiting"
> >   do! Async.Sleep 1000
> >   Console.WriteLine "Waiting"
> >   do! Async.Sleep 1000
> >   Console.WriteLine "Completed"
> > }
> > 
> > [<EntryPoint>]
> > let main _ =
> >   Async.Start (foo (), CancellationToken.None)
> >   Console.ReadKey () |> ignore
> >   0
> > ```

In both languages, this is the output.

> :Center
>
> ![Waiting output](src/assets/images/cancellation_completed.gif)

The behavior of `Async.Start` and its variants when not given a `CancellationToken` is to use the one returned by the static property [`Async.DefaultCancellationToken`](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-control-fsharpasync.html#DefaultCancellationToken).  That instance can either be directly canceled by calling `CancellationTokenSource.Cancel` or indirectly canceled by calling [`Async.CancelDefaultToken`](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-control-fsharpasync.html#CancelDefaultToken).  Therefore, if the previous F# code did not explicitly pass `CancellationToken.None`, then it would be impure because of mutable static state, which is the worst kind of impurity!

```fsharp | Program.fs
let foo () = async {
  use! __ = Async.OnCancel(fun () -> Console.WriteLine "Canceled")
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
  //Async.Start (foo (), CancellationToken.None)
  Async.Start (foo ())
  Async.Sleep 2500 |> Async.RunSynchronously
  Async.CancelDefaultToken ()
  Console.ReadKey () |> ignore
  0
```

This is the output.

> :Center
>
> ![Waiting output](src/assets/images/cancellation_wait_wait_canceled.gif)

If `CancellationToken.None` is given to `Async.Start`, then canceling the default token has no effect, and the original behavior is restored.

# Loop

Asynchronous code might contain a loop.  If some corresponding asynchronous computation should be stopped, then it is reasonable to also exit the loop.  In C#, this must be done explicitly by calling `CancellationToken.IsCancellationRequested` in the loop's termination condition, which is similar to the [IsCancellationRequested example](#iscancellationrequested).  In F#, this is done implicitly, which is similar to the [Waiting example](#waiting).

> :Tabs
>
> > :Tab title=C#
> > ```csharp | Program.cs
> > static void BusyWait() {
> >   foreach (var _ in Enumerable.Repeat(0, 150000000)) { }
> > }
> > 
> > static void Foo(CancellationToken ct) {
> >   Console.WriteLine("Starting");
> >   var i = 0;
> >   while (!ct.IsCancellationRequested && i < 3) {
> >     BusyWait();
> >     Console.WriteLine("Waiting");
> >     i++;
> >   }
> >   BusyWait();
> >   if (ct.IsCancellationRequested)
> >     Console.WriteLine("Canceled");
> >   else
> >     Console.WriteLine("Completed");
> > }
> > 
> > static async Task<int> Main() {
> >   using var cts = new CancellationTokenSource();
> >   _ = Task.Run(() => Foo(cts.Token));
> >   await Task.Delay(1500);
> >   cts.Cancel();
> >   _ = Console.ReadKey();
> >   return 0;
> > }
> > ```
>
> > :Tab title=F#
> > ```fsharp | Program.fs
> > let busyWait () =
> >   for _ in Enumerable.Repeat(0, 150000000) do ()
> > 
> > let foo () = async {
> >   use! __ = Async.OnCancel(fun () -> Console.WriteLine "Canceled")
> >   Console.WriteLine "Starting"
> >   let mutable i = 0
> >   while (i < 3) do
> >     busyWait ()
> >     Console.WriteLine "Waiting"
> >     i <- i + 1
> >   busyWait ()
> >   Console.WriteLine "Completed"
> > }
> > 
> > [<EntryPoint>]
> > let main _ =
> >   use cts = new CancellationTokenSource ()
> >   Async.Start (foo (), cts.Token)
> >   Async.Sleep 1500 |> Async.RunSynchronously
> >   cts.Cancel ()
> >   Console.ReadKey () |> ignore
> >   0
> > ```

The output differs slightly.  In C#, clearly `Waiting` is never printed after `Canceled`.  In F#, the callback given to [`Async.OnCancel`](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-control-fsharpasync.html#OnCancel) is executed shortly after `CancellationTokenSource.Cancel` is called, which prints `Canceled`.  In the meantime, the busy wait is still executing.  When that is done, the current iteration of the loop is finished, which prints `Waiting`.

> :Center
>
> ![Waiting output](src/assets/images/cancellation_wait_wait_canceled.gif)
> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
> ![Waiting output](src/assets/images/cancellation_wait_canceled_wait.gif)
> 
> C# output
> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
> F# output

I did not know that F# considers stopping asynchronous computations after each loop iteration until I was part way through writing this post.  I looked but failed to find this behavior described in documentation.  Please share a link in a comment if you know of such documentation.

If the call to `CancellationTokenSource.Cancel` is removed, then this is the output in both languages.

> :Center
>
> ![Waiting output](src/assets/images/cancellation_completed.gif)

Suppose the C# code never checked `CancellationToken.IsCancellationRequested`.  Then the F# code would need to replace the loop with [tail recursion](https://en.wikipedia.org/wiki/Tail_call).  This is conceptually similar to the [Never Stop example](#never-stop) in that the F# code needs to explicitly avoid implicit calls to `CancellationToken.IsCancellationRequested`.

---

> :SeeTypo$

# Tags

The [tags feature of Coding Blog Plugin](https://connect-platform.github.io/coding-blog-plugin/tags) is still being developed.  Eventually the tags will link somewhere.

[CSharp](:Tag) [FSharp](:Tag)

# Comments

> :DarkLight
> > :InLight
> >
> > > :Utterances theme=github-light
>
> > :InDark
> >
> > > :Utterances theme=icy-dark
