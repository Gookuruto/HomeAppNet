using NodaTime;
using System;

namespace HomeApp.Core.Database.Bills.Bill
{
    public class Bill
    {

        private Bill(int id, double billCost)
        {
            Id = id;
            BillCost = billCost;
        }

        public Bill(int id, BillType billName, double billCost, LocalDate? billPayDate = null)
        {
            Id = id;
            BillName = billName;
            BillCost = billCost;
            BillPayDate = billPayDate ?? LocalDate.FromDateTime(DateTime.Now);
        }

        public int Id { get; private set; }
        public BillType? BillName { get; private set; }
        public double BillCost { get; private set; }
        public LocalDate BillPayDate { get; private set; }
    }
}
