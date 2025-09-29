﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DientesLimpios.Persistencia.Migrations
{
    /// <inheritdoc />
    public partial class TablaDentistas2Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dentistas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(
                        type: "nvarchar(250)",
                        maxLength: 250,
                        nullable: false
                    ),
                    Email = table.Column<string>(
                        type: "nvarchar(254)",
                        maxLength: 254,
                        nullable: false
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dentistas", x => x.Id);
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Dentistas");
        }
    }
}
