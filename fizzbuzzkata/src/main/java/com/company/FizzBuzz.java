package com.company;

public class FizzBuzz {

    public static void main(String[] args) {
	// write your code here
    }

    public static String print(int from, int to) {
        if(to > 100) {
            to = 100;
        }

        String numbers = "";
        for (int i = from; i <= to; i++) {
            if(isFizzBuzz(i)) {
                numbers += "FizzBuzz";
            } else if (isFizz(i)) {
                numbers += "Fizz";
            } else if (isBuzz(i)) {
                numbers += "Buzz";
            } else {
                numbers += i;
            }
            numbers += "\n";
        }
        numbers = removeLastNewLineCharacter(numbers);
        return numbers;
    }

    private static boolean isFizzBuzz(int i) {
        return isFizz(i) && isBuzz(i);
    }

    private static boolean isBuzz(int i) {
        return i % 5 == 0 || String.valueOf(i).contains("5");
    }

    private static boolean isFizz(int i) {
        return i % 3 == 0 || String.valueOf(i).contains("3");
    }

    private static String removeLastNewLineCharacter(String numbers) {
        numbers = numbers.substring(0, numbers.length() - 1);
        return numbers;
    }
}
