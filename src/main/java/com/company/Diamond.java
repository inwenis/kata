package com.company;

public class Diamond {

    public static String printDiamond(char letter) {
        if(letter == 'A') {
            return "A\nA";
        } else if (letter == 'B') {
            return " A\nB B\n A";
        } else {
            String rightSideOfDiamond = printRightSideOfDiamond(letter);
            String[] lines = rightSideOfDiamond.split("\n");
            String diamond = "";
            diamond += spacesRepeatedTimes(letter - lines[0].charAt(lines[0].length() - 1)) + lines[0] + "\n";
            for (int i = 1; i < lines.length - 1; i++) {
                String line = lines[i];
                diamond += spacesRepeatedTimes(letter - line.charAt(line.length() - 1));
                diamond += new StringBuilder(line).reverse().toString().substring(0, line.length() - 1);
                diamond += line;
                diamond += "\n";
            }
            diamond += spacesRepeatedTimes(letter - lines[lines.length - 1].charAt(lines[lines.length - 1].length() - 1)) + lines[lines.length - 1];

            return diamond;
        }
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
}
