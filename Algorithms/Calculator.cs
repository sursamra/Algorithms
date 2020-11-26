using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    /*
     * Calculator("6*(4/2)+3*1") should return 15 
     * * Calculator("6+2-1") should return 7 
     */
    public class MainClass
    {

        public static string Calculator(string str)
        {

            var operations = new Dictionary<char, Func<int, int, int>>
            {
              {'+',(_,__)=>_+__},
              {'/',(_,__)=>_/__},
              {'-',(_,__)=>_-__},
              {'*',(_,__)=>_*__},
            };

            StringBuilder sbFirst = new StringBuilder();
            StringBuilder sbSecond = new StringBuilder();
            bool firstRead = false;
            char opr = '0';
            int result = 0;
            Stack<int> stack = new Stack<int>();
            Stack<char> stackOpr = new Stack<char>();

            for (int i = 0; i < str.Length; i++)
            {
                char token = str[i];
                if (token == '(')
                {
                    stack.Push(int.Parse(sbFirst.ToString()));
                    stackOpr.Push(opr);
                    firstRead = false;
                    sbFirst.Clear();
                    continue;
                }
                if (token == ')')
                {
                    if (sbFirst.Length > 0 && sbSecond.Length > 0)
                    {
                        result = operations[opr](int.Parse(sbFirst.ToString()), int.Parse(sbSecond.ToString()));
                        sbFirst.Clear();
                        sbSecond.Clear();
                        if (stack.Count > 0)
                        {
                            result = operations[stackOpr.Pop()](stack.Pop(), result);
                        }
                        sbFirst.Append(result);
                    }
                    continue;
                }

                if (!operations.ContainsKey(token))
                    if (!firstRead)
                        sbFirst.Append(token);
                    else
                        sbSecond.Append(token);
                else
                {

                    firstRead = true;
                    if (sbFirst.Length > 0 && sbSecond.Length > 0)
                    {
                        result = operations[opr](int.Parse(sbFirst.ToString()), int.Parse(sbSecond.ToString()));
                        sbFirst.Clear();
                        sbSecond.Clear();
                        sbFirst.Append(result);
                    }

                    opr = token;

                }

            }
            //deal with last operator and number
            result = operations[opr](int.Parse(sbFirst.ToString()), int.Parse(sbSecond.ToString()));
            return result.ToString();
        }

    }
}
