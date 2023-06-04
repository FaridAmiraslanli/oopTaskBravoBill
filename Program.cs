using System;
using System.Collections;

namespace oopTaskBravo
{
    class Program
    {
        static void Main(string[] args)
        {
            Products potato = new Products("Potato", 2, 0.2m, false, "kg");
            Products tomato = new Products("Tomato", 4, 0.1m, false, "kg");
            Products batteryDuracell = new Products("Battery Duracell", 18, 0.05m, true, "pcs");
            Products coffee = new Products("Coffee 100gr", 16, 0.05m, true, "pcs");
            Products tea = new Products("Azerchay 100gr", 4, 0.15m, true, "pcs");

            decimal budget = 450;
            decimal budgetChecker = budget;
            decimal totalPrice = 0;
            decimal totalEDV = 0;
            decimal totalDiscount = 0;
            bool continueToShop = true;
            decimal delivery;
            ArrayList shoppingDb = new ArrayList();

            Console.WriteLine("Select products from the list below according to their position number:");

            foreach (Products item in Products.db)
            {
                Console.WriteLine($"{item.Id}.{item.Name} | Price: {item.Price}");
            }

            while (continueToShop)
            {
            head:
                Console.WriteLine("Enter product position number:");
                int productId = int.Parse(Console.ReadLine() ?? "");
                Console.WriteLine("Enter amount:");
                int amount = int.Parse(Console.ReadLine() ?? "");
                Products purshasedProduct = (Products)Products.db[productId - 1];
                purshasedProduct.Amount = amount;
                budgetChecker -= (amount * purshasedProduct.Price * 0.98m - (purshasedProduct.Discount * purshasedProduct.Price * amount));
                if (budgetChecker > 0)
                {
                    shoppingDb.Add(purshasedProduct);
                    Console.WriteLine("Continue to buy: y/n");
                    string continueOrNot = (Console.ReadLine() ?? "").ToLower();
                    continueToShop = continueOrNot != "y" ? false : true;
                }
                else
                {
                    budgetChecker += (amount * purshasedProduct.Price * 0.98m - (purshasedProduct.Discount * purshasedProduct.Price * amount));
                    purshasedProduct.Amount = (int)(budgetChecker / (purshasedProduct.Price * 0.98m - (purshasedProduct.Discount * purshasedProduct.Price)));
                    Console.WriteLine($"Not enough budget for {amount} {purshasedProduct.UnitOfMeasurement} of {purshasedProduct.Name}");
                    Console.WriteLine($"You can buy {purshasedProduct.Amount} {purshasedProduct.UnitOfMeasurement} of {purshasedProduct.Name} instead. Would you like to continue with amount of {purshasedProduct.Amount} : y/n");
                    string agreeToBuy = (Console.ReadLine() ?? "").ToLower();
                    if (agreeToBuy == "n")
                    {
                        goto head;
                    }
                    shoppingDb.Add(purshasedProduct);

                    continueToShop = false;
                }

            }

        start:
            Console.WriteLine("Choose payment method: 1.cash 2.card");
            string paymentMethod = (Console.ReadLine() ?? "").ToLower();
            if (paymentMethod == "1" || paymentMethod == "2" || paymentMethod == "cash" || paymentMethod == "card")
            {
            }
            else
            {
                goto start;
            }
            Console.WriteLine("| Product | Amount | Price (AZN) | EDV(%) | Total(AZN) |");
            foreach (Products item in shoppingDb)
            {
                Console.WriteLine($"| {item.Name} | {item.Amount}{item.UnitOfMeasurement}  |   {item.Price}   |   {item.EDV}   |   {item.Amount * item.Price}   |");
                Console.WriteLine($" Discount({(item.Discount * 100).ToString("0")}%) =================== {(item.Discount * item.Price * item.Amount).ToString("0.00")}                    ");
                totalDiscount += (item.Discount * item.Price * item.Amount);
                totalEDV += (item.EDV * 0.01m * item.Price * item.Amount);
                totalPrice += (item.Amount * item.Price);
            }

            Console.WriteLine(" +++++++++++++++++++++++++++++++++++++++++++++++++++++++++");

            if (paymentMethod == "1" || paymentMethod == "cash")
            {
                Console.WriteLine($"Total EDV:                                         | {totalEDV.ToString("0.00")}|");
                Console.WriteLine($"Payment method: Cash                   EDV cashback:{(-totalEDV * 0.1m).ToString("0.00")}");
                Console.WriteLine($"Total discount:                                          | -{totalDiscount.ToString("0.00")}|");
                Console.WriteLine($"Bonus card discount(2%):                              | {(-totalPrice * 0.02m).ToString("0.00")}|");
                Console.WriteLine($"Total price:                                          | {(totalPrice)}|");
                delivery = totalPrice < 15 ? 4.5m : 0;
                Console.WriteLine($"Delivery fee:                                   {delivery}");
                Console.WriteLine($"Total payment:                                          | {(totalPrice * 0.98m - totalDiscount - totalEDV * 0.1m + delivery).ToString("0.00")}|");
                budget -= (totalPrice * 0.98m - totalDiscount - totalEDV * 0.1m + delivery);
            }
            else
            {
                Console.WriteLine($"Total EDV:                                          | {totalEDV.ToString("0.00")}|");
                Console.WriteLine($"Payment method: Card                   EDV cashback:{(-totalEDV * 0.15m).ToString("0.00")}");
                Console.WriteLine($"Total discount:                                          | -{totalDiscount.ToString("0.00")}|");
                Console.WriteLine($"Bonus card discount(2%):                              | {(-totalPrice * 0.02m).ToString("0.00")}|");
                Console.WriteLine($"Total price:                                          | {(totalPrice).ToString("0.00")}|");
                delivery = totalPrice < 15 ? 4.5m : 0;
                Console.WriteLine($"Delivery fee:                                  {delivery}");
                Console.WriteLine($"Total payment:                                          | {(totalPrice * 0.98m - totalDiscount - totalEDV * 0.15m + delivery).ToString("0.00")}|");
                budget -= (totalPrice * 0.98m - totalDiscount - totalEDV * 0.15m + delivery);
            }

            Console.WriteLine($"{budget.ToString("0.00")} left in your balance.");
            Console.WriteLine($"Date:{DateTime.Now}");
            Random random = new Random();
            int randomNumber = random.Next(100000000, 999999999);
            Console.WriteLine($"Number: {randomNumber}");
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