namespace Part4
{
    /** Юзер зависит от Company т.к. содержит ссылку на класс Company и зависит от этого класса **/
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        /** 
         * Foreign key
         * По умолчанию название внешнего ключа должно принимать одно из следующих вариантов имени:
         * - Имя_класса_связанной_сущности + Имя ключа из связанной сущности
         * - Имя_навигационного_свойства + Имя ключа из связанной сущности
         * 
         * NOTE: Необязательно указывать внешний ключ, т.к. Entity Framework может это сделать автоматически
         **/
        public int CompanyId { get; set; }
        /** Нав. свойство **/
        public Company? Company { get; set; }

        /** 
         * Способ №2
         * Аннотация данных
         **/
        //public int? CompanyInfoKey { get; set; }
        //[ForeignKey("CompanyInfoKey")]
        //public Company? Company { get; set; }
    }
}