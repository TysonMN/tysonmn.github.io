> :Hero src=src/assets/images/Windows_File_Explorer_Search.png

> :Title
>
> Everything

> :Author name=Tyson Williams,
>         date=2020-07-29,
>         avatar=src/assets/images/TysonWilliams.jpg

_The Windows search utility called Everything instantly returns search results._

Searching for files and folders is a basic operation.  Windows File Explorer is an adequate solution to this problem in limited cases, but an alternative is needed for the general case.  I have such an alternative.

# Windows File Explorer

Windows File Explorer can search for files and folders.  I often use it to find the `sln` file in a newly cloned repository.  Sometimes I use it within a git repository to quickly find and delete `bin` and `obj` directories as an alternative to executing [`git clean -fdx`](/2020-07-11_systematic_cleaning).

However, Windows File Explorer is exceedingly slow when the search space is large.  It took 17 minutes to complete the search for "the" shown in the feature image.  The search space was my `C` drive, which totals 154 GB in 1,000,000 files contained in 200,000 folders.

![Metadata for my C drive](src/assets/images/C_drive_metadata.png)

In response to this, some create an escalating sequence of [20 troubleshooting steps](https://windowsreport.com/file-explorer-slow-windows-10/) culminating in "Create a new user account".  Keep your user account.  I have another solution.

# Everything

A coworker introduced me to the search utility called [Everything](https://voidtools.com/) one day when we were pair programming.  I started a search in Windows File Explorer for some file, and he said that I should use Everything.  I let the Windows File Explorer search continue while I
- downloaded Everything,
- installed it,
- opened it,
- waited for it to finish indexing my `C` drive,
- entered the same query, and
- immediately found the file I wanted.

The whole process couldn't have taken more than a minute or two.  Then I went back and stopped the search in Windows File Explorer, which still had not found the file.

## Present working directory

New solutions become available with such wicked fast searching.  Here is one way that I like to use Everything.

We have all gotten a "file not found" error when attempting to find a file with a relative path.  One reason this happens to me is that I don't know what the present working directory is.  If the situation supports an attached debugger or logging, then I use that, but sometimes these options are not available.  In such extreme cases, instead of looking for a certain file, I create a file in the present working directory with a specific and unique name like `tyson-test`.  Then I use Everything to instantly find that file and thus the present working directory.

# Summary

When searching a large amount of files and folders in Windows, use the search utility called [Everything](https://voidtools.com/).  It will instantly return all the search results as fast as you can type.

---

> :SeeTypo$

# Tags

The [tags feature of Coding Blog Plugin](https://connect-platform.github.io/coding-blog-plugin/tags) is still being developed.  Eventually the tags will link somewhere.

[devops](:Tag) [Windows](:Tag)

# Comments

> :DarkLight
> > :InLight
> >
> > > :Utterances theme=github-light
>
> > :InDark
> >
> > > :Utterances theme=icy-dark
