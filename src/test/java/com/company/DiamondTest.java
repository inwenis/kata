package com.company;

import org.junit.Assert;
import org.junit.Test;

public class DiamondTest {
    @Test
    public void when_input_is_A_returns_A() {
        Assert.assertEquals("A", Diamond.printUpperRightDiamondEdge('A'));
    }

    @Test
    public void when_input_is_B_returns_AB() {
        String expected =
                "A\n" +
                " B";
        Assert.assertEquals(expected, Diamond.printUpperRightDiamondEdge('B'));
    }

    @Test
    public void when_input_is_letter_returns_one_diamond_edge_with_all_letters_until_the_input_teller() {
        String expected =
                "A\n" +
                " B\n" +
                "  C";
        Assert.assertEquals(expected, Diamond.printUpperRightDiamondEdge('C'));
    }
}