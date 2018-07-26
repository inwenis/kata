package com.company;

public class Palindrome {

    public static void main(String[] args) {
    }

    public static boolean isPalindrome(String input) {
        if(input.equals("")) {
            return false;
        } else {
            return input.charAt(0) == input.charAt(input.length() - 1);
        }
    }
}
