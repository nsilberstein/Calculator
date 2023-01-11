using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Calculator_App;
namespace CalculatorWinForms
{
    public partial class frmCalculator : Form
    {
        Calculator activecalc;
        Calculator calc1 = new Calculator();
        Calculator calc2 = new Calculator();
        Calculator calc3 = new Calculator();


        public frmCalculator()
        {
            InitializeComponent();
            btn0.Click += BtnEquation_Click;
            btn1.Click += BtnEquation_Click;
            btn2.Click += BtnEquation_Click;
            btn3.Click += BtnEquation_Click;
            btn4.Click += BtnEquation_Click;
            btn5.Click += BtnEquation_Click;
            btn6.Click += BtnEquation_Click;
            btn7.Click += BtnEquation_Click;
            btn8.Click += BtnEquation_Click;
            btn9.Click += BtnEquation_Click;
            btnDivide.Click += BtnEquation_Click;
            btnTimes.Click += BtnEquation_Click;
            btnMinus.Click += BtnEquation_Click;
            btnPlus.Click += BtnEquation_Click;
            btnClear.Click += BtnClear_Click;
            btnEquals.Click += BtnEquals_Click;
            optCalc1.Click += OptCalc1_Click;
            optCalc2.Click += OptCalc2_Click;
            optCalc3.Click += OptCalc3_Click;
            SwitchCalculator(1);

        }
        private void OptCalc3_Click(object? sender, EventArgs e)
        {
            SwitchCalculator(3);
        }

        private void OptCalc2_Click(object? sender, EventArgs e)
        {
            SwitchCalculator(2);     
        }

        private void OptCalc1_Click(object? sender, EventArgs e)
        {
            SwitchCalculator(1);          
        }

        private void DisplayCalculatorValues()
        {
            lblFactor1.Text = activecalc.Factor1.ToString();
            lblFactor2.Text = activecalc.Factor2.ToString();
            lblOperator.Text = activecalc.OperatorDisplay;
            lblFactor3.Text = activecalc.Result.ToString();
            if (activecalc == calc1)
            {
                txtCalc1.Text = activecalc.EquationDescription;
            }
            else if (activecalc == calc2)
            {
                txtCalc2.Text = activecalc.EquationDescription;
            }
            else
            {
                txtCalc3.Text = activecalc.EquationDescription;
            }

        }

        private void InputFactor(string value)
        {
            activecalc.AddInput(value);
            DisplayCalculatorValues();
        }
        private void Calculate()
        {
            activecalc.Calculate();
            DisplayCalculatorValues();
        }
        private void ClearCalculator()
        {
            activecalc.Clear();
            DisplayCalculatorValues();
        }
        private void SwitchCalculator(int value)
        {
            switch (value)
            {
                case 1:
                    activecalc = calc1;
                    break;
                case 2:
                    activecalc = calc2;
                    break;
                case 3:
                    activecalc = calc3;
                    break;

            }
            DisplayCalculatorValues();
        }

        private void BtnEquation_Click(object? sender, EventArgs e)
        {
            InputFactor(((Button)sender).Text);
        }

        private void BtnEquals_Click(object? sender, EventArgs e)
        {
            this.Calculate();
        }

        private void BtnClear_Click(object? sender, EventArgs e)
        {
            this.ClearCalculator();
        }
    }
}
