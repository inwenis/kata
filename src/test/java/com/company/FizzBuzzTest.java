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
    public void when_asked_to_print_numbers_from_1_to_any_number_prints_all_numbers_with_Fizz_every_3rd_number() {
        Assert.assertEquals("1\n2\nFizz\n4\n5", FizzBuzz.print(1,5));
    }

    @Test
    public void when_asked_to_print_numbers_from_any_to_any_number_prints_all_number() {
        Assert.assertEquals("Fizz\n4\n5\nFizz\n7", FizzBuzz.print(3,7));
    }
}