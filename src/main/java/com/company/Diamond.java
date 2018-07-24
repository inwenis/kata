package com.company;

import java.util.*;
import java.util.stream.Collectors;

public class Diamond {

    public static String printDiamond(char letter) {
        if(letter == 'A') {
            return "A\nA";
        }

        String diamond = "";
        int howManyLinesToPrint = letter - 'A' + 1;

        diamond += spacesRepeatedTimes(letter - 'A');
        diamond += 'A';
        diamond += "\n";

        for (int i = 1; i < howManyLinesToPrint; i++) {
            char currentLetter = (char) ('A' + i);
            int spacesBeforeLetter = letter - currentLetter;
            int spacesBetweenLetters = (i - 1) * 2 + 1;
            diamond += spacesRepeatedTimes(spacesBeforeLetter);
            diamond += currentLetter;
            diamond += spacesRepeatedTimes(spacesBetweenLetters);
            diamond += currentLetter;
            diamond += "\n";
        }

        List<String> reversedLines = new ArrayList<>();
        String[] lines = diamond.split("\n");
        Arrays.stream(lines,0, lines.length - 1) //skip last line which should not be repeated
            .collect(Collectors.toCollection(LinkedList::new))
            .descendingIterator()
            .forEachRemaining(reversedLines::add);
        for (String line : reversedLines) {
            diamond += line + "\n";
        }

        diamond = removeLastNewLineCharacter(diamond);

        return diamond;
    }

    private static String spacesRepeatedTimes(int i) {
        String spaces = "";
        for (int j = 0; j < i; j++) {
            spaces += " ";
        }
        return spaces;
    }

    private static String removeLastNewLineCharacter(String result) {
        result = result.substring(0, result.lastIndexOf('\n'));
        return result;
    }
}
