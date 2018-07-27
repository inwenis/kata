package com.company;

public class FizzBuzz {

    public static void main(String[] args) {
	// write your code here
    }

    public static String print(int from, int to) {
        if(to == 1) {
            return "1";
        } else if(to == 2) {
            return "1\n2";
        } else {
            String numbers = "";
            for (int i = 1; i <= to; i++) {
                numbers += i + "\n";
            }
            numbers = removeLastNewLineCharacter(numbers);
            return numbers;
        }
    }

    private static String removeLastNewLineCharacter(String numbers) {
        numbers = numbers.substring(0, numbers.length() - 1);
        return numbers;
    }
}
