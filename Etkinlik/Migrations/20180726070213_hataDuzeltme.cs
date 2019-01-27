using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Etkinlik.Migrations
{
    public partial class hataDuzeltme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSurveys_Surveys_SurveyChoiceModelId",
                table: "UserSurveys");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSurveys_SurveyChoices_SurveyChoiceModelId",
                table: "UserSurveys",
                column: "SurveyChoiceModelId",
                principalTable: "SurveyChoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSurveys_SurveyChoices_SurveyChoiceModelId",
                table: "UserSurveys");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSurveys_Surveys_SurveyChoiceModelId",
                table: "UserSurveys",
                column: "SurveyChoiceModelId",
                principalTable: "Surveys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
