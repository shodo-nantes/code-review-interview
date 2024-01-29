using System;
using System.Collections.Generic;
using System.Linq;

namespace shodoReview
{

/**
 * Created by thomas on 02/12/2019.
 * This class is a basket
 */
    public class BasketInformations
    {
        // The product of the basket
        static Dictionary<String, int> map = new Dictionary<string, int>();

        // The fact that the basket has promo code
        private static bool codeDePromotion = false;

        public void AddProductToBasket(string product, int price, bool isPromoCode)
        {
            if(isPromoCode === true)
            {
                codeDePromotion = true;
            }
            else
                map.Add(product, price);
        }

        public long GetBasketPrice(bool inCents)
        {
            int v = 0;
            foreach (var s in map.Keys)
            {
                v += map[s];
            }
            
            if (codeDePromotion)
            {
                v -= 100;
            }

            return inCents ? v * 100 : v;
        }

        public void ResetBasket()
        {
            BuyBasket();
            codeDePromotion = false;
        }

        public void BuyBasket()
        {
            map.Clear();
        }

        public Boolean IsBasketContains(String produit)
        {
            bool found = false;
            foreach (var s in map.Keys)
            {
                if (s == produit) found = true;
            }

            return found;
        }

        public static void MixWithBasket(BasketInformations b)
        {
            foreach (var s in b.map)
            {
                map.Append(s);
            }
        }
    }
}
