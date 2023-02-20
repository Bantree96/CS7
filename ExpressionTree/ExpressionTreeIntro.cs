using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTree
{
    // 표현식 트리 사용해 보기
    internal class ExpressionTreeIntro
    {
        public ExpressionTreeIntro()
        {
            Expression<Func<int, int, int>> adder = (x, y) => x + y;
            Console.WriteLine(adder);
        }
    }
}
