using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BrandId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Models_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    IsBanned = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    BrandId = table.Column<int>(type: "integer", nullable: false),
                    ModelId = table.Column<int>(type: "integer", nullable: false),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    ServiceTypeId = table.Column<int>(type: "integer", nullable: false),
                    StatusId = table.Column<int>(type: "integer", nullable: false),
                    Arrived = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requests_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requests_ServiceTypes_ServiceTypeId",
                        column: x => x.ServiceTypeId,
                        principalTable: "ServiceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requests_StatusEntity_StatusId",
                        column: x => x.StatusId,
                        principalTable: "StatusEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Token = table.Column<string>(type: "text", nullable: false),
                    Expires = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Created", "Name", "Updated" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 8, 21, 42, 47, 576, DateTimeKind.Utc).AddTicks(5970), "Audi", null },
                    { 2, new DateTime(2024, 5, 8, 21, 42, 47, 576, DateTimeKind.Utc).AddTicks(5982), "BMW", null },
                    { 3, new DateTime(2024, 5, 8, 21, 42, 47, 576, DateTimeKind.Utc).AddTicks(5984), "Chery", null },
                    { 4, new DateTime(2024, 5, 8, 21, 42, 47, 576, DateTimeKind.Utc).AddTicks(5985), "Chevrolet", null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Created", "Name", "Updated" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 8, 21, 42, 47, 578, DateTimeKind.Utc).AddTicks(3090), "Guest", null },
                    { 2, new DateTime(2024, 5, 8, 21, 42, 47, 578, DateTimeKind.Utc).AddTicks(3114), "Operator", null },
                    { 3, new DateTime(2024, 5, 8, 21, 42, 47, 578, DateTimeKind.Utc).AddTicks(3117), "Admin", null }
                });

            migrationBuilder.InsertData(
                table: "ServiceTypes",
                columns: new[] { "Id", "Created", "Description", "Name", "Price", "Updated" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 8, 21, 42, 47, 578, DateTimeKind.Utc).AddTicks(6104), "Комплекс специальных мероприятий по определению точного технического состояния авто и выявления неполадок. Услуга позволяет дать общую оценку работе всех ключевых узлов авто, безошибочно определить неисправности, причину их появления и оптимальный способ устранения.", "Диагностика автомобиля", 500m, null },
                    { 2, new DateTime(2024, 5, 8, 21, 42, 47, 578, DateTimeKind.Utc).AddTicks(6121), "Если вы столкнулись с необходимостью провести балансировку колес после их замены, то мастера автосервисного предприятия с легкостью выполнят такую работу. Однако владелец автомобиля должен знать, что только полный комплекс работ по шиномонтажу гарантирует максимальную безопасность эксплуатации транспортного средства любой марки и модельного ряда.", "Шиномонтажные работы", 2000m, null },
                    { 3, new DateTime(2024, 5, 8, 21, 42, 47, 578, DateTimeKind.Utc).AddTicks(6123), "Электротехнические работы состоят в проверке и ремонте приборов электрооборудования автомобилей. Приборы и агрегаты электрооборудования, неисправности которых не могли быть устранены на постах технического обслуживания, очищают от пыли и грязи, осматривают и испытывают на специальных установках.", "Электротехнические работы", 3300m, null },
                    { 4, new DateTime(2024, 5, 8, 21, 42, 47, 578, DateTimeKind.Utc).AddTicks(6125), "Для выполнения сварочных работ используется разнообразное оборудование – от простых и компактных бытовых трансформаторов тока до мощных промышленных автоматизированных линий.", "Сварочные работы", 2000m, null },
                    { 5, new DateTime(2024, 5, 8, 21, 42, 47, 578, DateTimeKind.Utc).AddTicks(6126), "Техническое обслуживание механизмов рулевого управления носит плановый характер. Объем выполняемых работ определяется видом технического обслуживания. В процессе ежедневного технического обслуживания необходимо проверять свободный ход рулевого колеса, состояние креплений сошки, а также ограничителей максимальных углов поворота управляемых колес. Кроме этого необходимо ежедневно проверять зазор в шарнирах гидроусилителя и в рулевых тягах, а также работу гидроусилителя и рулевого управления. Эти проверки выполняют при работающем двигателе.", "Ремонт рулевого управления", 4300m, null },
                    { 6, new DateTime(2024, 5, 8, 21, 42, 47, 578, DateTimeKind.Utc).AddTicks(6137), "Несвоевременная замена масла в автомобиле провоцирует снижение эксплуатационных и функциональных характеристик соответствующих узлов и систем. Подобные ситуации приводят к быстрому износу и поломкам тех либо иных деталей. Именно поэтому специалисты нашего сервиса рекомендуют менять моторное масло в сроки, установленные специфическими стандартами и нормативами.", "Замена масла в соответствующих узлах авто", 2300m, null },
                    { 7, new DateTime(2024, 5, 8, 21, 42, 47, 578, DateTimeKind.Utc).AddTicks(6139), "Ремонтные работы по ДВС различаются масштабом и сложностью выполняемых операций, используемыми методами диагностики автомобиля, технологиями замены и восстановления функциональных деталей.", "Осуществление ремонта двигателя", 8000m, null },
                    { 8, new DateTime(2024, 5, 8, 21, 42, 47, 578, DateTimeKind.Utc).AddTicks(6140), "Независимо от вида покраски, полная или частичная, требуется точно соблюдать всю технологию процедуры. Необходимо также учесть тот факт, что без применения профессионального оборудования и опыта хорошего результата ждать не стоит.", "Покрасочные работы", 3700m, null }
                });

            migrationBuilder.InsertData(
                table: "StatusEntity",
                columns: new[] { "Id", "Created", "Name", "Updated" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 8, 21, 42, 47, 579, DateTimeKind.Utc).AddTicks(2249), "В ожидание", null },
                    { 2, new DateTime(2024, 5, 8, 21, 42, 47, 579, DateTimeKind.Utc).AddTicks(2260), "Подтверждена", null },
                    { 3, new DateTime(2024, 5, 8, 21, 42, 47, 579, DateTimeKind.Utc).AddTicks(2262), "Закончена", null }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "BrandId", "Created", "Name", "Updated" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 5, 8, 21, 42, 47, 577, DateTimeKind.Utc).AddTicks(1033), "100", null },
                    { 2, 1, new DateTime(2024, 5, 8, 21, 42, 47, 577, DateTimeKind.Utc).AddTicks(1048), "80", null },
                    { 3, 1, new DateTime(2024, 5, 8, 21, 42, 47, 577, DateTimeKind.Utc).AddTicks(1050), "A3", null },
                    { 4, 2, new DateTime(2024, 5, 8, 21, 42, 47, 577, DateTimeKind.Utc).AddTicks(1052), "1 серия", null },
                    { 5, 2, new DateTime(2024, 5, 8, 21, 42, 47, 577, DateTimeKind.Utc).AddTicks(1053), "2 серия", null },
                    { 6, 2, new DateTime(2024, 5, 8, 21, 42, 47, 577, DateTimeKind.Utc).AddTicks(1056), "3 серия", null },
                    { 7, 3, new DateTime(2024, 5, 8, 21, 42, 47, 577, DateTimeKind.Utc).AddTicks(1057), "Amulet", null },
                    { 8, 3, new DateTime(2024, 5, 8, 21, 42, 47, 577, DateTimeKind.Utc).AddTicks(1058), "Bonus", null },
                    { 9, 3, new DateTime(2024, 5, 8, 21, 42, 47, 577, DateTimeKind.Utc).AddTicks(1060), "Fora", null },
                    { 10, 4, new DateTime(2024, 5, 8, 21, 42, 47, 577, DateTimeKind.Utc).AddTicks(1062), "Aveo", null },
                    { 11, 4, new DateTime(2024, 5, 8, 21, 42, 47, 577, DateTimeKind.Utc).AddTicks(1063), "Captiva", null },
                    { 12, 4, new DateTime(2024, 5, 8, 21, 42, 47, 577, DateTimeKind.Utc).AddTicks(1064), "Cobalt", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Created", "Email", "FirstName", "IsBanned", "LastName", "Password", "PhoneNumber", "RoleId", "Updated" },
                values: new object[,]
                {
                    { new Guid("7b932ddb-e921-4b4b-a501-7a1b18d1f72b"), new DateTime(2024, 5, 8, 21, 42, 47, 736, DateTimeKind.Utc).AddTicks(9377), "daniloperator@gmail.com", "Даниил", false, "Устюшкин", "$2a$11$0JNO6d46y85XipoanlDvUunB4XT/2uGCgM/mxU09W8qjDE2tem5C2", "+792281337227", 2, null },
                    { new Guid("a984eeab-d265-4da1-9ef5-74f82d3f0a4a"), new DateTime(2024, 5, 8, 21, 42, 47, 887, DateTimeKind.Utc).AddTicks(5851), "daniladmin@gmail.com", "Даниил", false, "Устюшкин", "$2a$11$ZPn5TLHn.Qq2iF/lO5Fg1ujtzfgpqnWm0RGdWezlA/N8AOP5BTF.q", "+792281337229", 3, null },
                    { new Guid("ddb0bedb-d93e-4885-9aa6-038dde1f38d3"), new DateTime(2024, 5, 8, 21, 42, 47, 579, DateTimeKind.Utc).AddTicks(6128), "danilguest@gmail.com", "Даниил", false, "Устюшкин", "$2a$11$cq9le5Vg9hMVcNysaGELHOar0C24vIyqfW0XP4mohjmHnwAcxgi/2", "+792281337228", 1, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Brands_Name",
                table: "Brands",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Models_BrandId",
                table: "Models",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Models_Name",
                table: "Models",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Requests_BrandId",
                table: "Requests",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ModelId",
                table: "Requests",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ServiceTypeId",
                table: "Requests",
                column: "ServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_StatusId",
                table: "Requests",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_UserId",
                table: "Requests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Name",
                table: "Roles",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTypes_Description",
                table: "ServiceTypes",
                column: "Description",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTypes_Name",
                table: "ServiceTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_UserId",
                table: "Sessions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StatusEntity_Name",
                table: "StatusEntity",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_PhoneNumber",
                table: "Users",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "ServiceTypes");

            migrationBuilder.DropTable(
                name: "StatusEntity");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
