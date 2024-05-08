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
                    { 1, new DateTime(2024, 5, 8, 13, 47, 3, 180, DateTimeKind.Utc).AddTicks(8614), "Audi", null },
                    { 2, new DateTime(2024, 5, 8, 13, 47, 3, 180, DateTimeKind.Utc).AddTicks(8666), "BMW", null },
                    { 3, new DateTime(2024, 5, 8, 13, 47, 3, 180, DateTimeKind.Utc).AddTicks(8668), "Chery", null },
                    { 4, new DateTime(2024, 5, 8, 13, 47, 3, 180, DateTimeKind.Utc).AddTicks(8670), "Chevrolet", null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Created", "Name", "Updated" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 8, 13, 47, 3, 182, DateTimeKind.Utc).AddTicks(4267), "Guest", null },
                    { 2, new DateTime(2024, 5, 8, 13, 47, 3, 182, DateTimeKind.Utc).AddTicks(4289), "Operator", null },
                    { 3, new DateTime(2024, 5, 8, 13, 47, 3, 182, DateTimeKind.Utc).AddTicks(4293), "Admin", null }
                });

            migrationBuilder.InsertData(
                table: "ServiceTypes",
                columns: new[] { "Id", "Created", "Description", "Name", "Price", "Updated" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 8, 13, 47, 3, 182, DateTimeKind.Utc).AddTicks(7549), "Комплекс специальных мероприятий по определению точного технического состояния авто и выявления неполадок. Услуга позволяет дать общую оценку работе всех ключевых узлов авто, безошибочно определить неисправности, причину их появления и оптимальный способ устранения.", "Диагностика автомобиля", 500m, null },
                    { 2, new DateTime(2024, 5, 8, 13, 47, 3, 182, DateTimeKind.Utc).AddTicks(7563), "Если вы столкнулись с необходимостью провести балансировку колес после их замены, то мастера автосервисного предприятия с легкостью выполнят такую работу. Однако владелец автомобиля должен знать, что только полный комплекс работ по шиномонтажу гарантирует максимальную безопасность эксплуатации транспортного средства любой марки и модельного ряда.", "Шиномонтажные работы", 2000m, null },
                    { 3, new DateTime(2024, 5, 8, 13, 47, 3, 182, DateTimeKind.Utc).AddTicks(7565), "Электротехнические работы состоят в проверке и ремонте приборов электрооборудования автомобилей. Приборы и агрегаты электрооборудования, неисправности которых не могли быть устранены на постах технического обслуживания, очищают от пыли и грязи, осматривают и испытывают на специальных установках.", "Электротехнические работы", 3300m, null },
                    { 4, new DateTime(2024, 5, 8, 13, 47, 3, 182, DateTimeKind.Utc).AddTicks(7567), "Для выполнения сварочных работ используется разнообразное оборудование – от простых и компактных бытовых трансформаторов тока до мощных промышленных автоматизированных линий.", "Сварочные работы", 2000m, null },
                    { 5, new DateTime(2024, 5, 8, 13, 47, 3, 182, DateTimeKind.Utc).AddTicks(7569), "Техническое обслуживание механизмов рулевого управления носит плановый характер. Объем выполняемых работ определяется видом технического обслуживания. В процессе ежедневного технического обслуживания необходимо проверять свободный ход рулевого колеса, состояние креплений сошки, а также ограничителей максимальных углов поворота управляемых колес. Кроме этого необходимо ежедневно проверять зазор в шарнирах гидроусилителя и в рулевых тягах, а также работу гидроусилителя и рулевого управления. Эти проверки выполняют при работающем двигателе.", "Ремонт рулевого управления", 4300m, null },
                    { 6, new DateTime(2024, 5, 8, 13, 47, 3, 182, DateTimeKind.Utc).AddTicks(7578), "Несвоевременная замена масла в автомобиле провоцирует снижение эксплуатационных и функциональных характеристик соответствующих узлов и систем. Подобные ситуации приводят к быстрому износу и поломкам тех либо иных деталей. Именно поэтому специалисты нашего сервиса рекомендуют менять моторное масло в сроки, установленные специфическими стандартами и нормативами.", "Замена масла в соответствующих узлах авто", 2300m, null },
                    { 7, new DateTime(2024, 5, 8, 13, 47, 3, 182, DateTimeKind.Utc).AddTicks(7580), "Ремонтные работы по ДВС различаются масштабом и сложностью выполняемых операций, используемыми методами диагностики автомобиля, технологиями замены и восстановления функциональных деталей.", "Осуществление ремонта двигателя", 8000m, null },
                    { 8, new DateTime(2024, 5, 8, 13, 47, 3, 182, DateTimeKind.Utc).AddTicks(7582), "Независимо от вида покраски, полная или частичная, требуется точно соблюдать всю технологию процедуры. Необходимо также учесть тот факт, что без применения профессионального оборудования и опыта хорошего результата ждать не стоит.", "Покрасочные работы", 3700m, null }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "BrandId", "Created", "Name", "Updated" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 5, 8, 13, 47, 3, 181, DateTimeKind.Utc).AddTicks(3625), "100", null },
                    { 2, 1, new DateTime(2024, 5, 8, 13, 47, 3, 181, DateTimeKind.Utc).AddTicks(3633), "80", null },
                    { 3, 1, new DateTime(2024, 5, 8, 13, 47, 3, 181, DateTimeKind.Utc).AddTicks(3635), "A3", null },
                    { 4, 2, new DateTime(2024, 5, 8, 13, 47, 3, 181, DateTimeKind.Utc).AddTicks(3637), "1 серия", null },
                    { 5, 2, new DateTime(2024, 5, 8, 13, 47, 3, 181, DateTimeKind.Utc).AddTicks(3639), "2 серия", null },
                    { 6, 2, new DateTime(2024, 5, 8, 13, 47, 3, 181, DateTimeKind.Utc).AddTicks(3642), "3 серия", null },
                    { 7, 3, new DateTime(2024, 5, 8, 13, 47, 3, 181, DateTimeKind.Utc).AddTicks(3644), "Amulet", null },
                    { 8, 3, new DateTime(2024, 5, 8, 13, 47, 3, 181, DateTimeKind.Utc).AddTicks(3645), "Bonus", null },
                    { 9, 3, new DateTime(2024, 5, 8, 13, 47, 3, 181, DateTimeKind.Utc).AddTicks(3646), "Fora", null },
                    { 10, 4, new DateTime(2024, 5, 8, 13, 47, 3, 181, DateTimeKind.Utc).AddTicks(3649), "Aveo", null },
                    { 11, 4, new DateTime(2024, 5, 8, 13, 47, 3, 181, DateTimeKind.Utc).AddTicks(3650), "Captiva", null },
                    { 12, 4, new DateTime(2024, 5, 8, 13, 47, 3, 181, DateTimeKind.Utc).AddTicks(3651), "Cobalt", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Created", "Email", "FirstName", "IsBanned", "LastName", "Password", "PhoneNumber", "RoleId", "Updated" },
                values: new object[,]
                {
                    { new Guid("45d697a5-5aef-4a41-8ec9-185bf66ccccc"), new DateTime(2024, 5, 8, 13, 47, 3, 183, DateTimeKind.Utc).AddTicks(5135), "danilguest@gmail.com", "Даниил", false, "Устюшкин", "$2a$11$QtV3XrkUqTK3UqaPOt4a1O.NFf8rChO6WevrOoqH3bEkgon03O5pS", "+792281337228", 1, null },
                    { new Guid("72d99ff0-ec79-4789-81de-203ad206bc0f"), new DateTime(2024, 5, 8, 13, 47, 3, 333, DateTimeKind.Utc).AddTicks(4444), "daniloperator@gmail.com", "Даниил", false, "Устюшкин", "$2a$11$4G/BpgDtiiSIXVmHzAjMZ.ye0HK1hvitsHRGoo2Sqsz4EsrXwl9RS", "+792281337227", 2, null },
                    { new Guid("92ec8a96-41ee-49b2-804d-1f2955a69cde"), new DateTime(2024, 5, 8, 13, 47, 3, 493, DateTimeKind.Utc).AddTicks(4851), "daniladmin@gmail.com", "Даниил", false, "Устюшкин", "$2a$11$K39CIvC4RBmKkewtEbzu6O1Q3jNMgqLywxoZDR5O42p2PPoAIwVXm", "+792281337229", 3, null }
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
                name: "Users");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
