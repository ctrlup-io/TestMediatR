using Microsoft.EntityFrameworkCore.Migrations;
using System.Reflection;

#nullable disable

namespace TestMediatR.Infrastructure.Migrations
{
    public partial class procstock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var assembly = Assembly.GetExecutingAssembly();
            string path = Path.Combine(Path.GetDirectoryName(assembly.Location), "Scripts");
            var resourceNames = Directory.GetFiles(path).
                        Where(str => str.EndsWith(".sql"));
            foreach (string resourceName in resourceNames)
            {
                using (StreamReader reader = new StreamReader(resourceName))
                {
                    string sql = reader.ReadToEnd();
                    migrationBuilder.Sql(sql);
                }
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
