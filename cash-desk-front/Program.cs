using cash_desk_backend;
using System;
using System.Collections.Generic;
using System.Linq;

namespace cash_desk_front
{
    class Program
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop();
            int iteration = 1;
            List<Product> Basket = new List<Product>();
            List<Receipt> AllReceipts = new List<Receipt>();
            while (1 == 1)
            {
                Console.Clear();
                Receipt receipt = new Receipt();
                Console.WriteLine("WITAJ W PROGRAMIE KASY SKLEPOWEJ");
                Console.WriteLine("");
                Console.WriteLine("Aby rozpocząć zakupy, wpisz 'a'");
                Console.WriteLine("Aby wyświetlić liste produktów, wpisz 'b'");
                Console.WriteLine("Aby wyświetlić listę paragonów, wpisz 'c'");
                string action = Console.ReadLine();
                while (action == "a")
                {
                    Console.Clear();
                    Console.WriteLine("Podaj kod kreskowy produktu");
                    string ProductSearchString = Console.ReadLine();
                    if (ProductSearchString.Length == 4)
                    {
                        int ProductSearch = int.Parse(ProductSearchString);
                        List<Product> TemporaryBasket = shop.AllProducts.Where(x => x.Barcode == ProductSearch).ToList();
                        if (TemporaryBasket.Count == 0)
                        {
                            Console.WriteLine("Nie znaleziono");
                        }
                        else
                        {
                            Console.WriteLine("Podaj ilość");
                            string numberAsString = Console.ReadLine();
                            int number = int.Parse(numberAsString);
                            TemporaryBasket[0].Amount = number;
                            Basket.Add(TemporaryBasket[0]);
                            TemporaryBasket.Clear();

                        }
                        Console.WriteLine("Jeśli chcesz:");
                        Console.WriteLine("Dodać kolejny produkt do paragonu, wpisz 'a'");
                        Console.WriteLine("Wyświetlić paragon i zakończyć zakupy, wpisz 'b'");
                        string toContinue = Console.ReadLine();
                        if (toContinue == "b")
                        {
                            Console.Clear();
                            decimal sum = 0;
                            decimal totalSum = 0;
                            decimal NumberofOne = 0;
                            decimal NumberofTwo = 0;
                            foreach (Product product in Basket)
                            {
                                sum = product.Price * product.Amount;
                                totalSum = totalSum + sum;
                                if (product.VatRate == 1)
                                {
                                    NumberofOne = NumberofOne + 1;
                                }
                                else
                                {
                                    NumberofTwo = NumberofTwo + 1;
                                }
                                                               
                            }
                            decimal net = (totalSum * NumberofOne * 8 / 100) + (totalSum * NumberofTwo * 23 / 100);
                            receipt.Id = iteration;
                            receipt.Products = Basket;
                            receipt.Date = DateTime.Now;
                            receipt.TotalCost = totalSum;
                            receipt.Net = net;
                            iteration = iteration + 1;
                            AllReceipts.Add(receipt);
                            Console.WriteLine("Numer paragonu:");
                            Console.WriteLine(receipt.Id);
                            Console.WriteLine("Data wystawienia:");
                            Console.WriteLine(receipt.Date);
                            Console.WriteLine("Produkty:");
                            foreach (Product product in receipt.Products)
                            {
                                Console.WriteLine("Nazwa produktu:");
                                Console.WriteLine(product.Name);
                                Console.WriteLine("Cena:");
                                Console.WriteLine(product.Price);
                                Console.WriteLine("Kat. VAT:");
                                Console.WriteLine(product.VatRate);
                                Console.WriteLine("Ilość:");
                                Console.WriteLine(product.Amount);
                                Console.WriteLine("");
                            }
                            Console.WriteLine("Suma Brutto:");
                            Console.WriteLine(totalSum);
                            Console.WriteLine("W tym VAT:");
                            Console.WriteLine(net);
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("Aby wrócić do startu, wciśnij 'Enter'");
                            Console.ReadLine();
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Zły kod produktu, spróbuj ponownie");
                        Console.WriteLine("Aby wrócić do startu, wciśnij 'Enter'");
                        Console.ReadLine();
                        break;
                    }
                }
                while (action == "b")
                {
                    Console.Clear();
                    foreach (Product product in shop.AllProducts)
                    {
                        Console.WriteLine("Nazwa produktu:");
                        Console.WriteLine(product.Name);
                        Console.WriteLine("Kod kreskowy:");
                        Console.WriteLine(product.Barcode);
                        Console.WriteLine("Cena:");
                        Console.WriteLine(product.Price);
                        Console.WriteLine("Kat. VAT:");
                        Console.WriteLine(product.VatRate);
                        Console.WriteLine("");
                    }
                    Console.WriteLine("Aby wrócić do startu, wciśnij 'Enter'");
                    Console.ReadLine();
                    break;
                }
                while (action == "c")
                {
                    if (AllReceipts.Count == 0)
                    {
                        Console.WriteLine("Nie wystawiono żadnych paragonów");
                        Console.WriteLine("Uwaga! nie stworzono żadnych paragonów, wciśnij 'Enter'");
                        Console.ReadLine();
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        foreach (Receipt receipt1 in AllReceipts)
                        {
                            Console.WriteLine("Numer paragonu:");
                            Console.WriteLine(receipt1.Id);
                            Console.WriteLine("Data wystawienia:");
                            Console.WriteLine(receipt1.Date);
                            Console.WriteLine("Kosz:");
                            Console.WriteLine(receipt1.TotalCost);
                            Console.WriteLine("W tym VAT:");
                            Console.WriteLine(receipt1.Net);
                            Console.WriteLine("");
                            Console.WriteLine("");
                        }
                        Console.WriteLine("Aby wrócić do startu, wciśnij 'Enter'");
                        Console.ReadLine();
                        break;
                    }
                }
            }
        }
    }
}
