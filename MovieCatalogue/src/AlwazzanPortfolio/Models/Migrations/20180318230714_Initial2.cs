using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlwazzanPortfolio.Models.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsNew",
                table: "Movies",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsTopViewed",
                table: "Movies",
                nullable: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsTopRating",
                table: "Movies",
                nullable: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsShowInBanner",
                table: "Movies",
                nullable: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsReviewedMovie",
                table: "Movies",
                nullable: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsRecentlyAdded",
                table: "Movies",
                nullable: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsFeatured",
                table: "Movies",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsNew",
                table: "Movies");

            migrationBuilder.AlterColumn<bool>(
                name: "IsTopViewed",
                table: "Movies",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsTopRating",
                table: "Movies",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsShowInBanner",
                table: "Movies",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsReviewedMovie",
                table: "Movies",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsRecentlyAdded",
                table: "Movies",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsFeatured",
                table: "Movies",
                nullable: true);
        }
    }
}
