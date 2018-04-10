using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Generatore_di_verbale
{
    //classe contenente tutte le percentuali utilizzate
    class Percentuali
    {
        private float _pProvincia;
        private float _pATC;
        private float _pComuniInvitati;
        private float _pSassoMorelli;
        private float _pGiardino;
        private float _pSestoImolese;
        private float _pSpazzateSassatelli;
        private XmlTextReader reader;

        public Percentuali()
        {
            reader = new XmlTextReader(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\percentuali.xml");
            string sName = "";
            try
            { 
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            sName = reader.Name;
                            break;
                        case XmlNodeType.Text:
                            switch (sName)
                            {
                                case "Provincia":
                                    _pProvincia = float.Parse(reader.Value);
                                    break;
                                case "ATC":
                                    _pATC = float.Parse(reader.Value);
                                    break;
                                case "ComuniInvitati":
                                    _pComuniInvitati = float.Parse(reader.Value);
                                    break;
                                case "SassoMorelli":
                                    _pSassoMorelli = float.Parse(reader.Value);
                                    break;
                                case "Giardino":
                                    _pGiardino = float.Parse(reader.Value);
                                    break;
                                case "SestoImolese":
                                    _pSestoImolese = float.Parse(reader.Value);
                                    break;
                                case "SpazzateSassatelli":
                                    _pSpazzateSassatelli = float.Parse(reader.Value);
                                    break;
                            }
                            break;
                    }
                }
            }
            catch(Exception ex)
            {
                Console.Write(ex.ToString());
            }
            reader.Close();
        }

        public float PProvincia
        {
            get { return _pProvincia; }
            set { _pProvincia = value; }
        }

        public float PATC
        {
            get { return _pATC; }
            set { _pATC = value; }
        }

        public float PComuniInvitati
        {
            get { return _pComuniInvitati; }
            set { _pComuniInvitati = value; }
        }

        public float PSassoMorelli
        {
            get { return _pSassoMorelli; }
            set { _pSassoMorelli = value; }
        }

        public float PGiardino
        {
            get { return _pGiardino; }
            set { _pGiardino = value; }
        }

        public float PSestoImolese
        {
            get { return _pSestoImolese; }
            set { _pSestoImolese = value; }
        }

        public float PSpazzateSassatelli
        {
            get { return _pSpazzateSassatelli; }
            set { _pSpazzateSassatelli = value; }
        }

        public void aggiorna ()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\percentuali.xml");
            XmlNode root = doc.DocumentElement;
            XmlNode myNode = root.SelectSingleNode("descendant::Provincia");
            myNode.FirstChild.Value = PProvincia + "";
            myNode = root.SelectSingleNode("descendant::ATC");
            myNode.FirstChild.Value = PATC + "";
            myNode = root.SelectSingleNode("descendant::ComuniInvitati");
            myNode.FirstChild.Value = PComuniInvitati + "";
            myNode = root.SelectSingleNode("descendant::SassoMorelli");
            myNode.FirstChild.Value = PSassoMorelli + "";
            myNode = root.SelectSingleNode("descendant::Giardino");
            myNode.FirstChild.Value = PGiardino + "";
            myNode = root.SelectSingleNode("descendant::SestoImolese");
            myNode.FirstChild.Value = PSestoImolese + "";
            myNode = root.SelectSingleNode("descendant::SpazzateSassatelli");
            myNode.FirstChild.Value = PSpazzateSassatelli + "";
            doc.Save(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\percentuali.xml");
            
        }   
    }
}
