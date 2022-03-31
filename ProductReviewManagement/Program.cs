using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReviewManagement
{
    internal class Program
    {
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
                new Products() { productId = 8, userId = 3, rating = 6, review = "good", isLike = true },
                new Products() { productId = 6, userId = 2, rating = 6, review = "good", isLike = true },
                new Products() { productId = 7, userId = 1, rating = 4, review = "bad", isLike = false }
            };
        }
    }
}
