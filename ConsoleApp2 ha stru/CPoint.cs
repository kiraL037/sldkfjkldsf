namespace ConsoleApp2_ha_stru
{
    internal class CPoint
    {
        private int v1;
        private int v2;

        public CPoint(int v1, int v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

        public int X { get; internal set; }
    }
}