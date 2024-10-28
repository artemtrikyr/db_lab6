using Microsoft.EntityFrameworkCore;

using (var db = new GalleryContext())
{
    // Створимо базу даних, якщо вона не існує
    db.Database.EnsureCreated();

    // Додавання даних
    db.Paintings.Add(new Painting { ArtistSurname = "Шевченко", Title = "Вечір на Дніпрі", Price = 3000, Status = 1 });
    db.Paintings.Add(new Painting { ArtistSurname = "Рєпін", Title = "Козаки пишуть листа", Price = 7000, Status = 2 });
    db.Paintings.Add(new Painting { ArtistSurname = "Айвазовський", Title = "Дев'ятий вал", Price = 90000, Status = 3 });
    db.Paintings.Add(new Painting { ArtistSurname = "Авраменко", Title = "Щока лицаря", Price = 4000, Status = 1 });
    db.Paintings.Add(new Painting { ArtistSurname = "Назойський", Title = "Машини майбутнього", Price = 2000, Status = 2 });
    db.Paintings.Add(new Painting { ArtistSurname = "Лакатош", Title = "Степова злива", Price = 12000, Status = 3 });
    db.Paintings.Add(new Painting { ArtistSurname = "Сиорхман", Title = "Ліс на окраїні", Price = 7000, Status = 1 });
    db.Paintings.Add(new Painting { ArtistSurname = "Магда", Title = "Степ", Price = 8000, Status = 2 });
    db.Paintings.Add(new Painting { ArtistSurname = "Шовш", Title = "Ромашки", Price = 21000, Status = 3 });
    db.SaveChanges();
}

Console.WriteLine("Дані збережено.");

static void DisplayStudents()
{
    using (var context = new GalleryContext())
    {
        //context.Database.EnsureCreated();
        var paintings = context.Paintings.ToList();

        foreach (var paint in paintings)
        {
            Console.WriteLine($"ID: {paint.Id}, Імʼя: {paint.ArtistSurname}, Назва витвору: {paint.Title}, Ціна: {paint.Price}, Статус: {paint.Status}");
        }
    }
}

static void FindByCode()
{
    Console.WriteLine("Введіть id картини:");
    int code = int.Parse(Console.ReadLine());

    using (var db = new GalleryContext())
    {
        var painting = db.Paintings.FirstOrDefault(p => p.Id == code);

        if (painting != null)
        {
            Console.WriteLine($"Художник: {painting.ArtistSurname}, Назва: {painting.Title}, Ціна: {painting.Price}");
        }
        else
        {
            Console.WriteLine("Картину не знайдено.");
        }
    }
}

static void CalculateSumPrice()
{
    using (var db = new GalleryContext())
    {
        var totalPrice = db.Paintings.Where(p => p.Status == 2).Sum(p => p.Price);
        Console.WriteLine($"Сумарна ціна картин у запаснику: {totalPrice}");
    }
}

static void ShowThreeStatus()
{
    using (var db = new GalleryContext())
    {
        var statusthree = db.Paintings.Where(p => p.Status == 3).ToList();

        if (statusthree.Any())
        {
            Console.WriteLine("Картини із статусом 'На виїзд': ");
            foreach (var painting in statusthree)
            {
                Console.WriteLine($"Художник: {painting.ArtistSurname}, Назва: {painting.Title}, Ціна: {painting.Price}");
            }
        }
        else
        {
            Console.WriteLine("Немає картин на виїзді");
        }

    }


}

DisplayStudents();
Console.WriteLine("------------------");
FindByCode();
Console.WriteLine("------------------");
CalculateSumPrice();
Console.WriteLine("------------------");
ShowThreeStatus();
Console.WriteLine("Успішно!");