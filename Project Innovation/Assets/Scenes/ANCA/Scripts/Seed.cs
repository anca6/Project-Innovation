using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed
{
    public string Type { get; set; }
    public int Quantity { get; set; }

    public Seed(string type, int quantity)
    {
        Type = type;
        Quantity = quantity;
    }
}

