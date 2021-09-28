using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ApplicationDbContextSeed
    {
        public static async Task SeedAsync(ApplicationDbContext dbContext)
        {
            if (await dbContext.Categories.AnyAsync() || await dbContext.Pruducts.AnyAsync() || await dbContext.Brands.AnyAsync()) return;

            var cat1 = new Category() { CategoryName = "Mens" };
            var cat2 = new Category() { CategoryName = "Ladies" };
            var cat3 = new Category() { CategoryName = "Unisex" };
            dbContext.AddRange(cat1, cat2,cat3);

            var brand1 = new Brand() { BrandName = "Citizen" };
            var brand2 = new Brand() { BrandName = "Casio" };
            var brand3 = new Brand() { BrandName = "Calvin Clein" };
            var brand4 = new Brand() { BrandName = "Fossil" };
            dbContext.AddRange(brand1, brand2, brand3, brand4);

            var p1 = new Product() { ProductName = "Mens Citizen Navihawk AT Alarm Chronograph Radio Controlled Eco-Drive Watch JY8037-50E", Description = "The Citizen Navihawk AT JY8037-50E is a super Gents watch. The case is made from Stainless Steel and has a black dial.", Price = 527.00m, PictureUri = "1.jpg", Category = cat1, Brand = brand1 };
            var p2 = new Product() { ProductName = "Mens Citizen Endeavour Watch AW1428-53X", Description = "One of our bestsellers, and with good reason, the Mens Citizen Endeavour Watch is a stylish performer ideally suited to sports lovers and fitness fanatics.", Price = 299.00m, PictureUri = "2.jfif", Category = cat1, Brand = brand1 };
            var p3 = new Product() { ProductName = "Mens Casio G-Steel Luxury Military Bluetooth Smart G-Shock Watch GST-B100GC-1AER", Description = "Casio Bluetooth Smart G-Shock GST-B100GC-1AER is an amazing and special Gents watch from G-Steel Luxury Military collection. ", Price = 349.00m, PictureUri = "3.jpg", Category = cat1, Brand = brand2 };
            var p4 = new Product() { ProductName = "Ladies Casio Collection Vintage Watch LA690WEGA-9EF", Description = "Casio Vintage LA690WEGA-9EF is an incredible interesting Ladies watch from Collection collection. Case material is Stainless Steel and the Gold dial gives the watch that unique look.", Price = 49.90m, PictureUri = "4.jpg", Category = cat2, Brand = brand2 };
            var p5 = new Product() { ProductName = "CALVIN KLEIN Watch K4E2N61Y", Description = "CALVIN KLEIN K4E2N61Y is an incredible trendy Ladies watch. Material of the case is Plated Stainless Steel, which stands for a high quality of the item while the dial colour is Silver.", Price = 299.00m, PictureUri = "5.jpg", Category = cat2, Brand = brand3 };
            var p6 = new Product() { ProductName = "Unisex Calvin Klein Accent Watch K2Y211C3", Description = "An accent watch if you ever saw one, this mid-size Calvin Klein watch in an elegant design in stainless steel and leather, set around a sleek dial with silver highlights.", Price = 269.00m, PictureUri = "6.jpg", Category = cat3, Brand = brand3 };
            var p7 = new Product() { ProductName = "Addict Watch", Description = "Calvin Klein Addict K7W2S616 is an incredible trendy Ladies watch. Case is made out of Stainless Steel while the dial colour is Silver.", Price = 202.00m, PictureUri = "7.jpg", Category = cat2, Brand = brand3 };
            var p8 = new Product() { ProductName = "Wavy Watch", Description = "Calvin Klein Wavy K9U23546 is an amazing and eye-catching Ladies watch. Case is made out of Stainless Steel while the dial colour is Silver.", Price = 211.00m, PictureUri = "8.jpg", Category = cat2, Brand = brand3 };
            var p9 = new Product() { ProductName = "Fossil Watch FS5786SET", Description = "Fossil Neutra Chrono FS5786SET is an amazing and handsome Gents watch. Case material is Stainless Steel and the Black dial gives the watch that unique look.", Price = 169.00m, PictureUri = "9.jpg", Category = cat1, Brand = brand4 };
            var p10 = new Product() { ProductName = "Fossil Watch ME3166", Description = "Part of the Dress Collection, the Ladies Fossil Tailor Watch shines with its modern looks and sharp style.", Price = 179.00m, PictureUri = "10.jfif", Category = cat2, Brand = brand4 };
            var p11 = new Product() { ProductName = "Fossil Watch ES4824", Description = "Fossil Copeland ES4824 is a beautiful and attractive Ladies watch from Holiday 2020 collection.", Price = 75.00m, PictureUri = "11.jpg", Category = cat2, Brand = brand4 };
            var p12 = new Product() { ProductName = "Fossil Watch FS5792", Description = "Fossil Neutra Chrono FS5792 is an amazing and attractive Gents watch. Case is made out of Stainless Steel and the Blue dial gives the watch that unique look", Price = 139.00m, PictureUri = "12.jpg", Category = cat1, Brand = brand4 };
            dbContext.AddRange(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12);

            await dbContext.SaveChangesAsync();
        }
    }
}
