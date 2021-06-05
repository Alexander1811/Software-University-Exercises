﻿using System;

namespace _02._Composite_Pattern
{
    public class StartUp
    {
        public static void Main()
        {
            SingleGift phone = new SingleGift("Phone", 256);
            phone.CalculateTotalPrice(); 
            Console.WriteLine();

            CompositeGift rootBox = new CompositeGift("RootBox", 0);
            
            SingleGift truckToy = new SingleGift("TruckToy", 289);
            SingleGift plainToy = new SingleGift("PlainToy", 587);
            
            rootBox.Add(truckToy); 
            rootBox.Add(plainToy);

            CompositeGift childBox = new CompositeGift("ChildBox", 0);
            
            SingleGift soldierToy = new SingleGift("SoldierToy", 200);
            
            childBox.Add(soldierToy);
            rootBox.Add(childBox);

            Console.WriteLine($"Total price of this composite present is: {rootBox.CalculateTotalPrice()}");
        }
    }
}
