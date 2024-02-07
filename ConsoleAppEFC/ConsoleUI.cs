using ConsoleAppEFC.Services;

namespace ConsoleAppEFC;

internal class ConsoleUI
{
    private readonly ProductService _productService;
    private readonly CustomerService _customerService;

    public ConsoleUI(ProductService productService, CustomerService customerService)
    {
        _productService = productService;
        _customerService = customerService;
    }

    //PRODUCTSUI
    public void CreateProduct_UI()
    {
        Console.Clear();
        Console.WriteLine("-- Create Product --");

        Console.Write("Product Title: ");
        var title = Console.ReadLine()!;

        Console.Write("Product Price: ");
        var price = decimal.Parse(Console.ReadLine()!);

        Console.Write("Product Category: ");
        var categoryName = Console.ReadLine()!;

        var result = _productService.CreateProduct(title, price, categoryName);
        if (result != null)
        {
            Console.Clear();
            Console.WriteLine("Product was created.");
            Console.ReadKey();
        }

    }
    public void GetProducts_UI() 
    {
        Console.Clear();

        var products = _productService.GetProducts();
        foreach (var product in products)
        {
            Console.WriteLine($"{product.Title} - {product.Category.CategoryName} ({product.Price} SEK)");
        }

        Console.ReadKey();
    }
    public void UpdateProduct_UI()
    {
        Console.Clear();
        Console.Write("Enter Product Id: ");
        var id = int.Parse(Console.ReadLine()!);

        var product = _productService.GetProductById(id);
        if (product != null)
        {
            Console.WriteLine($"{product.Title} - {product.Category.CategoryName} ({product.Price} SEK)");
            Console.WriteLine();

            Console.Write("New Product Title: ");
            product.Title = Console.ReadLine()!;

            var newProduct = _productService.UpdateProduct(product);
            Console.WriteLine($"{product.Title} - {product.Category.CategoryName} ({product.Price} SEK)");

        }
        else { Console.WriteLine("No Product Found."); }
        Console.ReadKey();
    }
    public void DeleteProduct_UI()
    {
        Console.Clear();
        Console.Write("Enter Product Id: ");
        var id = int.Parse(Console.ReadLine()!);

        var product = _productService.GetProductById(id);
        if (product != null)
        {
            _productService.DeleteProduct(product.Id);
            Console.WriteLine("The Product Was Deleted.");
        }
        else { Console.WriteLine("No Product Found."); }
        Console.ReadKey();
    }

