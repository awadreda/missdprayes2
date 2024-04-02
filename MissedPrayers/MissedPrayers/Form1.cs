using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MissedPrayers
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int TotalPraies = 0;
        int numFager, numZahir, numAsair, numMagrub, numAshai = 0;
        int DurrationOFFPerDay = 0;

        DateTime dateOfLastPray = new DateTime();
        DateTime nnOw = DateTime.Now;
        //TimeSpan durrationHostroy = new TimeSpan();

          void CalcTotalPariesManuel()
        {
            TotalPraies = (numFager + numZahir + numAsair + numMagrub + numAshai);
            ViewPraiesToUeser();
        }
        

    void ManualProgress(NumericUpDown nud)
        {
            switch(((nud).Name).ToString())
            {
                case "nudFager":
                    {
                        numFager -= (int)(nud).Value;
                        break;
                    }
                case "nudZohr":
                    {
                        numZahir -= (int)(nud).Value;
                        break;
                    }
                case "nudAsair":
                    {
                        numAsair -= (int)nud.Value;
                        break;
                    }
                case "nudMagrub":
                    {
                        numMagrub-= (int)nud.Value;
                        break;
                    }
                case "nudAsha":
                    {
                        numAshai -= (int)nud.Value;
                        break;
                    }

                 

            }


        }

        void FillVaribls ()
        {
            TotalPraies = DurrationOFFPerDay * 5;
            numFager = DurrationOFFPerDay;
            numZahir = DurrationOFFPerDay;
            numAsair = DurrationOFFPerDay;
            numMagrub = DurrationOFFPerDay;
            numAshai = DurrationOFFPerDay;
            ViewPraiesToUeser();
        }


        void ValidatedHistory( string inputHistory)
        {
            var isValid = DateTime.TryParse(inputHistory, out dateOfLastPray);

            if(isValid)
            {
                DurrationOFFPerDay = nnOw.Subtract(dateOfLastPray).Days;
                //DurrationOFFPerDay = Convert.ToInt32(dateOfLastPray.TimeOfDay);

                FillVaribls();
            }
            else
            {
                MessageBox.Show("Enter Valid Date", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



        }


        void CalcDurrationFromHistory()
        {
            ValidatedHistory(txtHistoryoflastPray.Text);
        }


       void RestartAll()
        {
            TotalPraies = 0;
            numFager = 0; numZahir = 0; numAsair = 0; numMagrub = 0;
            numAshai = 0;

            clsPrayPlan.PrayPlan = 0;
            clsPrayPlan.ActualPrays = 0;
            clsPrayPlan.TheDurationToMakeThePlan = 0;
            clsPrayPlan.totalPraiesToDoBerDay = 0;
            clsPrayPlan.VeiewPlanTOUser(lblFagerPlanPerDay, lblZohrPlanPerDay, lblAserPlanPerDay, lblMagerbPlanPerDay,
                           lblAshaiPlanPerDay, lblTotalPraysINDayPlan); MakenumricZero();

            ViewPraiesToUeser();

            EnabledInput();
            DisableManualTab();
            disableinPutPlan();
            gbChek.Enabled = false;
            tabControl1.Enabled =false;
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            RestartAll();
            
        }

        private void rdDurration_CheckedChanged(object sender, EventArgs e)
        {
            if(rdDurration.Checked)
            {
                lblHistroy.Visible = false;
                txtHistoryoflastPray.Visible = false;
                lblDurration.Visible = true;
                pnlDurration.Visible = true;
            }
           
        }

        private void rdHistroy_CheckedChanged(object sender, EventArgs e)
        {
            if(rdHistroy.Checked)
            {
                lblDurration.Visible = false;
                pnlDurration.Visible = false;
                lblHistroy.Visible = true;
                txtHistoryoflastPray.Visible = true;
            }
          
        }

        private void numericUpDown__ValueChanged(object sender, EventArgs e)
        {
            ManualProgress((NumericUpDown)sender);
        }

        void DisableManualTab()
        {
            gbManul.Enabled = false;    
        }

        void EnableManualTab()
        {
            gbManul.Enabled = true;
            nudFager.Value = 0;
            nudZohr.Value = 0;
            nudAsair.Value = 0;
            nudMagrub.Value = 0;
            nudAsha.Value = 0;

            btnsubmitManual.Enabled = true;
            btnAganiManul.Enabled = true;
            
        }

        void MakenumricZero()
        {
            nudFager.Value = 0;
            nudZohr.Value = 0;
            nudAsair.Value = 0;
            nudMagrub.Value = 0;
            nudAsha.Value = 0;
        }

        private void btnsubmitManual_Click(object sender, EventArgs e)
        {
            CalcTotalPariesManuel();
            MakenumricZero();
            DisableManualTab();
        }

        private void nudFager_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadThePage();
        }

        void LoadThePage()
        {
            lblHistroy.Visible = false;
            txtHistoryoflastPray.Visible = false;
            clsDataBaseLayerMissedPray.GetPrayes(ref TotalPraies, ref numFager, ref numZahir, ref numAsair, ref numMagrub, ref numAshai,
             ref clsPrayPlan.PrayPlan, ref clsPrayPlan.totalPraiesToDoBerDay);
            ViewPraiesToUeser();
            clsPrayPlan.VeiewPlanTOUser(lblFagerPlanPerDay, lblZohrPlanPerDay, lblAserPlanPerDay, lblMagerbPlanPerDay,
                lblAshaiPlanPerDay, lblTotalPraysINDayPlan);
        }


       

        void DisabledInput()
        {
            gbInputMethod.Enabled = false;
            txtHistoryoflastPray.Enabled = false;
            txtDaysOFF.Enabled = false;
            txtMonthsOFf.Enabled = false;
            txtYearsOff.Enabled = false;
        }

        

        private void btnAganiManul_Click_1(object sender, EventArgs e)
        {
            EnableManualTab();
        }

        void disableinPutPlan()
        {
            gbInputPlan.Enabled = false;

        }
         void EnableinPutPlan()
        {
            gbInputPlan.Enabled = true;

        }



        private void btnMakePlan_Click(object sender, EventArgs e)
        {
            clsPrayPlan.ReadTheDurationToMakeThePlan(txtDaysPlan, txtMonthsPlan, txtYearsPlan)
          ;  clsPrayPlan.MakeThePlan(TotalPraies);
            clsPrayPlan.VeiewPlanTOUser(lblFagerPlanPerDay,lblZohrPlanPerDay,lblAserPlanPerDay,lblMagerbPlanPerDay,
                lblAshaiPlanPerDay, lblTotalPraysINDayPlan);
            disableinPutPlan();
        }

        

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        void PraysAfterPlanDays()
        {
            if(chkFager.Checked)
            {
                numFager -= clsPrayPlan.PrayPlan;
            }

            if(chkZohir.Checked)
            {
                numZahir -= clsPrayPlan.PrayPlan;
            }

            if(chkAsar.Checked)
            {
                numAsair -= clsPrayPlan.PrayPlan;
            }

            if(chkMagrb.Checked)
            {
                numMagrub -= clsPrayPlan.PrayPlan;
            }

            if(chkAsha.Checked)
            {
                numAshai -= clsPrayPlan.PrayPlan;
            }

            CalcTotalPariesManuel();

        }

        void UnCheckedCheckBox()
        {
            chkFager.Checked = false;
            chkZohir.Checked = false;
            chkAsar.Checked = false;
            chkMagrb.Checked = false;
            chkAsha.Checked = false;
        }

        private void btnSumbitDayPlans_Click(object sender, EventArgs e)
        {

            PraysAfterPlanDays();
            UnCheckedCheckBox();
        }

        private void chkPray_CheckedChanged(object sender, EventArgs e)
        {
            clsPrayPlan.calcActualProgress((CheckBox)sender);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        void SaveAll()
        {
           if( clsDataBaseLayerMissedPray.UpdatePrayes(ref TotalPraies, ref numFager, ref numZahir, ref numAsair, ref numMagrub, ref numAshai,
             ref clsPrayPlan.PrayPlan, ref clsPrayPlan.totalPraiesToDoBerDay))

            {
                MessageBox.Show("تم الحفظ ", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("لم يتم الحفظ هناك مشكلة ", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void btnSaved_Click(object sender, EventArgs e)
        {
            SaveAll();
        }

        void makeBackGroundNone()
        {
            label1.BackColor = Color.Transparent;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void lblMagrub_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void lblAshia_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void lblFager_Click(object sender, EventArgs e)
        {

        }

        private void lblAsar_Click(object sender, EventArgs e)
        {

        }

        private void gbManul_Enter(object sender, EventArgs e)
        {

        }

        void EnabledInput()
        {
            gbInputMethod.Enabled =          true;
            txtHistoryoflastPray.Enabled =   true;
            txtDaysOFF.Enabled =             true;
            txtMonthsOFf.Enabled =           true;
            txtYearsOff.Enabled =            true;
        }

        
        
        

        private void btnCalcTotalParies_Click(object sender, EventArgs e)
        {
            if(rdDurration.Checked)
            {

                CalcDurrationAndParyies();
            }else if(rdHistroy.Checked)
            {
                CalcDurrationFromHistory();
            }

            DisabledInput();
            EnableManualTab();
            gbChek.Enabled = true;
            gbInputPlan.Enabled = true;
            
            tabControl1.Enabled = true;
        }


        void CalcDurrationAndParyies()
        {
            if (txtDaysOFF.Text == "")
                txtDaysOFF.Text = "0";

            if (txtMonthsOFf.Text == "")
                txtMonthsOFf.Text = "0";

            if (txtYearsOff.Text == "")
                txtYearsOff.Text = "0";

            DurrationOFFPerDay = Convert.ToInt32(txtDaysOFF.Text) + 
                (30 * Convert.ToInt32(txtMonthsOFf.Text)) +
                (365 * Convert.ToInt32(txtYearsOff.Text));
            FillVaribls();
        }





        void ViewPraiesToUeser()
        {
            lblTotalParies.Text = TotalPraies.ToString();
            lblFager.Text = numFager.ToString();
            lblZahr.Text = numZahir.ToString();
            lblAsar.Text = numAsair.ToString();
            lblMagrub.Text = numMagrub.ToString();
            lblAshia.Text = numAshai.ToString();
        }


    }
}
