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
            if(i % 3 == 0 && i % 5 == 0) {
                numbers += "FizzBuzz" + "\n";
            } else if(i % 3 == 0 || String.valueOf(i).contains("3")) {
                numbers += "Fizz" + "\n";
            } else if (i % 5 == 0) {
                numbers += "Buzz" + "\n";
            } else {
                numbers += i + "\n";
            }
        }
        numbers = removeLastNewLineCharacter(numbers);
        return numbers;
    }

    private static String removeLastNewLineCharacter(String numbers) {
        numbers = numbers.substring(0, numbers.length() - 1);
        return numbers;
    }
}
