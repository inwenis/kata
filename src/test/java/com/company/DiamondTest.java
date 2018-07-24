package com.company;

import org.junit.Assert;
import org.junit.Test;

public class DiamondTest {
    @Test
    public void when_input_is_A_returns_A() {
        Assert.assertEquals("A", Diamond.printDiamond('A'));
    }
}