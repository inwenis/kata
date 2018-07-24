package com.company;

import java.util.Enumeration;

public class Diamond {

    public static String printDiamond(char letter) {
        if(letter == 'A') {
            return "A";
        } else if (letter == 'B'){
            return "A\n B";
        } else {
            int howManyLinesToPrint = letter - 'A' + 1;
            String result = "";
            for (int i = 0; i < howManyLinesToPrint; i++) {
                for (int j = 0; j < i; j++) {
                    result += " ";
                }
                result += String.valueOf((char)('A' + i));
                result += "\n";
            }
            result = result.substring(0, result.lastIndexOf('\n'));
            return result;
        }
    }
}
