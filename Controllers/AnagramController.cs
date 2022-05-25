using Microsoft.AspNetCore.Mvc;
using static anagramapi.Anagram;

namespace anagramapi.Controllers;

[ApiController]
[Route("[controller]")]
public class anagramsController : ControllerBase { 

    [HttpGet("")]
    [Produces("application/json")]
    public ActionResult<anagramJson> GetAnagrams([FromQuery] String letters) {

        var obj = new anagramJson {
            letters = letters,
            words = Anagram.anagrams(readFile("american-english-small"),letters)
        };

        return obj;
    }
}

