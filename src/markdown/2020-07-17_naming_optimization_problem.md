> :Title
>
> Naming Optimization Problem

> :Author name=Tyson Williams,
>         date=2020-07-17,
>         avatar=src/assets/images/TysonWilliams.jpg

Naming is an [optimization problem](https://en.wikipedia.org/wiki/Optimization_problem) with uniqueness as the constraint and communication as the objective function.  Uniqueness is easy enough to achieve; just include a [guid](https://en.wikipedia.org/wiki/Universally_unique_identifier).  [Naming is impossibly hard](/2020-07-15_naming_is_impossibly_hard) because it involves communication.

# Uniqueness vs communication

That communication is hard is no revelation.  Instead, I find it helpful to be aware of the tension between uniqueness and communication when picking names.  A newly generated guid would be unique, but it communicates a minimal amount of information.  That is enough information for computers, but humans work better with more.

Uniqueness need not be an absolute constraint.  It might suffice for uniqueness to hold within a particular scope.  That is the theory behind [namespaces](https://en.wikipedia.org/wiki/Namespace).

# Example: Git

The commits in a git repository are a good example to consider.  Each commit includes a [hash](https://git-scm.com/book/en/v2/Getting-Started-What-is-Git%3F#_git_has_integrity), which is 40 characters long and appears random.  Thus, hashes are unique names for commits that computers effortlessly use to find commits.  Each commit also includes a [commit message](https://git-scm.com/docs/git-commit#_discussion), which is typically written by a human.  They are typically unique, but not completely.

I prefer to read commit messages when combing through commits.  If necessary, I double check the commit I found by comparing hashes.  The commit message "initial commit" not only communicates the existence of a commit but also the reasonable assumption that this is the message of the first commit.  On the other hand, a hash only communicates the existence of a commit.

# Summary

Naming is an [optimization problem](https://en.wikipedia.org/wiki/Optimization_problem) with uniqueness as the constraint and communication as the objective function.  When selecting your next name, consider the tension that exists between uniqueness and communication.

---

See a typo? You can fix it by editing [this file](https://github.com/bender2k14/tyson-williams-blog/blob/master/src/markdown/2020-07-17_naming_optimization_problem.md) and then sending me a [pull request](https://github.com/bender2k14/tyson-williams-blog/compare).

# Tags

The [tags feature of Coding Blog Plugin](https://connect-platform.github.io/coding-blog-plugin/tags) is still being developed.  Eventually the tags will link somewhere.

[reference](:Tag)

# Comments

> :DarkLight
> > :InLight
> >
> > > :Utterances theme=github-light
>
> > :InDark
> >
> > > :Utterances theme=icy-dark
