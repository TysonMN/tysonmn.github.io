> :Hero src=src/assets/images/as_extension_method.png

> :Title
>
> Identity as As

> :Author name=Tyson Williams,
>         date=2020-07-14,
>         avatar=src/assets/images/TysonWilliams.jpg

_The identity function is a useful extension method in C#._

The [identity function](https://en.wikipedia.org/wiki/Identity_function) is so trivial.  And yet, it is important enough that both [F#](https://baronfel.github.io/fsharp-core-api-docs//reference/FSharp.Core/microsoft-fsharp-core-operators.html#body-inner:~:text=The%20identity%20function) and [Haskell](https://hackage.haskell.org/package/base-4.14.0.0/docs/Prelude.html#v:id) expose this function to all developers under the name `id`.  The [standard justification](https://stackoverflow.com/questions/44545396/whats-the-purpose-of-id-function-in-the-fsharp-core/44545932#44545932) is that `id` can be a useful argument to a [higher-order function](https://en.wikipedia.org/wiki/Higher-order_function).  This is certainly true, but it is not the only justification.  In C#, I have found reasonable uses for calling `id` as an extension method.

# Identity extension method

Here is how I prefer to define the identity function as an extension method.

```csharp | GenericExtensions.cs
public static class GenericExtensions {
  public static A As<A>(this A a) => a;
}
```

My intended use case for this method is to explicitly specify the type parameter so that the C# compiler inserts an [implicit conversion](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/conversions#implicit-conversions) to `A` before supplying the result as the argument to this method.  This method is an explicit way to call an implicit conversion.

The name `As` is probably a surprise.  [Pre-defined implicit conversions](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/conversions#implicit-conversions:~:text=The%20pre%2Ddefined%20implicit%20conversions%20always%20succeed%20and%20never%20cause%20exceptions%20to%20be%20thrown.) and the [`as` operator](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/type-testing-and-cast#as-operator:~:text=the%20as%20operator%20never%20throws%20an%20exception.) are both type conversions and neither throws an exception.  If all [user-defined implicit conversions are properly designed](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/conversions#implicit-conversions:~:text=Properly%20designed%20user%2Ddefined%20implicit%20conversions%20should%20exhibit%20these%20characteristics%20as%20well.), then the use of this method never causes an exception to be thrown.  In fact, it would always succeed.  I like the name `As` because of this similarity and because the resulting code reads so well.

# Examples

Here are example use cases that I have found for this extension method.  The typical alternative is to use a [cast expression](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/expressions#cast-expressions).  I think using a cast expression is worse because it is a code smell (because a [cast expression can fail at runtime](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/conversions#explicit-conversions:~:text=conversions%20that%20cannot%20be%20proven%20to%20always%20succeed)) and because the readability of the extension method is better.

## 1. Ternary operator

The expressions in the branches of a ternary operator must have an [implicit conversion from one type to the other](https://github.com/dotnet/docs/issues/19468).  When this not the case, we can use `As` to make it so.


```csharp
interface IPlanet { }
class Earth : IPlanet { }
class Mars : IPlanet { }
class Sandbox {
  public IPlanet GetPlanet(bool b) =>
/*!*/    b ? new Earth() : new Mars().As<IPlanet>();
}
```

This issue looks like it [will be fixed](https://github.com/dotnet/csharplang/issues/2460) in a future version of C#.

In the meantime, an alternative that I sometimes prefer is to replace the ternary operator with an `if-else` statement so that the compiler can infer both implicit conversions.

```csharp
public IPlanet GetPlanet(bool b) {
  if (b) {
    return new Earth();
  } else {
    return new Mars();
  }
}
```

## 2. Explicit interface

When a class [explicitly implements an interface](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/interfaces/explicit-interface-implementation), one cannot directly call any interface method given a reference with the implementing class as its compile-time type.  It is necessary to first invoke the [implicit conversion that exists to an interface from an implementing class](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/types/casting-and-type-conversions#code-try-1:~:text=For%20reference%20types%2C%20an%20implicit%20conversion,or%20indirect%20base%20classes%20or%20interfaces.).

```csharp
interface IPlanet {
  bool HasLife { get; }
}

class Earth : IPlanet {
  bool IPlanet.HasLife => true;
}

class Sandbox {
  public bool EarthHasLife =>
/*!*/    new Earth().As<IPlanet>().HasLife;
}
```

## 3. Hidden member

Members can be [hidden in an inheritance hierarchy](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/basic-concepts#hiding-through-inheritance).  This case is similar to the previous case with explicit interfaces.  The difference is that removing `As` in that case causes a compiler error while removing `As` in this changes the resolved member.

```csharp
class Planet {
  public bool? HasLife => null;
}

class Earth : Planet {
  public new bool? HasLife => true;
}

class Sandbox {
  public bool? EarthAsPlanetHasLife =>
/*!*/    new Earth().As<Planet>().HasLife;
}
```

Don't use hidden members though.  It makes things very confusing.

## 4. Ambiguous call

I have only ever experienced this use case once, so I decided to provide that exact example instead of creating a simpler one.

[`language-ext`](https://github.com/louthy/language-ext/blob/4db4d9277151628e35309227475738180488606d/LanguageExt.Core/Extensions/TryOutExt.cs#L36-L42) contains extension methods for safely getting the value out of a dictionary that are mostly the same.  The main difference is the type of the first argument.  One is for [`IDictionary<K, V>`](https://github.com/louthy/language-ext/blob/4db4d9277151628e35309227475738180488606d/LanguageExt.Core/Extensions/TryOutExt.cs#L19-L25) and the other is for [`IReadOnlyDictionary<K, V>`](https://github.com/louthy/language-ext/blob/4db4d9277151628e35309227475738180488606d/LanguageExt.Core/Extensions/TryOutExt.cs#L36-L42).  Because of that, this is a compiler error.

```csharp
new Dictionary<int, int>()./*~err~*/TryGetValue/*~err~*/(0);
```

> Error CS0121 The call is ambiguous between the following methods or properties: `OutExtensions.TryGetValue<K, V>(IDictionary<K, V>, K)` and `OutExtensions.TryGetValue<K, V>(IReadOnlyDictionary<K, V>, K)`

I dislike so much about this.  (Below, I omit the type parameters for brevity.)

First, I think that `IReadOnlyDictionary` is not a good name.  It suggests that implementations must be immutable, but this is not the case.  Instead, a better name would be `IReadableDictionary`.  Better still would be to rename `IDictionary` to `IMutableDictionary` and rename `IReadOnlyDictionary` to `IDictionary` so that the safer type has the preferred name.

Second, [`IDictionary` should extend `IReadOnlyDictionary`](https://github.com/dotnet/runtime/issues/31001).  With this change, I think the compiler would select the extension method for `IDictionary`.  In fact, `language-ext` could then remove the extension method for `IDictionary`.

Third, `language-ext` could solve this problem now by also adding this extension method for `Dictionary`.  Instead, the [recommended workaround](https://github.com/louthy/language-ext/issues/414#issuecomment-390632509) is to name the argument, which varies accordingly for these two extension methods.

That workaround is fine, but if the argument names were also the same, then calling `As` is another workaround.


```csharp
/*!*/new Dictionary<int, int>().As<IDictionary<int, int>>().TryGetValue(0);
```

## 5. Excessive inference

The C# compiler can [infer the type arguments of a method](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/generic-methods#code-try-1:~:text=You%20can%20also%20omit%20the%20type%20argument%20and%20the%20compiler%20will%20infer%20it.).  The C# compiler can infer the need for an implicit conversion.  But the C# compiler cannot do too many of these at once.

Consider [this function](https://github.com/la-yumba/functional-csharp-code/blob/02eac68e275286e5301ab3fe1cc611540d340d21/LaYumba.Functional.Tests/Option/ApplicativeLaws.cs#L93-L95), which also appears on page 186 of [Functional Programming in C#](https://www.manning.com/books/functional-programming-in-c-sharp).  Notice the implicit conversion from `R` to `Option<R>` for the value `f(t)`.

```csharp
public Option<R> ApplyInTermsOfBind<T, R>(
  Option<Func<T, R>> func,
  Option<T> arg
) =>
  arg.Bind(t => func.Bind<Func<T, R>, R>(f => f(t)));
```

The type parameters of the inner call to `Bind` are specified because there would be a compiler error without them.

> Error CS1061 `Option<Func<T, R>>` does not contain a definition for `Bind` and no accessible extension method `Bind` accepting a first argument of type `Option<Func<T, R>>` could be found (are you missing a using directive or an assembly reference?)

If any _one_ type argument of a method cannot be inferred, then _all_ type arguments must be explicitly provided.  In contrast, we only have to provide one type parameter for each call to `As`.  Therefore, I typically prefer to help the compiler by explicitly invoking an implicit conversion via `As`.  In this case, instead of specifying two type parameters to `Bind`, we only need to specify one type parameter to `As` to invoke the implicit conversion.

As least, that is what I expected.  Instead, this code doesn't compile.  I do not understand why.

```csharp
public Option<R> ApplyInTermsOfBind<T, R>(
  Option<Func<T, R>> func,
  Option<T> arg
) =>
  arg.Bind(t => func.Bind<Func<T, R>, R>(f => /*~err~*/f(t/*~err~*/).As<Option<R>>()));
```

> Error CS1929 `R` does not contain a definition for `As` and the best extension method overload `GenericExtensions.As<Option<R>>(Option<R>)` requires a receiver of type `Option<R>`

It does work though when `As` is called like a static method instead of an extension method.  Now we don't have to specify the type parameters to `Bind`.

```csharp
public Option<R> ApplyInTermsOfBind<T, R>(
  Option<Func<T, R>> func,
  Option<T> arg
) =>
/*!*/  arg.Bind(t => func.Bind(f => GenericExtensions.As<Option<R>>(f(t))));
```

In the end, the best implementation would be to define a function `Some` that invokes the implicit conversion from `R` to `Option<R>` and then use that.

```csharp
public Option<R> ApplyInTermsOfBind<T, R>(
  Option<Func<T, R>> func,
  Option<T> arg
) =>
  arg.Bind(t => func.Bind(f => Some(f(t))));
```

# Summary

The identity function is a useful extension method in C# because it can help the compiler figure out the intended types in situations that would otherwise be too complicated and cause a compiler error.

---

The code in this post is available [here](https://github.com/bender2k14/tyson-williams-blog/tree/master/src/code/IdentityAsAs).

See a typo? You can fix it by editing [this file](https://github.com/bender2k14/tyson-williams-blog/blob/master/src/markdown/2020-07-14_identity_as_as.md) and then sending me a [pull request](https://github.com/bender2k14/tyson-williams-blog/compare).

# Comments

> :DarkLight
> > :InLight
> >
> > > :Utterances theme=github-light
>
> > :InDark
> >
> > > :Utterances theme=icy-dark
