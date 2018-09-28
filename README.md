This is my attempt on the anagram kata: http://codekata.com/kata/kata06-anagrams/


I have tried different implementation and tested them for performance.
Here are the results:

```
1. AnagramalistParallelLinq                        average from 20 tests: 0,5120279s
2. AnagramalistDictionary                          average from 20 tests: 0,79161086s
3. AnagramalistParallelForWithBatches              average from 20 tests: 0,92026755s
4. AnagramalistLinq                                average from 20 tests: 1,00821225s
5. AnagramalistConcurentDictionary_CutomComparator average from 20 tests: 1,012132575s
6. AnagramalistConcurentDictionary                 average from 20 tests: 1,05540081s
7. AnagramalistDictionary_CustomComparator         average from 20 tests: 1,918709145s
```
