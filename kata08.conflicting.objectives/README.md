# Kata08: Conflicting Objectives

My attempt on http://codekata.com/kata/kata08-conflicting-objectives/

Why do we write code? At one level, we’re trying to solve some particular problem, to add some kind of value to the world. But often there are also secondary objectives: the code has to solve the problem, and it also has to be fast, or easy to maintain, or extend, or whatever. So let’s look at that.

For this kata, we’re going to write a program to solve a simple problem, and we’re going to write it with three different sub-objectives. Our program is going do process the dictionary we used in previous kata, this time looking for all six letter words which are composed of two concatenated smaller words. For example:

```
al + bums => albums
bar + ely => barely
be + foul => befoul
con + vex => convex
here + by => hereby
jig + saw => jigsaw
tail + or => tailor
we + aver => weaver
```

Write the program three times.
* The first time, make program as readable as you can make it.
* The second time, optimize the program to run fast fast as you can make it.
* The third time, write as extendible a program as you can.

Now look back at the three programs and think about how each of the three subobjectives interacts with the others. For example, does making the program as fast as possible make it more or less readable? Does it make easier to extend? Does making the program readable make it slower or faster, flexible or rigid? And does making it extendible make it more or less readable, slower or faster? Are any of these correlations stronger than others? What does this mean in terms of optimizations you may perform on the code you write?

## My notes

Readable vs fast:
```
Readable was running for: 00:02:21.2813950
Fast was running for:     00:00:08.0776183
```

Both implementations return a different number of sums. This is because the input wordlist.txt contains invalid UTF8 characters. `string.StartsWtih()` in `.NET` works differently than my own `StartsWith(byte[] bigger, byte[] smaller)`.

Also: it's worth noticing that writing the output takes some time. It was optimized in the Fast version with preparing a single string and writing it with a single call to `Sytem.Console.WriteLine()`.

> For example, does making the program as fast as possible make it more or less readable?

A: yes. Optimizing a program often makes it less readable. Often it is possible to gain performance with not using the general puropse libraries. But general purpose libraries are readable, well known and make the code easy to read. In case of this exercie working with `byte` array is faster than working with strings, but which is more readable:
`string addend = sumCandidate.Substring(augend.Length);`
or 
`Array.Copy(sumCandidate, augend.Length, addend, 0, 12 - augend.Length);`?

> Does it make easier to extend?

Optimizing code can be based on some strict constraints put on our program by the requirement we get. For example this exercise is about finding sums of 6 character words thus we can optimize everything for 6 character words. This will clearly make the software harder to be extended to handle 10 character words.

> Does making the program readable make it slower or faster, flexible or rigid?

Making a program readable does not have to make it slower. But readable software is clearly easier to chage/maintain.

> And does making it extendible make it more or less readable, slower or faster?

I didn't write any "extendible" version. What should be the extensibility points in this program?
This program is preety short and can be modified in a lot of ways, especially the readable version. We could allow to parametrize the length of words we are interested in, or the number of summands. But would this make the program extendible or configurable?

> Are any of these correlations stronger than others?

Since I didn't write the "extendible" version - can't tell. If you dear reader have a "extendible" version please let me know, I'd be interested to see how you appraoched this requirement.

> What does this mean in terms of optimizations you may perform on the code you write?

["Premature optimization" is the root of all evil](http://wiki.c2.com/?PrematureOptimization)
If you make code more readable and simpler and thus it's performing it's task faster - that is optimization but at the same time it's refactoring towards a more readble solution. This is totally fine.

But optimzing code which we don't have to optimize is a bad idea.
If you write a complicated piece of code, which puts togeter a monthly summary of operations in your company and it takes 5 hours for it to finish. You can optimize it, make it less readable and make it finish it's task in maybe 2 hours. But how often will it be run? Maybe noone cares if it runs for 5 hours. Is it worth to put 1 week of your time to do the optimizations?

I rarely get the requirement for something to be fast. Usually it is "stable", "reliable", "readable" (requiered by other developers not by the business).

Even when there is a requirement for speed, we need to have some common sense what is enoght. At which point will futher optimization by a too big trade off in readability?
I'm working in C# usually, if I was supposed to write something "as optimal as possible" I could study C or Assembler but who would like to maintain code written in Assembles in a company full of C# developers? And would anyone really like to pay for this degree of optimization?