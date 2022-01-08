namespace Delivery_Final_Function
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DeliveryDataModel : DbContext
    {
        public DeliveryDataModel()
            : base("name=DeliveryDataModel")
        {
        }

        public virtual DbSet<Deliverytable> Deliverytables { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Deliverytable>()
                .Property(e => e.DeliveryPerson)
                .IsFixedLength();

            modelBuilder.Entity<Deliverytable>()
                .Property(e => e.Feedback)
                .IsFixedLength();

            modelBuilder.Entity<Deliverytable>()
                .Property(e => e.DeliveryAddress)
                .IsFixedLength();

            modelBuilder.Entity<Deliverytable>()
                .Property(e => e.DeliveredProducts)
                .IsFixedLength();
        }
    }
}
