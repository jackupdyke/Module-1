﻿using System.Collections.Generic;

namespace Exercises
{
    public partial class Exercises
    {
        /*
         * Given two Dictionaries, Dictionary<string, int>, merge the two into a new Dictionary, Dictionary<string, int> where keys in Dictionary2,
         * and their int values, are added to the int values of matching keys in Dictionary1. Return the new Dictionary.
         *
         * Unmatched keys and their int values in Dictionary2 are simply added to Dictionary1.
         *
         * ConsolidateInventory({"SKU1": 100, "SKU2": 53, "SKU3": 44} {"SKU2":11, "SKU4": 5})
         * 	 → {"SKU1": 100, "SKU2": 64, "SKU3": 44, "SKU4": 5}
         *
         */
        public Dictionary<string, int> ConsolidateInventory(Dictionary<string, int> mainWarehouse,
                                                            Dictionary<string, int> remoteWarehouse)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            
            if(mainWarehouse.Count == 0)
            {
                foreach(KeyValuePair<string, int> item2 in remoteWarehouse)
                {
                    result.Add(item2.Key, item2.Value);
                }
            }
            else if(remoteWarehouse.Count == 0)
            {
                foreach(KeyValuePair<string, int> item in mainWarehouse)
                {
                    result.Add(item.Key, item.Value);
                }
            }
            else
            {
                foreach (KeyValuePair<string, int> item in mainWarehouse)
                {
                    foreach (KeyValuePair<string, int> item2 in remoteWarehouse)
                    {

                        if ((!result.ContainsKey(item.Key) || !result.ContainsKey(item2.Key)) && item.Key != item2.Key)
                        {
                            if(!result.ContainsKey(item.Key))
                            {
                                result.Add(item.Key, item.Value);
                            }
                            if(!result.ContainsKey(item2.Key))
                            {
                                result.Add(item2.Key, item2.Value);
                            }

                        }
                        else if (item.Key == item2.Key)
                        {
                            result[item.Key] = item.Value + item2.Value;
                        }



                    }


                }
            }


            
            return result;
        }
    }
}
