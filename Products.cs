using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Products
{
    static int _idCounter = 1;
    public int Id { get; private set; }
    public string Name { get; private set; }
    public int Price { get; private set; }
    public int Amount { get; set; }
    public double Discount { get; private set; }
    public bool BoolEDV { get; private set; }
    public double EDV { get; private set; } = 0;
    public string UnitOfMeasurement { get; private set; } = "pcs";
    public static ArrayList db = new ArrayList();

    public Products(string name, int price, double discount, bool boolEDV, string unitOfMeasurement)
    {
        Name = name;
        Price = price;
        Discount = discount;
        BoolEDV = boolEDV;
        UnitOfMeasurement = unitOfMeasurement;
        if (boolEDV)
        {
            EDV = 18;
        }
        Id = _idCounter;
        _idCounter++;
        db.Add(this);
    }
}