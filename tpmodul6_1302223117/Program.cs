using System;

class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;
    private const int MAX_TITLE_LENGTH = 100;
    private const int MAX_PLAY_COUNT_INCREMENT = 10000000;

    public SayaTubeVideo(string title)
    {
        if (string.IsNullOrEmpty(title) || title.Length > MAX_TITLE_LENGTH)
        {
            throw new ArgumentException("Judul video harus memiliki panjang maksimal 100 karakter dan tidak boleh null");
        }

        this.id = GenerateRandomId();
        this.title = title;
        this.playCount = 0;
    }

    private int GenerateRandomId()
    {
        Random rnd = new Random();
        return rnd.Next(10000, 99999);
    }

    public void IncreasePlayCount(int count)
    {
        if (count < 0 || count > MAX_PLAY_COUNT_INCREMENT)
        {
            throw new ArgumentOutOfRangeException("Input penambahan play count harus antara 0 dan 10.000.000");
        }

        try
        {
            checked
            {
                playCount += count;
            }
        }
        catch (OverflowException ex)
        {
            Console.WriteLine("Terjadi overflow saat menambahkan play count: " + ex.Message);
        }
    }

    public void PrintVideoDetails()
    {
        Console.WriteLine("Video Details:");
        Console.WriteLine("ID: " + id);
        Console.WriteLine("Title: " + title);
        Console.WriteLine("Play Count: " + playCount);
    }
}

class Program
{
    static void Main(string[] args)
    {
        string namaPraktikan = "Muhammad Yudha Pratama";
        try
        {
            SayaTubeVideo invalidVideo = new SayaTubeVideo(null);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Terjadi kesalahan saat membuat video: " + ex.Message);
        }

        SayaTubeVideo video = new SayaTubeVideo("Tutorial Design By Contract – " + namaPraktikan);

        for (int i = 0; i < 10; i++)
        {
            try
            {
                video.IncreasePlayCount(1000000);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Terjadi kesalahan saat menambahkan play count: " + ex.Message);
            }
        }

        video.PrintVideoDetails();
    }
}
