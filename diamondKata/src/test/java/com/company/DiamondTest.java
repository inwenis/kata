package com.company;

import org.junit.Assert;
import org.junit.Test;

public class DiamondTest {
    @Test
    public void for_input_letter_A_return_AA() {
        Assert.assertEquals("A\nA", Diamond.printDiamond('A'));
    }

    @Test
    public void for_input_letter_B_return_ABBA() {
        String expected =
                " A\n" +
                "B B\n" +
                " A";
        Assert.assertEquals(expected, Diamond.printDiamond('B'));
    }

    @Test
    public void for_input_letter_D_prints_whole_diamond() {
        String expected =
                "   A\n" +
                "  B B\n" +
                " C   C\n" +
                "D     D\n" +
                " C   C\n" +
                "  B B\n" +
                "   A";
        Assert.assertEquals(expected, Diamond.printDiamond('D'));
    }
}