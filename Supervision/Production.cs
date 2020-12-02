using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Supervision
{
    public class Production
    {
        // Production archive parameters
        private int[] prevOrders = new int[90]; // Archives Générée aléatoirement 
        private int[] prevProds = new int[90];  // Archives Générée aléatoirement 
        private int customerNeed; // Généré aléatoirement 
        private int order; // Dynamique
        private string reqStatus; // Dynamique
        private string orderStatus; // Dynamique
        private Stopwatch timeProd = new Stopwatch();

        // intiialisation of the parameters of each archived production, different based on the production type
        public Production(string prodName)
        {
            var rand = new Random();
            DateTime actualDay = DateTime.Now;
            DateTime startDay = new DateTime(2020, 4, 1);
            int diffDay = ((int)(actualDay - startDay).TotalDays) ;

            this.reqStatus = "waiting";
            this.orderStatus = "waiting";
            if (prodName == "MnMs")
            {
                customerNeed = rand.Next(18500, 22000);
                for (int i = 0; i < diffDay; i++)
                {
                    this.prevOrders[i] = rand.Next(18500, 22000);
                    this.prevProds[i] = rand.Next(18500, 22000);
                }
            }

            if (prodName == "KitKat")
            {
                customerNeed = rand.Next(9500, 10500); ;
                for (int i = 0; i < diffDay; i++)
                {
                    this.prevOrders[i] = rand.Next(9500, 10500);
                    this.prevProds[i] = rand.Next(9500, 10500);
                }
            }

            if (prodName == "Milk")
            {
                customerNeed = rand.Next(4750, 5250); ;
                for (int i = 0; i < diffDay; i++)
                {
                    this.prevOrders[i] = rand.Next(4750, 5250);
                    this.prevProds[i] = rand.Next(4750, 5250);
                }
            }

            if (prodName == "SparkWater")
            {
                customerNeed = rand.Next(15000, 16000); ;
                for (int i = 0; i < diffDay; i++)
                {
                    this.prevOrders[i] = rand.Next(15000, 16000);
                    this.prevProds[i] = rand.Next(15000, 16000);
                }
            }

            if (prodName == "StillWater")
            {
                customerNeed = rand.Next(50000, 55000); ;
                for (int i = 0; i < diffDay; i++)
                {
                    this.prevOrders[i] = rand.Next(50000, 55000);
                    this.prevProds[i] = rand.Next(50000, 55000);
                }
            }
        }

        // Getters and setters
        public int getPrevOrder(int diffDay) { return prevOrders[diffDay]; }
        public int getPrevProds(int diffDay) { return prevProds[diffDay]; }
        public int getCustomerNeed() { return customerNeed; }
        public int getOrder() { return order; }
        public string getReqStatus() { return reqStatus; }
        public string getOrderStatus() { return orderStatus; }
        public bool setOrder(int value) { order = value; return true; }
        public bool setReqStatus(string value) { reqStatus = value; return true; }
        public bool setOrderStatus(string value) { orderStatus = value; return true; }

        public void startChrono() { timeProd.Restart(); }
        public TimeSpan elapsedTime() { return timeProd.Elapsed; }
    }


}
