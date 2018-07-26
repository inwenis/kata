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

    @Test
    public void when_checking_two_letter_palindrome_returns_true() {
        Assert.assertTrue(Palindrome.isPalindrome("xx"));
    }

    @Test
    public void when_checking_two_letter_no_palindrome_returns_false() {
        Assert.assertFalse(Palindrome.isPalindrome("xy"));
    }

    @Test
    public void when_checking_3_letters_palindrome_returns_true() {
        Assert.assertTrue(Palindrome.isPalindrome("xyx"));
    }

    @Test
    public void when_checking_3_letters_no_palindrome_returns_false() {
        Assert.assertFalse(Palindrome.isPalindrome("xya"));
    }

    @Test
    public void when_checking_no_palindrome_of_any_length_returns_false() {
        Assert.assertFalse(Palindrome.isPalindrome("xxyx"));
    }
}