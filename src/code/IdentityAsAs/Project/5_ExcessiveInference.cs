using System;
using LaYumba.Functional;

namespace ExcessiveInference {

  class Sandbox {
    Option<T> Some<T>(T t) => t;

    public Option<R> ApplyInTermsOfBind<T, R>(
      Option<Func<T, R>> func,
      Option<T> arg
    ) =>
      arg.Bind(t => func.Bind<Func<T, R>, R>(f => f(t)));
  }
}