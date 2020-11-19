using System;

namespace aoc2019
{
    public class Day5_1 : PuzzelBase, IPuzzel
    {
        public Day5_1(InputType input) : base(input, 5, 1)
        {
            
        }

        private int input = 1;
        private int output = 0;

        public IPuzzel Run()
        {
            Console.WriteLine("Test: 2,3,0,3,1002,8,3,8,33,99 -> " + FormatAnswer(RunProgram("2,3,0,3,1002,8,3,8,33,99".Split(','))));

            var program = Input[0].Split(',');

            input = 1;

            RunProgram(program);

            Answer = output.ToString();

            return this;
        }

        private string[] RunProgram(string[] program)
        {
            var prgPointer = 0;
            var endOfProgram = false;
            var memory = new int[] { 0 };

            do
            {
                var cmd = program[prgPointer];

                if (cmd != "99")
                    HandleCmd(cmd, ref prgPointer, ref program);
                else
                    endOfProgram = true;

                if (prgPointer >= program.Length) endOfProgram = true;
            } while (!endOfProgram);

            return program;
        }

        private void HandleCmd(string cmd, ref int p, ref string[] program)
        {
            var c = 0;

            if (cmd.Length > 1)
                c = ExtractCmd(cmd);
            else
                c = int.Parse(cmd);
            
            if (c == 1)
                HandleCmd_1(cmd, ref p, ref program);
            if (c == 2)
                HandleCmd_2(cmd, ref p, ref program);
            if (c == 3)
                HandleCmd_3(cmd, ref p, ref program);
            if (c == 4)
                HandleCmd_4(cmd, ref p, ref program);

        }

        private void HandleCmd_1(string cmd, ref int p, ref string[] program)
        {
            var idS = GetProgramPointer(3, p, program);

            var a = GetParameterFromMode(cmd, 1, p, program);
            var b = GetParameterFromMode(cmd, 2, p, program);
            var sum = 0;

            sum = a + b;

            program[idS] = sum.ToString();

            p += 4;
        }

        private void HandleCmd_2(string cmd, ref int p, ref string[] program)
        {
            var idS = GetProgramPointer(3, p, program);

            var a = GetParameterFromMode(cmd, 1, p, program);
            var b = GetParameterFromMode(cmd, 2, p, program);
            var sum = 0;

            sum = a * b;

            program[idS] = sum.ToString();

            p += 4;
        }

        private void HandleCmd_3(string cmd, ref int p, ref string[] program)
        {

            var idI = GetProgramPointer(1, p, program);

            program[idI] = input.ToString();

            p += 2;
        }

        private void HandleCmd_4(string cmd, ref int p, ref string[] program)
        {
            var idO = GetProgramPointer(1, p, program);

            output = int.Parse(program[idO]);

            p += 2;
        }

        private int GetProgramPointer(int i, int p, string[] program)
        {
            return int.Parse(program[p + i]);
        }

        private string FormatAnswer(string[] program)
        {
            var output = string.Empty;

            foreach (var p in program)
            {
                output += p + ",";
            }

            return output.Substring(0, output.Length - 1);
        }

        private int ExtractCmd(string cmd)
        {
            return int.Parse(cmd.Substring(cmd.Length - 2, 2));
        }

        private int GetParameterFromMode(string cmd, int id, int p, string[] program)
        {
            var mode = 0;

            if (id == 1 && cmd.Length < 3)
                mode = 0;
            else if (id == 2 && cmd.Length < 4)
                mode = 0;
            else if (id == 3 && cmd.Length < 5)
                mode = 0;
            else
                mode = int.Parse(cmd.Substring((cmd.Length - (2 + id)), 1));

            if (mode == 1)
                return int.Parse(program[p + id]);

            return int.Parse(program[GetProgramPointer(id, p, program)]);
        }

    }
}
