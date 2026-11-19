using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("742 Evergreen Terrace", "Springfield", "OR", "USA");
        Customer customer1 = new Customer("Homer Simpson", address1);
        Order order1 = new Order(customer1);

        order1.AddProduct(new Product("Box of Donuts", "DN-01", 12.99, 3));
        order1.AddProduct(new Product("Sway Bar", "SB-99", 45.00, 1));

        Address address2 = new Address("10 Downing Street", "London", "Greater London", "United Kingdom");
        Customer customer2 = new Customer("Winston Churchill", address2);
        Order order2 = new Order(customer2);

        order2.AddProduct(new Product("Cigar Box", "CG-50", 120.00, 1));
        order2.AddProduct(new Product("Pocket Watch", "PW-12", 250.00, 1));
        order2.AddProduct(new Product("Leather Journal", "LJ-05", 15.50, 2));
        Console.WriteLine("================ ORDER 1 ================");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine("\nPacking Label:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine($"\nTotal Price: ${order1.CalculateTotalCost():0.00}\n");

        Console.WriteLine("================ ORDER 2 ================");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine("\nPacking Label:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine($"\nTotal Price: ${order2.CalculateTotalCost():0.00}\n");
    }
}