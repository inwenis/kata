package com.company;

import java.util.*;
import java.util.stream.Collectors;

public class Diamond {

    public static String printDiamond(char letter) {
        if(letter == 'A') {
            return "A\nA";
        }

        String upperPartOfDiamond = getUpperPartOfDiamond(letter);
        String reversedDiamond = getReversedLines(upperPartOfDiamond);
        String reversedDiamondWithOutFirstLine = reversedDiamond.substring(reversedDiamond.indexOf('\n') + 1);
        String wholeDiamond = upperPartOfDiamond + reversedDiamondWithOutFirstLine;
        return removeLastNewLineCharacter(wholeDiamond);
    }

    private static String getReversedLines(String diamond) {
        String reversedDiamond = "";

        List<String> reversedLines = new ArrayList<>();
        String[] lines = diamond.split("\n");
        Arrays.stream(lines)
            .collect(Collectors.toCollection(LinkedList::new))
            .descendingIterator()
            .forEachRemaining(reversedLines::add);
        for (String line : reversedLines) {
            reversedDiamond += line + "\n";
        }
        return reversedDiamond;
    }

    private static String getUpperPartOfDiamond(char letter) {
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
