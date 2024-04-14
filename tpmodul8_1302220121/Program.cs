using tpmodul8_1302220121;

internal class Program
{
    private static void Main(string[] args)
    {
        CovidConfig config = new CovidConfig();

        Console.Write($"Berapa suhu badan anda saat ini? Dalam nilai {config.CONFIG1}: ");
        double suhu = double.Parse(Console.ReadLine());

        Console.Write("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala deman? ");
        int hariDeman = int.Parse(Console.ReadLine());

        bool isValid = false;
        if (config.CONFIG1 == "celcius")
        {
            isValid = suhu >= 36.5 && suhu <= 37.5;
        }
        else
        {
            isValid = suhu >= 97.7 && suhu <= 99.5;
        }

        isValid &= hariDeman < config.CONFIG2;

        if (isValid)
        {
            Console.WriteLine(config.CONFIG4);
        }
        else
        {
            Console.WriteLine(config.CONFIG3);
        }

        // Ubah satuan suhu
        config.UbahSatuan();
        Console.WriteLine($"Satuan suhu telah diubah menjadi {config.CONFIG1}");
    }
}