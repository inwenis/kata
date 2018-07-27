package com.company;

public class FizzBuzz {

    public static void main(String[] args) {
	// write your code here
    }

    public static String print(int from, int to) {
        String numbers = "";
        for (int i = from; i <= to; i++) {
            numbers += i + "\n";
        }
        numbers = removeLastNewLineCharacter(numbers);
        return numbers;
    }

    private static String removeLastNewLineCharacter(String numbers) {
        numbers = numbers.substring(0, numbers.length() - 1);
        return numbers;
    }
}
