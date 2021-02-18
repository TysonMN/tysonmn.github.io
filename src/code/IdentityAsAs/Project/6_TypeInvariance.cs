using System.Threading.Tasks;

namespace TypeInvariance {

  class Sandbox {
    public Task<string> taskString = Task.FromResult("");
    public void Foo() => Bar(taskString);
    //public void Foo() => Bar(taskString.ContinueWith(x => x.As<object>()));
    public void Bar(Task<object> _) { }
  }
}