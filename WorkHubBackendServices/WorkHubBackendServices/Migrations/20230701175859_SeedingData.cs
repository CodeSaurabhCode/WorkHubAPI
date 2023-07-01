using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WorkHubBackEndServices.Migrations
{
    /// <inheritdoc />
    public partial class SeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Veg" },
                    { 2, "Non-Veg" }
                });

            migrationBuilder.InsertData(
                table: "OrderTypes",
                columns: new[] { "Id", "TypeName" },
                values: new object[,]
                {
                    { 1, "Breakfast" },
                    { 2, "Lunch" }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Delicious vegetarian burger with fresh vegetables and sauce", "Veggie Burger", 120 },
                    { 2, 1, "Marinated cottage cheese cubes grilled with spices", "Paneer Tikka", 180 },
                    { 3, 1, "Thin crispy crepe made from fermented rice and lentil batter, served with chutney and sambar", "Masala Dosa", 100 },
                    { 4, 2, "Flavorful rice dish cooked with chicken, aromatic spices, and herbs", "Chicken Biryani", 200 },
                    { 5, 1, "Soft and spongy milk-based dessert soaked in sugar syrup", "Gulab Jamun", 80 },
                    { 6, 1, "Creamy spinach curry with paneer (cottage cheese)", "Palak Paneer", 160 },
                    { 7, 2, "Tender chicken pieces cooked in a rich and creamy tomato-based sauce", "Butter Chicken", 220 },
                    { 8, 1, "Crispy fried pastry filled with spiced potatoes and peas", "Samosa", 60 },
                    { 9, 2, "Grilled chicken in a creamy and flavorful tomato-based sauce", "Chicken Tikka Masala", 190 },
                    { 10, 1, "Soft and creamy cheese dumplings in sweetened milk", "Rasmalai", 90 },
                    { 11, 1, "Spicy chickpea curry served with deep-fried bread", "Chole Bhature", 140 },
                    { 12, 2, "Fish cooked in a tangy and flavorful curry", "Fish Curry", 180 },
                    { 13, 1, "Indian bread stuffed with spiced mashed potatoes, served with yogurt or pickle", "Aloo Paratha", 80 },
                    { 14, 2, "Fragrant rice dish cooked with tender mutton pieces, aromatic spices, and herbs", "Mutton Biryani", 240 },
                    { 15, 1, "Traditional Indian dessert made with grated carrots, milk, and sugar", "Gajar Halwa", 100 },
                    { 16, 1, "Small crispy puris filled with spicy tangy water and potato mixture", "Pani Puri", 70 },
                    { 17, 1, "Peas and paneer (cottage cheese) cooked in a creamy and flavorful sauce", "Matar Paneer", 160 },
                    { 18, 2, "Spicy and flavorful deep-fried chicken dish", "Chicken 65", 180 },
                    { 19, 1, "Red kidney bean curry served with steamed rice", "Rajma Chawal", 120 },
                    { 20, 1, "Creamy and rich lentil curry made with black lentils and kidney beans", "Dal Makhani", 140 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "OrderTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
