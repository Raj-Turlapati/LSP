using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URHealth.Service;
using URHealth.Model;
using URHealth.Repository;

namespace LSPClient
{
    class Program
    {
        static void Main(string[] args)
        {
            IProductContext productContext = new ProductContext();
            IProductRepository productRepository = new ProductRepository(productContext);
            ProductService productService = new ProductService(productRepository);
            IList<Product> products = productService.GetAllProducts();
            //  Product product = products.FirstOrDefault<Product>();            

            Console.WriteLine("********* UR Health Store - Meal Plans ***********");

            foreach (Product product in products)
            {
                Console.WriteLine("Meal: {0}, Name: {1}, Price: Rs.{2}, Calories: {3}", product.Category.Name, product.Name, product.Price, product.Calories);

            }

            Console.WriteLine("********* ********** ***********");
            Console.WriteLine("Choose the meal name to place order:");
            string productName = Console.ReadLine();
            Product selectedProduct = products.ToList<Product>().Find(x => x.Name.Contains(productName));
            Console.WriteLine("You have choosen meal: {0}, and price is Rs.{1}", selectedProduct.Name, selectedProduct.Price);
            Console.WriteLine("********* ********** ***********");

            Console.WriteLine("Our store supports Zeta / Sodexho.");

            Console.WriteLine("Please enter your card type to proceed for payment...");

            string cardType = Console.ReadLine();

            Console.WriteLine("********* ********** ***********");

            PaymentRequest paymentRequest = new PaymentRequest();

            paymentRequest.Amount = selectedProduct.Price;

            if(cardType == "Sodexho")
                paymentRequest.CardType = MealCardType.Sodexho;
            else if (cardType == "Zeta")
                paymentRequest.CardType = MealCardType.Zeta;

            paymentRequest.PaymentTransactionId = "URHealth"+Guid.NewGuid().ToString();

            PaymentService paymentService = new PaymentService();
            PaymentResponse paymentResponse = paymentService.Pay(paymentRequest);

            string status = ((paymentResponse.Success == true) ? "Thank you for payment! Your transaction is successful.  You'll receive URHealth meal pack in 1 hour." : "Your card is declined, please refer your tranaction id in future communication - "+paymentRequest.PaymentTransactionId);


            Console.WriteLine(status + " \n Transaction message: {0}", paymentResponse.Message);

            Console.Read();
        }
    }
}
