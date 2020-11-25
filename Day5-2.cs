using System;

namespace aoc2019
{
    public class Day5_2 : PuzzelBase, IPuzzel
    {
        public Day5_2(InputType input) : base(input, 5, 2)
        {
            
        }

        private int input = 8;
        private int output = 0;

        public IPuzzel Run()
        {
            Console.WriteLine("Input: " + input);
            // Console.WriteLine("Test: 3,9,8,9,10,9,4,9,99,-1,8 -> " + FormatAnswer(RunProgram("3,9,8,9,10,9,4,9,99,-1,8".Split(','))));
            // Console.WriteLine("Output: " + output);
            // Console.WriteLine("Test: 3,9,8,9,10,9,4,9,99,-1,8 -> " + FormatAnswer(RunProgram("3,9,7,9,10,9,4,9,99,-1,8".Split(','))));
            // Console.WriteLine("Output: " + output);
            // Console.WriteLine("Test: 3,3,1108,-1,8,3,4,3,99 -> " + FormatAnswer(RunProgram("3,3,1108,-1,8,3,4,3,99".Split(','))));
            // Console.WriteLine("Output: " + output);
            // Console.WriteLine("Test: 3,3,1107,-1,8,3,4,3,99 -> " + FormatAnswer(RunProgram("3,3,1107,-1,8,3,4,3,99".Split(','))));
            // Console.WriteLine("Output: " + output);
            // Console.WriteLine("Test: 3,12,6,12,15,1,13,14,13,4,13,99,-1,0,1,9 -> " + FormatAnswer(RunProgram("3,12,6,12,15,1,13,14,13,4,13,99,-1,0,1,9".Split(','))));
            // Console.WriteLine("Output: " + output);
            // Console.WriteLine("Test: 3,3,1105,-1,9,1101,0,0,12,4,12,99,1 -> " + FormatAnswer(RunProgram("3,3,1105,-1,9,1101,0,0,12,4,12,99,1".Split(','))));
            // Console.WriteLine("Output: " + output);
            Console.WriteLine(FormatAnswer(RunProgram("3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104,999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99".Split(','))));
            Console.WriteLine("Output: " + output);


            var program = Input[0].Split(',');

            input = 5;

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
            var opCode = 0;

            if (cmd.Length > 1)
                opCode = ExtractOpcode(cmd);
            else
                opCode = int.Parse(cmd);
            
            if (opCode == 1)
                HandleCmd_1(cmd, ref p, ref program);
            if (opCode == 2)
                HandleCmd_2(cmd, ref p, ref program);
            if (opCode == 3)
                HandleCmd_3(cmd,ref p, ref program);
            if (opCode == 4)
                HandleCmd_4(cmd,ref p, ref program);
            if (opCode == 5)
                HandleCmd_5(cmd,ref p, ref program);
            if (opCode == 6)
                HandleCmd_6(cmd,ref p, ref program);
            if (opCode == 7)
                HandleCmd_7(cmd, ref p, ref program);
            if (opCode == 8)
                HandleCmd_8(cmd, ref p, ref program);

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
            var mode = 0;
            var id = 1;

            if(cmd.Length< 2){
                mode = 0;
            } 
            else if (id == 1 && cmd.Length < 3)
                mode = 0;
            else if (id == 2 && cmd.Length < 4)
                mode = 0;
            else if (id == 3 && cmd.Length < 5)
                mode = 0;
            else
                mode = int.Parse(cmd.Substring((cmd.Length - (2 + id)), 1));

            if (mode == 1)
                output = int.Parse(program[p + id]);
            else
                output = int.Parse(program[GetProgramPointer(id, p, program)]);

            p += 2;
        }

        // jump-if-true
        private void HandleCmd_5(string cmd, ref int p, ref string[] program)
        {
            var a = GetParameterFromMode(cmd, 1, p, program);
            var id = GetParameterFromMode(cmd, 2, p, program);

            if(a != 0)
                p = id;
            else
                p += 3;
        }

        // jump-if-false
        private void HandleCmd_6(string cmd, ref int p, ref string[] program)
        {
            var a = GetParameterFromMode(cmd, 1, p, program);
            var id = GetParameterFromMode(cmd, 2, p, program);

            if(a == 0)
                p = id;
            else
                p += 3;
        }

        // less than
        private void HandleCmd_7(string cmd, ref int p, ref string[] program)
        {
            var id = GetProgramPointer(3, p, program);

            var a = GetParameterFromMode(cmd, 1, p, program);
            var b = GetParameterFromMode(cmd, 2, p, program);

            if(a<b)
                program[id] = 1.ToString();
            else
                program[id] = 0.ToString();

            p += 4;
        }

        // equals
        private void HandleCmd_8(string cmd, ref int p, ref string[] program)
        {
            var id = GetProgramPointer(3, p, program);

            var a = GetParameterFromMode(cmd, 1, p, program);
            var b = GetParameterFromMode(cmd, 2, p, program);

            if(a==b)
                program[id] = 1.ToString();
            else
                program[id] = 0.ToString();

            p += 4;
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

        private int ExtractOpcode(string cmd)
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
