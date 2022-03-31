using System;
using System.Collections.Generic;
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
            Console.ReadLine();
        }
    }
}
