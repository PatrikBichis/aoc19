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
            var range = Input[0].Split('-');
            var start = int.Parse(range[0]);
            var target = int.Parse(range[1]);
            var count = 0;

            for (var i = start; i < target; i++)
            {
                var seq = i;

                if (CheckIfNeverDecreases(seq))
                {
                    if(CheckIfAnyDouble(seq)){
                        count++;
                    }
                }
            }

            Answer = count.ToString();

            return this;
        }

        private bool CheckIfAnyDouble(int seq)
        {
            var s = seq.ToString().ToCharArray();

            for(var i = 0; i<s.Length-1; i++)
            {
                var a = s[i];
                var b = s[i + 1];

                if (a == b)
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
