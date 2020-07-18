> :Hero src=src/assets/images/git_clean_fdx.png

> :Title
>
> Systematic Cleaning

> :Author name=Tyson Williams,
>         date=2020-07-11,
>         avatar=src/assets/images/TysonWilliams.jpg

_There are several ways to clean, but `git clean -fdx` is one of my favorites._

My builds can fail for peculiar reasons.  When this happens, I start cleaning.  That is, I remove the output created by previous builds.  Sometimes this helps.

# Cleaning hierarchy

I prefer to slowly escalate my cleaning by starting with the least aggressive cleaning method and then only use more aggressive cleaning methods as needed.  With this approach, I learn something about what caused the state of my repository to become corrupted.

## No-op cleaning

The least aggressive cleaning method is to do no cleaning at all.  In this case, I just try building again.  Most of the time, this is enough.

## Visual Studio clean

[Visual Studio has a clean operation](https://docs.microsoft.com/en-us/visualstudio/ide/building-and-cleaning-projects-and-solutions-in-visual-studio), which is accessible via `Build -> Clean Solution`.  This operation only cleans the loaded projects for the current [configuration](https://docs.microsoft.com/en-us/visualstudio/debugger/how-to-set-debug-and-release-configurations) and the current [platform](https://docs.microsoft.com/en-us/visualstudio/ide/how-to-configure-projects-to-target-platforms).  It does not delete any directories, which I sometimes find confusing.  If such a directory is empty, then I would prefer that it not exist.

I also use this cleaning operation to be completely confident that all tests pass.  Of course when a test executes and fails, it is placed in the group of failed tests.  However, if a test fails to execute, then its group remains the same.  This can happen if a test causes a stack overflow.  So to be sure all tests pass, I first clean, which puts all the tests into the group of not run tests, and then run all tests.  If any test remains in the not run group, then I know that it failed to execute.  I want to see all test in the group of passed tests, and I want this to mean that they all passed the most recently attempted test run.

I am not a fan of the rebuild operation, which is accessible via `Build -> Rebuild Solution` and [essentially the same as cleaning and then building](https://stackoverflow.com/questions/1247457/difference-between-rebuild-and-clean-build-in-visual-studio/1247480#1247480).  Sometimes cleaning can fail.  A common example is when a file is in use.  If this happens while only cleaning, then I immediately know the that problem is related to cleaning.  If this happens while rebuilding, then I need to work harder to determine if the problem is related to cleaning or to building.  Sure, most of the time cleaning succeeds and the computer is more efficient when rebuilding compared to building after cleaning.  However, I am not trying to optimize the efficiency of the computer; I am trying to optimize my own efficiency--the efficiency of the developer.

## `dotnet clean`

Typically I work with code in Visual Studio, but if I am in a terminal, then I might clean by executing [`dotnet clean`](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-clean).  By default and with a solution file in the present working directory, it cleans
- all projects referenced in the solution file,
- for the `Debug` configuration, and
- for all frameworks specified in the project files.

Like the clean operations in Visual Studio, it leaves empty directories everywhere.  Let's see how to avoid that.

## `git clean -fdx`

I always use `git` for source control.  It has a [`clean` command](https://git-scm.com/docs/git-clean) that I always execute as `git clean -fdx`.  It is my favorite way to clean because it makes (the working tree of) my repository look like it was just cloned... except for modifications to tracked files, which are preserved.  To quickly deal with those, I can commit, stash, or discard them.  Here are short explanations of the options.
- [`f`](https://git-scm.com/docs/git-clean#Documentation/git-clean.txt--f) is short for `force` and causes deletions to occur without prompts.
- [`d`](https://git-scm.com/docs/git-clean#Documentation/git-clean.txt--d) causes recursion into untracked directories.
- [`x`](https://git-scm.com/docs/git-clean#Documentation/git-clean.txt--x8) causes deletion of untracked files.

In the terminal, this command outputs the relative path to any file it deletes.  To see that output but not actually delete anything, just add the option [`--dry-run`](https://git-scm.com/docs/git-clean#Documentation/git-clean.txt---dry-run).  And the best part?  It also deletes directories.

There is one disadvantage of this cleaning via `git` compared to `dotnet clean` or the clean operation in Visual Studio.  I need to first close Visual Studio, because it has open handles to various files in the `.vs` directory and this cleaning by `git` wants to delete that directory and everything in it.  That is another reason for the slow cleaning escalation.  I would prefer to keep Visual Studio open, so I only attempt to clean via git if cleaning via Visual Studio failed.

Before I learned about cleaning via `git`, I used to simulate this level of cleaning by deleting everything in the repository except the `.git` directory and then discarding all file deletions in my working tree via `git`.  That works but is exceedingly slower than executing `git clean`.

## Reclone repository

When all else fails, the last resort is to reclone the repository.  This maximum level of cleaning is warranted when there is a problem in `.git` directory.

I created such a problem while developing this [CODEDOC](https://codedoc.cc/)-based website.  I added some configuration that (accidentally) duplicated files when executing [`codedoc build`](https://codedoc.cc/#publishing).  To my surprise, it also duplicated files in the `.git` directory.  No worries.  I had pushed a recent copy to GitHub, so I recloned and got right back to work.

# Summary

I systematically clean my repository when I have build failures for peculiar reasons.  I start with operations that have minimal changes and slowing escalate to operations that have more changes.  Among these operations, my favorite is `git clean -fdx` because it is fast, lists all its changes, and typically leaves my repository in a squeaky-clean state.

---

See a typo? You can fix it by editing [this file](https://github.com/bender2k14/tyson-williams-blog/blob/master/src/markdown/2020-07-11_systematic_cleaning.md) and then sending me a [pull request](https://github.com/bender2k14/tyson-williams-blog/compare).

# Tags

The [tags feature of Coding Blog Plugin](https://connect-platform.github.io/coding-blog-plugin/tags) is still being developed.  Eventually the tags will link somewhere.

[devops](:Tag) [git](:Tag)

# Comments

> :DarkLight
> > :InLight
> >
> > > :Utterances theme=github-light
>
> > :InDark
> >
> > > :Utterances theme=icy-dark
