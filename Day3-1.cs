using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace aoc2019
{
    public class Day3_1 : PuzzelBase, IPuzzel
    {
        public Day3_1(InputType input) : base(input, 3, 1)
        {

        }

        public IPuzzel Run()
        {
            var line1 = Input[0].Split(',');
            var line2 = Input[1].Split(',');

            var points = new List<Point>();
            var points2 = new List<Point>();

            ExtractPointsFromLine(line1, ref points, true);
            ExtractPointsFromLine(line2, ref points, false);

            var intersectionPoints = points.Where(x => x.Intersection == true).OrderBy(x=>x.Length);

            Answer = intersectionPoints.First().Length.ToString();

            return this;
        }

        private void ExtractPointsFromLine(string[] line, ref List<Point> points, bool first)
        {
            var x = 0;
            var y = 0;

            foreach (var p in line)
            {
                var point = GetPointFromLinePoint(p);
                for (var i = 0; i < point.Item2; i++)
                {

                    if (point.Item1 == "U") y++;
                    if (point.Item1 == "L") x--;
                    if (point.Item1 == "R") x++;
                    if (point.Item1 == "D") y--;

                    AddPoint(x, y, ref points, first);
                }
            }
        }

        private Tuple<string, int> GetPointFromLinePoint(string p)
        {
            var cmd = p.Substring(0, 1);
            var steps = p.Substring(1, p.Length - 1);

            return new Tuple<string, int>(cmd, int.Parse(steps));
        }

        private void AddPoint(int x, int y, ref List<Point> points, bool first)
        {
            if (first)
            {
                points.Add(new Point { X = x, Y = y, Intersection = false, First = first });
            }
            else
            {
                var p = points.FirstOrDefault(i => i.X == x && i.Y == y && i.First == true);

                if (p != null)
                {
                    p.Intersection = true;
                }
                else
                {
                    points.Add(new Point { X = x, Y = y, Intersection = false, First = false });
                }
            }
        }
    }

    internal class Point
    {
        public int X { get; set; } = 0;

        public int Y { get; set; } = 0;

        public long Step { get; set; } = 0;

        public bool First { get; set; } = true;

        public int Length 
        { 
            get
            {
                return Math.Abs(X) + Math.Abs(Y);
            }
        }

        public bool Intersection { get; set; } = false;
    }
}
