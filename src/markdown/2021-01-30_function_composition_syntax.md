> :Title
>
> Function composition syntax

> :Author name=Tyson Williams,
>         date=2021-01-30,
>         avatar=src/assets/images/TysonWilliams.jpg

_The execution order of code should match the way it is read in English: from left to right._

Whenever I see function composition in a new context, I make sure to look up its precise definition.  There is a choice that must be made in the definition that has always seemed arbitrary to me...at least until now.  I no longer think the choice is completely arbitrary, and I have an opinion about which choice is better.

# Function composition order

The choice that I am referring to is about the order in which the two functions being composed appear next to the composition operator (which I find is always an [infix](https://en.wikipedia.org/wiki/Infix_notation) operator).  Typically when defining function composition, the names given to the two function being composed are `f` and `g`.  Since I am trying to contrast two possible orderings, I don't want the [implied alphabetic ordering](/2020-07-19_type_parameter_naming) between `f` and `g` to introduce bias.  So instead, I will use the symbols `⬜` and `⚪` to denote the two functions being composed.

For a set `S`, suppose `⬜ : S -> S` and `⚪ : S -> S` are two unary functions from `S` to `S` (i.e. they are [endofunctions](https://en.wikipedia.org/wiki/Endomorphism#Endofunctions)).  Furthermore, let's have the function composition operator be [implicit](https://en.wikipedia.org/wiki/Multiplication#Implicit), which just means that `⬜⚪` is a composition of these two functions.  The ambiguity is this: does `⬜⚪` mean that `⬜` is evaluated first and then `⚪` or is it the other way around?  More specifically, is the composition operator defined so that `⬜⚪(s)` = `⚪(⬜(s))` or is it defined so that `⬜⚪(s)` = `⬜(⚪(s))`?

In my experience with mathematics, I have seen it defined both ways.  If I try to mentally convert my experiences to statistics, the anecdotal conclusion I reach is that I have seen it defined each way about half the time.  That is one reason why the choice seemed arbitrary to me.  If there was an overall advantage with one definition, I would expect to see more of a consensus.

The other reason that this choice seemed arbitrary to me is that I could think of exactly one argument in favor of each definition, and these two arguments seemed about equally strong to me.

The advantage of `⬜⚪(s) = ⚪(⬜(s))` is that the order in which the functions are evaluated is the order in which they appear in the composition syntax.  Technically, this latter ordering depends on the implicit assumption that we are encountering this notation in the context of a natural language like English where the implied ordering is left-to-right (and then top-to-bottom).

On the other hand, the advantage of `⬜⚪(s) = ⬜(⚪(s))` is that when expanding the left side into the right side, the order in which the functions appear does not change.

So until recently, I assumed that the first definition was likely used more often in situations that involved more functions being composed while the second definition was used more in situations that involved more functions being decomposed in order to evaluate them both one at a time.

But now I think the first choice of `⬜⚪(s) = ⚪(⬜(s))` is superior.

To explain why, let's start with just a single function `f`.  It is very common to see the evaluation of `f` on an input `x` written as `f(x)`.  Sometimes the input to `f` is not a single value like `x` but an expression like `a + b` as in `f(a + b)`.  In this case, `a + b` is computed first and then `f` is evaluated on the resulting value.  But this means that the computation is not occurring in the order implied by English: the computation is happening from right-to-left, but we English speakers read this expression from left-to-right.

The placement of the function (or operator) `f` before its input `x` as in `f(x)` is called [prefix notation](https://en.wikipedia.org/wiki/Polish_notation).  If `f` appears after its input `x` as in `(x)f` then it is called [postfix notation](https://en.wikipedia.org/wiki/Reverse_Polish_notation).  If we were using postfix notation for function application (and kept using an implicit infix notation for function composition), then the two potential definitions for function composition would be `(s)⬜⚪ = ((s)⬜)⚪` and `(s)⬜⚪ = ((s)⚪)⬜`.  Now in this case, `(s)⬜⚪ = ((s)⬜)⚪` is the obvious winner.  It has both advantages discussed above: the functions appear in the "English" left-to-right order in which they are evaluated and the order of the functions is unchanged when decomposing the composition.  This leaves no advantages for the other definition.

With this in mind, I can rephrase the advantage that preserves the syntactic ordering when decomposing.  A single function is typically written with its input using prefix notation.  Then to define function composition as `⬜⚪(s) = ⬜(⚪(s))` is to be more consistent with the prefix notation for single function application.  I have to admit, that is a very convincing reason to prefer this definition.

When I design a software application, I try to break up the problem into several loosely coupled pieces.  One reason for this is to help isolate any bad choices.  In this case, I am suggesting that using prefix notation for function evaluation was a bad choice.  As such, I don't want to feel obligated to perpetuate that bad choice into the definition of function composition as well.  Instead, I want to reconsider the advantages and disadvantages and give `⬜⚪(s) = ⚪(⬜(s))` a reasonable chance at being the chosen definition.

# Languages

## C#

C# doesn't have a function composition operator.  It is easy to define an [extension method](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods) to do this, but I haven't found it to be that useful.  Instead, I often use an extension method called [`Apply`](https://github.com/louthy/language-ext/blob/master/LanguageExt.Core/DataTypes/Cond/Cond.cs#L69-L70) that acts as an infix operator taking a unary function on its right and the input to the unary function on its left.  If you squint so that Apply disappears, then this is a way to expression function application in C# using postfix notation.  Then instead of first composing two functions `f` and `g` and then evaluating the result on an input `x`, I use `Apply` twice by writing `x.Apply(f).Apply(g)`.  Now the computation occurs in essentially the same ordering implicit in English, namely left-to-right.

This is very similar to the way [pipelines](https://en.wikipedia.org/wiki/Pipeline_(Unix)) are created in Unix.  As such, I find piped Unix commands natural to read (well...except for the abundant use of abbreviations).

Recall that `Apply` is a binary function and `f` and `g` are unary functions.  We can improve readability (by reducing the noise) with bit more work.  If we turn `f` and `g` in to extension methods (and capitalize them as is convention), then we can write `x.F().G()`.  And now we can increases the expressiveness by passing in additional values to `F` and `G`.  This type of syntax is called [method chaining](https://en.wikipedia.org/wiki/Method_chaining) and is used to create [fluent interfaces](https://en.wikipedia.org/wiki/Fluent_interface).  Enrico Buonanno recommends this style.

> :Quote from=Page 104 of Functional Programming in C#
>
> The method chaining syntax...provides a more readable way of achieving function composition in C#.

Notice that sometimes the method chaining is written with `x`, `F`, and `G` each on their own lines.  This is still consistent with the implicit ordering in English, which is also top-to-bottom.

## Haskell

Consider the function composition operators [`.`](https://wiki.haskell.org/Function_composition) and [`$`](https://typeclasses.com/featured/dollar) in Haskell.  (These operators just [vary in precedence](https://stackoverflow.com/questions/940382/what-is-the-difference-between-dot-and-dollar-sign/1290727#1290727).)  When writing code in Haskell that uses these operators, the resulting code executes in the "wrong" order, i.e. from right-to-left.  As an alternative, you can compose function in the opposite order using the `>>>` operator from [Control.Arrow](https://hackage.haskell.org/package/base-4.14.1.0/docs/Control-Arrow.html).

## F#

The operators `>>` and `<<` compose functions in F#.  The first is called the [forward composition operator](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/symbol-and-operator-reference/#table-of-symbols-and-operators:~:text=Composes%20two%20functions%20(forward%20composition%20operator).) and satisfies `(f >> g) = g(f x)`.  The second is called the [backward composition operator](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/symbol-and-operator-reference/#table-of-symbols-and-operators:~:text=Composes%20two%20functions%20in%20reverse%20order%3B,is%20executed%20first%20(backward%20composition%20operator).) and is described as executing its arguments in the reverse order.  That is, it satisfies `(g << f) = g(f x)`.  [Don Syme](https://en.wikipedia.org/wiki/Don_Syme) (the creator of F#) and I are in total agreement here about which of these two operators is superior.

The symmetry of these operators is also beautiful.  There are other pairs of operators in F# with the same symmetry.  One pair is `|>` and `<|`, which are respectively the [forward](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/symbol-and-operator-reference/#table-of-symbols-and-operators:~:text=Passes%20the%20result%20of%20the%20left%20side%20to%20the%20function%20on%20the%20right%20side%20(forward%20pipe%20operator).) and [backward](https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/symbol-and-operator-reference/#table-of-symbols-and-operators:~:text=Passes%20the%20result%20of%20the%20expression,on%20left%20side%20(backward%20pipe%20operator).) pipe operators and satisfy `a |> f = f a = f <| a`.

[Don does not like the backward pipe opreator](https://youtu.be/MGLxyyTF3OM?t=2511).  I expect he would say the same thing about the backward function composition operator.  Unlike what Don said there, I am glad that both forward and backward operators exist in F#.  It makes it easier to refactor code.  Like Don though, I agree that most code should not use these backward operators (once the refactoring is complete).  Otherwise, the order of execution does not match the reading order in English.

# Summary

The ultimate goal here is to write readable code.  We often say things like "this code is readable" or "that code is not readable" as though readability is a binary condition.  In reality, readability is in a continuum for each person and also varies among people.  What we all (well, many of us) have in common is fluency with a natural language like English that reads left-to-right and top-to-bottom.  By tapping into that common shared experience, we can design programming languages and write code that is more readable for most of us.

---

This post was based on [this post](https://tysondw.blogspot.com/2019/01/syntax-for-composition-of-functions.html) to my previous blog on 2019-01-20.  This post is mostly the same except for [the section about F#](/2021-mm-dd_function_composition_syntax#f), which is new.


> :SeeTypo$

# Tags

The [tags feature of Coding Blog Plugin](https://connect-platform.github.io/coding-blog-plugin/tags) is still being developed.  Eventually the tags will link somewhere.

[Suggestion](:Tag) [CSharp](:Tag) [FSharp](:Tag) [Haskell](:Tag)

# Comments

> :DarkLight
> > :InLight
> >
> > > :Utterances theme=github-light
>
> > :InDark
> >
> > > :Utterances theme=icy-dark
