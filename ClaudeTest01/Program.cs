using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("0～9の数字を入力してください。");
            Console.WriteLine("アプリを終了する場合は e または E を入力してください。");
            Console.Write("入力: ");

            string? input = Console.ReadLine();

            switch (input)
            {
                case "0":
                    ShowCalendar();
                    break;

                case "1":
                    ShowToday();
                    break;

                case "e":
                case "E":
                    Console.WriteLine("アプリを終了します。");
                    return;

                default:
                    Console.WriteLine("0～9の数字、または e / E を入力してください。");
                    break;
            }

            Console.WriteLine();
        }
    }

    // 0：現在の月のカレンダーを表示
    static void ShowCalendar()
    {
        DateTime today = DateTime.Today;

        int year = today.Year;
        int month = today.Month;

        Console.WriteLine($"{year}年{month}月");
        Console.WriteLine("日 月 火 水 木 金 土");

        DateTime firstDay = new DateTime(year, month, 1);

        int daysInMonth = DateTime.DaysInMonth(year, month);

        int startDayOfWeek = (int)firstDay.DayOfWeek;

        for (int i = 0; i < startDayOfWeek; i++)
        {
            Console.Write("   ");
        }

        for (int day = 1; day <= daysInMonth; day++)
        {
            Console.Write($"{day,2} ");

            if ((startDayOfWeek + day) % 7 == 0)
            {
                Console.WriteLine();
            }
        }

        Console.WriteLine();
    }

    // 1：本日の日付と曜日を表示
    static void ShowToday()
    {
        DateTime today = DateTime.Today;

        string dayOfWeek = today.ToString(
            "dddd",
            CultureInfo.GetCultureInfo("ja-JP")
        );

        Console.WriteLine($"本日は {today:yyyy年MM月dd日}（{dayOfWeek}）です。");
    }
}