using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace store_api.Migrations
{
    /// <inheritdoc />
    public partial class SeedProductsList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "Image", "Name", "Price", "SpecialTag" },
                values: new object[,]
                {
                    { 1, "Категория 3", "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", "https://place-hold.it/305x249", "Большой Бетонный Куртка", 982.60m, "Популярный" },
                    { 2, "Категория 3", "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "https://place-hold.it/419x458", "Потрясающий Стальной Майка", 810.70m, "Новинка" },
                    { 3, "Категория 2", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "https://place-hold.it/415x442", "Фантастический Стальной Автомобиль", 504.17m, "Рекомендуемый" },
                    { 4, "Категория 2", "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "https://place-hold.it/346x315", "Потрясающий Неодимовый Сабо", 958.41m, "Популярный" },
                    { 5, "Категория 1", "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "https://place-hold.it/304x496", "Грубый Меховой Куртка", 739.32m, "Новинка" },
                    { 6, "Категория 2", "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "https://place-hold.it/268x439", "Невероятный Резиновый Плащ", 198.80m, "Популярный" },
                    { 7, "Категория 1", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "https://place-hold.it/374x326", "Потрясающий Меховой Кулон", 347.28m, "Популярный" },
                    { 8, "Категория 2", "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "https://place-hold.it/305x298", "Грубый Хлопковый Автомобиль", 236.07m, "Новинка" },
                    { 9, "Категория 3", "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "https://place-hold.it/411x319", "Грубый Пластиковый Кулон", 821.60m, "Новинка" },
                    { 10, "Категория 3", "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "https://place-hold.it/293x405", "Интеллектуальный Кожанный Автомобиль", 793.31m, "Популярный" },
                    { 11, "Категория 3", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "https://place-hold.it/495x228", "Большой Деревянный Кулон", 187.79m, "Популярный" },
                    { 12, "Категория 2", "The Football Is Good For Training And Recreational Purposes", "https://place-hold.it/465x265", "Потрясающий Деревянный Свитер", 900.49m, "Новинка" },
                    { 13, "Категория 3", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "https://place-hold.it/485x403", "Практичный Деревянный Берет", 367.39m, "Рекомендуемый" },
                    { 14, "Категория 2", "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "https://place-hold.it/387x477", "Интеллектуальный Хлопковый Кулон", 866.50m, "Новинка" },
                    { 15, "Категория 1", "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "https://place-hold.it/336x491", "Невероятный Резиновый Стол", 190.66m, "Рекомендуемый" },
                    { 16, "Категория 2", "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "https://place-hold.it/453x483", "Великолепный Неодимовый Свитер", 392.84m, "Рекомендуемый" },
                    { 17, "Категория 1", "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "https://place-hold.it/271x464", "Свободный Кожанный Сабо", 721.26m, "Новинка" },
                    { 18, "Категория 3", "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "https://place-hold.it/265x233", "Свободный Натуральный Куртка", 577.47m, "Новинка" },
                    { 19, "Категория 2", "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "https://place-hold.it/219x464", "Фантастический Стальной Носки", 630.06m, "Популярный" },
                    { 20, "Категория 3", "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "https://place-hold.it/302x437", "Свободный Хлопковый Ботинок", 635.46m, "Рекомендуемый" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);
        }
    }
}
