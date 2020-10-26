using NodaTime;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeApp.Core.Database.Hobbys
{
    public class HobbyItem
    {
        public HobbyItem(int id, double cost, string name, LocalDate dateOfPurchase)
        {
            Id = id;
            Cost = cost;
            Name = name;
            DateOfPurchase = dateOfPurchase;
        }

        public int Id { get; private set; }
        public double Cost { get; private set; }
        public string Name { get; private set; }
        public LocalDate DateOfPurchase { get; private set; }
    }
}
