public class calculations
{
    public static int CalculateTotal(int[] numbers)
    {
        int total = 0;
        for (int i = 0; i < numbers.Length; i++) 
        {
            total += numbers[i];
        }
        return total;
    }

    public static void Main(string[] args)
    {
        int[] data1 = { 1, 2, 3 };
        int[] data2 = { 4, 5, 6 };

        Console.WriteLine(CalculateTotal(data1));
        Console.WriteLine(CalculateTotal(data2));
    }
}