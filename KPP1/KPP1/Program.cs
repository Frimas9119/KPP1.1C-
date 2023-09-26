using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Toy
{
    public string Name { get; set; }
    public int Price { get; set; }
    public int MinAge { get; set; }
    public int MaxAge { get; set; }
    public string SizeOrQuantityOrWeight { get; set; }

    public Toy(string name, int price, int minAge, int maxAge, string sizeOrQuantityOrWeight)
    {
        Name = name;
        Price = price;
        MinAge = minAge;
        MaxAge = maxAge;
        SizeOrQuantityOrWeight = sizeOrQuantityOrWeight;
    }
}

class Program
{
    static void Main()
    {
        List<Toy> toys = new List<Toy>();
        string[] lines = File.ReadAllLines("q.txt");

        foreach (string line in lines)
        {
            string[] parts = line.Split(',');
            string name = parts[0];
            int price = int.Parse(parts[1]);
            int minAge = int.Parse(parts[2]);
            int maxAge = int.Parse(parts[3]);
            string sizeOrQuantityOrWeight = parts[4];

            Toy toy = new Toy(name, price, minAge, maxAge, sizeOrQuantityOrWeight);
            toys.Add(toy);
        }

        Console.Write("Введіть початкову ціну (у копійках): ");
        int minPrice = int.Parse(Console.ReadLine());

        Console.Write("Введіть кінцеву ціну (у копійках): ");
        int maxPrice = int.Parse(Console.ReadLine());

        List<Toy> filteredToys = toys
            .Where(toy => toy.Price >= minPrice && toy.Price <= maxPrice && toy.MinAge > 4)
            .OrderByDescending(toy => toy.Price)
            .ToList();

        Console.WriteLine("Результати фільтрації:");
        foreach (Toy toy in filteredToys)
        {
            Console.WriteLine($"Назва: {toy.Name}, Ціна: {toy.Price / 100.0} грн, Мінімальний вік: {toy.MinAge}, Максимальний вік: {toy.MaxAge}");
            if (toy.Name == "Лялька")
            {
                Console.WriteLine($"Розмір: {toy.SizeOrQuantityOrWeight} см");
            }
            else if (toy.Name == "Кубики")
            {
                Console.WriteLine($"Кількість в наборі: {toy.SizeOrQuantityOrWeight} шт");
            }
            else if (toy.Name == "М'яч")
            {
                Console.WriteLine($"Вага: {toy.SizeOrQuantityOrWeight} г");
            }
            else if (toy.Name == "Конструктор")
            {
                Console.WriteLine($"Кількість конструкцій: {toy.SizeOrQuantityOrWeight}");
            }
            Console.WriteLine();
        }
    }
}
