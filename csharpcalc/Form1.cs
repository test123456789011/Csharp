using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace csharpcalc
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            Expression ex = new Expression();
            string expr = txtExpression.Text;
            lblAnswer.Text = "= " + ex.ParseExpr(ref expr).ToString();
            txtExpression.Text = "";
        }


    }
}
