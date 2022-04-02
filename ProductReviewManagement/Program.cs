using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReviewManagement
{
    internal class Program
    {
        
        public static void Display(List<Products> result)
        {
            foreach (var product in result)
            {
                Console.WriteLine("ProductID:" + product.productId + " UserID:" + product.userId + " Rating:" + product.rating);
            }
        }
        
        public static void DisplayTable(DataTable product)
        {
            foreach (DataRow row in product.Rows)
            {
                Console.WriteLine("ProductID: " + row["ProductID"] + " Rating: " + row["Rating"]);
            }
        }

        //return records whose isLike value is true
        public static void IsLike(List<Products> list)
        {
            var recorddata = from product in list where (product.isLike == true) select product;
            foreach (Products product in recorddata)
            {
                Console.WriteLine(product.productId + " " + product.userId + " " + product.rating + " " + product.review + " " + product.isLike);
            }
        }

        //find average rating of each product
        public static void AverageOfRecord(List<Products> list)
        {
            var productIds = (from product in list select product.productId).Distinct();
            Console.WriteLine("productId  AverageRating");
            foreach (var pID in productIds)
            {
                var recorddata = (from product in list where product.productId == pID select product).Average(x => x.rating);
                Console.WriteLine(pID + "                 " + recorddata);
            }
        }
        static void Main(string[] args)
        {
            List<Products> products = new List<Products>()
            {
                new Products() { productId = 1, userId = 1, rating = 8, review = "good", isLike = true },
                new Products() { productId = 2, userId = 2, rating = 7, review = "good", isLike = true },
                new Products() { productId = 3, userId = 3, rating = 4, review = "bad", isLike = false },
                new Products() { productId = 5, userId = 4, rating = 8, review = "good", isLike = true },
                new Products() { productId = 5, userId = 5, rating = 7, review = "good", isLike = true },
                new Products() { productId = 8, userId = 5, rating = 7, review = "good", isLike = true },
                new Products() { productId = 8, userId = 4, rating = 5, review = "bad", isLike = false },
                new Products() { productId = 4, userId = 3, rating = 10, review = "good", isLike = true },
                new Products() { productId = 6, userId = 2, rating = 9, review = "good", isLike = true },
                new Products() { productId = 7, userId = 1, rating = 4, review = "bad", isLike = false }
            };
            //return record of top three ratings 
            var result1 = products.OrderByDescending(x => x.rating).Take(3);
            foreach (var product in result1)
            {
                Console.WriteLine(product.rating);
            }

            //return all record from the list who’s rating are greater then 3 and ID=1 or 4 or 9
            var IDArray = new int[] { 1, 4, 9 };
            var result2 = products.Where(x => x.rating > 3 && IDArray.Contains(x.productId)).ToList();
            Display(result2);
            
            //Retrieve count of review present for each productID
            var result3 = products.GroupBy(x => x.productId).Select(x => new { productId = x.Key, Count = x.Count() });
            foreach (var item in result3)
            {
                Console.WriteLine("ProductID: " + item.productId + " Count:" + item.Count);
            }

            //return only ID and review
            var result4 = (from product in products select product).Select(x => new { productID = x.productId, Review = x.review });
            foreach (var item in result4)
            {
                Console.WriteLine("ProductID:" + item.productID + " Review:" + item.Review);
            }

            //skip top 5 records
            var result5 = products.Skip(5);
            Display(result5.ToList());
            

            //DataTable created
            DataTable datatable = new DataTable();
            
            datatable.Columns.Add("UserID", typeof(int));
            datatable.Columns.Add("Rating", typeof(int));
            datatable.Columns.Add("ProductID", typeof(int));
            datatable.Columns.Add("Review");
            datatable.Columns.Add("IsLike", typeof(bool));
            datatable.Rows.Add(1, 19, 1, "bad", "false");
            datatable.Rows.Add(2, 75, 5, "good", "true");
            datatable.Rows.Add(3, 7, 2, "good", "true");
            datatable.Rows.Add(4, 98, 4, "good", "true");
            datatable.Rows.Add(5, 35, 1, "bad", "false");
            datatable.Rows.Add(6, 10, 5, "good", "true");
            datatable.Rows.Add(7, 11, 2, "good", "true");
            datatable.Rows.Add(8, 52, 4, "good", "true");
            datatable.Rows.Add(9, 20, 1, "bad", "false");
            datatable.Rows.Add(10, 77, 5, "good", "true");
            datatable.Rows.Add(11, 85, 2, "good", "true");
            datatable.Rows.Add(12, 51, 4, "good", "true");

            DisplayTable(datatable);

            IsLike(products);

            AverageOfRecord(products);

            Console.ReadLine();
        }
    }
}
