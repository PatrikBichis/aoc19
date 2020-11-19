using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2019
{
    public class Day3_2 : PuzzelBase, IPuzzel
    {
        public Day3_2(InputType input) : base(input, 3, 2)
        {

        }

        public IPuzzel Run()
        {
            var line1 = Input[0].Split(',');
            var line2 = Input[1].Split(',');

            var points = new List<Point>();
            var points2 = new List<Point>();

            ExtractPointsFromLine(line1, ref points, true);
            ExtractPointsFromLine(line2, ref points2, false);

            var i = 0;
            foreach(var p in points)
            {
                var p2 = points2.FirstOrDefault(x => x.X == p.X && x.Y == p.Y);

                if(p2 != null)
                {
                    p.Intersection = true;
                    p2.Intersection = true;
                }
                i++;
            }

            //var intersectionPoints = points.Where(x => x.Intersection == true).OrderBy(x => x.Length);
            var inter1 = points.Where(x => x.Intersection == true).OrderBy(x => x.Step);
            var inter2 = points2.Where(x => x.Intersection == true).OrderBy(x => x.Step);

            long sum = 0;

            foreach(var _i in inter1)
            {
                var i2 = inter2.First(x => x.X == _i.X && x.Y == _i.Y);

                var s = _i.Step + i2.Step;

                if (sum == 0 || sum > s) sum = s;
            }

            Answer = sum.ToString();

            return this;
        }

        private void ExtractPointsFromLine(string[] line, ref List<Point> points, bool first)
        {
            var x = 0;
            var y = 0;
            var step = 0;

            foreach (var p in line)
            {
                var point = GetPointFromLinePoint(p);
                for (var i = 0; i < point.Item2; i++)
                {

                    if (point.Item1 == "U") { y++; step++; }
                    if (point.Item1 == "L") { x--; step++; }
                    if (point.Item1 == "R") { x++; step++; }
                    if (point.Item1 == "D") { y--; step++; }

                    if (true)//x > -600 && x < 600 && y > -600 && y < 600)
                    {
                        AddPoint(x, y, step, ref points, first);
                    }
                }
            }
        }

        private Tuple<string, int> GetPointFromLinePoint(string p)
        {
            var cmd = p.Substring(0, 1);
            var steps = p.Substring(1, p.Length - 1);

            return new Tuple<string, int>(cmd, int.Parse(steps));
        }

        private void AddPoint(int x, int y, long step, ref List<Point> points, bool first)
        {
            points.Add(new Point { X = x, Y = y, Step = step, Intersection = false, First = first });
        }
    }
}