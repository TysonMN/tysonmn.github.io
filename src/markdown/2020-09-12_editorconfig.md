> :Title
>
> EditorConfig

> :Author name=Tyson Williams,
>         date=2020-09-12,
>         avatar=src/assets/images/TysonWilliams.jpg

_Maintain coding style conventions using EditorConfig._

I like working in a codebase with a consistent coding style.  Variations in coding style surprise me.  In programming, [surprise is not good](https://en.wikipedia.org/wiki/Principle_of_least_astonishment).

To help maintain a consistent coding style, I use [EditorConfig](https://editorconfig.org/).  It is a configuration file that exists in the repository just like a [.gitignore file](https://git-scm.com/docs/gitignore).  Many code editors support EditorConfig, including [Visual Studio](https://docs.microsoft.com/en-us/visualstudio/ide/create-portable-custom-editor-options).  In fact, Visual Studio can export [its code style settings as an EditorConfig file](https://docs.microsoft.com/en-us/visualstudio/ide/code-styles-and-code-cleanup#code-styles-in-editorconfig-files).

EditorConfig is especially helpful when working in a team.  Part of my onboarding process used to include giving the new programmer my Visual Studio settings file that only contained my text editor settings.  Now their copy of Visual Studio will automatically use the coding style defined in the EditorConfig file.

To help you get started, you can use my [EditorConfig file](src/assets/text/.editorconfig).  For each setting, the choice I made is less important than that fact that I made a choice.  It is fine to choose different settings.  The important thing is that you have some EditorConfig file.

# Summary

Use EditorConfig to store coding style conventions and to efficiently share those conventions with everyone on your team.

---

> :SeeTypo$

# Tags

The [tags feature of Coding Blog Plugin](https://connect-platform.github.io/coding-blog-plugin/tags) is still being developed.  Eventually the tags will link somewhere.

[DevOps](:Tag) [Teamwork](:Tag)

# Comments

> :DarkLight
> > :InLight
> >
> > > :Utterances theme=github-light
>
> > :InDark
> >
> > > :Utterances theme=icy-dark
