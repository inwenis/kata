package com.company;

public class Palindrome {

    public static void main(String[] args) {
    }

    public static boolean isPalindrome(String input) {
        if(input.equals("")) {
            return false;
        } else if (input.length() <=3 ) {
            return input.charAt(0) == input.charAt(input.length() - 1);
        } else {
            int leftIndex = 0;
            int rightIndex = input.length() - 1;
            while (true) {
                char left = input.charAt(leftIndex);
                char right = input.charAt(rightIndex);

                if (left != right) {
                    return false; // if at least one pair of chars do not mach we don't have to check any more
                }

                leftIndex++;
                rightIndex--;
            }
        }
    }
}
