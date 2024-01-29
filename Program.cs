namespace Part4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // #1
            // Example1();

            // #2
            // Example2();

            // #3
            // Example3();

            // #4
            // Example4();
        }

        public static void Example1()
        {
            using ApplicationContext db = new();
            Company company1 = new() { Name = "Google" };
            Company company2 = new() { Name = "Microsoft" };

            /** добавление компаний **/
            db.Companies.AddRange(company1, company2);

            /** 
             * Установка главной сущности по свойству-внешнему ключу зависимой сущности
             * В юзере указываем id компании
             **/
            User user1 = new() { Name = "Tom", CompanyId = company1.Id };
            User user2 = new() { Name = "Bob", CompanyId = company1.Id };
            User user3 = new() { Name = "Sam", CompanyId = company2.Id };

            /** 
             * Установка зависимой сущности через навигационное свойство главной сущности 
             * В компании указываем юзеров
             **/
            // Company company1 = new Company { Name = "Google", Users = { user1, user2 } };
            // Company company2 = new Company { Name = "Microsoft", Users = { user3 } };

            /** Добавление пользователей **/
            db.Users.AddRange(user1, user2, user3);

            db.SaveChanges();

            foreach (var user in db.Users.ToList())
            {
                Console.WriteLine($"{user.Name} работает в {user.Company?.Name}");
            }
        }

        public static void Example2()
        {
            using ApplicationContext db = new();

            Company company1 = new() { Name = "Google" };
            Company company2 = new() { Name = "Microsoft" };

            User user1 = new() { Name = "Tom", Company = company1 };
            // User user2 = new() { Name = "Bob", CompanyName = "Microsoft" };
            // User user3 = new() { Name = "Sam", CompanyName = company2.Name };

            db.Companies.AddRange(company1, company2);
            // db.Users.AddRange(user1, user2, user3);
            db.SaveChanges();

            foreach (var user in db.Users.ToList())
            {
                Console.WriteLine($"{user.Name} работает в {user.Company?.Name}");
            }

        }

        public static void Example3()
        {
            using ApplicationContext db = new();

            // Добавляем начальные данные
            Company microsoft = new() { Name = "Microsoft" };
            Company google = new() { Name = "Google" };

            db.Companies.AddRange(microsoft, google);
            db.SaveChanges();

            User tom = new() { Name = "Tom", Company = microsoft };
            User bob = new() { Name = "Bob", Company = google };
            User alice = new() { Name = "Alice", Company = microsoft };
            User kate = new() { Name = "Kate", Company = google };

            db.Users.AddRange(tom, bob, alice, kate);
            db.SaveChanges();

            // Получаем пользователей
            List<User> users = db.Users.ToList();
            foreach (var user in users) Console.WriteLine(user.Name);

            // Удаляем первую компанию
            Company? comp = db.Companies.FirstOrDefault();
            if (comp != null) db.Companies.Remove(comp);

            db.SaveChanges();

            Console.WriteLine("\nСписок пользователей после удаления компании");

            // Снова получаем пользователей
            users = [.. db.Users];
            foreach (User user in users) Console.WriteLine(user.Name);
        }

        static void Example4()
        {
            //using (ApplicationContext db = new())
            //{
            //    // Пересоздадим базу данных
            //    db.Database.EnsureDeleted();
            //    db.Database.EnsureCreated();

            //    Position manager = new() { Name = "Manager" };
            //    Position developer = new() { Name = "Developer" };
            //    db.Positions.AddRange(manager, developer);

            //    City washington = new() { Name = "Washington" };
            //    db.Cities.Add(washington);

            //    Country usa = new() { Name = "USA", Capital = washington };
            //    db.Countries.Add(usa);

            //    Company microsoft = new() { Name = "Microsoft", Country = usa };
            //    Company google = new() { Name = "Google", Country = usa };
            //    db.Companies.AddRange(microsoft, google);

            //    User tom = new() { Name = "Tom", Company = microsoft, Position = manager };
            //    User bob = new() { Name = "Bob", Company = google, Position = developer };
            //    User alice = new() { Name = "Alice", Company = microsoft, Position = developer };
            //    User kate = new() { Name = "Kate", Company = google, Position = manager };
            //    db.Users.AddRange(tom, bob, alice, kate);

            //    db.SaveChanges();
            //}

            //using (ApplicationContext db = new())
            //{
            //    // Получаем пользователей
            //    var users = db.Users
            //        // добавляем данные по компаниям
            //        .Include(u => u.Company)
            //        // к компании добавляем страну 
            //        .ThenInclude(comp => comp!.Country)
            //        // к стране добавляем столицу
            //        .ThenInclude(count => count!.Capital)
            //        // добавляем данные по должностям
            //        .Include(u => u.Position)
            //        .ToList();

            //    foreach (var user in users)
            //    {
            //        Console.WriteLine($"{user.Name} - {user.Position?.Name}");
            //        Console.WriteLine($"{user.Company?.Name} - {user.Company?.Country?.Name} - {user.Company?.Country?.Capital?.Name}");
            //        Console.WriteLine("----------------------");
            //    }
            //}
        }

    }
}
