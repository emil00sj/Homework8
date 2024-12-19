using System;
using System.Collections.Generic;

namespace Tumakov_Tasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Упражнение 9.1-9.3");
            using (BankAccount account = new BankAccount(AccountType.Savings))
            {
                account.Deposit(1000);
                account.Withdraw(500);
                account.Withdraw(200);
                Console.WriteLine($"Баланс счета: {account.Balance}");
            }
            Console.WriteLine("Домашнее задание 9.1");
            Console.WriteLine("Обновленная песня");
            var songs = new List<Song>
        {
            new Song("Песня - Любимый цвет", "Автор - Noize MC"),
            new Song("Песня - ICE AGE", "Автор - Saluki"),
            new Song("Песня - Золотые рыбки", "Автор - ЛСП"),
            new Song("Песня - В клубе", "Автор - Тимати")
        };
            PrintSongs(songs);
            var isEqual = songs[0].Equals(songs[1]);
            Console.WriteLine(isEqual ? "Первая и вторая песни в списке равны." : "Первая и вторая песни в списке не равны.");
            var mySong = new Song();
            Console.WriteLine("Создана mySong с названием: " + mySong);
            Console.WriteLine("Нажмите любую клавишу для выхода");
            Console.ReadKey();
        }
        static void PrintSongs(List<Song> songs)
        {
            foreach (var song in songs)
            {
                Console.WriteLine("Название: " + song);
            }
        }
    }
}
