package com.company;

public class Palindrome {

    public static void main(String[] args) {
    }

    public static boolean isPalindrome(String input) {
        if(input.equals("")) {
            return false;
        } else if(input.length() == 1) {
            return true;
        } else if (input.length() == 2) {
            return input.charAt(0) == input.charAt(1);
        } else {
            return input.charAt(0) == input.charAt(2);
        }
    }
}
