using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.Migrations
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
                    { 1, "Категория 2", "Кадров создание принимаемых важную в широким практика.", "https://placehold.co/200", "Интеллектуальный Стальной Кепка", 624.66m, "Популярный" },
                    { 2, "Категория 1", "Влечёт предпосылки последовательного повседневной собой.", "https://placehold.co/200", "Великолепный Меховой Шарф", 587.97m, "Популярный" },
                    { 3, "Категория 3", "Реализация вызывает модернизации нашей участниками.", "https://placehold.co/200", "Свободный Резиновый Компьютер", 553.27m, "Популярный" },
                    { 4, "Категория 3", "Эксперимент принципов процесс особенности проект поставленных способствует активизации создаёт.", "https://placehold.co/200", "Свободный Бетонный Берет", 910.44m, "Новинка" },
                    { 5, "Категория 2", "Участниками реализация специалистов.", "https://placehold.co/200", "Великолепный Резиновый Берет", 164.19m, "Рекомендуемый" },
                    { 6, "Категория 3", "Инновационный мира развития кругу же изменений.", "https://placehold.co/200", "Интеллектуальный Пластиковый Ножницы", 479.26m, "Популярный" },
                    { 7, "Категория 3", "Развития профессионального рамки рост сложившаяся поэтапного профессионального организационной нас.", "https://placehold.co/200", "Большой Меховой Стол", 739.89m, "Новинка" },
                    { 8, "Категория 2", "Этих с целесообразности порядка внедрения гражданского намеченных массового.", "https://placehold.co/200", "Свободный Меховой Свитер", 815.81m, "Рекомендуемый" },
                    { 9, "Категория 3", "Практика высокотехнологичная опыт насущным обществом рамки.", "https://placehold.co/200", "Интеллектуальный Меховой Майка", 688.80m, "Новинка" },
                    { 10, "Категория 2", "Задач мира порядка прогресса общества форм широким.", "https://placehold.co/200", "Свободный Резиновый Плащ", 556.74m, "Рекомендуемый" },
                    { 11, "Категория 1", "Разработке проект плановых соответствующей создание экономической таким активности.", "https://placehold.co/200", "Великолепный Хлопковый Кулон", 759.70m, "Рекомендуемый" },
                    { 12, "Категория 1", "Сфера от реализация.", "https://placehold.co/200", "Свободный Деревянный Кепка", 911.54m, "Популярный" },
                    { 13, "Категория 2", "Кругу демократической идейные активности.", "https://placehold.co/200", "Великолепный Гранитный Куртка", 833.02m, "Популярный" },
                    { 14, "Категория 3", "Административных с путь представляет нами соображения выбранный экономической.", "https://placehold.co/200", "Практичный Деревянный Шарф", 101.16m, "Рекомендуемый" },
                    { 15, "Категория 1", "Проверки общественной деятельности инновационный создание.", "https://placehold.co/200", "Большой Резиновый Кошелек", 335.45m, "Популярный" },
                    { 16, "Категория 1", "Концепция отметить высокотехнологичная создаёт структура.", "https://placehold.co/200", "Практичный Резиновый Кулон", 694.74m, "Рекомендуемый" },
                    { 17, "Категория 2", "Соображения прогресса формировании организации в систему позволяет.", "https://placehold.co/200", "Великолепный Неодимовый Носки", 530.81m, "Популярный" },
                    { 18, "Категория 1", "Отношении за с уточнения общественной.", "https://placehold.co/200", "Потрясающий Гранитный Берет", 431.51m, "Новинка" },
                    { 19, "Категория 3", "Повседневной важную занимаемых организации кругу равным влечёт существующий способствует.", "https://placehold.co/200", "Большой Бетонный Кепка", 219.56m, "Рекомендуемый" },
                    { 20, "Категория 1", "Задача модернизации способствует организационной актуальность.", "https://placehold.co/200", "Грубый Резиновый Ножницы", 613.13m, "Рекомендуемый" }
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
