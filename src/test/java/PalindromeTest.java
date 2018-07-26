import com.company.Palindrome;
import org.junit.Assert;
import org.junit.Test;

public class PalindromeTest {
    @Test
    public void when_checking_empty_string_returns_false() {
        Assert.assertFalse(Palindrome.isPalindrome(""));
    }

    @Test
    public void when_checking_single_letter_string_returns_true() {
        Assert.assertTrue(Palindrome.isPalindrome("a"));
    }
}