> :Hero src=https://images.unsplash.com/photo-1598259464107-c64378c191ff?w=1993&h=950&fit=crop&crop=bottom

> :Title
>
> Pair programming is like driving with a navigator

> :Author name=Tyson Williams,
>         date=2021-10-15,
>         avatar=src/assets/images/TysonWilliams.jpg

_In my experience, pair programming is like driving with help from a navigator._

[All analogies are wrong, but some are useful.](https://en.wikipedia.org/wiki/All_models_are_wrong)  In the set of all analogies for pair programming, I prefer the one that compares it to driving with a navigator.  I find it useful.  Hopefully you do too.

# Dueling analogies

I am writing this blog post in order to join a conversation on Twitter about pair programming analogies.  On one side is [this tweet](https://twitter.com/mattwynne/status/1448000722620989440) that says (when exaggerated) that pair programming is better than asynchronously reviewed pull requests.

> :Quote from=Matt Wynne
>
> Imagine being in a band where each member plays their instrument separately, then sends it to the others who write a letter with their feedback.
> 
> That is what your PR / code review process looks like to someone who has experienced ensemble or pair programming.

On the other side is [this tweet](https://twitter.com/ploeh/status/1448027069116567553) that says (when exaggerated) that asynchronously reviewed pull requests are better than pair programming.

> :Quote from=Mark Seemann
>
> Imagine being asked to write an essay for an anthology, but someone's constantly looking over your shoulder. "Why are you typing 'e' now?" Contemplation? Forget it.
> 
> That's how pair programming feels to someone who's tried asynchronous development with PRs.

I think the truth is somewhere in the middle.

# Driving

The analogy of pair programming to driving with a navigator is so common among my friends that we often use the verb "drive" to mean the act of pressing keys on the keyboard in order to write the code.

> :Quote
>
> You want to pair program?  Ok.  Would you like to drive or should I drive?

Driving a car requires a high degree of concentration.  You need to stay in your lane, know your speed, pay attention to other cars, watch for pedestrians, and obey all traffic laws.  Some situations require more focus like high levels of traffic, many intersections, or bad weather.  Such moments require the highest levels of focus.  This is also known as being in the zone or being in the [state of flow](https://en.wikipedia.org/wiki/Flow_(psychology)).

Driving the keyboard to write code also requires a high degree of concentration.  You have to remember what you are trying to compute, what functions are available to call, what data is available to pass, and it all needs to fit together like a perfect jigsaw puzzle.  Some situations require more focus like when dealing with multiple threads, simultaneously working with many levels of abstractions, or fixing buggy code.  Such moments greatly benefit from a heightened state of flow.

# Navigating as driver

The role of a driver is different from the role of the navigator.  In fact, there is even a term for a navigator that is trying to tell the driver how to drive.  Such a navigator is called a [backseat driver](https://en.wikipedia.org/wiki/Back-seat_driver).  Growing up, my dad would often drive for our family on trips through Iowa.  He would always look to the side at the fields of corn and beans and tried to spot deer.  Inevitably, he would drift toward the edge of the road and my mom would say

> :Quote
>
> edge....edge...edge..edge Edge EDGE EDGE! EDGE!!!

Surely my mom thought she was being a good navigator in that moment, and my dad probably thought there was nothing to worry about since the [rumble strip](https://en.wikipedia.org/wiki/Rumble_strip) would let him know when he had drifted too far.

When pair programming, the role of the person at the keyboard is different from the person assisting this keyboardist.  The efforts of such a programming assistant are unlikely to be well received.

> :Quote
>
> Why are you typing `e` now?  You typed `babe` but meant to type `baby`.

If I were this keyboardist, I would not appreciate this comment either _as I type `e`_.  I am trying to 
maintain my focus.  Don't knock me out of flow with this immediate and detailed feedback.  Wait until there is a pause in the action, I see the compiler error under the unknown identifier `babe`, and then say "change `e` to `y`".

It is easy for me to see how people like Mark dislike pair programming if they have only paired with navigators that try to be drivers.

# Navigating as navigator

Recently I was driving my family to our home in the suburbs of the [Twin Cities of Minnesota](https://en.wikipedia.org/wiki/Minneapolis%E2%80%93Saint_Paul).  Normally I can do this without assistance, but the heavy traffic in the other direction reminded us that a Vikings football game was almost done.  Typically I would drive right by the stadium, but that was not a good way to go right now.  I continued my role as a driver by keeping my eyes on the road, my hands on the wheel, and my foot on the accelerator.  At the same time, my wife took on the role of navigator.  However, it wasn't as simple as her asking Google Maps for directions.  The first direction we were given was confusing to both of us.  Because of the uncertainty, I did what I could to make things better by slowing down and getting in a middle lane (so that both options at the next fork would be easy to take).  She did what she could by looking ahead on the path Google had selected to figure out which way we were supposed to go.  Importantly, neither of us took on the responsibilities of the other person's role.  (The confusion was that Google has used a secondary name for the road that we did not know and was not on any road signs.)

Recently at work, I couldn't get a test to pass.  A list from an API call was supposed to contain two elements but it contained none.  I had just added the test in a part of the codebase that was new to me.  I started writing that test by copying one of the existing tests.  The behavior of the feature under test seemed correct to me when I manually tested it.  Those last two facts should have led me to the problem, but I still couldn't find it.  My coworker came to help.  He didn't see the problem right away either, so he navigated while I drove as we stepped through each stack frame one by one.  In one method call, we found a filter was applied causing the two elements to be dropped.  But there shouldn't be a filter in this case!  Immediately we went back to the test and deleted the filter that I had copied from the other test.  Finding a bug in test code is especially difficult, and [Mark has also found a bug in test code while doing pair/mob programming](https://blog.ploeh.dk/2019/10/14/tautological-assertion/).

I have been overseas twice: once to Jamaica and once to Germany.  On neither occasion did I drive, but I remember thinking what it would be like: constant uncertainty!  Even as a pedestrian in Germany I felt uncertain.  While I was waiting at a crosswalk for a signal to cross, a local walked past without hesitation.  Back in the US, I would have taken this as my sign to follow, but I thought it best to compensate for my high level of uncertainty by waiting for the "official" signal to cross instead of this ad hoc one.  I would be so greatly helped as a driver in Germany if I had a navigator.  It wouldn't be like this forever either.  Over time, my confidence would increase, my uncertainty would decrease, and I would feel comfortable driving alone.

# Solo driving

Most of my time driving a car is done without a navigator.  I drive to soccer (and back), to dance (and back), to church (and back).  I don't need a navigator in these cases.  My driving skill is high enough, those routes are easy enough, and my experience with them is quite large.  But sometimes I make mistakes when solo driving that would have been caught by a navigator.  Once I was driving east on a highway when I suddenly believed that I actually wanted to be going west.  I abruptly pulled over to the great surprise of my partially asleep girlfriend.  A brief discussion convinced me that we did in fact want to go east.  Another time without a navigator, I missed my turn to go west.  Instead I continued north for 30 minutes.

I wouldn't make either of those mistakes today.  Google Maps on my phone would quickly let me know if I missed my turn, and I should just continue driving on the same road in the same direction if Google Maps hasn't told me otherwise (assuming Google Maps is still running!).

I think Mark believes that pair programming is typically not required.  Or, more specifically, that two programmers writing code together is typically less productive than two programmers writing code separately.  That the combined throughput is lower.  I also believe that.  I can get along with my coding well enough by myself most of the time.  Certainly I would be more productive if someone were also there helping me.  However, I think the pair of us would typically be less productive writing code together than when writing code separately.  However, the objective function is more complicated than this.  Pair programming is partly a form of investment.  Roughly speaking, each programmer has become a more efficient programmer from the experience.

[Mark practices a variant](https://blog.ploeh.dk/2020/05/11/afk/) of the [Pomodoro technique](https://en.wikipedia.org/wiki/Pomodoro_Technique) where he leaves his office every 25 minutes.  For 25 continuous minutes, he tries to stay focused and be in the flow state.  A timer then beeps at the stroke of 25 minutes to begin the process of breaking his flow.  He takes off the "driver hat", puts on the "navigator hat", and thinks about where he is going.  Was he going north during that entire 25 minute session when actually missed his turn and should have been going west?  Hopefully not, but probably "yes" some of the time.  That sort of thing certainly happens to me.  Sometimes it is best to just discard all changes and start over.  I think this practice compensates for the fact that Mark is driving alone.  It forces him to consider the navigator's perspective from time to time to make sure he is staying on course.

# Stretching the analogy

Since all analogies are wrong, let me be the first to point out what I think is particularly bad about this one.  Driving a car is a real-time critical task.  There is no `Ctrl+Z` in real life.  Putting too much focus on navigating instead of driving can result in property damage, injury, or death.  In contrast, the risk of writing some wrong code is typically minor.  Pair programming is not a substitute for code reviews of a pull request, nor the other way around.  Code reviews should always happen and they often yield many improvements.

A "code review" for "driving a car" would be like pointing out that I could have done better by parking in the parking lot of my church instead of parking a block away.  My contribution passed "the corresponding test", which would be something like the ability to walk to the church from the parking spot, but I certainly agree that your suggestion is an improvement, and I will make that change.  In general, the driving review can only consider the final state of the car (as well as the people and things inside).  There is no knowledge about the trip itself.  I don't think "the final state of solo driving" makes for a good analogy of asynchronous code reviews for pull requests.  Maybe there is one composite analogy that works well for both pair programming and asynchronous code reviews of pull requests.

# Summary

I think a good analogy for pair programming is driving a car with a navigator.  In both cases, each person should take on different responsibilities according to their role and work together to achieve something that is greater than the sum of the parts.  I think the benefits of pair programming mostly occur when inexperience or uncertainty are high.  One benefit of pair programming is that it is a form of investment.  Ideally each programmer walks away from the experience better prepared for the future.

[Even if it hurts, do it more often](https://blog.ploeh.dk/2021/06/21/agile-pull-requests/).  That goes for both pair programming and asynchronous code reviews of pull requests

My guess is that Mark and I mostly agree about the benefits of pair programming, the benefits of asynchronous code reviews for pull requests, and the tradeoffs between them.  Maybe he will like this analogy for pair programming.

---

Hero image by [Dario Morandotti](https://unsplash.com/@madmartigand) from [Unsplash](https://unsplash.com/)

> :SeeTypo$

# Tags

The [tags feature of Coding Blog Plugin](https://connect-platform.github.io/coding-blog-plugin/tags) is still being developed.  Eventually the tags will link somewhere.

[Suggestion](:Tag) [DevOps](:Tag)

# Comments

> :DarkLight
> > :InLight
> >
> > > :Utterances theme=github-light
>
> > :InDark
> >
> > > :Utterances theme=icy-dark
