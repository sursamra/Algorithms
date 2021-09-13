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
     public static string GetStringBetweenStrings(string text, string start, string end)
        {
            int p1 = text.IndexOf(start) + start.Length;
            int p2 = text.IndexOf(end, p1);

            if (end == "") return (text.Substring(p1));
            else return text.Substring(p1, p2 - p1);
        }
        public static string GetStringBetweenChars(string input, char charFrom, char charTo)
        {
            int posFrom = input.IndexOf(charFrom);
            if (posFrom != -1) //if found char
            {
                int posTo = input.IndexOf(charTo, posFrom + 1);
                if (posTo != -1) //if found char
                {
                    return input.Substring(posFrom + 1, posTo - posFrom - 1);
                }
            }

            return string.Empty;
        }
     public static string WildcardCharacters_new(string str)
        {
            string first = str.Split(' ')[0];
            string sec = str.Split(' ')[1];            
            int first_counter = 0;
            int sec_counter = 0;
            for (int i = 0; i < first.Length; i++)
            {
                first_counter = i;                
                char c = first[i];

                switch (c)
                {
                    case '+':                        
                        if (sec_counter + 1 > sec.Length)
                            return "false";
                        sec_counter += 1;
                        break;
                    case '*':
                        int num = 0;
                        if (i + 1 < first.Length && first[i + 1] == '{')
                        {
                            num = int.Parse(GetStringBetweenChars(first, '{', '}'));
                            i = i + 2 + num.ToString().Length;
                        }
                        else
                            num = 3;
                        if ((sec_counter + num < sec.Length) && (sec[sec_counter] != sec[sec_counter + 1] && sec[sec_counter] != sec[sec_counter + 2]))
                            return "false";
                        sec_counter += num;


                        break;

                }
            }
            
            return (sec_counter < sec.Length - 1)?"false":"true";

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
