using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_App
{
    public class Calculator
    {
        public enum OperatorEnum { None, Plus, Minus, Divide, Times }

        public void AddInput(string value)
        {
            int n = 0;
            bool b = int.TryParse(value, out n);
            if (b == true)
            {
                if (this.Factor1 != null && this.Operator != OperatorEnum.None)
                {
                    this.Factor2 = AddInputToFactor(this.Factor2, n);
                }
                else
                {
                    this.Factor1 = AddInputToFactor(this.Factor1, n);
                }

            }
            else
            {
                switch (value.ToLower())
                {
                    case "+":
                        this.Operator = OperatorEnum.Plus;
                        break;
                    case "-":
                        this.Operator = OperatorEnum.Minus;
                        break;
                    case "*":
                    case "x":
                        this.Operator = OperatorEnum.Times;
                        break;
                    case "/":
                    case "\\":
                        this.Operator = OperatorEnum.Divide;
                        break;
                }
            }
        }
        private decimal? AddInputToFactor(decimal? currentval, int newval)
        {
            if (currentval == null || currentval == 0)
            {
                currentval = newval;
            }
            else
            {
                string s = currentval.ToString() + newval.ToString();
                decimal n;
                decimal.TryParse(s, out n);
                currentval = n;
            }
            return currentval;
        }
        public decimal? Calculate()
        {
            decimal? val = 0;
            switch (this.Operator)
            {
                case OperatorEnum.Divide:
                    val = this.Factor1 / this.Factor2;
                    break;
                case OperatorEnum.Times:
                    val = this.Factor1 * this.Factor2;
                    break;
                case OperatorEnum.Minus:
                    val = this.Factor1 - this.Factor2;
                    break;
                case OperatorEnum.Plus:
                    val = this.Factor1 + this.Factor2;
                    break;
            }

            this.Result = val;

            return val;
        }

        public void Clear()
        {
            this.Factor1 = null;
            this.Factor2 = null;
            this.Operator = OperatorEnum.None;
            this.Result = null;
        }

        public string OperatorDisplay
        {
            get
            {
                string val = "";
                switch (this.Operator)
                {
                    case OperatorEnum.Divide:
                        val = "/";
                        break;
                    case OperatorEnum.Times:
                        val = "*";
                        break;
                    case OperatorEnum.Minus:
                        val = "-";
                        break;
                    case OperatorEnum.Plus:
                        val = "+";
                        break;
                }
                return val;
            }
        }
        public string EquationDescription
        {
            get
           {
               return  Factor1.ToString() + " " + OperatorDisplay.ToString() + " " + Factor2.ToString() + "  = " + Result.ToString();
        
            }
        }


        public decimal? Factor1 { get; set; }
        public decimal? Factor2 { get; set; }
        public OperatorEnum Operator { get; set; }
        public decimal? Result { get; private set; }



    }
}
