# Kata04: Data Munging

My attempt on http://codekata.com/kata/kata04-data-munging/

Martin Fowler gave me a hard time for Kata02, complaining that it was yet another single-function, academic exercise. Which, or course, it was. So this week let’s mix things up a bit.

Here’s an exercise in three parts to do with real world data. Try hard not to read ahead—do each part in turn.

### Part One: Weather Data
In weather.dat you’ll find daily weather data for Morristown, NJ for June 2002. Download this text file, then write a program to output the day number (column one) with the smallest temperature spread (the maximum temperature is the second column, the minimum the third column).

### Part Two: Soccer League Table
The file football.dat contains the results from the English Premier League for 2001/2. The columns labeled ‘F’ and ‘A’ contain the total number of goals scored for and against each team in that season (so Arsenal scored 79 goals against opponents, and had 36 goals scored against them). Write a program to print the name of the team with the smallest difference in ‘for’ and ‘against’ goals.

### Part Three: DRY Fusion
Take the two programs written previously and factor out as much common code as possible, leaving you with two smaller programs and some kind of shared functionality.

### Kata Questions
To what extent did the design decisions you made when writing the original programs make it easier or harder to factor out common code?
> I didn't extract any functions so everything was in one function. Thus it was easy to see what is common for both functions.
> The second `Parser` was a copy-paste with modification from the first one - this made it easy to extract common code from them.

Was the way you wrote the second program influenced by writing the first?
> Yes. The second was a almost copy-pasete of the first.

Is factoring out as much common code as possible always a good thing? 
> No. Sometimes code looks similiar but after extracting a common part we burry logic depper in the "shared" part. The code using "shared" logic beomes harder to understand because we need to jump back and forth when reading code.
> I try to use the "rule of three" as a rule of thumb when to extract common code - you need at least 3 places to extract common code.
> When you see similar code in 2 places it might be it just an "accident", the code is too simple to be extracted, the requirements for both code pieces might change and the common part will make even less sense.

Did the readability of the programs suffer because of this requirement? 
> Yes
How about the maintainability?
> I think it suffered too becuse whenever new requirement will come for any of the Parsers it will be probably handled in the common code, thus we will need to make sure we don't break any other code using the "common" code.
