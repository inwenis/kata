package com.company;

import org.junit.Assert;
import org.junit.Test;

public class FizzBuzzTest {
    @Test
    public void when_asked_to_print_number_1_prints_1_number() {
        Assert.assertEquals("1", FizzBuzz.print(1,1));
    }

    @Test
    public void when_asked_to_print_numbers_1_to_2_prints_2_number() {
        Assert.assertEquals("1\n2", FizzBuzz.print(1,2));
    }

    @Test
    public void when_asked_to_print_numbers_from_1_to_any_number_prints_all_numbers_with_Fizz_every_3rd_number_and_Buzz_every_5th_number() {
        Assert.assertEquals("1\n2\nFizz\n4\nBuzz", FizzBuzz.print(1,5));
    }

    @Test
    public void when_asked_to_print_numbers_from_any_to_any_number_prints_all_number_with_Buzz_every_3rd_number_and_Buzz_every_5th_number() {
        Assert.assertEquals("Fizz\n4\nBuzz\nFizz\n7", FizzBuzz.print(3,7));
    }

    @Test
    public void when_asked_to_print_numbers_up_to_a_number_greater_than_100_truncates_the_result_to_100() {
        Assert.assertEquals("98\nFizz\nBuzz", FizzBuzz.print(98, 120));
    }

    @Test
    public void when_asked_to_print_number_dividable_by_3_and_5_prints_FizzBuzz() {
        Assert.assertEquals("14\nFizzBuzz\n16", FizzBuzz.print(14, 16));
    }

    @Test
    public void when_asekd_to_print_number_containing_3_prints_Fizz_insted_of_the_number() {
        Assert.assertEquals("Fizz\n14", FizzBuzz.print(13, 14));
    }
}