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
    public int Id { get; }
    public string Name { get; }
    public decimal Price { get; }
    public int Amount { get; set; }
    public decimal Discount { get; }
    public bool BoolEDV { get; }
    public decimal EDV { get; } = 0;
    public string UnitOfMeasurement { get; } = "pcs";
    public static ArrayList db = new ArrayList();

    public Products(string name, decimal price, decimal discount, bool boolEDV, string unitOfMeasurement)
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