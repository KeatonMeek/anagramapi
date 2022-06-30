using Microsoft.AspNetCore.Mvc;

namespace anagramapi; 

public class Anagram {

    //Function to intake the file path and the list where the total file contents will be stored and reads the file
    public static List<String> readFile(string filePath) {

        List<string> words = new List<String>();    
        //Instanciates a streamdreader to read the file
        StreamReader sr = new StreamReader(filePath);
            
            //loops through the file and checks if the value is null before storing the value in the list
        while (sr.Peek() != -1) {

            var currentLine = sr.ReadLine();
            words.Add(currentLine!);

        }    

        return words;                  
    }

    //Fuction to return a list of words that start with a specific character
    public static List<String> returnWords(List<String> words, string character) {

        List<String> values = words;

        return values.Where(s => s.StartsWith(character.ToString())).ToList();
    }


    //function checks if a value can be rebuilt from the key 
    public static bool isAnagram(String key, String value) {

        //converts the key and value to a list of chars
        List<char> keyList = key.ToLower().ToList();
        List<char> valueList = value.ToLower().ToList();

        //list used to rebuild a string from the value provided
        List<char> rebuilt = new List<char>();

        //runs through the values in value list
        foreach (char vItem in valueList) {
            //runs through the values in key list
            foreach(char kItem in keyList) {
                //if the current vItem is found in kItem
                if (vItem == kItem) {
                    //add the current vItem to the rebuilt list and remove the kItem from the keyList
                    rebuilt.Add(vItem);
                    keyList.Remove(kItem);
                    //breaks to stop the loop since we found a value, this stops duplicate letters from being found on a single run
                    break;

                }
            }
        }

        //checks to see if the rebuilt string is equal to the original value we are comparing
        if (value != new String(rebuilt.ToArray())) {
            return false;
        }
        return true;
        
    }

    //prints out all anagrams present in the dictionary by taking the list of words and comparing it to the "Key" the user wants to compare
    public static List<String> anagrams(List<String> words, String key) {
            
        //creates a list of anagrams found
        List<String> foundAnagrams = new List<String>();

        //runs through the dictionary of words to find anagrams
        foreach (String item in words) {
                
            //if it finds an anagram, adds the anagram to the list of found anagrams.
            if (isAnagram(key, item) == true) {
                   
                foundAnagrams.Add(item);
            }
        }

        //sorts the list from longest string to smallest string
        foundAnagrams.Sort((b, a) => a.Length.CompareTo(b.Length));

        return foundAnagrams;
    }

    public class anagramJson {
        public string? letters {get; set;}
        public List<String>? words {get; set;}

    }

}