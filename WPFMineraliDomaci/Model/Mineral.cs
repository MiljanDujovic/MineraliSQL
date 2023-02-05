using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFMineraliDomaci {
	public class Mineral {
		public int Id { get; set; }
		public string Naziv { get; set; }
		public string Kompozicija { get; set; }
		public string KristalniOblik { get; set; }
		public int Tvrdoca { get; set; }
		public string Boja { get; set; }

		public Mineral(int id, string naziv, string kompozicija, string kristalniOblik, int tvrdoca, string boja) {
			Id = id;
			Naziv = naziv;
			Kompozicija = kompozicija;
			KristalniOblik = kristalniOblik;
			Tvrdoca = tvrdoca;
			Boja = boja;
		}
	}
}
