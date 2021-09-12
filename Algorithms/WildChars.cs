using System.Linq;

namespace Algorithms
{
  public class TestWildcardCharacters
  {

    /*
    Rules 
     +	-> exact 1	letter
     *	-> repeat of 3 letters
     *{N}-> repeat of letters N times
     *
     * Example WildcardCharacters("++* gheeee") should returns false as there should be only 3 e
     * Example WildcardCharacters("++++* ghabeee") should returns true
     * Example WildcardCharacters("**+* eeebbbghhh") should returns true **+*{2} mmmrrrkbb
     * * Example WildcardCharacters("**+*{2} mmmrrrkbb") should returns true 

     */
    public static string WildcardCharacters_new(string str)
    {
      char[] first = str.Split(' ')[0].ToCharArray();
      char[] sec = str.Split(' ')[1].ToCharArray();
      int sec_counter = 0;
      for (int i = 0; i < first.Length; i++)
      {
        switch (first[i])
        {
          case '+':
            if (sec[sec_counter] == sec[sec_counter + 1])
              return "false";
            sec_counter++;
            break;

          case '*':
            {
              //if (first[i+1] == '{' )
              // complete it

              if (sec_counter + 2 > sec.Length) return "false";
              if (sec[sec_counter] != sec[sec_counter + 1] && sec[sec_counter + 1] != sec[sec_counter + 2])
                return "false";
              
            }
            break;
          
        }
      }
      return "true";
    }
    public static string WildcardCharacters(string str)
    {
      string first = str.Split(' ')[0];
      string second = str.Split(' ')[1];
      bool result = true;
      int n = 0;
      int secondCounter = 0;

      for (int i = 0; i < first.Length; i++)
      {
        char token = first[i];
        char secLetter = second[i];

        if (token == '+')
        {
          if (second[i] == second[i + 1])
            result = false;
          else
            secondCounter++;
        }

        else if (token == '*' && (i + 1) < first.Length && first[i + 1] == '{')
        {
          if (!first.EndsWith("}"))
          {
            result = false;
            break;
          }
          int Pos1 = first.IndexOf('{');
          int Pos2 = first.IndexOf('}');
          n = int.Parse(first.Substring(Pos1 + 1, Pos2 - Pos1 - 1));

          if (second.Substring(secondCounter, n).Distinct().Count() > 1)
          {
            result = false;
            break;
          }
          else
            secondCounter++;
        }
        else if (token == '*')
        {
          if (second.Substring(secondCounter, 3).Distinct().Count() > 1 || second[secondCounter] == second[secondCounter + 3 + 1])
          {
            result = false;
            break;

          }
          else
            secondCounter = +secondCounter + 3;
        }
      }
      // code goes here  
      return result.ToString().ToLower();

    }
  }
}
