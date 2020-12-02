> :Title
>
> Bottom Type in F#

> :Author name=Tyson Williams,
>         date=2020-09-21,
>         avatar=src/assets/images/TysonWilliams.jpg

_It is ALMOST possible to express the bottom type in F#._

The [bottom type](https://en.wikipedia.org/wiki/Bottom_type) is the type that has no values.  It is useful as the return type of a function when every execution either does not terminate or throws an exception.  [Some languages](https://en.wikipedia.org/wiki/Bottom_type#In_programming_languages) include the bottom type.  The [suggestion for F#](https://github.com/fsharp/fslang-suggestions/issues/349) to add the bottom type was declined.  Interestingly, the [suggestion for C#](https://github.com/dotnet/csharplang/issues/538) to add the bottom type lives on.

Nevertheless, it is possible to define the bottom type in F#.  Here is how I would do it.

```fsharp
type Bottom = private Bottom of Bottom
```

My original thought was to omit `of Bottom` and then have this line be alone in its module (so that a public function does not provide access to this private case constructor).  Then I read the suggestion to include `of Bottom` in [this post on Reddit](https://www.reddit.com/r/fsharp/comments/5dmo1f/f_logical_void_type/) from three years ago.  By including `of Bottom`, this [discriminated union](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/discriminated-unions) is a [recursive type](https://fsharpforfunandprofit.com/posts/recursive-types-and-folds/) but lacks a base case.  As such, it is clear from this one line that it is impossible to obtain an instance of `Bottom`.

In addition to having no values, there is another property of the bottom type.  In subtyping systems, it is a subtype of all types.  That is the motivation for the name "bottom".  It sits at the bottom of the type hierarchy.  My bottom type does not have this property.  I think the suggestion for F# to add the bottom type was specifically requesting this feature.

_Added 2020-09-23_

I just realized that this does not work as I had intended because [`Unchecked.defaultof<>`](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-operators-unchecked.html#defaultof) exists.

```fsharp | F# Interactive
> type Bottom = Bottom of Bottom;;
type Bottom = | Bottom of Bottom

> Unchecked.defaultof<Bottom>;;
val it : Bottom = <null>
```

This definition of `Bottom` is a reference type, and reference types can be `null`.  Now the recursive nature is a detriment.  I was aiming for a type with zero values, but I actually created a type with infinitely many values since `<null>`, `Bottom <null>`, `Bottom (Bottom <null>)`, and so on are a rather direct translation of the [Church numerals](https://en.wikipedia.org/wiki/Church_encoding#Church_numerals).

If we change `Bottom` to a `struct`, then the compiler complains about the recursive definition.

```fsharp
[<Struct>]
type (*~*)Bottom(*~*) = Bottom of Bottom
```

> Error	FS0954 This type definition involves an immediate cyclic reference through a struct field or inheritance relation

After removing `of Bottom` to make the type non-recursive, both the reference and struct variants of the definition now have exactly one value.  This is now just a more verbose way to define the [unit type](https://en.wikipedia.org/wiki/Unit_type), the type with just one value, which [F# already has](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/unit-type).

My six-year-old daughter has been saying lately that "there is no perfect; there is only good enough".  I am going to take her advice here and be content with this approximation of the theoretically perfect bottom type in the pragmatic language that is F#.

---

> :SeeTypo$

# Tags

The [tags feature of Coding Blog Plugin](https://connect-platform.github.io/coding-blog-plugin/tags) is still being developed.  Eventually the tags will link somewhere.

[type theory](:Tag) [FSharp](:Tag)

# Comments

> :DarkLight
> > :InLight
> >
> > > :Utterances theme=github-light
>
> > :InDark
> >
> > > :Utterances theme=icy-dark
