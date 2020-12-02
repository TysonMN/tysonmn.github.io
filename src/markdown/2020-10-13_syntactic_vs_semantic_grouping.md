> :Title
>
> Syntactic vs semantic grouping

> :Author name=Tyson Williams,
>         date=2020-10-13,
>         avatar=src/assets/images/TysonWilliams.jpg

_It is more helpful to create semantic groupings than syntactic groupings._

# Grouping types

I think there are at least two types of groupings.  I like to call them syntactic groupings and semantic groupings.  A _syntactic grouping_ is a grouping of items based on some intrinsic characteristic of the items.  A _semantic grouping_ is a grouping of items based on how the items are used.

Let's ground ourselves with several examples.

# Examples

My primary goal with these examples is to show what I mean by syntactic and semantic groupings.  For that reason, many of them are intentionally simple.  Since I have a preference for semantic groupings, maybe I selected examples that over represent the utility of semantic groupings.  To compensate, please do share either more complicated examples or examples in which syntactic groupings have an advantage.

## Shoes

At my house, we keep all of our shoes in our mudroom.  We could group them syntactically by storing all the left shoes in one bin and all the right shoes in another bin.  Of course we don't do that.  Instead, we group them semantically by storing each pair of shoes together.

## Gloves

At the Minnesota State Fair, there is an agricultural education exhibit called [Kemps Little Farm Hands](https://www.mnstatefair.org/location/little-farm-hands/).  At one point in the exhibit, the kids plant a pretend seed in a garden using their hands.  Although the seed is fake, the dirt is real, so the kids use gloves to keep their hands clean.  The whole exhibit is a built like an assembly line.  Anything the kids pick up an one point gets dropped off at another point later on down the line (and then volunteers brings the items back up stream in batches).

The left gloves are in a bin labeled "LEFT" and the right gloves are in a bit labeled "RIGHT".  This syntactic grouping is a good one.  Any left glove works perfectly well with a right glove and vice versa.  It would take more effort to by the volunteers to keep gloves stored in pairs and any mistake would cause a slowdown in the assembly line of kids.  It is easy for the volunteers to keep the gloves syntactically grouped (partly because the left gloves have a big "L" on both sides and the right gloves have a big "R" on both sides), and it is easy for the kids to grab two gloves and know that they have a pair of gloves.

## Pairs of shoes

If you came to my house and cleaned our mudroom,[Please _do_ let me know if you ever want to come over and clean my mudroom! ;)](:Footnote) I am sure that you would do a great job grouping the shoes into pairs.  However, I do not think you would know where to put each pair.  Each of my three kids puts their shoes in a bin (and puts that bin in a cubbyhole).  My wife's shoes go on a shoe rack in the closet and my shoes also go in the closet to the right of the shoe rack.

Grouping the pairs by owner is a semantic grouping.  I think any grouping that you could do would be a syntactic grouping.  Syntactic groupings can have different correlations with semantic groupings.  I would expect the correlation between grouping by owner and grouping by color to be rather low.  Alternatively, the longest or heaviest shoes will be mine, the next longest and heaviest will be my wife's, and all the remaining shoes will mostly be tied for length and weight among my twin 6-year-olds and 4-year-old (with the body of a 5-year-old).

## Netflix

The home screen of Netflix explicitly groups videos by genre.  That is a syntactic grouping.  There is an implicit grouping as well.  Any video shown to me on any part of the home screen is one that Netflix is recommending to me.  That group of videos is much smaller and than the group of videos that Netflix decided not to recommend to me.  This semantic grouping is very valuable to me (and Netflix).

## Files in a repository

This is more than an example.  It is the case that lead me to think about these two types of grouping.

Let's use [Elmish.WPF](https://github.com/elmish/Elmish.WPF) as an example.  A particularly extreme syntactic grouping would separate files by file type:
- F# files (`.fs`)
- F# project files (`.fsproj`)
- C# files (`.cs`)
- C# project files (`.csproj`)
- XAML files (`.xaml`)

Compared to the current organization of the repository, this organization would increase the time it would take me to make a change.  When working on a particular sample, it is helpful to have all the files for that sample next to each other.  Notice that the current organization includes some syntactic organization.  For each sample, the F# files are separate from the C# and XAML files.  This syntactic distinction can be thought of as a constraint imposed my Microsoft's design of C#, F#, their compilers, and Visual Studio.

If I want all F# files next to each other, then I can just search Solution Explorer in Visual Studio or Explorer in Windows for files ending in `.fs`.  So spending time to manually group files semantically gives the best of both worlds because I can immediately make use of the semantic grouping and I can quickly make use of many different syntactic groupings after a search.

# Experience with Angular

My first assignment as a professional programmer was on a project creating a website using Angular.  We organized files in our solution by putting models in one folder, services in another folder, controllers in another folder, entities in another folder mapping logic in another folder, and so on.

I remember reading an article that recommended grouping files by the feature they support instead of by the role they play to implement the feature.  That seemed so much harder to do--because it is!  It is hard for a programmer to look at a new repository and know what features exist in the resulting program.  Relatively speaking, it is much easier for that programmer to find all the controllers.

The [Angular style guide](https://angular.io/guide/styleguide#lift) says it this way.

> :Quote
>
> **LIFT**
>
> **Style 04-01**
>
> **Do** structure the app such that you can Locate code quickly, Identify the code at a glance, keep the Flattest structure you can, and Try to be DRY.
>
> **Do** define the structure to follow these four basic guidelines, listed in order of importance.
>
> **Why?** LIFT provides a consistent structure that scales well, is modular, and makes it easier to increase developer efficiency by finding code quickly. To confirm your intuition about a particular structure, ask: can I quickly open and start work in all of the related files for this feature?
> 
> **Locate**
>
> **Style 04-02**
>
> **Do** make locating code intuitive, simple, and fast.
>
> **Why?** To work efficiently you must be able to find files quickly, especially when you do not know (or do not remember) the file names. Keeping related files near each other in an intuitive location saves time. A descriptive folder structure makes a world of difference to you and the people who come after you.

I am all about developer efficiency.  I strive to improve the efficiency of the development process, and the most important part of the development process is the developers.

Code spends most of its life being read and only a little bit being written.  Therefore, the organization of the code should be optimized for reading.  If I need to add a new service related to feature `X`, it would be easy to create a new file in the `Services` folder.  But when later working on feature `X`, it will be more difficult to find and read that service.  Instead, it is better to spend the time to think about the features, name the features, and group files by the feature they help implement.

# Summary

A general goal is to improve efficiency.  I store my shoes, keys, wallet, and coat in my mudroom because when I am in my mudroom, it often means that I am about to leave my house, and I often need those things when I leave my house.

A specific goal in software development is to improve the efficiency of the development process.  One way to do this is to store files for a single feature together.  I call this a semantic grouping because the feature is not something intrinsic to the files, not a part of the syntax.  It is a phenomenon that is absent in the parts but emerges in their sum.

I feel like naming these grouping types syntactic and semantic has helped me better understand these types of groupings, especially by seeing examples of these grouping types outside of programming.  I hope that you find them helpful as well.

# Footnotes

> :Footnotes

---

> :SeeTypo$

# Tags

The [tags feature of Coding Blog Plugin](https://connect-platform.github.io/coding-blog-plugin/tags) is still being developed.  Eventually the tags will link somewhere.

[naming](:Tag) [software development](:Tag)

# Comments

> :DarkLight
> > :InLight
> >
> > > :Utterances theme=github-light
>
> > :InDark
> >
> > > :Utterances theme=icy-dark
