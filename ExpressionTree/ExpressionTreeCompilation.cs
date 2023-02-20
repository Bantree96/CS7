using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTree
{
    // 표현식 트리를 델리게이트로 컴파일하는 법
    internal class ExpressionTreeCompilation
    {
        public ExpressionTreeCompilation()
        {
            Expression<Func<int, int, int>> adder = (x, y) => x + y;
            // 표현식 트리를 컴파일해 델리게이트 생성
            Func<int, int, int> executableAdder = adder.Compile();
            // 델리게이트를 일반적인 방법으로 호출
            Console.WriteLine(executableAdder(2,3));
        }
    }
}
