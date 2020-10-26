using HomeApp.Core.Databse.Users.Models;
using NodaTime;

namespace HomeApp.Core.Database.Bills.Income
{
    public class Income
    {
        public int Id { get; private set; }
        public LocalDate DateOfInccome { get; private set; }
        public double AmountOfIncome { get; private set; }
        public User? User { get; set; }

        private Income(int id, double amountOfIncome)
        {
            Id = id;
            AmountOfIncome = amountOfIncome;
        }

        public Income(int id, LocalDate dateOfInccome, double amountOfIncome, User? user)
        {
            Id = id;
            DateOfInccome = dateOfInccome;
            AmountOfIncome = amountOfIncome;
            User = user;
        }
    }
}
