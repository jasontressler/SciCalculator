using System;
using System.Linq;
using System.Windows.Forms;

namespace Calculator {
    public partial class Calculator : Form {
        delegate double Scientific(double op1);
        delegate double Calculation(double op1, double op2);
        private bool isDirty = true;
        double op1 = 0, op2 = 0;
        string opr = "n";
        public Calculator() {
            InitializeComponent();
        }       
        // Number click handler
        private void Btn_Click(object sender, EventArgs e) {
            if (isDirty) {
                text.Clear();
                isDirty = false;
            }
            text.Text += toButton(sender).Text;
        }
        // Decimal click handler
        private void Dec_Click(object sender, EventArgs e) {
            if (text.Text.Equals("0")) {
                text.Text = "0.";
                isDirty = false;
            }
            else if (text.Text.Contains(".")) {
                // do nothing
            }
            else {
                text.Text += ".";
            }
        }
        // Operator click handler
        private void Opr_Click(object sender, EventArgs e) {
            opr = toButton(sender).Text;
            op1 = Convert.ToDouble(text.Text);
            isDirty = true;
        }
        // Equal click handler
        private void Equal_Click(object sender, EventArgs e) {
            Calculation calc;
            if(!isDirty)
                op2 = Convert.ToDouble(text.Text);
            switch (opr) {
                case "+":
                    calc = add;
                    break;
                case "-":
                    calc = sub;
                    break;
                case "*":
                    calc = mul;
                    break;
                case "/":
                    calc = div;
                    break;
                case "xʸ":
                    calc = exp;
                    break;
                default:
                    //TODO
                    calc = add;
                    break;
            }
            op1 = calc(op1, op2);
            dispResult();
        }
        private void Scientific_Click(object sender, EventArgs e) {
            op1 = Convert.ToDouble(text.Text);
            Button btn = toButton(sender);
            if (btn == btnSin) { op1 = Math.Sin(op1); }
            else if (btn == btnCos) { op1 = Math.Cos(op1); }
            else if (btn == btnTan) { op1 = Math.Tan(op1); }
            else if (btn == btnLog) { op1 = Math.Log(op1); }
            else if (btn == btnRad) { op1 = Math.Sqrt(op1); }
            else if (btn == btnSqr) { op1 = Math.Pow(op1, 2); }
            else if (btn == btnFac) {
                for (double x = op1-1; x > 0; x-=1) {
                    op1 *= x;
                }
            }
            dispResult();
        }
        // Operations
        public static double add(double op1, double op2) {
            return op1 + op2;
        }
        public static double sub(double op1, double op2) {
            return op1 - op2;
        }
        public static double mul(double op1, double op2) {
            return op1 * op2;
        }
        public static double div(double op1, double op2) {
            return op1 / op2;
        }
        public static double exp(double op1, double op2) {
            return Math.Pow(op1, op2);
        }
        // C button
        private void C_Click(object sender, EventArgs e) {
            op1 = 0;
            op2 = 0;
            opr = "n";
            text.Text = "0";
            isDirty = true;
        }
        // CE button
        private void CE_Click(object sender, EventArgs e) {
            text.Text = "0";
            isDirty = true;
        }

        
        // Convert object to button
        private Button toButton(object sender) {
            return (Button)sender;
        }

        

        // Display result
        private void dispResult() {
            text.Text = op1.ToString();
            isDirty = true;
        }

    }
}
