package com.company;

import org.junit.Assert;
import org.junit.Test;

public class FizzBuzzTest {
    @Test
    public void when_asked_to_print_number_1_prints_1_number() {
        Assert.assertEquals("1", FizzBuzz.print(1,1));
    }
}