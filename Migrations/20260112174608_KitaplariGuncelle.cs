using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KutuphaneAPI.Migrations
{
    /// <inheritdoc />
    public partial class KitaplariGuncelle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Ömer Seyfettin");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Sabahattin Ali");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Yaşar Kemal");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Orhan Pamuk");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Reşat Nuri Güntekin");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Halide Edib Adıvar");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Zülfü Livaneli");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Fyodor Dostoyevski");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "Franz Kafka");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "Albert Camus");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 11,
                column: "Name",
                value: "George Orwell");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 12,
                column: "Name",
                value: "Stefan Zweig");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 13,
                column: "Name",
                value: "Victor Hugo");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 14,
                column: "Name",
                value: "Lev Tolstoy");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 15,
                column: "Name",
                value: "Gabriel Garcia Marquez");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "978001", "Kaşağı" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "978002", "Falaka" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "978003", "Kürk Mantolu Madonna" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "978004", "Kuyucaklı Yusuf" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "978005", "İnce Memed" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "978006", "Yılanı Öldürseler" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "978007", "Kara Kitap" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "978008", "Masumiyet Müzesi" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "978009", "Çalıkuşu" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "978010", "Yaprak Dökümü" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "978011", "Sinekli Bakkal" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "978012", "Ateşten Gömlek" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "978013", "Serenad" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "978014", "Kardeşimin Hikayesi" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "978015", "Suç ve Ceza" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "978016", "Yeraltından Notlar" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "978017", "Dönüşüm" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "978018", "Dava" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "978019", "Yabancı" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "978020", "Veba" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "978021", "1984" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "978022", "Hayvan Çiftliği" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "978023", "Satranç" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "978024", "Bilinmeyen Bir Kadının Mektubu" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "978025", "Sefiller" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "978026", "Notre Dame'ın Kamburu" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "978027", "Savaş ve Barış" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "978028", "Anna Karenina" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "978029", "Yüzyıllık Yalnızlık" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "978030", "Kırmızı Pazartesi" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Yazar 1");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Yazar 2");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Yazar 3");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Yazar 4");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Yazar 5");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Yazar 6");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Yazar 7");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Yazar 8");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "Yazar 9");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "Yazar 10");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 11,
                column: "Name",
                value: "Yazar 11");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 12,
                column: "Name",
                value: "Yazar 12");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 13,
                column: "Name",
                value: "Yazar 13");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 14,
                column: "Name",
                value: "Yazar 14");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 15,
                column: "Name",
                value: "Yazar 15");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "ISBN-1A", "Kitap 1A" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "ISBN-1B", "Kitap 1B" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "ISBN-2A", "Kitap 2A" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "ISBN-2B", "Kitap 2B" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "ISBN-3A", "Kitap 3A" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "ISBN-3B", "Kitap 3B" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "ISBN-4A", "Kitap 4A" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "ISBN-4B", "Kitap 4B" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "ISBN-5A", "Kitap 5A" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "ISBN-5B", "Kitap 5B" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "ISBN-6A", "Kitap 6A" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "ISBN-6B", "Kitap 6B" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "ISBN-7A", "Kitap 7A" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "ISBN-7B", "Kitap 7B" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "ISBN-8A", "Kitap 8A" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "ISBN-8B", "Kitap 8B" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "ISBN-9A", "Kitap 9A" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "ISBN-9B", "Kitap 9B" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "ISBN-10A", "Kitap 10A" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "ISBN-10B", "Kitap 10B" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "ISBN-11A", "Kitap 11A" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "ISBN-11B", "Kitap 11B" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "ISBN-12A", "Kitap 12A" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "ISBN-12B", "Kitap 12B" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "ISBN-13A", "Kitap 13A" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "ISBN-13B", "Kitap 13B" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "ISBN-14A", "Kitap 14A" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "ISBN-14B", "Kitap 14B" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "ISBN-15A", "Kitap 15A" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "ISBN", "Title" },
                values: new object[] { "ISBN-15B", "Kitap 15B" });
        }
    }
}
