This is my attempt on the anagram kata: http://codekata.com/kata/kata06-anagrams/


I have tried different implementation and tested them for performance.
Here are the results:

```
.NET Core 2.1.201:
1. AnagramalistParrallelGrouping_CustomStruct        average from 50 tests: 0,311820s
2. AnagramalistParallelLinq                          average from 50 tests: 0,414820s
3. AnagramalistDictionary                            average from 50 tests: 0,541533s
4. AnagramalistParrallelForEach_CustomStruct         average from 50 tests: 0,715652s
5. AnagramalistLinq                                  average from 50 tests: 0,861752s
6. AnagramalistParallelForWithBatches                average from 50 tests: 0,881180s
7. AnagramalistConcurentDictionary_CutomComparator   average from 50 tests: 1,116662s
8. AnagramalistDictionary_CustomComparator           average from 50 tests: 1,535724s
9. AnagramalistConcurentDictionary                   average from 50 tests: 1,965752s

.NET Framework 4.7.1:
1. AnagramalistParrallelGrouping_CustomStruct        average from 50 tests: 0,269898s
2. AnagramalistParallelLinq                          average from 50 tests: 0,408583s
3. AnagramalistDictionary                            average from 50 tests: 0,653909s
4. AnagramalistParrallelForEach_CustomStruct         average from 50 tests: 0,656355s
5. AnagramalistParallelForWithBatches                average from 50 tests: 0,792701s
6. AnagramalistConcurentDictionary                   average from 50 tests: 0,799633s
7. AnagramalistConcurentDictionary_CutomComparator   average from 50 tests: 0,851838s
8. AnagramalistLinq                                  average from 50 tests: 0,879904s
9. AnagramalistDictionary_CustomComparator           average from 50 tests: 1,646294s
```

Oh yeach, check it out! How did best? My custom struct did best, deal with it!
Oh yeach!
