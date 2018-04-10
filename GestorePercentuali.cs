using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Generatore_di_verbale
{
    class GestorePercentuali
    {
        private ViewPercentuali _vp = null;
        private Percentuali percentuali = new Percentuali();

        public GestorePercentuali (ViewPercentuali vp)
        {
            this._vp = vp;
            _vp.BtAggiorna.Click += btAggiorna_Click;

            //carico tutte le percentuali standard
            _vp.TbpProvincia.Text = (percentuali.PProvincia * 100)+"";
            _vp.TbpATC.Text = (percentuali.PATC * 100) + "";
            _vp.TbpComuniInvitati.Text = (percentuali.PComuniInvitati * 100) + "";
            _vp.TbpSassoMorelli.Text = (percentuali.PSassoMorelli * 100) + "";
            _vp.TbpGiardino.Text = (percentuali.PGiardino * 100) + "";
            _vp.TbpSestoImolese.Text = (percentuali.PSestoImolese * 100) + "";
            _vp.TbpSpazzateSassatelli.Text = (percentuali.PSpazzateSassatelli * 100) + "";
        }

        //event handler che gestisce l'aggiornamento delle percentuali
        private void btAggiorna_Click(object sender, EventArgs e)
        {
            int temp = 0;

            if (_vp.TbpProvincia.Text == "")
                MessageBox.Show("Percentuale Provincia mancante");
            else if (!int.TryParse(_vp.TbpProvincia.Text, out temp))
                MessageBox.Show("Percentuale Provincia non numerica");
            else if (_vp.TbpATC.Text == "")
                MessageBox.Show("Percentuale ATC mancante");
            else if (!int.TryParse(_vp.TbpATC.Text, out temp))
                MessageBox.Show("Percentuale ATC non numerica");
            else if (_vp.TbpComuniInvitati.Text == "")
                MessageBox.Show("Percentuale Comuni Invitati mancante");
            else if (!int.TryParse(_vp.TbpComuniInvitati.Text, out temp))
                MessageBox.Show("Percentuale Comuni Invitati non numerica");
            else if (_vp.TbpSassoMorelli.Text == "")
                MessageBox.Show("Percentuale Sasso Morelli mancante");
            else if (!int.TryParse(_vp.TbpSassoMorelli.Text, out temp))
                MessageBox.Show("Percentuale Sasso Morelli non numerica");
            else if (_vp.TbpGiardino.Text == "")
                MessageBox.Show("Percentuale Giardino mancante");
            else if (!int.TryParse(_vp.TbpGiardino.Text, out temp))
                MessageBox.Show("Percentuale Giardino non numerica");
            else if (_vp.TbpSestoImolese.Text == "")
                MessageBox.Show("Percentuale Sesto Imolese mancante");
            else if (!int.TryParse(_vp.TbpSestoImolese.Text, out temp))
                MessageBox.Show("Percentuale Sesto Imolese non numerica");
            else if (_vp.TbpSpazzateSassatelli.Text == "")
                MessageBox.Show("Percentuale Spazzate Sassatelli mancante");
            else if (!int.TryParse(_vp.TbpSpazzateSassatelli.Text, out temp))
                MessageBox.Show("Percentuale Spazzate Sassatelli non numerica");
            else
            {
                percentuali.PProvincia = (float.Parse(_vp.TbpProvincia.Text) / 100);
                percentuali.PATC = float.Parse(_vp.TbpATC.Text) / 100;
                percentuali.PComuniInvitati = float.Parse(_vp.TbpComuniInvitati.Text) / 100;
                percentuali.PSassoMorelli = float.Parse(_vp.TbpSassoMorelli.Text) / 100;
                percentuali.PGiardino = float.Parse(_vp.TbpGiardino.Text) / 100;
                percentuali.PSestoImolese = float.Parse(_vp.TbpSestoImolese.Text) / 100;
                percentuali.PSpazzateSassatelli = float.Parse(_vp.TbpSpazzateSassatelli.Text) / 100;
                percentuali.aggiorna();
                MessageBox.Show("Percentuali aggiornate");
                _vp.Close();
            }
        }
    }
}
