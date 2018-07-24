package com.company;

public class Diamond {

    public static String printDiamond(char letter) {
        String rightSideOfDiamond = printRightSideOfDiamond(letter);
        String[] lines = rightSideOfDiamond.split("\n");
        String diamond = "";

        for (String line : lines) {
            diamond += spacesRepeatedTimes(letter - getCharForLine(line));
            diamond += reverseString(line).substring(0, line.length() - 1);
            diamond += line;
            diamond += "\n";
        }
        diamond = removeLastNewLineCharacter(diamond);

        return diamond;
    }

    private static String reverseString(String line) {
        return new StringBuilder(line).reverse().toString();
    }

    private static char getCharForLine(String firstLine) {
        return firstLine.charAt(firstLine.length() - 1);
    }

    private static String printRightSideOfDiamond(char letter) {
        if(letter == 'A') {
            return "A\nA";
        } else {
            String upperRightDiamondEdge = printUpperRightDiamondEdge(letter);
            String[] lines = upperRightDiamondEdge.split("\n");
            upperRightDiamondEdge += "\n";
            for (int i = lines.length - 2; i >= 0; i--) {
                upperRightDiamondEdge += lines[i] + "\n";
            }
            return upperRightDiamondEdge;
        }
    }

    private static String printUpperRightDiamondEdge(char letter) {
        int howManyLinesToPrint = letter - 'A' + 1;
        String result = "";
        for (int i = 0; i < howManyLinesToPrint; i++) {
            result += spacesRepeatedTimes(i);
            result += String.valueOf((char)('A' + i));
            result += "\n";
        }
        result = removeLastNewLineCharacter(result);
        return result;
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
