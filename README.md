# Kata11: Sorting It Out

http://codekata.com/kata/kata11-sorting-it-out/

Just because we need to sort something doesn’t necessarily mean we need to use a conventional sorting algorithm.

We use sorting routines all the time; putting customer records in to name order, arranging orders by value (and even sorting the letters in a word back in KataSix). Most of the time we (wisely) use one of the sort routines built in to our language’s library (such as C’s qsort and Java’s java.Collections.sort). After all, very clever folks spent a lot of time getting these library routines tuned for speed and/or memory usage.

However, there are times when whipping up a sort of our own can outperform these generic routines. Our challenge this week is to implement a couple of different sorts. (However, at the risk of giving the game away, these sorts both have something in common).

## Sorting Balls
In the Pragmatic Lottery (motto: There’s One Born Every Minute, and it Might Just Be You!), we select each week’s winning combination by drawing balls. There are sixty balls, numbered (not surprisingly, as we are programmers) 0 to 59. The balls are drawn by the personable, but somewhat distracted, Daisy Mae. As a result, some weeks five numbers are drawn, while other weeks seven, nine, or even fifteen balls make it to the winner’s rack. Regardless of the number of balls drawn, our viewers need to see the list of winning numbers in sorted order just as soon as possible. So, your challenge is to come up with some code that accepts each number as it is drawn and presents the sorted list of numbers so far. The tests might look something like:

```
rack = Rack.new
assert_equal([], rack.balls)
rack.add(20)
assert_equal([ 20 ], rack.balls)
rack.add(10)
assert_equal([ 10, 20 ], rack.balls)
rack.add(30)
assert_equal([ 10, 20, 30 ], rack.balls)
```

## Sorting Characters
Our resident conspiracy expert, Dr. X, is looking for hidden messages in the collected publications of Hugh Hefner. Dr. X believes the message is hidden in the individual letters, so rather than get distracted by the words, he’s asked us to write a program to take a block of text and return the letters it contains, sorted. Given the text:

```
When not studying nuclear physics, Bambi likes to play beach volleyball.
```
our program would return:
```
aaaaabbbbcccdeeeeeghhhiiiiklllllllmnnnnooopprsssstttuuvwyyyy
```

The program ignores punctuation, and maps upper case to lower case.

Are there any ways to perform this sort cheaply, and without using built-in libraries?

## Benchmarking Sorting

I have compared my sorting implementation and one using `Linq`. Both take advantage of the fact that we don't really have to sort characters, we can just count them.

Benchamrks use [BenchmarkDotNet](https://benchmarkdotnet.org/):


``` ini

BenchmarkDotNet=v0.11.3, OS=Windows 10.0.17134.407 (1803/April2018Update/Redstone4)
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
Frequency=2742190 Hz, Resolution=364.6720 ns, Timer=TSC
  [Host]     : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.3221.0
  DefaultJob : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.3221.0


```
|             Method |     Mean |     Error |    StdDev |
|------------------- |---------:|----------:|----------:|
| TestSortUsingLinqu | 46.72 us | 0.8095 us | 0.6760 us |
|     TestCustomSort | 25.44 us | 0.2268 us | 0.2122 us |
