This is my attempt on the anagram kata: http://codekata.com/kata/kata06-anagrams/


I have tried different implementation and tested them for performance.
Here are the results:

AnagramalistParallelLinq                        average from 20 tests: 0,5120279s
AnagramalistDictionary                          average from 20 tests: 0,79161086s
AnagramalistParallelForWithBatches              average from 20 tests: 0,92026755s
AnagramalistLinq                                average from 20 tests: 1,00821225s
AnagramalistConcurentDictionary_CutomComparator average from 20 tests: 1,012132575s
AnagramalistConcurentDictionary                 average from 20 tests: 1,05540081s
AnagramalistDictionary_CustomComparator         average from 20 tests: 1,918709145s
