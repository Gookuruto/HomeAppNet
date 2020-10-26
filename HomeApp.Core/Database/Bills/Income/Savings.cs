using NodaTime;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeApp.Core.Database.Bills.Income
{
    public class Savings
    {
        public Savings(int id, double savedValue)
        {
            Id = id;
            SavedValue = savedValue;
        }

        public int Id { get; private set; }
        public double SavedValue { get; private set; }
        public LocalDate LastChangeDate { get; private set; }

    }
}
