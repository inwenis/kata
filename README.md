This is my attempt on the anagram kata: http://codekata.com/kata/kata06-anagrams/


I have tried different implementation and tested them for performance.
Here are the results:

```
1. AnagramalistParrallelGrouping_CustomStruct      average from 20 tests: 0,27184006s
2. AnagramalistParallelLinq                        average from 20 tests: 0,40302332s
3. AnagramalistParrallelForEach_CustomStruct       average from 20 tests: 0,645113415s
4. AnagramalistDictionary                          average from 20 tests: 0,6502554s
5. AnagramalistLinq                                average from 20 tests: 0,84276298s
6. AnagramalistParallelForWithBatches              average from 20 tests: 0,908370985s
7. AnagramalistConcurentDictionary                 average from 20 tests: 1,234861255s
8. AnagramalistConcurentDictionary_CutomComparator average from 20 tests: 1,57445962
9. AnagramalistDictionary_CustomComparator         average from 20 tests: 1,616826525s
```

Oh yeach, check it out! How did best? My custom struct did best, deal with it!
Oh yeach!
