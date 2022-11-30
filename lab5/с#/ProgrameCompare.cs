class ProgramCompare
{
    public class Character
    {
        public int level;
        public float fuel;
    }

    static void Main()
    {
        List<Character> list = new List<Character>();
        list.Sort();
    }

    public static int SortInt(int i1, int i2)
    {
        if(i1 == i2) return 0;
        if (i1 > i2) return -1;
        else return 1;
        i1.CompareTo(i2);
    }

    public static int SortCharacterByLevel(Character p1, Character p2)
    {
        return p1.level.CompareTo(p2.level);
    }

}