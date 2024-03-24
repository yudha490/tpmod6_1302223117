using System;

class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;

    public SayaTubeVideo(string title)
    {
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
        playCount += count;
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
        SayaTubeVideo video = new SayaTubeVideo("Tutorial Design By Contract – " + namaPraktikan);
        video.IncreasePlayCount(0);
        video.PrintVideoDetails();
    }
}