    //CUSTOMERSUI
    public void CreateCustomer_UI()
    {
        Console.Clear();
        Console.WriteLine("-- Create Customer --");

        Console.Write("First Name: ");
        var firstName = Console.ReadLine()!;

        Console.Write("Last Name: ");
        var lastName = Console.ReadLine()!;

        Console.Write("Email: ");
        var email = Console.ReadLine()!;

        Console.Write("Street Name: ");
        var streetName = Console.ReadLine()!;

        Console.Write("Postal Code: ");
        var postalCode = Console.ReadLine()!;

        Console.Write("City: ");
        var city = Console.ReadLine()!;

        Console.Write("Role Name: ");
        var roleName = Console.ReadLine()!;


        var result = _customerService.CreateCustomer(firstName, lastName, email, roleName, streetName, postalCode, city);
        if (result != null)
        {
            Console.Clear();
            Console.WriteLine("Customer created.");
            Console.ReadKey();
        }

    }
    public void GetCustomers_UI()
    {
        Console.Clear();

        var customers = _customerService.GetCustomers();
        foreach (var customer in customers)
        {
            Console.WriteLine($"{customer.FirstName} - {customer.LastName} ({customer.Role.RoleName})");
            Console.WriteLine($"{customer.Address.StreetName}, {customer.Address.PostalCode}, {customer.Address.City}");
        }

        Console.ReadKey();
    }
    public void UpdateCustomer_UI()
    {
        Console.Clear();
        Console.Write("Enter Customer Email: ");
        var email = Console.ReadLine()!;

        var customer = _customerService.GetCustomerByEmail(email);
        if (customer != null)
        {
            Console.WriteLine();
            Console.WriteLine($"{customer.FirstName} - {customer.LastName} ({customer.Role.RoleName})");
            Console.WriteLine($"{customer.Address.StreetName}, {customer.Address.PostalCode}, {customer.Address.City}");
            Console.WriteLine();

            Console.Write("Do you want to update customer information? (yes/no): ");
            var updateChoice = Console.ReadLine()?.ToLower();

            if (updateChoice == "yes")
            {
                Console.Write("New First Name (leave blank for no update): ");
                string newFirstName = Console.ReadLine()!;
                if (!string.IsNullOrWhiteSpace(newFirstName))
                {
                    customer.FirstName = newFirstName;
                }

                Console.Write("New Last Name (leave blank for no update): ");
                string newLastName = Console.ReadLine()!;
                if (!string.IsNullOrWhiteSpace(newLastName))
                {
                    customer.LastName = newLastName;
                }

                Console.Write("New Street Name (leave blank for no update): ");
                string newStreetName = Console.ReadLine()!;
                if (!string.IsNullOrWhiteSpace(newStreetName))
                {
                    customer.Address.StreetName = newStreetName;
                }

                Console.Write("New Postal Code (leave blank for no update): ");
                string newPostalCode = Console.ReadLine()!;
                if (!string.IsNullOrWhiteSpace(newPostalCode))
                {
                    customer.Address.PostalCode = newPostalCode;
                }

                Console.Write("New City (leave blank for no update): ");
                string newCity = Console.ReadLine()!;
                if (!string.IsNullOrWhiteSpace(newCity))
                {
                    customer.Address.City = newCity;
                }

                var newCustomer = _customerService.UpdateCustomer(customer);
                Console.WriteLine();
                Console.WriteLine($"{newCustomer.FirstName} - {newCustomer.LastName} ({newCustomer.Role.RoleName})");
                Console.WriteLine($"{newCustomer.Address.StreetName}, {newCustomer.Address.PostalCode}, {newCustomer.Address.City}");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No changes were made.");
            }
        }
        else
        {
            Console.WriteLine("No Customer Found.");
        }
        Console.ReadKey();
    }
    public void DeleteCustomer_UI()
    {
        Console.Clear();
        Console.Write("Enter Customer Email: ");
        var email = Console.ReadLine()!;

        var customer = _customerService.GetCustomerByEmail(email);
        if (customer != null)
        {
            _customerService.DeleteCustomer(customer.Id);
            Console.WriteLine("Customer Was Deleted.");
        }
        else { Console.WriteLine("No Customer Found."); }
        Console.ReadKey();
    }

    //MAINMENU
    public void MainMenu()
    {
        bool continueExecution = true;

        while (continueExecution)
        {
            Console.Clear();
            Console.WriteLine("Main Menu:");
            Console.WriteLine("1. Product Operations");
            Console.WriteLine("2. Customer Operations");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine()!;

            switch (choice)
            {
                case "1":
                    ProductMenu();
                    break;
                case "2":
                    CustomerMenu();
                    break;
                case "3":
                    continueExecution = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
    public void ProductMenu()
    {
        bool continueExecution = true;

        while (continueExecution)
        {
            Console.Clear();
            Console.WriteLine("Product Menu:");
            Console.WriteLine("1. Create Product");
            Console.WriteLine("2. Get Products");
            Console.WriteLine("3. Update Product");
            Console.WriteLine("4. Delete Product");
            Console.WriteLine("5. Back to Main Menu");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine()!;

            switch (choice)
            {
                case "1":
                    CreateProduct_UI();
                    break;
                case "2":
                    GetProducts_UI();
                    break;
                case "3":
                    UpdateProduct_UI();
                    break;
                case "4":
                    DeleteProduct_UI();
                    break;
                case "5":
                    continueExecution = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
    public void CustomerMenu()
    {
        bool continueExecution = true;

        while (continueExecution)
        {
            Console.Clear();
            Console.WriteLine("Customer Menu:");
            Console.WriteLine("1. Create Customer");
            Console.WriteLine("2. Get Customers");
            Console.WriteLine("3. Update Customer");
            Console.WriteLine("4. Delete Customer");
            Console.WriteLine("5. Back to Main Menu");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateCustomer_UI();
                    break;
                case "2":
                    GetCustomers_UI();
                    break;
                case "3":
                    UpdateCustomer_UI();
                    break;
                case "4":
                    DeleteCustomer_UI();
                    break;
                case "5":
                    continueExecution = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

}
