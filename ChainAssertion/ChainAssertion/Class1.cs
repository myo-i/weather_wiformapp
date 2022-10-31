using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainAssertion
{
    public class Class1
    {
        public static int Add(int a, int b)
        {
            if (a < 0 )
            {
                throw new InputException("負の数は入力できません");
            }
            return a + b;
        }
    }
}
