using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Xml.Linq;
using WPFMineraliDomaci.ViewModel;
using System.Data.Common;

namespace WPFMineraliDomaci {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : MetroWindow {
		const string connectionString = "Data Source=ZVER\\MSSQLSERVER2016;Initial Catalog=Minerali_DB;User ID=sa;Password=1234";
		MineraliViewModel Mminerali = new MineraliViewModel();
		public MainWindow() {
			InitializeComponent();
		}

		private void UnesiteMineral_Click(object sender, RoutedEventArgs e) {
			try {
				SqlConnection sqlConnection = new SqlConnection(connectionString);
				var Naziv = tbxNaziv.Text;
				var Kompozicija = tbxKompozicija.Text;
				var Oblik = tbxOblik.Text;
				var Tvrdoca = tbxTvrdoca.Text;
				var Boja = tbxBoja.Text;
				sqlConnection.Open();
				if ( Naziv != null && Kompozicija != null &&  Oblik != null && Tvrdoca != null && Boja != null) {
				SqlCommand command = new SqlCommand($"INSERT INTO Minerali_Tabela (Naziv, Kompozicija, KristalniOblik, Tvrdoca, Boja) VALUES ('{Naziv}', '{Kompozicija}', '{Oblik}', '{Tvrdoca}', '{Boja}');", sqlConnection);
				SqlDataReader reader = command.ExecuteReader();
				MessageBox.Show($"Nov mineral je dodat u listu! {Naziv.ToUpper()}");
				}
				sqlConnection.Close();
			}
			catch (Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
		private void PrikaziteListuMinerala_Click(object sender, RoutedEventArgs e) {
			
			try {
				SqlConnection sqlConnection = new SqlConnection(connectionString);
				sqlConnection.Open();
				SqlCommand command = new SqlCommand("SELECT Id, Naziv, Kompozicija, KristalniOblik, Tvrdoca, Boja FROM Minerali_Tabela;", sqlConnection);
				SqlDataReader reader = command.ExecuteReader();
				
				while (reader.Read()) {
					var id = reader.GetInt32(0);
					string naziv = reader.GetString(1);
					var kompozicija = reader.GetString(2);
					var kristalniOblik = reader.GetString(3);
					var tvrdoca = reader.GetInt32(4);
					var boja = reader.GetString(5);
					var mineral = new Mineral(id, naziv, kompozicija, kristalniOblik, tvrdoca, boja);
					Mminerali.Minerali.Add(mineral);
					
				}
				
				sqlConnection.Close();
				
				ListaMinerala.DataContext = Mminerali;
			}
			catch (Exception ex) {
				MessageBox.Show(ex.ToString());
			}
			

		}
		private void ObrisiSaListe_Click(object sender, RoutedEventArgs e) {
			try {
				SqlConnection sqlConnection = new SqlConnection(connectionString);
				
				sqlConnection.Open();
				
					SqlCommand command = new SqlCommand($"DELETE FROM Minerali_Tabela WHERE Naziv = '{tbxNaziv.Text}'", sqlConnection);
					SqlDataReader reader = command.ExecuteReader();
					MessageBox.Show($"Mineral koji ste obrisali: {tbxNaziv.Text.ToUpper()}");
				
				sqlConnection.Close();
			}
			catch (Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}

		
	}
}
