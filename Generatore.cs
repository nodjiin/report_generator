using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Excel = Microsoft.Office.Interop.Excel;

namespace Generatore_di_verbale
{
    class Generatore
    {
        private Facciata _facciata = null;
        public Generatore (Facciata facciata)
        {
            _facciata = facciata;
            _facciata.Label7.Hide();
            _facciata.TbComuniInvitati.Hide();
            _facciata.TbComuniInvitati.ReadOnly = true;
            _facciata.Button.Click += button1_Click;
            _facciata.RbSi.CheckedChanged += cChanged;
        }

        //event handler che gestisce il cambio di check di "si" e "no"
        private void cChanged(object sender, EventArgs e)
        {
            if(_facciata.RbSi.Checked == true)
            {
                _facciata.Label7.Show();
                _facciata.TbComuniInvitati.Show();
                _facciata.TbComuniInvitati.ReadOnly = false;
            }
            else
            {
                _facciata.Label7.Hide();
                _facciata.TbComuniInvitati.Hide();
                _facciata.TbComuniInvitati.ReadOnly = true;
                _facciata.TbComuniInvitati.Text = "";
            } 
        }

        //event handler che gestisce il click di "genera verbale"
        private void button1_Click(object sender, EventArgs e)
        {
            int nMaschi = 0;
            int nFemmine = 0;

            //controlli sull'input
            if (_facciata.TbNomeVerbale.Text == "")
            {
                MessageBox.Show("Nome del verbale mancante!");
            }
            else if (_facciata.TbDataCattura.Text == "")
            {
                MessageBox.Show("Data della cattura mancante!");
            }
            else if (_facciata.TbComune.Text == "")
            {
                MessageBox.Show("Nome del comune mancante!");
            }
            else if (_facciata.TbZonaCatturata.Text == "")
            {
                MessageBox.Show("Nome della zona di cattura mancante!");
            }
            else if (_facciata.RbSi.Checked == true && _facciata.TbComuniInvitati.Text == "")
            {
                MessageBox.Show("Nome del comune invitato mancante!");
            }
            else if (_facciata.TbMaschi.Text == "")
            {
                MessageBox.Show("Numero dei maschi mancante!");
            }
             else if (!int.TryParse(_facciata.TbMaschi.Text,out nMaschi))
             {
                 MessageBox.Show("valore dei maschi non numerico");
             }
            else if (_facciata.TbFemmine.Text == "")
            {
                MessageBox.Show("Numero delle femmine mancante!");
            }
            else if (!int.TryParse(_facciata.TbFemmine.Text, out nFemmine))
            {
                MessageBox.Show("valore delle femmine non numerico");
            }
            else
            {
                //genero il verbale
                Verbale verbale = generaVerbale(_facciata.TbDataCattura.Text, _facciata.TbComune.Text,
                    _facciata.TbZonaCatturata.Text,_facciata.TbComuniInvitati.Text, nMaschi, nFemmine);

                //genero il file in Excell
                generaExcell(_facciata.TbNomeVerbale.Text, verbale);
               
            }
            
        }

        private Verbale generaVerbale(String data, String comune, String zona, 
            String comuniInvitati, int maschi, int femmine)
        {
            Percentuali perc = new Percentuali();

            //calcolo le percentuali per i maschi
            float provinciam = maschi * perc.PProvincia;
            float ATCm = maschi * perc.PATC;
            int maschi1 = maschi - ((int)provinciam + (int)ATCm);
            float comuniInvm = 0;
            if(comuniInvitati != "" && _facciata.RbSi.Checked == true)
                comuniInvm = maschi1 * perc.PComuniInvitati;
            int maschi2 = maschi1 - (int)comuniInvm;
            float sassoMorellim = maschi2 * perc.PSassoMorelli;
            float giardinom = maschi2 * perc.PGiardino;
            float sestoImolesem = maschi2 * perc.PSestoImolese;
            float spazzatem = maschi2 * perc.PSpazzateSassatelli;
            float totalim = sassoMorellim + giardinom + sestoImolesem + spazzatem;

            //calcolo le percentuali per le femmine
            float provinciaf = femmine * perc.PProvincia;
            float ATCf = femmine * perc.PATC;
            int femmine1 = femmine - ((int)provinciaf + (int)ATCf);
            float comuniInvf = 0;
            if (comuniInvitati != "" && _facciata.RbSi.Checked == true)
                comuniInvf = femmine1 * perc.PComuniInvitati;
            int femmine2 = femmine1 - (int)comuniInvf;
            float sassoMorellif = femmine2 * perc.PSassoMorelli;
            float giardinof = femmine2 * perc.PGiardino;
            float sestoImolesef = femmine2 * perc.PSestoImolese;
            float spazzatef = femmine2 * perc.PSpazzateSassatelli;
            float totalif = sassoMorellif + giardinof + sestoImolesef + spazzatef;

            return new Verbale(data, comune, zona, comuniInvitati, maschi, femmine,
                provinciam, ATCm, comuniInvm, sassoMorellim, giardinom, sestoImolesem, spazzatem, totalim,
                provinciaf, ATCf, comuniInvf, sassoMorellif, giardinof, sestoImolesef, spazzatef, totalif);
        } 

