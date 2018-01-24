using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket
{
    class Program
    {
        private static StringBuilder finalResult = new StringBuilder();
        private static Dictionary<string, Product> allProductsByName = new Dictionary<string, Product>();
        private static Dictionary<string, SortedSet<Product>> allProductsByTypeSorted = new Dictionary<string, SortedSet<Product>>();
        private static SortedSet<Product> allProductsSorted = new SortedSet<Product>();

        static void Main(string[] args)
        {
            string currentInput = Console.ReadLine();

            string[] splittedInput;
            for (; currentInput != "end";)
            {
                splittedInput = currentInput.Split();
                switch (splittedInput[0])
                {
                    case "add":
                        AddProduct(splittedInput);
                        break;
                    case "filter":
                        switch (splittedInput[2])
                        {
                            case "type":
                                FilterByType(splittedInput);
                                break;
                            case "price":
                                FilterByPrice(splittedInput);
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }

                currentInput = Console.ReadLine();
            }

            Console.Write(finalResult);
        }

        private static void FilterByPrice(string[] splittedInput)
        {
            if (splittedInput.Length == 7)
            {
                decimal minPrice = Decimal.Parse(splittedInput[4]);
                decimal maxPrice = Decimal.Parse(splittedInput[6]);

                HashSet<Product> productsSatisfyingCondition = new HashSet<Product>(allProductsSorted.Where(product => product.Price >= minPrice && product.Price <= maxPrice).Take(10));

                if (productsSatisfyingCondition.Count == 0)
                {
                    finalResult.AppendLine("Ok: ");
                }
                else
                {
                    finalResult.AppendLine("Ok: " + string.Join(", ", productsSatisfyingCondition));
                }
            }
            else if (splittedInput.Length == 5)
            {
                if (splittedInput[3] == "from")
                {
                    decimal startPrice = Decimal.Parse(splittedInput[4]);

                    HashSet<Product> productsSatisfyingCondition = new HashSet<Product>(allProductsSorted.Where(product => product.Price >= startPrice).Take(10));

                    if (productsSatisfyingCondition.Count == 0)
                    {
                        finalResult.AppendLine("Ok: ");
                    }
                    else
                    {
                        finalResult.AppendLine("Ok: " + string.Join(", ", productsSatisfyingCondition));
                    }
                }
                else if (splittedInput[3] == "to")
                {
                    decimal maxPrice = Decimal.Parse(splittedInput[4]);

                    HashSet<Product> productsSatisfyingCondition = new HashSet<Product>(allProductsSorted.Where(product => product.Price <= maxPrice).Take(10));

                    if (productsSatisfyingCondition.Count == 0)
                    {
                        finalResult.AppendLine("Ok: ");
                    }
                    else
                    {
                        finalResult.AppendLine("Ok: " + string.Join(", ", productsSatisfyingCondition));
                    }
                }
            }
        }

        private static void FilterByType(string[] splittedInput)
        {
            string productType = splittedInput[3];
            if (!allProductsByTypeSorted.ContainsKey(productType))
            {
                finalResult.AppendLine(string.Format("Error: Type {0} does not exists", productType));
            }
            else
            {
                finalResult.AppendLine("Ok: " + string.Join(", ", allProductsByTypeSorted[productType].Take(10)));
            }
        }

        private static void AddProduct(string[] splittedInput)
        {
            string newProductName = splittedInput[1];
            string newProductType = splittedInput[3];

            if (!allProductsByName.ContainsKey(newProductName))
            {
                Product newProduct = new Product(newProductName, Decimal.Parse(splittedInput[2]), splittedInput[3]);
                allProductsByName.Add(newProductName, newProduct);
                finalResult.AppendLine(string.Format("Ok: Product {0} added successfully", newProductName));

                allProductsSorted.Add(newProduct);

                if (!allProductsByTypeSorted.ContainsKey(newProductType))
                {
                    allProductsByTypeSorted.Add(newProductType, new SortedSet<Product>());
                    allProductsByTypeSorted[newProductType].Add(newProduct);
                }
                else
                {
                    if (allProductsByTypeSorted[newProductType].Count < 10)
                    {
                        allProductsByTypeSorted[newProductType].Add(newProduct);
                    }
                    else
                    {
                        Product lastByType = allProductsByTypeSorted[newProductType].Last();
                        if (lastByType.CompareTo(newProduct) > 0)
                        {
                            allProductsByTypeSorted[newProductType].Add(newProduct);
                            allProductsByTypeSorted[newProductType].Remove(lastByType);
                        }
                    }
                }
            }
            else
            {
                finalResult.AppendLine(string.Format("Error: Product {0} already exists", newProductName));
            }
        }
    }

    class Product : IComparable<Product>
    {
        private string name;
        private decimal price;
        private string type;

        public Product(string name, decimal price, string type)
        {
            this.Name = name;
            this.Price = price;
            this.Type = type;
        }

        public string Name { get => this.name; set => this.name = value; }
        public decimal Price { get => this.price; set => this.price = value; }
        public string Type { get => this.type; set => this.type = value; }

        public int CompareTo(Product other)
        {
            int resultForReturning = this.Price.CompareTo(other.Price);
            if (resultForReturning == 0)
            {
                resultForReturning = this.Name.CompareTo(other.Name);
            }
            if (resultForReturning == 0)
            {
                resultForReturning = this.Type.CompareTo(other.Type);
            }
            return resultForReturning;
        }

        public override string ToString()
        {
            return string.Format("{0}({1})", this.Name, this.Price.ToString("G29"));
        }
    }
}