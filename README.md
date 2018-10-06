This is my attempt on the anagram kata: http://codekata.com/kata/kata06-anagrams/


I have tried different implementation and tested them for performance.
Here are the results:

```
.Net Core
1. AnagramalistParrallelGrouping_CustomStruct        median from 50 tests: 0,313321s
2. AnagramalistParallelLinq                          median from 50 tests: 0,553064s
3. AnagramalistDictionary                            median from 50 tests: 0,476297s
4. AnagramalistParrallelForEach_CustomStruct         median from 50 tests: 0,621717s
5. AnagramalistLinq                                  median from 50 tests: 0,861557s
6. AnagramalistParallelForWithBatches                median from 50 tests: 1,325915s
7. AnagramalistDictionary_CustomComparator           median from 50 tests: 1,462692s
8. AnagramalistConcurentDictionary                   median from 50 tests: 1,741895s
9. AnagramalistConcurentDictionary_CutomComparator   median from 50 tests: 1,959800s

.Net Framework
1. AnagramalistParrallelGrouping_CustomStruct        median from 50 tests: 0,261519s
2. AnagramalistParallelLinq                          median from 50 tests: 0,365016s
3. AnagramalistParrallelForEach_CustomStruct         median from 50 tests: 0,683831s
4. AnagramalistDictionary                            median from 50 tests: 0,798739s
5. AnagramalistParallelForWithBatches                median from 50 tests: 0,680975s
6. AnagramalistConcurentDictionary                   median from 50 tests: 0,712211s
7. AnagramalistLinq                                  median from 50 tests: 0,825489s
8. AnagramalistConcurentDictionary_CutomComparator   median from 50 tests: 1,027014s
9. AnagramalistDictionary_CustomComparator           median from 50 tests: 1,604239s
```

Oh yeach, check it out! How did best? My custom struct did best, deal with it!
Oh yeach!
