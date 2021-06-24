> :Hero src=src/assets/images/git_clean_unlink_failed.png

> :Title
>
> Lock Hunter

> :Author name=Tyson Williams,
>         date=2021-06-21,
>         avatar=src/assets/images/TysonWilliams.jpg

_Use Lock Hunter to close open file handles._

Deleting, moving, or renaming a file fails when a process has an open handle to it.  I [previously suggested](2020-07-13_process_explorer) using [Process Explorer](https://docs.microsoft.com/en-us/sysinternals/downloads/process-explorer) to quickly close open file handles.  Now I suggest using [Lock Hunter](https://lockhunter.com) because it is simpler and faster.

Process Explorer closes open file handles by killing the corresponding process.  Lock Hunter directly closes the open handles while leaving the process alive.


# Lock Hunter

Here is an example of how to use [Lock Hunter](https://lockhunter.com) to close an open handle to a particular file.

Right-click the file and select "What's locking this file?".

> :Center
>
> ![Right-click the file with an open handle and select "What's locking this file?"](src/assets/images/Lock_Hunter_right_click.png)

Click "Yes" to confirm when prompted by [User Agent Control](https://docs.microsoft.com/en-us/windows/security/identity-protection/user-account-control/user-account-control-overview).  Then click "Unlock It!"...

> :Center
>
> ![Click "Unlock It!"](src/assets/images/Lock_Hunter_unlock.png)

...and confirm that want to unlock by clicking "Yes".

> :Center
>
> ![Click "Yes"](src/assets/images/Lock_Hunter_unlock_confirmation.png)

# Summary

Follow these steps to close an open file handle.

- First time
  1. Download and install [Lock Hunter](https://lockhunter.com)
- Every time
  1. Right-click the file
  2. Select **What's locking this file?**
  3. Click **Yes** to confirm the User Agent Control prompt
  4. Click **Unlock It!**
  5. Click **Yes** to confirm unlocking

---

> :SeeTypo$

# Tags

The [tags feature of Coding Blog Plugin](https://connect-platform.github.io/coding-blog-plugin/tags) is still being developed.  Eventually the tags will link somewhere.

[Suggestion](:Tag) [DevOps](:Tag) [Windows](:Tag)

# Comments

> :DarkLight
> > :InLight
> >
> > > :Utterances theme=github-light
>
> > :InDark
> >
> > > :Utterances theme=icy-dark
