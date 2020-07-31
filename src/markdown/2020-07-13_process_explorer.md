> :Hero src=src/assets/images/git_clean_unlink_failed.png

> :Title
>
> Process Explorer

> :Author name=Tyson Williams,
>         date=2020-07-13,
>         avatar=src/assets/images/TysonWilliams.jpg

_Use Process Explorer to find and kill processes with open file handles._

Deleting, moving, or renaming a file fails when a process has an open handle to it.  The worst is when I don't know what process has the open handle.  [Process Explorer](https://docs.microsoft.com/en-us/sysinternals/downloads/process-explorer) helps solve this problem.

# Restart computer

I used to fix this problem by restarting my computer.  Whatever process had the open file handle would be killed by the restart and stay "dead".  However, I think this is a huge inconvenience.  I had all my programs running and files open--everything in a particular state--but all of that is also lost in the restart.

Sometimes restarting my computer is the correct fix.  However, I was very happy when I found a targeted solution to this problem.

# Use Process Explorer

Here is an example of how to use [Process Explorer](https://docs.microsoft.com/en-us/sysinternals/downloads/process-explorer) to find and kill the process with an open handle to a particular file.  Suppose I want clean my repository by [executing `git clean -fdx`](/2020-07-11_systematic_cleaning#git-clean--fdx).  As shown in the feature image above, it can fail if Visual Studio is still open.

> git clean -fdx
>
> Unlink of file 'src/.vs/Elmish.WPF/v16/TestStore/0/000.testlog' failed. Should I try again? (y/n)

Use the "Find Handle or DLL..." feature...

![Select Find Handle or DLL in Process Explorer](src/assets/images/Process_Explorer_find_handle_or_DLL.png)

...to enter the file (or folder!) name, click "Search", then click on the correct search result...

![Enter the name and select the correct search result in Process Explorer](src/assets/images/Process_Explorer_search_results.png)

...and kill it.

![Select Kill Process in Process Explorer](src/assets/images/Process_Explorer_kill_process.png)

# Summary

Follow these steps to kill an unknown process with an open file handle.

- First time
  1. Download [Process Explorer](https://docs.microsoft.com/en-us/sysinternals/downloads/process-explorer)
- Every time
  1. Open **Process Explorer**
  2. Press **`Ctrl+F`** or select **File -> Find Handle or DLL...**
  3. Enter the file **name** (or the name of a folder in its path)
  4. Press **Enter** or click **Search**
  5. Click on the correct **search result**
  6. Press **`Del`** or **right-click** and select **Kill Process**
  7. **Confirm** the killing of the process

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
