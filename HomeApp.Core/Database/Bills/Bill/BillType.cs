using System;
using System.Collections.Generic;
using System.Text;

namespace HomeApp.Core.Database.Bills.Bill
{
    public class BillType
    {
        public BillType(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }

    }
}
