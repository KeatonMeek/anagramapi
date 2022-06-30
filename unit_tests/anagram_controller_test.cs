using anagramapi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using static anagramapi.Anagram;

public class AnagramControllerTestClass {

    /*
    Tests the return of the API call to verify that the expected return is equal to the actual return of the api call
    */
    [Fact]  
    public void getAnagramControllerTest() {

        //initializes an anagramsController
        anagramsController controller = new anagramsController();
        
        //creates an actionresult<anagramsJson> to compare to the expected return of the api call
        ActionResult<anagramJson> expectedReturn = new anagramJson {
            letters = "keaton",
            words = new List<String> {"token","taken","atone","note","teak","tank","take","neat","knot","tone","aeon","eon",
            "eat","net","not","ton","oak","toe","one","ate","ken","tan","ant","tea","ten","to","at","on","no","an","a"}
        };


        //makes the call to return anagrams of the name "keaton"
        var actionResult = controller.GetAnagrams("keaton");

        //tests that the letters were returned correctly
        Assert.Equal(expectedReturn?.Value?.letters, actionResult?.Value?.letters);

        //tests that the words returned from the letters were correct and equal to the expected result
        Assert.Equal(expectedReturn?.Value?.words, actionResult?.Value?.words);

    }
}