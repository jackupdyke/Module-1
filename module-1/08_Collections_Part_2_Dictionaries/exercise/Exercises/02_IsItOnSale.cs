﻿using System.Collections.Generic;

namespace Exercises
{
    public partial class Exercises
    {
        /*
         * Given an string item number (a.k.a. SKU), return the discount percentage if the item is on sale.
         * If the item is not on sale, return 0.00.
         *
         * If the item number is empty or null, return 0.00.
         *
         * "KITCHEN4001" -> 0.20
         * "GARAGE1070" -> 0.15
         * "LIVINGROOM"	-> 0.10
         * "KITCHEN6073" -> 0.40
         * "BEDROOM3434" -> 0.60
         * "BATH0073" -> 0.15
         *
         * The item number should be case insensitive so "kitchen4001", "Kitchen4001", and "KITCHEN4001"
         * should all return 0.20.
         *
         * IsItOnSale("kitchen4001") → 0.20
         * IsItOnSale("") → 0.00
         * IsItOnSale("GARAGE1070") → 0.15
         * IsItOnSale("dungeon9999") → 0.00
         *
         */
        public double IsItOnSale(string itemNumber)
        {

            Dictionary<string, double> result = new Dictionary<string, double>();

            result.Add("KITCHEN4001", 0.20);
            result.Add("GARAGE1070", 0.15);
            result.Add("LIVINGROOM", 0.10);
            result.Add("KITCHEN6073", 0.40);
            result.Add("BEDROOM3434", 0.60);
            result.Add("BATH0073", 0.15);

            

            if(itemNumber == null)
            {
                return 0.00;
            }

            string item = itemNumber.ToUpper();

            if (result.ContainsKey(item))
            {
                return result[item];
            }
            else
            {
                return 0.00;
            }

            
        }
    }
}
