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
}