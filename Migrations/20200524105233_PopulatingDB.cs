using Microsoft.EntityFrameworkCore.Migrations;

namespace Vega2.Migrations
{
    public partial class PopulatingDB : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO MAKE(NAME) VALUES('MAKE 1')");
            mb.Sql("INSERT INTO MAKE(NAME) VALUES('MAKE 2')");
            mb.Sql("INSERT INTO MAKE(NAME) VALUES('MAKE 3')");

            mb.Sql("INSERT INTO MODELS(NAME,MAKEID) VALUES('MAKE 1-MODEL 1',1)");
            mb.Sql("INSERT INTO MODELS(NAME,MAKEID) VALUES('MAKE 1-MODEL 2',1)");
            mb.Sql("INSERT INTO MODELS(NAME,MAKEID) VALUES('MAKE 1-MODEL 3',1)");

            mb.Sql("INSERT INTO MODELS(NAME,MAKEID) VALUES('MAKE 2-MODEL 1',2)");
            mb.Sql("INSERT INTO MODELS(NAME,MAKEID) VALUES('MAKE 2-MODEL 2',2)");
            mb.Sql("INSERT INTO MODELS(NAME,MAKEID) VALUES('MAKE 2-MODEL 3',2)");

            mb.Sql("INSERT INTO MODELS(NAME,MAKEID) VALUES('MAKE 3-MODEL 1',3)");
            mb.Sql("INSERT INTO MODELS(NAME,MAKEID) VALUES('MAKE 3-MODEL 2',3)");
            mb.Sql("INSERT INTO MODELS(NAME,MAKEID) VALUES('MAKE 3-MODEL 3',3)");


            mb.Sql("INSERT INTO FEATURE(NAME) VALUES('FEATURE 1')");
            mb.Sql("INSERT INTO FEATURE(NAME) VALUES('FEATURE 2')");
            mb.Sql("INSERT INTO FEATURE(NAME) VALUES('FEATURE 3')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM MAKE");
            migrationBuilder.Sql("DELETE FROM FEATURE");
        }
    }
}
