package com.company;

public class Diamond {

    public static String printUpperRightDiamondEdge(char letter) {
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

    public static String printDiamond(char letter) {
        return "A\nA";
    }
}
