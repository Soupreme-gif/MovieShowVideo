﻿using System;
using System.IO;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieShowVideo.Migrations
{
    public partial class InsertRatings8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sqlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files", "SQL", @"6-8-InsertRatings.sql");
            migrationBuilder.Sql(File.ReadAllText(sqlFile));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from usermovies where id >= 80000 and id < 90000");
        }
    }
}