        //deve gestire la storia dei comuni invitati presenti o no
        private void generaExcell(String nomeVerbale,Verbale verbale)
        {
            
            Percentuali perc = new Percentuali();

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            nomeVerbale = path + "\\" + nomeVerbale + ".xls";

            //file excel originale, situato nel folder dell'eseguibili
            var m_TemplateFileName = System.IO.Path.GetDirectoryName(Application.ExecutablePath) 
                + "\\modello_verbale.xls";

            //nome del foglio
            var m_InputWorkSheetName = "07.12.2013";
            var application = new Excel.Application();
            var workBook = application.Workbooks.Open(m_TemplateFileName);
            var inputWorkSheet = workBook.Worksheets.Cast<Excel.Worksheet>().Where(w => w.Name == m_InputWorkSheetName).FirstOrDefault();

            //compilazione del verbale
            inputWorkSheet.Cells.SetValue("C6", verbale.DataCattura);
            inputWorkSheet.Cells.SetValue("E6", verbale.Comune);
            inputWorkSheet.Cells.SetValue("C8", verbale.ZonaCatturata);
            //prima tabella
            inputWorkSheet.Cells.SetValue("C14", (verbale.Maschi + verbale.Femmine) + "");
            inputWorkSheet.Cells.SetValue("D14", verbale.Maschi + "");
            inputWorkSheet.Cells.SetValue("E14", verbale.Femmine + "");
            inputWorkSheet.Cells.SetValue("D17", verbale.ConsegnateProvm + "");
            inputWorkSheet.Cells.SetValue("E17", verbale.ConsegnateProvf + "");
            inputWorkSheet.Cells.SetValue("D19", verbale.ConsegnateATCm + "");
            inputWorkSheet.Cells.SetValue("E19", verbale.ConsegnateATCf + "");
            //seconda tabella
            inputWorkSheet.Cells.SetValue("A25", _facciata.TbComuniInvitati.Text);
            inputWorkSheet.Cells.SetValue("D28", verbale.ConsegnateComuniInvitatim + "");
            inputWorkSheet.Cells.SetValue("E28", verbale.ConsegnateComuniInvitatif + "");
            //terza tabella
            inputWorkSheet.Cells.SetValue("D40", verbale.ConsegnateSassoMorellim + "");
            inputWorkSheet.Cells.SetValue("E40", verbale.ConsegnateSassoMorellif + "");
            inputWorkSheet.Cells.SetValue("D42", verbale.ConsegnateGiardinom + "");
            inputWorkSheet.Cells.SetValue("E42", verbale.ConsegnateGiardinof + "");
            inputWorkSheet.Cells.SetValue("D44", verbale.ConsegnateSestoImolesem + "");
            inputWorkSheet.Cells.SetValue("E44", verbale.ConsegnateSestoImolesef + "");
            inputWorkSheet.Cells.SetValue("D46", verbale.ConsegnateSpazzateSassatellim + "");
            inputWorkSheet.Cells.SetValue("E46", verbale.ConsegnateSpazzateSassatellif + "");

            //percentuali
            inputWorkSheet.Cells.SetValue("B16", (perc.PProvincia * 100) + "");
            inputWorkSheet.Cells.SetValue("B18", (perc.PATC * 100) + "");
            inputWorkSheet.Cells.SetValue("B26", (perc.PComuniInvitati * 100) + "");
            inputWorkSheet.Cells.SetValue("B39", (perc.PSassoMorelli * 100) + "");
            inputWorkSheet.Cells.SetValue("B41", (perc.PGiardino * 100) + "");
            inputWorkSheet.Cells.SetValue("B43", (perc.PSestoImolese * 100) + "");
            inputWorkSheet.Cells.SetValue("B45", (perc.PSpazzateSassatelli * 100) + "");

            try
            {
                //salvataggio in un file nuovo
                object misValue = System.Reflection.Missing.Value;
                workBook.SaveAs(nomeVerbale, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                MessageBox.Show("verbale generato sul vostro desktop");
            } 
            catch(Exception ex)
            {
                MessageBox.Show("verbale non generato");
            }
            workBook.Close(false);
            application.Quit();
        }
    }
}

public static class Extensions
{
    public static void SetValue(this Excel.Range range, String cellAddress, object value)
    {
        var cell = range.get_Range(cellAddress);
        Object[] args1 = new Object[1];
        args1[0] = value;
        cell.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, cell, args1);
    }
}
