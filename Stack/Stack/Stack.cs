using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    public class MathExpression
    {
        string Expression;

        public MathExpression(string Expression)
        {
            this.Expression = Expression;
        }

        public void Push(char newChar)
        {
            Expression += newChar;
        }

        public void Pop()
        {
            Expression.Remove(Expression.Length - 1);
        }

        public char Top()
        {
            return Expression[Expression.Length];
        }

        public Int64 Calculate()
        {
            Int64 sum = new Int64();

            // calculate

            return sum;
        }

        public override string ToString()
        {
            return Expression;
        }
    }
}
