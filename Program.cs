using System;
using System.Collections;

namespace oopTaskBravo
{
    class Program
    {
        static void Main(string[] args)
        {
            Products potato = new Products("Potato", 2, 0.2, false, "kg");
            Products tomato = new Products("Tomato", 4, 0.1, false, "kg");
            Products batteryDuracell = new Products("Battery Duracell", 18, 0.05, true, "pcs");
            Products coffee = new Products("Coffee 100gr", 16, 0.05, true, "pcs");
            Products tea = new Products("Azerchay 100gr", 4, 0.15, true, "pcs");

            int budget = 450;
            int totalPrice = 0;
            int totalEDV = 0;
            int totalDiscount = 0;
            bool continueToShop = true;
            ArrayList shoppingDb = new ArrayList();
            ArrayList billDb = new ArrayList();

            System.Console.WriteLine("Select products from the list below according to their position number:");

            foreach (Products item in Products.db)
            {
                System.Console.WriteLine($"{item.Id}.{item.Name} | Price: {item.Price}");
            }

            while (continueToShop)
            {
                System.Console.WriteLine("Enter product position number:");
                int productId = int.Parse(Console.ReadLine() ?? "");
                System.Console.WriteLine("Enter amount:");
                int amount = int.Parse(Console.ReadLine() ?? "");
                Products purshasedProduct = (Products)Products.db[productId - 1];
                purshasedProduct.Amount = amount;
                budget -= (int)(amount * (purshasedProduct.Price - purshasedProduct.Discount * purshasedProduct.Price) * 0.98);
                if (budget > 0)
                {
                    shoppingDb.Add(purshasedProduct);
                    System.Console.WriteLine("Continue to buy: y/n");
                    string continueOrNot = (Console.ReadLine() ?? "").ToLower();
                    continueToShop = continueOrNot != "y" ? false : true;
                }
                else
                {
                    budget += (int)(amount * (purshasedProduct.Price - purshasedProduct.Discount * purshasedProduct.Price) * 0.98);
                    purshasedProduct.Amount = budget / purshasedProduct.Price;
                    shoppingDb.Add(purshasedProduct);
                    System.Console.WriteLine("Not enough budget to continue...");
                    continueToShop = false;
                }

            }

        start:
            System.Console.WriteLine("Choose payment method: 1.cash 2.card");
            string paymentMethod = (Console.ReadLine() ?? "").ToLower();
            if (paymentMethod == "1" || paymentMethod == "2" || paymentMethod == "cash" || paymentMethod == "card")
            {
            }
            else
            {
                goto start;
            }

            System.Console.WriteLine("| Product | Amount | Price (AZN) | EDV(%) | Total(AZN) |");
            foreach (Products item in shoppingDb)
            {

                System.Console.WriteLine($"| {item.Name} | {item.Amount}{item.UnitOfMeasurement}  |   {item.Price}   |   {item.EDV}   |   {item.Amount * item.Price}   |");
                System.Console.WriteLine($" Discount({item.Discount * 100}%) =================== {(int)(item.Discount * item.Price * item.Amount)}                    ");
                totalDiscount += (int)(item.Discount * item.Price * item.Amount);
                totalEDV += (int)(item.EDV / 100 * item.Price * item.Amount);
                totalPrice += (int)(item.Amount * (item.Price - item.Discount * item.Price));
            }

            System.Console.WriteLine(" +++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            System.Console.WriteLine($"Total discount                                          | {totalDiscount}|");
            System.Console.WriteLine($"Total EDV                                          | {totalEDV}|");
            System.Console.WriteLine($"Bonus card discount(2%)                              | {(int)(totalPrice * 0.02)}|");
            System.Console.WriteLine($"Total price                                          | {(int)(totalPrice * 0.98)}|");
            System.Console.WriteLine($"Total price                                          | {(int)(totalPrice * 0.98)}|");
            budget -= (int)(totalPrice * 0.98);
            if (paymentMethod == "1" || paymentMethod == "cash")
            {
                System.Console.WriteLine($"Payment method: Cash                   EDV cashback:{(int)(totalEDV * 0.1)}");
                budget -= (int)(totalEDV * 0.1);
            }
            else
            {
                System.Console.WriteLine($"Payment method: Card                   EDV cashback:{(int)(totalEDV * 0.15)}");
                budget -= (int)(totalEDV * 0.15);
            }
            System.Console.WriteLine($"{budget} left in your balance.");
            System.Console.WriteLine($"Date:{DateTime.Now}");
            Random random = new Random();
            int randomNumber = random.Next(100000000, 999999999);
            System.Console.WriteLine($"Number: {randomNumber}");
        }
    }
}

#region gelende eve corey al
/*
 *  Online alis veris :
 *  * Console ekaraninda musterini ilk once  menu qarsilamalidir,
 *  mehsullari menudan sececek( qiymetleri de olmalidir) sonra hansindan ne qeder istediyini qeyd edecek
 *  bildiklerinizi tetbiq ederek asagidaki numune cekin hazilanmasi
 *  lazimdir. Mehsul adlari onlarin qiymetleri edv olub olmamasi mehsulda endirim olub olmamasi
 *  siz terefden serbest teyin olunacaq.(burada gosterilenler hayel urunudur hic biri gercegi yansitmamaktadir).
 *
 *  | mehsul adi        |  miqdar  |  qiymet  |EDV  |toplam|
 *  | Un                | 5 kq     |  1       |0 %  |5     |
 *   Sizin qazanciniz=================== 0,495             |
 *  | quzu eti          | 3,5 kq   |  12      |18 % |42    |
 *   Sizin qazanciniz=================== 0,90              |
 *  | cay               | 2   eded |  1,50    |0 %  |      |
 *   Sizin qazanciniz=================== 0,90              |
 *  | alma qirmizi      | 2   kq   |  2,50    |0 %  |      |
 *   Sizin qazanciniz=================== 0,90              |
 *  | alma sari         | 2   kq   |  2       |18 % |      |
 *   Sizin qazanciniz=================== 0,90              |
 *  | goyerti           | 2   eded |  0,15    |0 %  |      |
 *   Sizin qazanciniz=================== 0,90              |
 *  | makaron           | 2   eded |  2       |0 %  |      |
 *   Sizin qazanciniz=================== 0,90              |
 *  | baliq konservasi  | 2   eded |  3,50    |0 %  |      |
 *   Sizin qazanciniz=================== 0,90              |
 *  | lavas             | 1   eded |  1,50    |0 %  |      |
 *   Sizin qazanciniz=================== 0,90              |
 *  | corek             | 2   eded |  0,50    |18 % |      |
 *   Sizin qazanciniz=================== 0,90              |
 *  | pomidor           | 2   kq   |  2,50    |0 %  |      |
 *   Sizin qazanciniz=================== 0,90              |
 *  | xiyar             | 2   kq   |  2       |0 %  |      |
 *   Sizin qazanciniz=================== 0,90              |
 *  | toyuq             | 2   eded |  2,50    |0 %  |      |
 *   Sizin qazanciniz=================== 0,90
 * +++++++++++++++++++++++++++++++++++++++++++++++++++++++++
 * Endirim                                          | 2,48 |
 * vergi edv                                        | 5,02 |
 * yekun mebleg                                     | 54,50|
 * odenis novu: kartla odenib                        
 * tarix 20:04:21
 * qebz nomresi : 12
 *
 * Musterinin hesabinda umumi 450 azn pul var,
 * elave olaraq musteri bravo endirim kartina sahib oldugu ucun her alis verishinde
 * umumi meblegin 2% qeder endirim elde edir. Musteri odenisi kartla ederse 0,18 elave deyer vergisinin
 * 10 % qederini , negd pulla ederse 15 % qederini yeniden musterinin hesabina kocurulur.
 *
 * sizin qazanciniz :
 * | Un                | 5 kq     |  1       |0 %  | 5
 *  Sizin qazanciniz=================== 0,495 ( 5 % endirim olub bu mehsulda digerlerinde de bu sekilde endrim olarsa hesablanmalidir.)
 *  0,495 qaliqlarda yuvarlasdirmada edersiz 
 * EDV :
 *  asagida gosterildiyi kimi bezi mehsullarda 0% bezilerinde 18% edv olmalidir.
 *  Sonda elave deyer vergisi-de hansi mehsullarda varsa toplanib yekun meblegin
 *  uzerine gelmelidir. Musteri odenisi kart-la  edibse 10% negd yolla odenis edibse
 *  15 % umumi edv-den musterinin hesabina pul qayidacaq.
 * 
 *  | mehsul adi        |  miqdar  |  qiymet  |EDV  |toplam
 *  | Un                | 5 kq     |  1       |0 %  |5
 *   Sizin qazanciniz=================== 0,495
 *  | quzu eti          | 3,5 kq   |  12      |18 % |42
 *
 *
 *  alis veris 15 azn den azdirsa catdirilma ucun 4,50 azn teleb olunacaq.
 */
#endregion