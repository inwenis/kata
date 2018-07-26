package com.company;

public class Palindrome {

    public static void main(String[] args) {
    }

    public static boolean isPalindrome(String input) {
        if(input.equals("")) {
            return false;
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
                if(leftIndex > rightIndex) {
                    return true; // if we are here we have compared all letters
                }
            }
        }
    }
}
