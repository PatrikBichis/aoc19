using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2019
{
    public class Day2_2 : PuzzelBase, IPuzzel
    {
        public Day2_2(InputType input) : base(input, 2, 2)
        {

        }

        public IPuzzel Run()
        {
            
            for (var i = 0; i <= 99; i++) {
                for (var j = 0; j <= 99; j++)
                {
                    var program = Input[0].Split(','); // Change from 0 -> 1 etc to test diffrent tests
                    var prgPointer = 0;
                    var endOfProgram = false;

                    program[1] = i.ToString();
                    program[2] = j.ToString();

                    do
                    {
                        var cmd = program[prgPointer];

                        if (cmd != "99")
                            HandleCmd(cmd, prgPointer, ref program);
                        else
                            endOfProgram = true;

                        prgPointer += 4;

                        if (prgPointer >= program.Length) endOfProgram = true;
                    } while (!endOfProgram);

                    if(program[0] == "19690720")
                    {
                        Answer = (100 * i + j).ToString();
                        break;
                    }
                }
            }

            return this;
        }

        private void HandleCmd(string cmd, int p, ref string[] program)
        {
            var idA = GetProgramPointer(1, p, program);
            var idB = GetProgramPointer(2, p, program);
            var idS = GetProgramPointer(3, p, program);

            var a = int.Parse(program[idA]);
            var b = int.Parse(program[idB]);
            var sum = 0;

            if (cmd == "1")
                sum = a + b;
            if (cmd == "2")
                sum = a * b;

            program[idS] = sum.ToString();
        }

        private int GetProgramPointer(int i, int p, string[] program)
        {
            return int.Parse(program[p + i]);
        }
    }
}
