using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2019
{
    public class Day4_1 : PuzzelBase, IPuzzel
    {
        public Day4_1(InputType input) : base(input, 4, 1)
        {
            
        }

        public IPuzzel Run()
        {
            Console.WriteLine(ValidateSeq(112233));
            Console.WriteLine(ValidateSeq(123444));
            Console.WriteLine(ValidateSeq(111122));

            var range = Input[0].Split('-');
            var start = int.Parse(range[0]);
            var target = int.Parse(range[1]);
            var count = 0;

            for (var i = start; i < target; i++)
            {
                var seq = i;

                if (ValidateSeq(seq)) count++;
            }

            Answer = count.ToString();

            return this;
        }

        private bool ValidateSeq(int seq)
        {
            if (CheckIfNeverDecreases(seq))
            {
                if (CheckIfAnyDouble(seq))
                {
                    return true;
                }
            }

            return false;
        }

        private bool CheckIfAnyDouble(int seq)
        {
            var s = seq.ToString().ToCharArray();
            var type = ' ';
            var count = 0;
            var foundTwo = false;

            for(var i = 0; i<s.Length-1; i++)
            {
                var a = s[i];
                var b = s[i + 1];

                if (a == b)
                {
                    if (type != b)
                    {
                        if(count == 1)
                        {
                            foundTwo = true;
                        }
                        count = 1;
                    }
                    else count++;
                    type = b;
                }
            }

            if (count == 1 || foundTwo)
            {
                return true;
            }

            return false;
        }

        private bool CheckIfNeverDecreases(int seq)
        {
            var s = seq.ToString().ToCharArray();

            for (var j = 0; j < s.Length-1; j++)
            {
                var a = int.Parse(s[j].ToString());
                var b = int.Parse(s[j + 1].ToString());

                if (a > b)
                    return false;
            }

            return true;
        }
    }
}
