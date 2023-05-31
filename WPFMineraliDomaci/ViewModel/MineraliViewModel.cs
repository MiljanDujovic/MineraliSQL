using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFMineraliDomaci.ViewModel {
	internal class MineraliViewModel {
		public List<Mineral> Minerali { get; set; }

		public MineraliViewModel() {
			Minerali = new List<Mineral>();
			
			
		}
	}
}
