using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2019
{
    public class Day1_1 : PuzzelBase, IPuzzel
    {
        public Day1_1(InputType test) : base(test, 1, 1)
        {

        }

        public IPuzzel Run()
        {
            var totalFule = 0f;

            for (var i = 0; i < Input.Length; i++)
            {
                totalFule += CalcFule(Input[i]);
            }

            Answer = totalFule.ToString();

            return this;
        }

        private float CalcFule(string sMass)
        {
            var mass = float.Parse(sMass);
            var div = mass / 3;
            var fule = (float)Math.Round(div, 0, MidpointRounding.ToZero) - 2;
            return fule;
        }
    }
}
