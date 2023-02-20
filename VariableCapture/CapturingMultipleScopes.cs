using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariableCapture
{
    public class CapturingMultipleScopes
    {
        static public  List<Action> CreateCountingActions()
        {
            var actions = new List<Action>();
            // 두 개의 델리게이트에서 하나의 변수를 캡처
            int outerCounter = 0;

            for(int i =0; i<2; i++)
            {
                int innerCounter = 0;
                Action action = () =>
                {
                    Console.WriteLine($"Outer : {outerCounter} / Inner : {innerCounter}");
                    outerCounter++;
                    innerCounter++;
                };
                actions.Add(action);
            }
            return actions;
        }
    }
}
