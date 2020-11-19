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
                var seq = start + i;

                var index = CheckIfAnyDouble(seq);
                if (index != -1)
                {
                    if (CheckIfNeverDecreases(seq, index))
                    {
                        count++;
                    }
                }
            }

            Answer = count.ToString();

            return this;
        }

        private int CheckIfAnyDouble(int seq)
        {
            var s = seq.ToString().ToCharArray();

            for(var i = 0; i<s.Length; i++)
            {
                if (i+1 < s.Length && s[i] == s[i+1])
                    return i;
            }

            return -1;
        }

        private bool CheckIfNeverDecreases(int seq, int index)
        {
            var s = seq.ToString().ToCharArray();

            var i = new int[] { 
                int.Parse(s[0].ToString()),
                int.Parse(s[1].ToString()),
                int.Parse(s[2].ToString()),
                int.Parse(s[3].ToString()),
                int.Parse(s[4].ToString()),
                int.Parse(s[5].ToString())
            };

            for (var j = 0; j < s.Length-1; j++)
            {
                if (i[j] > i[j+1])
                    return false;
            }

            return true;
        }
    }
}
