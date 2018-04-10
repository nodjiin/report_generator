using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Generatore_di_verbale
{
    public partial class Facciata : Form
    {
        private Generatore _gen = null;

        public Facciata()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Facciata_Load(object sender, EventArgs e)
        {
            _gen = new Generatore(this);
        }

        private void cChanged(object sender, EventArgs e)
        {

        }

        private void btPercentuali_Click(object sender, EventArgs e)
        {
            ViewPercentuali viewP = new ViewPercentuali();
            viewP.Show();
        }
    }
}
