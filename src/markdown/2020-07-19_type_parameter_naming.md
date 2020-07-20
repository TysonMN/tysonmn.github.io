> :Hero src=src/assets/images/func_17.png

> :Title
>
> Type Parameter Naming

> :Author name=Tyson Williams,
>         date=DRAFT,
>         avatar=src/assets/images/TysonWilliams.jpg

_`A`, `B`, `C`, ... are minimal and intuitive names for type parameters._

A generic type has a certain number of [type parameters](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/types#type-parameters).  In C#, a programmer must give names to each type parameter in some order.  Descriptive names are typically best, but sometimes a single letter name is completely self explanatory.  In this case, there are multiple naming conventions in use.  Let's state some of them and then list their pros and cons.

# Naming guidelines

Microsoft has [guidelines for naming type parameters](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/generic-type-parameters).  I briefly repeat them here for convenience.

1. **Do** name generic type parameters with descriptive names, unless a single letter name is completely self explanatory and a descriptive name would not add value.
2. **Consider** using T as the type parameter name for types with one single letter type parameter.
3. **Do** prefix descriptive type parameter names with "T".
4. **Consider** indicating [[type] constraints](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/constraints-on-type-parameters) placed on a type parameter in the name of parameter.

It is idiomatic in C# for type parameter names to start with `T`.  Such names are consistent with these guidelines.

This post is about the case in which
- a single letter name is completely self explanatory,
- a descriptive name would not add value,
- the generic type has multiple type parameters, and
- there are no type constraints placed on a type parameter.

This implies that the scope of the type parameters is small since short names imply that the size of the containing scope is also small.  As Robert Martin says in [N5 on page 312](https://www.google.com/books/edition/Clean_Code/hjEFCAAAQBAJ?gbpv=1&bsq=%22N5:%20Use%20Long%20Names%20for%20Long%20Scopes%22) of [Clean Code](https://www.amazon.com/Clean-Code-Handbook-Software-Craftsmanship/dp/0132350882),
> The length of a name should be related to the length of the scope.  You can use very short variable names for tiny scopes, but for big scopes you should use longer names.

# Naming constraints

Like all instances of the [naming optimization problem](2020-07-17_naming_optimization_problem), the type parameter names must be unique because they are in the same scope.  An additional constraint imposed by C# is that each name must be a [legal identifier](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/inside-a-program/identifier-names).  Roughly speaking, a legal identifier starts with an underscore (`_`) or a letter and then may have additional underscores (`_`), letters, and numbers.

# Conventions

Below I give three conventions for naming type parameters.  I created names for each of them.  If any convention already has a name, then I would love to hear about it.

## 1. Numeric

> `T1`, `T2`, `T3`, ...

This convention begins each name with `T` and then finishes with the next natural number.  A good example of this convention is the multi-parameter versions of `Func`.  The [variant with 17 type parameters](https://docs.microsoft.com/en-us/dotnet/api/system.func-17) is shown above in the feature image.

### Advantages

- Order, quantity, and indices are clearly communicated by the natural numbers.
- All names start with the idiomatic letter `T`.

### Disadvantages

- The prefix `T` is somewhat redundant.  When every name in a scope starts with `T`, then none of them should.  It could be that `T` was only included because the identifier is not legal without it.

### Variable names

With these type parameter names, I would be [least surprised](https://en.wikipedia.org/wiki/Principle_of_least_astonishment) to see `t1`, `t2`, `t3`, ... as the variable names.  They have the same advantages and disadvantages as the type parameter names.  In the `Func` example, the variables are named `arg1`, `arg2`, `arg3`, ..., which increases the amount of redundant information.

## 2. Mid-alphabetic

> `T`, `U`, `V` ...

This convention selects `T` as the name of the first type parameter and then continues alphabetically using the letters after `T`.  I have only seen this convention used in proprietary code.  I have also seen alternatives that start with `S` instead of `T`.

### Advantages

- No redundant information.
- Order clearly communicated by the order of the letters in the alphabet.
- One name starts with the idiomatic letter `T`.

### Disadvantages

- Most names do not start with the idiomatic letter `T`.
- Quantity and indices are not immediately clear.  Because of the alternative starting from `S`, it is unclear if the index of `T` is `1` or `2`.  Beyond that, I do not know the index of `X` because I do not intuitively know how far `X` is away from `T`.

### Variable names

With these type parameter names, the variable names that I have see are their lowercase equivalents.  That would be `t`, `u`, `v`, ... when starting from `t`.  They have the same advantages and disadvantages as the type parameter names.

## 3. Alphabetic

> `A`, `B`, `C`, ...

This convention selects `A` as the name of the first type parameter and then continues alphabetically using the letters after `A`.  I first encountered this convention in [`language-ext`](https://github.com/louthy/language-ext).  Here is an example of me [standardizing a file](https://github.com/louthy/language-ext/pull/514/files) to use this convention.

### Advantages

- No redundant information.
- Order, indices, and quantity are intuitively communicated by the natural correspondence between the alphabet and the natural numbers.

### Disadvantages

- No names start with the idiomatic letter `T`.

### Variable names

With these type parameter names, the variable names that I have seen are their lowercase equivalents.  That would be `a`, `b`, `c`, ..., and they have the same advantages and disadvantages as the type parameter names.

# My opinion

I prefer the alphabetic convention.  I think it has best tradeoffs.  Since the scope is small, it is clear from context that these are all names of type parameters.  Beginning each name with `T` is completely redundant.

# Summary

When the only thing known about a set of type parameters is their order and quantity, then naming them alphabetically starting with `A`, `B`, `C`, ... minimizes noise while still intuitively communicating the order and quantity because of the natural correspondence between the alphabet and the natural numbers.

---

The feature image is from a screenshot I took of the [documentation of `System.Func-17`](https://docs.microsoft.com/en-us/dotnet/api/system.func-17) in the .NET API.

This post was based on [this post](https://tysondw.blogspot.com/2019/01/minimal-and-intuitive-type-parameter.html) to my previous blog on 2019-01-19.  I think this post is better.

> :SeeTypo$

# Tags

The [tags feature of Coding Blog Plugin](https://connect-platform.github.io/coding-blog-plugin/tags) is still being developed.  Eventually the tags will link somewhere.

[CSharp](:Tag)

# Comments

> :DarkLight
> > :InLight
> >
> > > :Utterances theme=github-light
>
> > :InDark
> >
> > > :Utterances theme=icy-dark
