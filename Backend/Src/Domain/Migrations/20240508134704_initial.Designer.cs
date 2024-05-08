﻿// <auto-generated />
using System;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Domain.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240508134704_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.BrandEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2024, 5, 8, 13, 47, 3, 180, DateTimeKind.Utc).AddTicks(8614),
                            Name = "Audi"
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2024, 5, 8, 13, 47, 3, 180, DateTimeKind.Utc).AddTicks(8666),
                            Name = "BMW"
                        },
                        new
                        {
                            Id = 3,
                            Created = new DateTime(2024, 5, 8, 13, 47, 3, 180, DateTimeKind.Utc).AddTicks(8668),
                            Name = "Chery"
                        },
                        new
                        {
                            Id = 4,
                            Created = new DateTime(2024, 5, 8, 13, 47, 3, 180, DateTimeKind.Utc).AddTicks(8670),
                            Name = "Chevrolet"
                        });
                });

            modelBuilder.Entity("Domain.Entities.ModelEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BrandId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Models");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BrandId = 1,
                            Created = new DateTime(2024, 5, 8, 13, 47, 3, 181, DateTimeKind.Utc).AddTicks(3625),
                            Name = "100"
                        },
                        new
                        {
                            Id = 2,
                            BrandId = 1,
                            Created = new DateTime(2024, 5, 8, 13, 47, 3, 181, DateTimeKind.Utc).AddTicks(3633),
                            Name = "80"
                        },
                        new
                        {
                            Id = 3,
                            BrandId = 1,
                            Created = new DateTime(2024, 5, 8, 13, 47, 3, 181, DateTimeKind.Utc).AddTicks(3635),
                            Name = "A3"
                        },
                        new
                        {
                            Id = 4,
                            BrandId = 2,
                            Created = new DateTime(2024, 5, 8, 13, 47, 3, 181, DateTimeKind.Utc).AddTicks(3637),
                            Name = "1 серия"
                        },
                        new
                        {
                            Id = 5,
                            BrandId = 2,
                            Created = new DateTime(2024, 5, 8, 13, 47, 3, 181, DateTimeKind.Utc).AddTicks(3639),
                            Name = "2 серия"
                        },
                        new
                        {
                            Id = 6,
                            BrandId = 2,
                            Created = new DateTime(2024, 5, 8, 13, 47, 3, 181, DateTimeKind.Utc).AddTicks(3642),
                            Name = "3 серия"
                        },
                        new
                        {
                            Id = 7,
                            BrandId = 3,
                            Created = new DateTime(2024, 5, 8, 13, 47, 3, 181, DateTimeKind.Utc).AddTicks(3644),
                            Name = "Amulet"
                        },
                        new
                        {
                            Id = 8,
                            BrandId = 3,
                            Created = new DateTime(2024, 5, 8, 13, 47, 3, 181, DateTimeKind.Utc).AddTicks(3645),
                            Name = "Bonus"
                        },
                        new
                        {
                            Id = 9,
                            BrandId = 3,
                            Created = new DateTime(2024, 5, 8, 13, 47, 3, 181, DateTimeKind.Utc).AddTicks(3646),
                            Name = "Fora"
                        },
                        new
                        {
                            Id = 10,
                            BrandId = 4,
                            Created = new DateTime(2024, 5, 8, 13, 47, 3, 181, DateTimeKind.Utc).AddTicks(3649),
                            Name = "Aveo"
                        },
                        new
                        {
                            Id = 11,
                            BrandId = 4,
                            Created = new DateTime(2024, 5, 8, 13, 47, 3, 181, DateTimeKind.Utc).AddTicks(3650),
                            Name = "Captiva"
                        },
                        new
                        {
                            Id = 12,
                            BrandId = 4,
                            Created = new DateTime(2024, 5, 8, 13, 47, 3, 181, DateTimeKind.Utc).AddTicks(3651),
                            Name = "Cobalt"
                        });
                });

            modelBuilder.Entity("Domain.Entities.RequestEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Arrived")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("BrandId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("ModelId")
                        .HasColumnType("integer");

                    b.Property<int>("ServiceTypeId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<int>("Year")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("ModelId");

                    b.HasIndex("ServiceTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("Domain.Entities.RoleEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2024, 5, 8, 13, 47, 3, 182, DateTimeKind.Utc).AddTicks(4267),
                            Name = "Guest"
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2024, 5, 8, 13, 47, 3, 182, DateTimeKind.Utc).AddTicks(4289),
                            Name = "Operator"
                        },
                        new
                        {
                            Id = 3,
                            Created = new DateTime(2024, 5, 8, 13, 47, 3, 182, DateTimeKind.Utc).AddTicks(4293),
                            Name = "Admin"
                        });
                });

            modelBuilder.Entity("Domain.Entities.ServiceTypeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("Description")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("ServiceTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2024, 5, 8, 13, 47, 3, 182, DateTimeKind.Utc).AddTicks(7549),
                            Description = "Комплекс специальных мероприятий по определению точного технического состояния авто и выявления неполадок. Услуга позволяет дать общую оценку работе всех ключевых узлов авто, безошибочно определить неисправности, причину их появления и оптимальный способ устранения.",
                            Name = "Диагностика автомобиля",
                            Price = 500m
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2024, 5, 8, 13, 47, 3, 182, DateTimeKind.Utc).AddTicks(7563),
                            Description = "Если вы столкнулись с необходимостью провести балансировку колес после их замены, то мастера автосервисного предприятия с легкостью выполнят такую работу. Однако владелец автомобиля должен знать, что только полный комплекс работ по шиномонтажу гарантирует максимальную безопасность эксплуатации транспортного средства любой марки и модельного ряда.",
                            Name = "Шиномонтажные работы",
                            Price = 2000m
                        },
                        new
                        {
                            Id = 3,
                            Created = new DateTime(2024, 5, 8, 13, 47, 3, 182, DateTimeKind.Utc).AddTicks(7565),
                            Description = "Электротехнические работы состоят в проверке и ремонте приборов электрооборудования автомобилей. Приборы и агрегаты электрооборудования, неисправности которых не могли быть устранены на постах технического обслуживания, очищают от пыли и грязи, осматривают и испытывают на специальных установках.",
                            Name = "Электротехнические работы",
                            Price = 3300m
                        },
                        new
                        {
                            Id = 4,
                            Created = new DateTime(2024, 5, 8, 13, 47, 3, 182, DateTimeKind.Utc).AddTicks(7567),
                            Description = "Для выполнения сварочных работ используется разнообразное оборудование – от простых и компактных бытовых трансформаторов тока до мощных промышленных автоматизированных линий.",
                            Name = "Сварочные работы",
                            Price = 2000m
                        },
                        new
                        {
                            Id = 5,
                            Created = new DateTime(2024, 5, 8, 13, 47, 3, 182, DateTimeKind.Utc).AddTicks(7569),
                            Description = "Техническое обслуживание механизмов рулевого управления носит плановый характер. Объем выполняемых работ определяется видом технического обслуживания. В процессе ежедневного технического обслуживания необходимо проверять свободный ход рулевого колеса, состояние креплений сошки, а также ограничителей максимальных углов поворота управляемых колес. Кроме этого необходимо ежедневно проверять зазор в шарнирах гидроусилителя и в рулевых тягах, а также работу гидроусилителя и рулевого управления. Эти проверки выполняют при работающем двигателе.",
                            Name = "Ремонт рулевого управления",
                            Price = 4300m
                        },
                        new
                        {
                            Id = 6,
                            Created = new DateTime(2024, 5, 8, 13, 47, 3, 182, DateTimeKind.Utc).AddTicks(7578),
                            Description = "Несвоевременная замена масла в автомобиле провоцирует снижение эксплуатационных и функциональных характеристик соответствующих узлов и систем. Подобные ситуации приводят к быстрому износу и поломкам тех либо иных деталей. Именно поэтому специалисты нашего сервиса рекомендуют менять моторное масло в сроки, установленные специфическими стандартами и нормативами.",
                            Name = "Замена масла в соответствующих узлах авто",
                            Price = 2300m
                        },
                        new
                        {
                            Id = 7,
                            Created = new DateTime(2024, 5, 8, 13, 47, 3, 182, DateTimeKind.Utc).AddTicks(7580),
                            Description = "Ремонтные работы по ДВС различаются масштабом и сложностью выполняемых операций, используемыми методами диагностики автомобиля, технологиями замены и восстановления функциональных деталей.",
                            Name = "Осуществление ремонта двигателя",
                            Price = 8000m
                        },
                        new
                        {
                            Id = 8,
                            Created = new DateTime(2024, 5, 8, 13, 47, 3, 182, DateTimeKind.Utc).AddTicks(7582),
                            Description = "Независимо от вида покраски, полная или частичная, требуется точно соблюдать всю технологию процедуры. Необходимо также учесть тот факт, что без применения профессионального оборудования и опыта хорошего результата ждать не стоит.",
                            Name = "Покрасочные работы",
                            Price = 3700m
                        });
                });

            modelBuilder.Entity("Domain.Entities.SessionEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Expires")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("Domain.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsBanned")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("45d697a5-5aef-4a41-8ec9-185bf66ccccc"),
                            Created = new DateTime(2024, 5, 8, 13, 47, 3, 183, DateTimeKind.Utc).AddTicks(5135),
                            Email = "danilguest@gmail.com",
                            FirstName = "Даниил",
                            IsBanned = false,
                            LastName = "Устюшкин",
                            Password = "$2a$11$QtV3XrkUqTK3UqaPOt4a1O.NFf8rChO6WevrOoqH3bEkgon03O5pS",
                            PhoneNumber = "+792281337228",
                            RoleId = 1
                        },
                        new
                        {
                            Id = new Guid("72d99ff0-ec79-4789-81de-203ad206bc0f"),
                            Created = new DateTime(2024, 5, 8, 13, 47, 3, 333, DateTimeKind.Utc).AddTicks(4444),
                            Email = "daniloperator@gmail.com",
                            FirstName = "Даниил",
                            IsBanned = false,
                            LastName = "Устюшкин",
                            Password = "$2a$11$4G/BpgDtiiSIXVmHzAjMZ.ye0HK1hvitsHRGoo2Sqsz4EsrXwl9RS",
                            PhoneNumber = "+792281337227",
                            RoleId = 2
                        },
                        new
                        {
                            Id = new Guid("92ec8a96-41ee-49b2-804d-1f2955a69cde"),
                            Created = new DateTime(2024, 5, 8, 13, 47, 3, 493, DateTimeKind.Utc).AddTicks(4851),
                            Email = "daniladmin@gmail.com",
                            FirstName = "Даниил",
                            IsBanned = false,
                            LastName = "Устюшкин",
                            Password = "$2a$11$K39CIvC4RBmKkewtEbzu6O1Q3jNMgqLywxoZDR5O42p2PPoAIwVXm",
                            PhoneNumber = "+792281337229",
                            RoleId = 3
                        });
                });

            modelBuilder.Entity("Domain.Entities.ModelEntity", b =>
                {
                    b.HasOne("Domain.Entities.BrandEntity", "Brand")
                        .WithMany("Models")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("Domain.Entities.RequestEntity", b =>
                {
                    b.HasOne("Domain.Entities.BrandEntity", "Brand")
                        .WithMany("Requests")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.ModelEntity", "Model")
                        .WithMany("Requests")
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.ServiceTypeEntity", "ServiceType")
                        .WithMany("Requests")
                        .HasForeignKey("ServiceTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.UserEntity", "User")
                        .WithMany("Requests")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Model");

                    b.Navigation("ServiceType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.SessionEntity", b =>
                {
                    b.HasOne("Domain.Entities.UserEntity", "User")
                        .WithMany("Sessions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.UserEntity", b =>
                {
                    b.HasOne("Domain.Entities.RoleEntity", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Domain.Entities.BrandEntity", b =>
                {
                    b.Navigation("Models");

                    b.Navigation("Requests");
                });

            modelBuilder.Entity("Domain.Entities.ModelEntity", b =>
                {
                    b.Navigation("Requests");
                });

            modelBuilder.Entity("Domain.Entities.RoleEntity", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Domain.Entities.ServiceTypeEntity", b =>
                {
                    b.Navigation("Requests");
                });

            modelBuilder.Entity("Domain.Entities.UserEntity", b =>
                {
                    b.Navigation("Requests");

                    b.Navigation("Sessions");
                });
#pragma warning restore 612, 618
        }
    }
}
