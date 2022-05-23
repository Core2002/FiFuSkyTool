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

        public override string ToString()
        {
            return $"({SkyLoc.Item1},{SkyLoc.Item2})";
        }
    }

    public class Sky
    {
        public int SIDE { get; set; }

        public int MAX_ISLAND { get; set; }

        public int GetR(int SkyR)
        {
            return SIDE * SkyR;
        }

        public int GetRR(int SkyR)
        {
            return SIDE * (SkyR + 1) - 1;
        }

        public int GetSkyR(int rr)
        {
            return rr >= 0 ? rr / SIDE : -((-rr + SIDE - 1) / SIDE);
        }

    }
}
