abstract class Product
{
    public string Name { get; set; }
    public double Price { get; set; }
    public int Stock { get; set; }

    public Product(string name, double price, int stock)
    {
  
        Name = name;
        Price = price;
        Stock = stock;
    }

    public abstract void PrintInfo();

    public virtual void Sell(int quantity)
    {

        if (quantity <= Stock)
        {
            Stock -= quantity;
            Console.WriteLine($"{quantity} eded {Name} satıldı. Qalan stok: {Stock}");
        }
        else
        {
         
            Console.WriteLine("Anbarda kifayet qeder mehsul yoxdur.");
        }
    }
}


interface IDiscountable
{
    void ApplyDiscount(double percentage);
}

interface IShippable
{
    double CalculateShippingCost();
    void ShipOrder();
}

class Electronics : Product, IDiscountable, IShippable
{
    public int WarrantyPeriod { get; set; } 

    public Electronics(string name, double price, int stock, int warrantyPeriod)
        : base(name, price, stock)
    {

        WarrantyPeriod = warrantyPeriod;
    }

    public override void PrintInfo()
    {
      
        Console.WriteLine($"Mehsul: {Name}, Qiymet: {Price} AZN, Zemanet: {WarrantyPeriod} ay, Stok: {Stock}");
    }

    public void ApplyDiscount(double percentage)
    {

        Price -= Price * percentage / 100;
        Console.WriteLine($"Yeni qiymet: {Price} AZN");
    }

    public double CalculateShippingCost()
    {
    
        return 10 + 0.01 * Price;
    }

    public void ShipOrder()
    {

        Console.WriteLine($"{Name} mehsulu gönderildi.");
    }
}

class Clothing : Product, IDiscountable, IShippable
{
    public string Size { get; set; }
    public string Color { get; set; }

    public Clothing(string name, double price, int stock, string size, string color)
        : base(name, price, stock)
    {
      
        Size = size;
        Color = color;
    }

    public override void PrintInfo()
    {
     
        Console.WriteLine($"Mehsul: {Name}, Qiymet: {Price} AZN, Ölçü: {Size}, Reng: {Color}, Stok: {Stock}");
    }

    public void ApplyDiscount(double percentage)
    {
   
        Price -= Price * percentage / 100;
        Console.WriteLine($"Yeni qiymet: {Price} AZN");
    }

    public double CalculateShippingCost()
    {
        
        return 5;
    }

    public void ShipOrder()
    {
        
        Console.WriteLine($"{Name} mehsulu gönderildi.");
    }
}


class Book : Product, IShippable
{
    public string Author { get; set; }
    public int PageCount { get; set; }

    public Book(string name, double price, int stock, string author, int pageCount)
        : base(name, price, stock)
    {
       
        Author = author;
        PageCount = pageCount;
    }

    public override void PrintInfo()
    {
       
        Console.WriteLine($"Mehsul: {Name}, Qiymet: {Price} AZN, Müellif: {Author}, Sehife sayı: {PageCount}, Stok: {Stock}");
    }

    public double CalculateShippingCost()
    {
      
        return 3;
    }

    public void ShipOrder()
    {
        Console.WriteLine($"{Name} kitabı gönderildi.");
    }
}


class Program
{
    static void Main(string[] args)
    {
     
        Electronics smartphone = new Electronics("Smartphone", 1200, 10, 24);
        smartphone.PrintInfo();
        smartphone.ApplyDiscount(10); 
        Console.WriteLine($"Genderme xerc: {smartphone.CalculateShippingCost()} AZN");
        smartphone.Sell(4); 
        smartphone.ShipOrder();

        Console.WriteLine();

  
        Clothing tshirt = new Clothing("T-shirt", 20, 50, "M", "Black");
        tshirt.PrintInfo();
        tshirt.ApplyDiscount(20);
        Console.WriteLine($"Genderme xerc: {tshirt.CalculateShippingCost()} AZN");
        tshirt.Sell(5); 
        tshirt.ShipOrder();

        Console.WriteLine();

       
        Book csharpBook = new Book("C# Dersliyi", 30, 25, "John Doe", 450);
        csharpBook.PrintInfo();
        Console.WriteLine($"Gönderme xerc: {csharpBook.CalculateShippingCost()} AZN");
        csharpBook.Sell(2); 
        csharpBook.ShipOrder();
    }
}
