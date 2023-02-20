using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariableCapture
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            var demo = new CapturedVariablesDemo();
            // 델리게이트 생성 시점에 그저 변수의 값이 복사되는 것이 아니라 변수 자체가 캡처된다.
            Action<string> action = demo.CreateAction("method argument");
            action("lambda argument");
            */

            /*
            // 2. 지역 변수에 대한 다중 초기화
            List<Action> actions = CapturingMultipleInstantiations.CreateActions();
            foreach(Action action in actions)
            {
                action();
            }
            */

            // 3. 서로 다른 범위에 속한 여러 변수를 캡처
            List<Action> actions = CapturingMultipleScopes.CreateCountingActions();
            actions[0]();
            actions[0]();
            actions[1]();
            actions[1]();
        }
    }

    class CapturedVariablesDemo
    {
        private string _instanceField = "instance field";

        public Action<string> CreateAction(string methodParameter)
        {
            string methodLocal = "Method local";
            
            // CreateAction 메서드의 지역변수. 람다 표현식 내에 사용되지 않아 캡처되지 않음
            string uncaptured = "uncaptured local";

            Action<string> action = lambdaParameter =>
            {
                string lambdaLocal = "lambda local";
                // CapturedVariablesDemo 클래스의 인스턴스 필드. 람다 표현식에 의해 캡처됨
                Console.WriteLine($"Instance field : {_instanceField}");
                // CreateAction 메서드의 매개변수. 람다 표현식에 의해 캡처됨
                Console.WriteLine($"Method parameter : {methodParameter}");
                // CreateAction 메서드의 지역변수. 람다 표현식에 의해 캡처됨
                Console.WriteLine($"Method local : {methodLocal}");

                // 람다 표현식 자체의 매개변수이므로 캡처 변수가 아님
                Console.WriteLine($"Lambda parameter : {lambdaParameter}");
                // 람다 표현식 자체의 지역변수이므로 캡처 변수가 아님
                Console.WriteLine($"Lambda local : {lambdaLocal}");
            };
            methodLocal = "modified method local";
            return action;
        }
    }
}
