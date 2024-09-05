using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeageBillete_api.Migrations
{
    public partial class initia2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Event_leages",
                columns: table => new
                {
                    Event_leageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Location = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event_leages", x => x.Event_leageId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ticket_purchases",
                columns: table => new
                {
                    Ticket_purchaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Total_price = table.Column<float>(type: "float", nullable: false),
                    Firstname_facture = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Lastname_facture = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address_facture = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Date_purchase = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Code_reserva = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket_purchases", x => x.Ticket_purchaseId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Event_Days",
                columns: table => new
                {
                    Event_DayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EventDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Capacity_ticket = table.Column<int>(type: "int", nullable: false),
                    Area = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActif = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Event_leageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event_Days", x => x.Event_DayId);
                    table.ForeignKey(
                        name: "FK_Event_Days_Event_leages_Event_leageId",
                        column: x => x.Event_leageId,
                        principalTable: "Event_leages",
                        principalColumn: "Event_leageId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Price_Tickets",
                columns: table => new
                {
                    Price_ticketId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price_unit = table.Column<float>(type: "float", nullable: false),
                    Quantite_ticket_min = table.Column<int>(type: "int", nullable: false),
                    Is_all_event = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Event_leageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Price_Tickets", x => x.Price_ticketId);
                    table.ForeignKey(
                        name: "FK_Price_Tickets_Event_leages_Event_leageId",
                        column: x => x.Event_leageId,
                        principalTable: "Event_leages",
                        principalColumn: "Event_leageId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Detail_Purchases",
                columns: table => new
                {
                    Detail_purchaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Quantite_ticket = table.Column<int>(type: "int", nullable: false),
                    Code_detail = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Total_price = table.Column<float>(type: "float", nullable: false),
                    Price_ticketId = table.Column<int>(type: "int", nullable: false),
                    Event_leageId = table.Column<int>(type: "int", nullable: false),
                    Ticket_purchaseId = table.Column<int>(type: "int", nullable: false),
                    Event_DayId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detail_Purchases", x => x.Detail_purchaseId);
                    table.ForeignKey(
                        name: "FK_Detail_Purchases_Event_Days_Event_DayId",
                        column: x => x.Event_DayId,
                        principalTable: "Event_Days",
                        principalColumn: "Event_DayId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Detail_Purchases_Event_leages_Event_leageId",
                        column: x => x.Event_leageId,
                        principalTable: "Event_leages",
                        principalColumn: "Event_leageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Detail_Purchases_Price_Tickets_Price_ticketId",
                        column: x => x.Price_ticketId,
                        principalTable: "Price_Tickets",
                        principalColumn: "Price_ticketId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Detail_Purchases_Ticket_purchases_Ticket_purchaseId",
                        column: x => x.Ticket_purchaseId,
                        principalTable: "Ticket_purchases",
                        principalColumn: "Ticket_purchaseId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Detail_Purchases_Event_DayId",
                table: "Detail_Purchases",
                column: "Event_DayId");

            migrationBuilder.CreateIndex(
                name: "IX_Detail_Purchases_Event_leageId",
                table: "Detail_Purchases",
                column: "Event_leageId");

            migrationBuilder.CreateIndex(
                name: "IX_Detail_Purchases_Price_ticketId",
                table: "Detail_Purchases",
                column: "Price_ticketId");

            migrationBuilder.CreateIndex(
                name: "IX_Detail_Purchases_Ticket_purchaseId",
                table: "Detail_Purchases",
                column: "Ticket_purchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_Days_Event_leageId",
                table: "Event_Days",
                column: "Event_leageId");

            migrationBuilder.CreateIndex(
                name: "IX_Price_Tickets_Event_leageId",
                table: "Price_Tickets",
                column: "Event_leageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Detail_Purchases");

            migrationBuilder.DropTable(
                name: "Event_Days");

            migrationBuilder.DropTable(
                name: "Price_Tickets");

            migrationBuilder.DropTable(
                name: "Ticket_purchases");

            migrationBuilder.DropTable(
                name: "Event_leages");
        }
    }
}
