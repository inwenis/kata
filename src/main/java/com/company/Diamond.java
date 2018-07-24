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

    public static String printRightSideOfDiamond(char letter) {
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

    public static String printDiamond(char letter) {
        return "A\nA";
    }
}
