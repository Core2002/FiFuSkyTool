namespace FiFu空岛相关工具_第二弹_
{
    public class IsLand
    {
        public (int, int) SkyLoc { get; set; }
        public int X { get; set; }
        public int XX { get; set; }
        public int Y { get; set; }
        public int YY { get; set; }

        public bool IsInIsLand(int xx, int zz)
        {
            return X <= xx && xx <= XX && Y <= zz && zz <= YY;
        }

        public string GetInfo()
        {
            return @$"岛屿 {ToLocString()} 的信息如下：
X   为   {X}
XX  为   {XX}
Y   为   {Y}
YY  为   {YY}
";
        }

        public string ToLocString()
        {
            return $"({SkyLoc.Item1},{SkyLoc.Item2})";
        }

        public override string ToString()
        {
            return ToLocString() + "\n" + GetInfo();
        }
    }

    public class Sky
    {
        public static readonly int SIDE = 1024;

        public static readonly int MAX_ISLAND = 29296;

        public static int GetR(int SkyR)
        {
            return SIDE * SkyR;
        }

        public static int GetRR(int SkyR)
        {
            return SIDE * (SkyR + 1) - 1;
        }

        public static int GetSkyR(int rr)
        {
            return rr >= 0 ? rr / SIDE : -((-rr + SIDE - 1) / SIDE);
        }

        public static IsLand GetIsland(int X, int Y)
        {
            if (Math.Abs(X) > MAX_ISLAND || Math.Abs(Y) > MAX_ISLAND)
                throw new FormatException($"SkyLoc 不合法！  ->  ({X},{Y})");
            return new IsLand
            {
                X = GetR(X),
                XX = GetRR(X),
                Y = GetR(Y),
                YY = GetRR(Y),
                SkyLoc = (X, Y)
            };
        }

        public static IsLand GetIsland(string SkyLoc)
        {
            if (SkyLoc.Equals("null") || !SkyLoc.StartsWith('(') || !SkyLoc.Contains(',') || !SkyLoc.EndsWith(')'))
                throw new FormatException($"SkyLoc 不合法！  ->  {SkyLoc}");
            var c = SkyLoc.IndexOf(',');
            var X = int.Parse(SkyLoc[1..c]);
            var Y = int.Parse(SkyLoc.Substring(c + 1, SkyLoc.IndexOf(')') - c -1));
            return GetIsland(X, Y);
        }
    }
}
