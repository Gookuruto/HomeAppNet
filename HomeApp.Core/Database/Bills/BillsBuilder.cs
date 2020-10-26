using HomeApp.Core.Database.Bills.Bill;
using Microsoft.EntityFrameworkCore;
using NodaTime;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeApp.Core.Database.Bills
{
    public static class BillsBuilder
    {
        public static void BuildBillsEntities(ModelBuilder builder)
        {
            builder.Entity<BillType>(entity =>
            {
                entity.HasIndex(x => x.Name).IsUnique();
            });
            builder.Entity<Bill.Bill>(entity =>
            {
                entity.Property(x => x.BillPayDate).HasConversion(v => v.ToDateTimeUnspecified(), v => LocalDate.FromDateTime(v));
            });
            builder.Entity<Income.Income>(entity =>
            {
                entity.Property(x => x.DateOfInccome).HasConversion(v => v.ToDateTimeUnspecified(), v => LocalDate.FromDateTime(v));
            });
            builder.Entity<Income.Savings>(entity =>
            {
                entity.Property(x => x.LastChangeDate).HasConversion(v => v.ToDateTimeUnspecified(), v => LocalDate.FromDateTime(v));
            });
        }
    }
}
