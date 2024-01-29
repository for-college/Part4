namespace Part4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using ApplicationContext db = new();
            Company company1 = new() { Name = "Google" };
            Company company2 = new() { Name = "Microsoft" };

            /** добавление компаний **/
            db.Companies.AddRange(company1, company2);
            db.SaveChanges();

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

            /** добавление пользователей **/
            db.Users.AddRange(user1, user2, user3);
            db.SaveChanges();

            foreach (var user in db.Users.ToList())
            {
                Console.WriteLine($"{user.Name} работает в {user.Company?.Name}");
            }
        }
    }
}
