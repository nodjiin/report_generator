using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generatore_di_verbale
{
    class Verbale
    {
        private String _dataCattura = null;
        private String _comune = null;
        private String _comuniInvitati = null;
        private String _zonaCatturata = null;
        private int _maschi = 0;
        private int _femmine = 0;

        //maschi
        private float _provinciam = 0;
        private int _consegnateProvm = 0;
        private float _ATCm = 0;
        private int _consegnateATCm = 0;
        private float _comuniInvitatim = 0;
        private int _consegnateComuniInvitatim = 0;
        private float _sassoMorellim = 0;
        private int _consegnateSassoMorellim = 0;
        private float _giardinom = 0;
        private int _consegnateGiardinom = 0;
        private float _sestoImolesem = 0;
        private int _consegnateSestoImolesem = 0;
        private float _spazzateSassatellim = 0;
        private int _consegnateSpazzateSassatellim = 0;
        private float _totalim = 0;
        private int _consegnateTotalim = 0;

        //femmine
        private float _provinciaf = 0;
        private int _consegnateProvf = 0;
        private float _ATCf = 0;
        private int _consegnateATCf = 0;
        private float _comuniInvitatif = 0;
        private int _consegnateComuniInvitatif = 0;
        private float _sassoMorellif = 0;
        private int _consegnateSassoMorellif = 0;
        private float _giardinof = 0;
        private int _consegnateGiardinof = 0;
        private float _sestoImolesef = 0;
        private int _consegnateSestoImolesef = 0;
        private float _spazzateSassatellif = 0;
        private int _consegnateSpazzateSassatellif = 0;
        private float _totalif = 0;
        private int _consegnateTotalif = 0;

        //i valori float delle percentuali vengono trasformati in int, così approssimiamo per difetto
        public Verbale(string _dataCattura, string _comune, string _zonaCatturata, string _comuniInvitati, int _maschi, int _femmine,
            float _provinciam, float _ATCm, float _comuniInvitatim, float _sassoMorellim, float _giardinom,
            float _sestoImolesem, float _spazzateSassatellim, float _totalim,
            float _provinciaf, float _ATCf, float _comuniInvitatif, float _sassoMorellif, float _giardinof,
            float _sestoImolesef, float _spazzateSassatellif, float _totalif)
        {
            this.ComuniInvitati = _comuniInvitati;
            this.DataCattura = _dataCattura;
            this.Comune = _comune;
            this.ZonaCatturata = _zonaCatturata;
            this.Maschi = _maschi;
            this.Femmine = _femmine;
            this.Provinciam = _provinciam;
            this.ConsegnateProvm = (int)_provinciam;
            this.ATCm = _ATCm;
            this.ConsegnateATCm = (int)_ATCm;
            this.ComuniInvitatim = _comuniInvitatim;
            this.ConsegnateComuniInvitatim = (int)_comuniInvitatim;
            this.SassoMorellim = _sassoMorellim;
            this.ConsegnateSassoMorellim = (int)_sassoMorellim;
            this.Giardinom = _giardinom;
            this.ConsegnateGiardinom = (int)_giardinom;
            this.SestoImolesem = _sestoImolesem;
            this.ConsegnateSestoImolesem = (int)_sestoImolesem;
            this.SpazzateSassatellim = _spazzateSassatellim;
            this.ConsegnateSpazzateSassatellim = (int)_spazzateSassatellim;
            this.Totalim = _totalim;
            this.ConsegnateTotalim = ConsegnateSassoMorellim + ConsegnateGiardinom + ConsegnateSestoImolesem + ConsegnateSpazzateSassatellim;
            this.Provinciaf = _provinciaf;
            this.ConsegnateProvf = (int)_provinciaf;
            this.ATCf = _ATCf;
            this.ConsegnateATCf = (int)_ATCf;
            this.ComuniInvitatif = _comuniInvitatif;
            this.ConsegnateComuniInvitatif = (int)_comuniInvitatif;
            this.SassoMorellif = _sassoMorellif;
            this.ConsegnateSassoMorellif = (int)_sassoMorellif;
            this.Giardinof = _giardinof;
            this.ConsegnateGiardinof = (int)_giardinof;
            this.SestoImolesef = _sestoImolesef;
            this.ConsegnateSestoImolesef = (int)_sestoImolesef;
            this.SpazzateSassatellif = _spazzateSassatellif;
            this.ConsegnateSpazzateSassatellif = (int)_spazzateSassatellif;
            this.Totalif = _totalif;
            this.ConsegnateTotalif = ConsegnateSassoMorellif + ConsegnateGiardinof + ConsegnateSestoImolesef + ConsegnateSpazzateSassatellif;

            //sistemo le lepri in eccesso
            ConsegnateProvm += calcolaRestom();
            ConsegnateProvf += calcolaRestof();
        }

        public int Maschi
        {
            get
            {
                return _maschi;
            }

            set
            {
                _maschi = value;
            }
        }

        public int Femmine
        {
            get
            {
                return _femmine;
            }

            set
            {
                _femmine = value;
            }
        }

        public string DataCattura
        {
            get
            {
                return _dataCattura;
            }

            set
            {
                _dataCattura = value;
            }
        }

        public string Comune
        {
            get
            {
                return _comune;
            }

            set
            {
                _comune = value;
            }
        }

        public string ZonaCatturata
        {
            get
            {
                return _zonaCatturata;
            }

            set
            {
                _zonaCatturata = value;
            }
        }

        public string ComuniInvitati
        {
            get
            {
                return _comuniInvitati;
            }

            set
            {
                _comuniInvitati = value;
            }
        }

        public float Provinciam
        {
            get
            {
                return _provinciam;
            }

            set
            {
                _provinciam = value;
            }
        }

        public int ConsegnateProvm
        {
            get
            {
                return _consegnateProvm;
            }

            set
            {
                _consegnateProvm = value;
            }
        }

        public float ATCm
        {
            get
            {
                return _ATCm;
            }

            set
            {
                _ATCm = value;
            }
        }

        public int ConsegnateATCm
        {
            get
            {
                return _consegnateATCm;
            }

            set
            {
                _consegnateATCm = value;
            }
        }

        public float ComuniInvitatim
        {
            get
            {
                return _comuniInvitatim;
            }

            set
            {
                _comuniInvitatim = value;
            }
        }

        public int ConsegnateComuniInvitatim
        {
            get
            {
                return _consegnateComuniInvitatim;
            }

            set
            {
                _consegnateComuniInvitatim = value;
            }
        }

        public float SassoMorellim
        {
            get
            {
                return _sassoMorellim;
            }

            set
            {
                _sassoMorellim = value;
            }
        }

        public int ConsegnateSassoMorellim
        {
            get
            {
                return _consegnateSassoMorellim;
            }

            set
            {
                _consegnateSassoMorellim = value;
            }
        }

        public float Giardinom
        {
            get
            {
                return _giardinom;
            }

            set
            {
                _giardinom = value;
            }
        }

        public int ConsegnateGiardinom
        {
            get
            {
                return _consegnateGiardinom;
            }

            set
            {
                _consegnateGiardinom = value;
            }
        }

        public float SestoImolesem
        {
            get
            {
                return _sestoImolesem;
            }

            set
            {
                _sestoImolesem = value;
            }
        }

        public int ConsegnateSestoImolesem
        {
            get
            {
                return _consegnateSestoImolesem;
            }

            set
            {
                _consegnateSestoImolesem = value;
            }
        }

        public float SpazzateSassatellim
        {
            get
            {
                return _spazzateSassatellim;
            }

            set
            {
                _spazzateSassatellim = value;
            }
        }

        public int ConsegnateSpazzateSassatellim
        {
            get
            {
                return _consegnateSpazzateSassatellim;
            }

            set
            {
                _consegnateSpazzateSassatellim = value;
            }
        }

        public float Totalim
        {
            get
            {
                return _totalim;
            }

            set
            {
                _totalim = value;
            }
        }

        public int ConsegnateTotalim
        {
            get
            {
                return _consegnateTotalim;
            }

            set
            {
                _consegnateTotalim = value;
            }
        }

        public float Provinciaf
        {
            get
            {
                return _provinciaf;
            }

            set
            {
                _provinciaf = value;
            }
        }

        public int ConsegnateProvf
        {
            get
            {
                return _consegnateProvf;
            }

            set
            {
                _consegnateProvf = value;
            }
        }

        public float ATCf
        {
            get
            {
                return _ATCf;
            }

            set
            {
                _ATCf = value;
            }
        }

        public int ConsegnateATCf
        {
            get
            {
                return _consegnateATCf;
            }

            set
            {
                _consegnateATCf = value;
            }
        }

        public float ComuniInvitatif
        {
            get
            {
                return _comuniInvitatif;
            }

            set
            {
                _comuniInvitatif = value;
            }
        }

        public int ConsegnateComuniInvitatif
        {
            get
            {
                return _consegnateComuniInvitatif;
            }

            set
            {
                _consegnateComuniInvitatif = value;
            }
        }


        public float SassoMorellif
        {
            get
            {
                return _sassoMorellif;
            }

            set
            {
                _sassoMorellif = value;
            }
        }

        public int ConsegnateSassoMorellif
        {
            get
            {
                return _consegnateSassoMorellif;
            }

            set
            {
                _consegnateSassoMorellif = value;
            }
        }

        public float Giardinof
        {
            get
            {
                return _giardinof;
            }

            set
            {
                _giardinof = value;
            }
        }

        public int ConsegnateGiardinof
        {
            get
            {
                return _consegnateGiardinof;
            }

            set
            {
                _consegnateGiardinof = value;
            }
        }

        public float SestoImolesef
        {
            get
            {
                return _sestoImolesef;
            }

            set
            {
                _sestoImolesef = value;
            }
        }

        public int ConsegnateSestoImolesef
        {
            get
            {
                return _consegnateSestoImolesef;
            }

            set
            {
                _consegnateSestoImolesef = value;
            }
        }

        public float SpazzateSassatellif
        {
            get
            {
                return _spazzateSassatellif;
            }

            set
            {
                _spazzateSassatellif = value;
            }
        }

        public int ConsegnateSpazzateSassatellif
        {
            get
            {
                return _consegnateSpazzateSassatellif;
            }

            set
            {
                _consegnateSpazzateSassatellif = value;
            }
        }

        public float Totalif
        {
            get
            {
                return _totalif;
            }

            set
            {
                _totalif = value;
            }
        }

        public int ConsegnateTotalif
        {
            get
            {
                return _consegnateTotalif;
            }

            set
            {
                _consegnateTotalif = value;
            }
        }

        private int calcolaRestom ()
        {
            int restom = (int)Totalim - ConsegnateTotalim;

            return restom;
        }

        private int calcolaRestof()
        {
            int restof = (int)Totalif - ConsegnateTotalif;

            return restof;
        }

    }
}
