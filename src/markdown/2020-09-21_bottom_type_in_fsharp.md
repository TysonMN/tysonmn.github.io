> :Title
>
> Bottom Type in F#

> :Author name=Tyson Williams,
>         date=2020-09-21,
>         avatar=src/assets/images/TysonWilliams.jpg

_It is possible to express the bottom type in F#._

The [bottom type](https://en.wikipedia.org/wiki/Bottom_type) is the type that has no values.  It is useful as the return type of a function when every execution either does not terminate or throws an exception.  [Some languages](https://en.wikipedia.org/wiki/Bottom_type#In_programming_languages) include the bottom type.  The [suggestion for F#](https://github.com/fsharp/fslang-suggestions/issues/349) to add the bottom type was declined.  Interestingly, the [suggestion for C#](https://github.com/dotnet/csharplang/issues/538) to add the bottom type lives on.

Nevertheless, it is possible to define the bottom type in F#.  Here is how I would do it.

```fsharp
type Bottom = private Bottom of Bottom
```

My original thought was to omit `of Bottom` and then have this line be alone in its module (so that a public function does not provide access to this private case constructor).  Then I read the suggestion to include `of Bottom` in [this post on Reddit](https://www.reddit.com/r/fsharp/comments/5dmo1f/f_logical_void_type/) from three years ago.  By including `of Bottom`, this [discriminated union](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/discriminated-unions) is a [recursive type](https://fsharpforfunandprofit.com/posts/recursive-types-and-folds/) but lacks a base case.  As such, it is clear from this one line that it is impossible to obtain an instance of `Bottom`.

In addition to having no values, there is another property of the bottom type.  In subtyping systems, it is a subtype of all types.  That is the motivation for the name "bottom".  It sits at the bottom of the type hierarchy.  My bottom type does not have this property.  I think the suggestion for F# to add the bottom type was specifically requesting this feature.

---

> :SeeTypo$

# Tags

The [tags feature of Coding Blog Plugin](https://connect-platform.github.io/coding-blog-plugin/tags) is still being developed.  Eventually the tags will link somewhere.

[Type Theory](:Tag) [FSharp](:Tag)

# Comments

> :DarkLight
> > :InLight
> >
> > > :Utterances theme=github-light
>
> > :InDark
> >
> > > :Utterances theme=icy-dark
