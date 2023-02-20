using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariableCapture
{
    public class CapturingMultipleInstantiations
    {
        static public List<Action> CreateActions()
        {
            List<Action> actions = new List<Action>();
            for(int i=0; i< 5; i++)
            {
                // 루프 내에서 지역 변수를 선언 => Loop를 반복할 때 마다 새로운 변수가 생성
                // 각각의 람다 표현식은 서로 다른 변수를 캡처한다.
                // 결과적으로 5개의 서로 다른 text 변수가 생김.
                string text = string.Format($"Message : {i}");
                // 람다 표현식 내에서 변수를 캡처
                actions.Add(() => Console.WriteLine(text));
            }
            return actions;
        }
    }
}
