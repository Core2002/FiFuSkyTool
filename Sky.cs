namespace FiFu空岛相关工具_第二弹_
{
    public class IsLand
    {
        public (long, long) SkyLoc { get; set; }
        public long X { get; set; }
        public long XX { get; set; }
        public long Y { get; set; }
        public long YY { get; set; }

        public bool IsInIsLand(long xx, long zz)
        {
            return X <= xx && xx <= XX && Y <= zz && zz <= YY;
        }

        public (long, long) IslandCenter()
        {
            return ((XX - X) / 2 + X, (YY - Y) / 2 + Y);
        }

        public bool IsOverflow()
        {
            return Math.Abs(SkyLoc.Item1) > Sky.MAX_ISLAND || Math.Abs(SkyLoc.Item2) > Sky.MAX_ISLAND;
        }

        public string GetInfo()
        {
            return @$"岛屿 {ToLocString()} 的信息：
起始xx：{X}
终止xx：{XX}
起始yy：{Y}
终止yy：{YY}
中央坐标为  {IslandCenter().Item1},{IslandCenter().Item2}";
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
        public static readonly long SIDE = 1024;

        public static readonly long MAX_ISLAND = 29296;

        public static long GetR(long SkyR)
        {
            return SIDE * SkyR;
        }

        public static long GetRR(long SkyR)
        {
            return SIDE * (SkyR + 1) - 1;
        }

        public static long GetSkyR(long rr)
        {
            return rr >= 0 ? rr / SIDE : -((-rr + SIDE - 1) / SIDE);
        }

        public static IsLand GetIsland(long X, long Y)
        {
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
            var X = long.Parse(SkyLoc[1..c]);
            var Y = long.Parse(SkyLoc.Substring(c + 1, SkyLoc.IndexOf(')') - c - 1));
            return GetIsland(X, Y);
        }
    }
}
