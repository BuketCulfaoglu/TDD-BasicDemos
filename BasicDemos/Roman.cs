namespace BasicDemos
{
    public static class Roman
    {
        private static Dictionary<char, int> map = new()
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000},
        };


        public static int Parse(string roman)
        {
            int result = 0;
            for (int i = 0; i < roman.Length; i++)
            {
                if (i + 1 < roman.Length && map[roman[i]] < map[roman[i + 1]])
                    result -= map[roman[i]];
                else
                    result += map[roman[i]];
            }

            return result;
        }
    }
}
