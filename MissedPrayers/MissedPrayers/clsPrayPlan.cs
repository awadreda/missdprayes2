using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MissedPrayers
{
   public static  class clsPrayPlan 
    {

       
       public static int TheDurationToMakeThePlan = 0;
        public static int totalPraiesToDoBerDay = 0;
        public static  int  PrayPlan = 0;
        public static int ActualPrays = 0;

     public static   void ReadTheDurationToMakeThePlan(MaskedTextBox day,MaskedTextBox Month,MaskedTextBox Year)
        {
            if (day.Text == "")
                day.Text = "0";

            if (Month.Text == "")
                Month.Text = "0";

            if (Year.Text == "")
                Year.Text = "0";
 TheDurationToMakeThePlan = Convert.ToInt32(day.Text) + Convert.ToInt32(Month.Text) * 30 + Convert.ToInt32(Year.Text) * 365;
    

        }


        public static void calcActualProgress(CheckBox chk)
        {
            if(chk.Checked)
            {
                ActualPrays += PrayPlan;

               
            }

        }


        public static  void MakeThePlan(int TotalPraies)
        {
            totalPraiesToDoBerDay = TotalPraies / TheDurationToMakeThePlan;
            PrayPlan = totalPraiesToDoBerDay / 5;
            
            
            
 }


        public static void VeiewPlanTOUser(Label lblPrayPlan, Label lblPrayPlan2, Label lblPrayPlan3,
            Label lblPrayPlan4, Label lblPrayPlan5, Label lblTotalPrayPlanPerDay )
        {
            lblTotalPrayPlanPerDay.Text = totalPraiesToDoBerDay.ToString();
            lblPrayPlan.Text = PrayPlan.ToString();
            lblPrayPlan2.Text = PrayPlan.ToString();
            lblPrayPlan3.Text = PrayPlan.ToString();
            lblPrayPlan4.Text = PrayPlan.ToString();
            lblPrayPlan5.Text = PrayPlan.ToString();

        }

        public static void SubmtTheDayRebort(ref int TotalPraies,ref int fager, ref int Zohr, ref int Asar, ref int Magrub, ref int Ashai)
        {
            TotalPraies -= ActualPrays;
            fager -= PrayPlan;
            Zohr -= PrayPlan;
            Asar -= PrayPlan;
            Magrub -= PrayPlan;
            Ashai -= PrayPlan;
        }


        

    }
}
