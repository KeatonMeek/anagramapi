using anagramapi;
using Xunit;

public class AnagramClassTests {

    /*
    Tests the file reader readFile(String filepath) 
    */
    [Fact]
    public void readFileTest() {
        
        //gets the length of the list of words returned from the file
        int length = Anagram.readFile("american-english-small").Count;

        //tests that the length of the returned list is equal to the expected length of the file
        Assert.Equal(51142, length);

    }

    /*
    Tests whether the function returnWords(List<String> words, string character) returns the correct list of words based on a specific
    character given.
    */
    [Fact]
    public void returnWordsTest() {
        
        //list provided for the method.
        List<String> words = new List<String> {"happy","hello","hungry","violin","handful","house","wrong","right"};
        
        //string to compare words to
        string character = "h";
        
        //expected return
        List<String> expectedReturn = new List<String>{"happy","hello","hungry","handful","house"};
        
        //confirming method returns values equal to expected return
        Assert.Equal(expectedReturn, Anagram.returnWords(words,character));
        
        //provide a different list of words to test
        words = new List<String> {"titan","tyranny","hungry","turn","tacos","house","temple","drill"};
        
        //changes the compare character to "t"
        character = "t";

        //expected return based on t compare value
        expectedReturn = new List<String>{"titan","tyranny","turn","tacos","temple"};

        //confirming method returns values equal to expected return
        Assert.Equal(expectedReturn, Anagram.returnWords(words,character));
        
    }

    /*
    Tests whether or not a word value is an anagram of a key Anagram.isAnagram(String key, String value)
    */
    [Fact]
    public void isAnagramTest() {

        //Testing true assertions
        Assert.True(Anagram.isAnagram("test","set"));
        Assert.True(Anagram.isAnagram("keaton","atone"));
        Assert.True(Anagram.isAnagram("laughable","bagel"));

        //Testing False assertions
        Assert.False(Anagram.isAnagram("random","dragon"));
        Assert.False(Anagram.isAnagram("nothing","something"));
        Assert.False(Anagram.isAnagram("hello","goodbye"));
    }


    /*
    Tests the equivalency of anagrams returned from a key value and a list of words passed into the anagrams method
    Using a predetermined key value and a list of words passed into the method and comparing those to a correct expected return
    and an incorrect result that should be not equal to the return value
    Anagram.anagrams(List<String> words, String key)
    */
    [Fact]
    public void returnAnagramsTest() {

        //key that we are trying to find anagrams for
        String key = "nothing";
        
        //Words passed into the method with an ordering of words from greatest length to least length
        List<String> words = new List<String> {"Restless", "wealthy","rodney","toning","night","hog","got","ho"};
        
        //expected return
        List<String> expectedResult = new List<String> {"toning","night","hog","got","ho"};
        
        //incorrect return
        List<String> incorrectresult = new List<String>{"Hello","Radical","lightbulb","lock"};
        
        //testing for the equality of the return and the expected result with ordered word list compared to a correct result and incorrect result
        Assert.Equal(expectedResult, Anagram.anagrams(words, key));
        Assert.NotEqual(incorrectresult, Anagram.anagrams(words,key));

        //changing key to random
        key = "random";
        
        //passing in a new list of strings with no specific order
        words = new List<String> {"a","roam","desk","nor","roman","light","mod","random","do","california","pickle"};
        
        //expected return
        expectedResult = new List<String> {"random","roman","roam","nor","mod","do","a"};

        //incorrect return
        incorrectresult = new List<String>{"caffinated","glossary","set","pest"};
        
        //testing for equality of the return with random word order compared to a correct result and incorrect result
        Assert.Equal(expectedResult, Anagram.anagrams(words, key));
        Assert.NotEqual(incorrectresult, Anagram.anagrams(words,key));



    }
}