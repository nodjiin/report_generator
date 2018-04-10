using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Generatore_di_verbale
{
    public partial class ViewPercentuali : Form
    {
        private GestorePercentuali gp = null;

        public ViewPercentuali()
        {
            InitializeComponent();
        }

        private void ViewPercentuali_Load(object sender, EventArgs e)
        {
            gp = new GestorePercentuali(this);
        }

        private void btAnnulla_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btAggiorna_Click(object sender, EventArgs e)
        {

        }
    }
}
