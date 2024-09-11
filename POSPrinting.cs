using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPLS_Software
{
    public partial class POSPrinting : Form
    {
        string transDate;
        string attendantName;
        string customerName;
        string customerAddress;
        string customerNumber;
        string mix;
        string weightWhite;
        string weightColored;
        string weightTotal;
        string expense1;
        string expense2;
        string expense3;
        string expense4;
        string expense5;
        string expense6;
        string totalPrice;
        string paymentMode;
        string unpaidAmount;
        string hashCode;
        string loadNumber;
        string paidAmount;
        int tagsAmount;
        int n;
        string userLevel;
        public POSPrinting(string username, string cName, string cAddress, string cNumber, string m, string ww,
            string wc, string wt, string wash, string washQ, string washP, string dry, string dryQ, string dryP,
            string det, string detQ, string detP, string cond, string condQ, string condP, string serv, string servP,
            string bagQ, string bagP, string totalP, string pMode, string uAmount, string pAmount, string tAmount,
            string hash, string userLvl)
        {
            InitializeComponent();
            transDate = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongDateString();
            attendantName = username;
            customerName = cName;
            customerAddress = cAddress;
            customerNumber = cNumber;
            mix = m;
            weightWhite = ww;
            weightColored = wc;
            weightTotal = wt;
            expense1 = wash + " (" + washQ + " LOAD/S) = " + washP;
            expense2 = dry + " (" + dryQ + " LOAD/S) = " + dryP;
            expense3 = det + " (" + detQ + " PIECE/S) = " + detP;
            expense4 = cond + " (" + condQ + " PIECE/S) = " + condP;
            expense5 = "LAUNDRY PLASTIC BAG (" + bagQ + " PIECE/S) = " + bagP;
            expense6 = serv + " = " + servP;
            totalPrice = totalP;
            paymentMode = pMode;
            unpaidAmount = uAmount;
            paidAmount = pAmount;
            hashCode = hash;
            tagsAmount = int.Parse(tAmount);
            userLevel = userLvl;
        }
        private void print(string copy)
        {
            if (userLevel == "Admin")
            {

            }
        }
    }
}
