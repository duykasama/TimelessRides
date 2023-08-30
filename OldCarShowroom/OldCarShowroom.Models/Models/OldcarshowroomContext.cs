using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OldCarShowroom.Models.Models;

public partial class OldcarshowroomContext : DbContext
{
    public OldcarshowroomContext()
    {
    }

    public OldcarshowroomContext(DbContextOptions<OldcarshowroomContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<CarDescription> CarDescriptions { get; set; }

    public virtual DbSet<CarImage> CarImages { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<ClientNotification> ClientNotifications { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<OffMeeting> OffMeetings { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Showroom> Showrooms { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<StaffNotification> StaffNotifications { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=(local);database=oldcarshowroom;uid=sa;pwd=12345;trusted_connection=true;trustservercertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__admin__3213E83F3FDA1078");

            entity.ToTable("admin");

            entity.Property(e => e.Id)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.Avatar)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("avatar");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("role");
        });

        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__car__3213E83FA4FAC85A");

            entity.ToTable("car");

            entity.HasIndex(e => e.CarDescriptionId, "UQ__car__E83E2849142A4CA8").IsUnique();

            entity.Property(e => e.Id)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.CarDescriptionId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("car_description_id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.ShowroomId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("showroom_id");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("status");

            entity.HasOne(d => d.CarDescription).WithOne(p => p.Car)
                .HasForeignKey<Car>(d => d.CarDescriptionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__car__car_descrip__300424B4");

            entity.HasOne(d => d.Showroom).WithMany(p => p.Cars)
                .HasForeignKey(d => d.ShowroomId)
                .HasConstraintName("FK__car__showroom_id__30F848ED");
        });

        modelBuilder.Entity<CarDescription>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__car_desc__3213E83F0E6C5689");

            entity.ToTable("car_description");

            entity.Property(e => e.Id)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.Body)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("body");
            entity.Property(e => e.BodyColor)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("body_color");
            entity.Property(e => e.Co2Emission)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("co2_emission");
            entity.Property(e => e.EngineCapacity)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("engine_capacity");
            entity.Property(e => e.FirstRegistration)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("first_registration");
            entity.Property(e => e.FuelType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("fuel_type");
            entity.Property(e => e.InteriorColor)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("interior_color");
            entity.Property(e => e.InteriorMaterial)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("interior_material");
            entity.Property(e => e.LicensePlate)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("license_plate");
            entity.Property(e => e.Make)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("make");
            entity.Property(e => e.Mileage)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("mileage");
            entity.Property(e => e.Model)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("model");
            entity.Property(e => e.Others)
                .HasMaxLength(2000)
                .HasColumnName("others");
            entity.Property(e => e.Power)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("power");
            entity.Property(e => e.Seats).HasColumnName("seats");
            entity.Property(e => e.Transmission)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("transmission");
        });

        modelBuilder.Entity<CarImage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__car_imag__3213E83F3F1FAD51");

            entity.ToTable("car_image");

            entity.Property(e => e.Id)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.CarId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("car_id");
            entity.Property(e => e.Content)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("content");

            entity.HasOne(d => d.Car).WithMany(p => p.CarImages)
                .HasForeignKey(d => d.CarId)
                .HasConstraintName("FK__car_image__car_i__33D4B598");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__client__3213E83FCDD74EEF");

            entity.ToTable("client");

            entity.Property(e => e.Id)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .HasColumnName("address");
            entity.Property(e => e.Avatar)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("avatar");
            entity.Property(e => e.Dob)
                .HasColumnType("date")
                .HasColumnName("dob");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Gender)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.JoinAt)
                .HasColumnType("date")
                .HasColumnName("join_at");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("role");
        });

        modelBuilder.Entity<ClientNotification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__client_n__3213E83FEDA1EC38");

            entity.ToTable("client_notification");

            entity.Property(e => e.Id)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.Content)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("content");
            entity.Property(e => e.CreateDate)
                .HasColumnType("date")
                .HasColumnName("create_date");
            entity.Property(e => e.CreateTime).HasColumnName("create_time");
            entity.Property(e => e.ReceiverId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("receiver_id");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("status");

            entity.HasOne(d => d.Receiver).WithMany(p => p.ClientNotifications)
                .HasForeignKey(d => d.ReceiverId)
                .HasConstraintName("FK__client_no__recei__48CFD27E");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__feedback__3213E83FB690A704");

            entity.ToTable("feedback");

            entity.Property(e => e.Id)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.ClientId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("client_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("date")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasMaxLength(2000)
                .HasColumnName("description");
            entity.Property(e => e.Rating).HasColumnName("rating");

            entity.HasOne(d => d.Client).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("FK__feedback__client__45F365D3");
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__invoice__3213E83F963E3415");

            entity.ToTable("invoice");

            entity.HasIndex(e => e.CarId, "UQ__invoice__4C9A0DB2DC444F6F").IsUnique();

            entity.Property(e => e.Id)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.CarId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("car_id");
            entity.Property(e => e.ClientId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("client_id");
            entity.Property(e => e.CreateDate)
                .HasColumnType("date")
                .HasColumnName("create_date");
            entity.Property(e => e.CreateTime).HasColumnName("create_time");
            entity.Property(e => e.Others)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("others");
            entity.Property(e => e.StaffId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("staff_id");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.Tax)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("tax");
            entity.Property(e => e.Total).HasColumnName("total");

            entity.HasOne(d => d.Car).WithOne(p => p.Invoice)
                .HasForeignKey<Invoice>(d => d.CarId)
                .HasConstraintName("FK__invoice__car_id__3E52440B");

            entity.HasOne(d => d.Client).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("FK__invoice__client___3D5E1FD2");

            entity.HasOne(d => d.Staff).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.StaffId)
                .HasConstraintName("FK__invoice__staff_i__3C69FB99");
        });

        modelBuilder.Entity<OffMeeting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__off_meet__3213E83FAD66AFBA");

            entity.ToTable("off_meeting");

            entity.Property(e => e.Id)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.CarId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("car_id");
            entity.Property(e => e.ClientId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("client_id");
            entity.Property(e => e.CreateDate)
                .HasColumnType("date")
                .HasColumnName("create_date");
            entity.Property(e => e.CreateTime).HasColumnName("create_time");
            entity.Property(e => e.Description)
                .HasMaxLength(2000)
                .HasColumnName("description");
            entity.Property(e => e.MeetingDate)
                .HasColumnType("date")
                .HasColumnName("meeting_date");
            entity.Property(e => e.MeetingTime).HasColumnName("meeting_time");
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.StaffId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("staff_id");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("status");

            entity.HasOne(d => d.Car).WithMany(p => p.OffMeetings)
                .HasForeignKey(d => d.CarId)
                .HasConstraintName("FK__off_meeti__car_i__4316F928");

            entity.HasOne(d => d.Client).WithMany(p => p.OffMeetings)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("FK__off_meeti__clien__4222D4EF");

            entity.HasOne(d => d.Staff).WithMany(p => p.OffMeetings)
                .HasForeignKey(d => d.StaffId)
                .HasConstraintName("FK__off_meeti__staff__412EB0B6");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__post__3213E83F6BF2A203");

            entity.ToTable("post");

            entity.HasIndex(e => e.CarId, "UQ__post__4C9A0DB23FC9D35E").IsUnique();

            entity.Property(e => e.Id)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.CarId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("car_id");
            entity.Property(e => e.ClientId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("client_id");
            entity.Property(e => e.Description)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.ExpireDate)
                .HasColumnType("date")
                .HasColumnName("expire_date");
            entity.Property(e => e.Plan)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("plan");
            entity.Property(e => e.PostDate)
                .HasColumnType("date")
                .HasColumnName("post_date");
            entity.Property(e => e.PostTime).HasColumnName("post_time");
            entity.Property(e => e.Priority).HasColumnName("priority");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("status");

            entity.HasOne(d => d.Car).WithOne(p => p.Post)
                .HasForeignKey<Post>(d => d.CarId)
                .HasConstraintName("FK__post__car_id__37A5467C");

            entity.HasOne(d => d.Client).WithMany(p => p.Posts)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("FK__post__client_id__38996AB5");
        });

        modelBuilder.Entity<Showroom>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__showroom__3213E83F388CB50A");

            entity.ToTable("showroom");

            entity.Property(e => e.Id)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .HasColumnName("address");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .HasColumnName("city");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__staff__3213E83F6A491660");

            entity.ToTable("staff");

            entity.Property(e => e.Id)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .HasColumnName("address");
            entity.Property(e => e.Avatar)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("avatar");
            entity.Property(e => e.Dob)
                .HasColumnType("date")
                .HasColumnName("dob");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Gender)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.JoinedAt)
                .HasColumnType("date")
                .HasColumnName("joined_at");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("role");
            entity.Property(e => e.ShowroomId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("showroom_id");

            entity.HasOne(d => d.Showroom).WithMany(p => p.Staff)
                .HasForeignKey(d => d.ShowroomId)
                .HasConstraintName("FK__staff__showroom___286302EC");
        });

        modelBuilder.Entity<StaffNotification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__staff_no__3213E83F80217BD8");

            entity.ToTable("staff_notification");

            entity.Property(e => e.Id)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.Content)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("content");
            entity.Property(e => e.CreateDate)
                .HasColumnType("date")
                .HasColumnName("create_date");
            entity.Property(e => e.CreateTime).HasColumnName("create_time");
            entity.Property(e => e.ReceiverId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("receiver_id");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("status");

            entity.HasOne(d => d.Receiver).WithMany(p => p.StaffNotifications)
                .HasForeignKey(d => d.ReceiverId)
                .HasConstraintName("FK__staff_not__recei__4BAC3F29");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
