> :Title
>
> Functional Programming in C#

> :Author name=Tyson Williams,
>         date=2020-08-23,
>         avatar=src/assets/images/TysonWilliams.jpg

_Start programming functionally in C# by reading Functional Programming in C# and using `language-ext`._

I started my professional programming career mostly writing C#.  I had learned to program about a decade before and had mostly used Java after that, so the transition to C# was easy for me.  In C#, my style was initially [object-oriented](https://en.wikipedia.org/wiki/Object-oriented_programming) and continued to be so for the first couple years.

Around that time, the idea to write more [functionally](https://en.wikipedia.org/wiki/Functional_programming) was in the air at our company.  I debated whether I should first switch to a functional language like F# and then learn functional programming or stick with C# and learn functional programming there.  Surely learning F# (in my free time) would be easier than learning functional programming, right?  Then I could learn functional programming in a language that was designed for it.

I decided that the best approach was to stick with C#.  The main reason is that I was using C# every day at work, so while I am trying to learn functional programming in C# with my limited free time, I can practice using the new concepts that I am learning while writing C# at work.

If you are a C# programmer with an object-oriented style and want to begin your journey into functional programming, then here are my top recommendations.

# Read the book Functional Programming in C#

Enrico Buonanno is the author of the book [Functional Programming in C#](https://www.manning.com/books/functional-programming-in-c-sharp).  This is the prefect book on functional programming for C# programmers.  It is beyond satisfying to see functional programming examples in a language that is so familiar to me.  Even better is that the examples are pragmatic and focus on line-of-business application scenarios.

The book is published by Manning Publications, and the link above is to their page for this book.  At that page, you can buy this book in paper or electronic form.  I recommend buying both.
Immediately after being told about this book, [I bought paper and electronic copies](https://github.com/louthy/language-ext/issues/507#issuecomment-432369715).  A nice benefit of buying this book from Manning is access to an exclusive place to comment on the book.  Enrico Buonanno replied to many of the questions that I asked there.

# Use `language-ext`

[`language-ext`](https://github.com/louthy/language-ext) is a base class library for functional programming in C#.  It is the best library for this purpose.  It is lead by [Paul Louth](https://github.com/louthy).  He has the heart of a teacher.  It is not uncommon for Paul to respond at length to user questions.  See the issues tagged [`examples / documentation`](https://github.com/louthy/language-ext/issues?q=is%3Aissue+label%3A%22examples+%2F+documentation%22).  He has also written extensive [documentation in the wiki](https://github.com/louthy/language-ext/wiki).

Supporting Paul and this library are a good number of [contributors](https://github.com/louthy/language-ext/graphs/contributors).  I started my journeys into both functional programming and contributing to open source through `language-ext`.  Especially because of my initial activity, I currently have the second most commits.  I am less active these days, but I am still [watching](https://github.com/louthy/language-ext/graphs/contributors) and will answer questions or fix bugs if I have the necessary knowledge.  If you have a question about `language-ext`, then [create an issue](https://github.com/louthy/language-ext/issues/new) and Paul, I, or someone else will answer your question.

# Consume content by Mark Seemann

Mark Seemann is a [Microsoft MVP](https://mvp.microsoft.com/en-us/PublicProfile/5000205?fullName=Mark%20Seemann), [conference speaker](https://www.youtube.com/c/NDCConferences/search?query=Mark+Seemann), and teacher with [a video series at Clean Coders](https://cleancoders.com/series/humane-code-real) and [courses at Pluralsight](https://www.pluralsight.com/authors/mark-seemann).  On top of that, he is a prolific [blogger](https://blog.ploeh.dk/).  Many of his blog posts are aimed at C# programmers.  The example code on his blog is written in C#, F#, or Haskell, and often the same example is given in more than one language.  One way I routinely encounter ideas in functional programming that are new to me is by reading his latest blog posts.  I often comment on his posts, and he always responds.

To consider an example, my favorite blog post is [Composite as a monoid](https://blog.ploeh.dk/2018/03/12/composite-as-a-monoid/).  It became my favorite after taking his workshop [From Design Patterns to Universal Abstractions](https://seemannworkshop.netcorebcn.group/) at NDC Minneapolis 2019.  The main thing I learned from the workshop was that a [monoid](https://en.wikipedia.org/wiki/Monoid), which is essentially the same as the [composite pattern](https://en.wikipedia.org/wiki/Composite_pattern), is the correct way to expose [impure behavior](https://en.wikipedia.org/wiki/Pure_function#Impure_functions).

# Read Eric Lippert's blog post series on Monads

Functional programming is famous (and possibly infamous) for the concept of a [monad](https://en.wikipedia.org/wiki/Monad_(functional_programming)).  Much ink has been spilled and ASCII characters displayed in attempts to explain this concept.  This is partly because it is a difficult concept to understand.  It look me a long time to reach my current understanding, and I know there is more on this topic that I want to learn.

I think the best source for a C# programmer to begin forming a precise understanding of monads is by reading [Eric Lippert's blog post series on monads](https://ericlippert.com/2013/02/21/monads-part-one/).  It begins at that link and includes thirteen posts.  [Eric Lippert](https://ericlippert.com/about-eric-lippert/) was a member of the C# language design time, and [has many highly voted answers](https://stackoverflow.com/search?q=user:88656+[c%23]) for questions tagged C# on StackOverflow.  That is to say, he knowns a lot about about C#, and he spends lots of time explaining the complicated parts of C# to others.

I say "begin forming a precise understanding" because an explanation of monads is not required to start using them, which is much more important than "understanding them".  In fact, you are probably already using monads in C# without realizing it.  Types like `IEnumerable<T>` and `Task<T>` are monads because of intensional choices by language designers like Eric Lippert.  It is not necessary to study monads in order to program functionally in C#.  Instead, at some point on your journey into functional programming, you will want gain a better understanding of monads.  That is when you should begin reading those posts.

# Summary

There are great resources for C# programmers to learn about functional programming.  Start by buying both the paper and electronic copies of Enrico Buonanno's [Functional Programming in C#](https://www.manning.com/books/functional-programming-in-c-sharp).  As you read that, begin incorporating what you learn into your C# programs at work with help from [`language-ext`](https://github.com/louthy/language-ext).  Keep up your motivation to learn functional programming by subscribing to [blog posts by Mark Seemann](https://blog.ploeh.dk/), and read [Eric Lippert's blog post series on monads](https://ericlippert.com/2013/02/21/monads-part-one/) when you are ready to challenge yourself and gain a better understanding of monads.

---

> :SeeTypo$

# Tags

The [tags feature of Coding Blog Plugin](https://connect-platform.github.io/coding-blog-plugin/tags) is still being developed.  Eventually the tags will link somewhere.

[functional programming](:Tag) [CSharp](:Tag)

# Comments

> :DarkLight
> > :InLight
> >
> > > :Utterances theme=github-light
>
> > :InDark
> >
> > > :Utterances theme=icy-dark
