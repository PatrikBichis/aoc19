using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2019
{
    public class Day1_2 : PuzzelBase, IPuzzel
    {
        public Day1_2(InputType input) : base(input, 1, 2)
        {

        }

        public IPuzzel Run()
        {
            var totalFule = 0f;

            foreach(var i in Input)
            {
                var currentFule = 0f;
                var lastValue = float.Parse(i);
                var lessOrZero = false;

                do
                {
                    lastValue = CalcFule(lastValue);

                    if (lastValue > 0)
                        currentFule += lastValue;
                    else
                        lessOrZero = true;
                }
                while (!lessOrZero);

                totalFule += currentFule;
            }

            Answer = totalFule.ToString();

            return this;
        }

        private float CalcFule(float massOrFule)
        {
            //var mass = float.Parse(sMass);
            var div = massOrFule / 3;
            var fule = (float)Math.Round(div, 0, MidpointRounding.ToZero) - 2;
            return fule;
        }
    }
}
