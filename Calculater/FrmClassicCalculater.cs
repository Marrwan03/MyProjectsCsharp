using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDI_Container
{
    public partial class FrmClassicCalculater : Form
    {
        public FrmClassicCalculater()
        {
            InitializeComponent();
        }
        stCalculate Calculate;
    
        

        enum enOperationType
        {
            enSum,
            enSub,
            enMul,
            enDiv,
            enRest
        }
        struct stCalculate
        {
            public string Number1, Number2, Result, CopyNumber;
            public bool TurnNumber2, DeleteNumber2, NumberFirst, MultiOpType, UsedPoint, FindPoint1, UsedPlusOrMines;
            public enOperationType OpType;

        };
      

        float SimpleCalculate(float Number1, float Number2, Label lblOperationType)
        {
            switch (lblOperationType.Text)
            {
                case "+":

                    return Number1 + Number2;

                case "-":
                    return Number1 - Number2;

                case "/":
                    return Number1 / Number2;

                case "*":
                    return Number1 * Number2;

                case "%":
                    return Number1 % Number2;

                default:
                    return 0;

            }
        }
        void RefreshCalculate()
        {
            Calculate.Number1 = null;
            Calculate.Number2 = null;
            Calculate.Result = null;
            Calculate.NumberFirst = false;
            Calculate.TurnNumber2 = false;
            Calculate.UsedPoint = false;
            lblNumber1WhenEqual.Visible = false;
            lblEqual.Visible = false;

            lblNumber1.Text = "Null";
            lblNumber2.Text = "";
            lblOpType.Text = "";
            lblNumber1.Tag = "Null";
            lblNumber2.Tag = "Null";
        }

        void SolioutionPointNumber1()
        {
            if (string.IsNullOrEmpty(Calculate.Number1))
            {
                Calculate.Number1 = "0.";
                Calculate.UsedPoint = true;
                return;
            }

            if (CheckPoint1(Calculate.Number1))
            {
                return;
            }
            else
            {
                Calculate.Number1 += ".";
                Calculate.UsedPoint = true;
            }

        }

        void SolioutionPointNumber2()
        {
            if (string.IsNullOrEmpty(Calculate.Number2))
            {
                Calculate.Number2 = "0.";
                Calculate.UsedPoint = true;
                return;
            }

            //Calculate.UsedPoint ||
            if (CheckPoint1(Calculate.Number2))
            {
                return;
            }
            else
            {
     
                Calculate.Number2 += ".";
                Calculate.UsedPoint = true;
            }

        }


        void WhenPressNumbers(Button btn)
        {
            

            if (Calculate.TurnNumber2)
            { 
                lblNumber2.Tag = "NotNull";
               if (Calculate.DeleteNumber2)
               {
                   Calculate.Number2 = "";
                   Calculate.DeleteNumber2 = false;
               }

                if (btn.Tag.ToString() == ".")
                {
                    SolioutionPointNumber2();
                }
                else
                {
                    Calculate.Number2 += btn.Tag.ToString();
                }

                lblNumber1.Text = Calculate.Number2;
                Calculate.MultiOpType = false;
            }
            else
            {
                

                Calculate.NumberFirst = true;
                lblNumber1.Tag = "NotNull";

                if (btn.Tag.ToString() == ".")
                {
                    SolioutionPointNumber1();
                }
                else
                {
                    Calculate.Number1 += btn.Tag.ToString();
                }

                lblNumber1.Text = Calculate.Number1;
            }
        }

        void CalculateResult()
        {
            Calculate.Result = SimpleCalculate(Convert.ToSingle(Calculate.Number1), Convert.ToSingle(Calculate.Number2), lblOpType).ToString();

            Calculate.DeleteNumber2 = true;
        }



        void FillOperation(string OpType)
        {
            //Reset to using Point(.)
            Calculate.UsedPoint = false;

            //Reset to using PlusOrMines( +/- )
            Calculate.UsedPlusOrMines = false;

            if (Calculate.MultiOpType)
            {
                lblOpType.Text = OpType;
                Calculate.TurnNumber2 = true;
               
                return;
            }

            //in firs insert
            lblOpType.Text = OpType;
            Calculate.TurnNumber2 = true;
        }

        void Changelabel()
        {
            if (Calculate.MultiOpType)
            {
                return;
            }
            lblNumber2.Text = lblNumber1.Text;
            lblNumber1.Text = "";
            if (!Calculate.MultiOpType)
            {
                if (IsFullData())
                {
                    CalculateResult();
                    AddCalculateInHistory(Calculate.Number1, Calculate.Number2, Calculate.Result, lblOpType.Text);
                    Calculate.Number1 = Calculate.Result;
                    
                    lblNumber2.Text = Calculate.Result;
                }
                Calculate.MultiOpType = true;
                return;
            }

        }

        void WhenPressOperation(enOperationType OpType)
        {
            if (!Calculate.NumberFirst)
            {
                return;
            }
           
            Changelabel();
            switch (OpType)
            {
                case enOperationType.enSum:
                    FillOperation("+");
                    return;

                case enOperationType.enSub:
                    FillOperation("-");
                    return;

                case enOperationType.enMul:
                    FillOperation("*");
                    return;

                case enOperationType.enDiv:
                    FillOperation("/");
                    return;
                case enOperationType.enRest:
                    FillOperation("%");
                    return;
            }

        }

        bool IsFullData()
        {
            if (lblNumber1.Tag.ToString() != "Null" && lblNumber2.Tag.ToString() != "Null")
            {
                return true;
            }
            return false;
        }

        void WhenPressEqual()
        {
            if (lblNumber1.Tag.ToString() == "Null" || lblNumber1.Text == "")
            {
                if (MessageBox.Show("You should Fill (Number1 Or Number2 Or OperationType)", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    return;
                }
            }
            else
            {
                Calculate.TurnNumber2 = false;
                Calculate.Result = SimpleCalculate(Convert.ToSingle(Calculate.Number1), Convert.ToSingle(Calculate.Number2), lblOpType).ToString();
                lblNumber1WhenEqual.Visible = true;
                lblNumber1WhenEqual.Text = Calculate.Number2;
                lblEqual.Visible = true;
                lblEqual.Text = "=";

                lblNumber1.Text = Calculate.Result;


                if (MessageBox.Show("Result of calculate is : " + Calculate.Result, "Result", MessageBoxButtons.OK) == DialogResult.OK)
                {
                    AddCalculateInHistory(Calculate.Number1, Calculate.Number2, Calculate.Result, lblOpType.Text);
                    RefreshCalculate();
                }
            }
        }
        void WhenPressClear()
        {
          RefreshCalculate();
        }

        bool CheckPoint1(string Number)
        {
            string ZeroWithPoint = default;
            for (int i = 0; i <= Number.Length - 1; i++)
            {
                if (i != Number.Length - 1)
                {
                    ZeroWithPoint = Number[i].ToString() + Number[i + 1].ToString();
                }

                if (Number[i] == '.' || "0." == ZeroWithPoint)
                {
                    //Calculate.UsedPoint = false;
                    //Calculate.FindPoint1 = true;
                    return true;
                }
            }
            return false;
        }

      

        void WhenPressDelete()
        {
           
            if (Calculate.TurnNumber2)
            {
                if (string.IsNullOrEmpty(Calculate.Number2))
                {
       
                    return; 
                }
                Calculate.Number2 = Calculate.Number2.Substring(0, Calculate.Number2.Length - 1);
                lblNumber1.Text = Calculate.Number2;
            }
            else
            {
                if (string.IsNullOrEmpty(Calculate.Number1))
                {
                   
                    return; 
                }
                Calculate.Number1 = Calculate.Number1.Substring(0, Calculate.Number1.Length - 1);
                lblNumber1.Text = Calculate.Number1;
            }
        }

        void WhenPressCE()
        {
            if (Calculate.TurnNumber2)
            {
                if (string.IsNullOrEmpty(Calculate.Number2))
                {
                    return;
                }
                Calculate.Number2 = "";
                lblNumber1.Text = Calculate.Number2;
            }
            else
            {
                if (string.IsNullOrEmpty(Calculate.Number1))
                {
                    return;
                }
                Calculate.Number1 = "";
                lblNumber1.Text = Calculate.Number1;
            }
        }

        void WhenPressPlusOrMines()
        {
            if (Calculate.TurnNumber2)
            {
                if (string.IsNullOrEmpty(Calculate.Number2))
                {
                    return;
                }
                if(!Calculate.UsedPlusOrMines)
                {
                    Calculate.Number2 = Calculate.Number2.Insert(0, "-");
                    Calculate.UsedPlusOrMines = true;
                }
                else
                {
                    Calculate.Number2 = Calculate.Number2.Substring(1, Calculate.Number2.Length - 1);
                    Calculate.UsedPlusOrMines = false;
                }
               
                lblNumber1.Text = Calculate.Number2;
            }
            else
            {
                if (string.IsNullOrEmpty(Calculate.Number1))
                {
                    return;
                }
                if (!Calculate.UsedPlusOrMines)
                {
                    Calculate.Number1 = Calculate.Number1.Insert(0, "-");
                    Calculate.UsedPlusOrMines = true;
                }
                else
                {
                    Calculate.Number1 = Calculate.Number1.Substring(1, Calculate.Number1.Length - 1);
                    Calculate.UsedPlusOrMines = false;
                }

                lblNumber1.Text = Calculate.Number1;
            }
        }

      

        void AddCalculateInHistory(string Number1, string Number2, string Result, string OpType)
        {
            string Calulate = Number1 + "  " + OpType + "  " + Number2;
            clbHistory.Items.Add(Calulate + " = " + Result);
        }

       void DeleteCalculateInHistory()
        {
            if(MessageBox.Show("Are you sure,\nDo you want delete this calculate?", "Delete!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes) 
            {
                clbHistory.Items.Remove(clbHistory.SelectedItem);
                if(MessageBox.Show("operation accomplished successfully", "Successfully :-)", MessageBoxButtons.OK) == DialogResult.OK)
                {
                    return;
                }
            }
            else
            {
                return;
            }
        }

        void Copy()
        {
            if (Calculate.TurnNumber2)
            {
                Calculate.CopyNumber = Calculate.Number2;
                Calculate.Number2 = Calculate.CopyNumber;
                return;
            }
            else
            {
                Calculate.CopyNumber = Calculate.Number1;
               
                return;
            }
        }

        void Paste()
        {
            if(Calculate.TurnNumber2)
            {
                lblNumber2.Tag = "NotNull";
                Calculate.Number2 = Calculate.CopyNumber;
                lblNumber1.Text = Calculate.Number2;
                Calculate.MultiOpType = false;
                return;
            }
            else
            {
                lblNumber1.Tag = "NotNull";
                Calculate.Number1 = Calculate.CopyNumber;
                lblNumber1.Text = Calculate.Number1;
                return;
            }

        }

        void DoubleNumber()
        {
            if (Calculate.TurnNumber2)
            {
                double result = Math.Pow(Convert.ToDouble(Calculate.Number2), 2);
                if (MessageBox.Show("The result will be [ "+result.ToString() + " ]\nDo you agree?", "Double Number",MessageBoxButtons.YesNo, MessageBoxIcon.Question,MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    Calculate.Number2 = result.ToString();
                    lblNumber1.Text = Calculate.Number2;
                    return;
                }
            }
            else
            {
                double result = Math.Pow(Convert.ToDouble(Calculate.Number1), 2);
                if (MessageBox.Show("The result will be [ " + result.ToString() + " ]\nDo you agree?", "Double Number", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    Calculate.Number1 = result.ToString();
                    lblNumber1.Text = Calculate.Number1;
                    return;
                }
            }
        }
        void SqrtNumber()
        {
            if (Calculate.TurnNumber2)
            {
                double result = Math.Sqrt(Convert.ToDouble(Calculate.Number2));
                if (MessageBox.Show("The result will be [ " + result.ToString() + " ]\nDo you agree?", "Sqrt Number", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    Calculate.Number2 = result.ToString();
                    lblNumber1.Text = Calculate.Number2;
                    return;
                }
            }
            else
            {
                double result = Math.Sqrt(Convert.ToDouble(Calculate.Number1));
                if (MessageBox.Show("The result will be [ " + result.ToString() + " ]\nDo you agree?", "Sqrt Number", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    Calculate.Number1 = result.ToString();
                    lblNumber1.Text = Calculate.Number1;
                    return;
                }
            }
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            WhenPressEqual();
        }

        private void btnNumber_Click(object sender, EventArgs e)
        {
            WhenPressNumbers((Button)sender);
        }

        private void lblOpType_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            WhenPressClear();
        }

        private void btnSum_Click(object sender, EventArgs e)
        {
            WhenPressOperation(enOperationType.enSum);
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            WhenPressOperation(enOperationType.enSub);
        }

        private void btnMul_Click(object sender, EventArgs e)
        {
            WhenPressOperation(enOperationType.enMul);
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            WhenPressOperation(enOperationType.enDiv);
        }

        private void lblNumber2_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            WhenPressDelete();
        }

     
        private void FrmClassicCalculater_Load(object sender, EventArgs e)
        {

        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            WhenPressCE();
        }

        private void btnRest_Click(object sender, EventArgs e)
        {
            WhenPressOperation(enOperationType.enRest);
        }

        private void btnPlusOrMines_Click(object sender, EventArgs e)
        {
            WhenPressPlusOrMines();
        }

     

       

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteCalculateInHistory();
        }

      
        private void pasteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Paste();
            
        }

     

       

        private void clbHistory_MouseEnter(object sender, EventArgs e)
        {
            if (clbHistory.Items.Count <= 0)
            {
                deleteAllToolStripMenuItem.Enabled = false;
                deleteToolStripMenuItem.Enabled = false;
            }
            else
            {
                deleteAllToolStripMenuItem.Enabled = true;
                deleteToolStripMenuItem.Enabled = true;
            }

        }

        private void deleteAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
          clbHistory.Items.Clear();
        }

        private void CopyToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Copy();
            pasteToolStripMenuItem.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DoubleNumber();
        }

        private void btnSqrt_Click(object sender, EventArgs e)
        {
            SqrtNumber();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void gbCalculater_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void clbHistory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
