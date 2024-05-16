namespace BasicDemos
{
    public static class FizzBuzz
    {
        public static string GetFizzBuzzText(int i)
        {
            if (i == 0) return i.ToString();
            if (i % 15 == 0)
                return "FizzBuzz";
            if (i % 3 == 0)
                return "Fizz";
            if (i % 5 == 0)
                return "Buzz";
            return i.ToString();
        }
    }
}
