using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppListaCursos
{
    public partial class MainPage : ContentPage
    {

        List<String> itens = new List<String>();

        public MainPage()
        {
            InitializeComponent();
        }

        private void btnInserir_Clicked(object sender, EventArgs e)
        {
            itens.Add(edtCursos.Text);
            lstCursos.ItemsSource = null;
            lstCursos.ItemsSource = itens;
            edtCursos.Text = "";
            edtCursos.Focus();
        }

        private void sbCursos_TextChanged(object sender, TextChangedEventArgs e)
        {
            lstCursos.ItemsSource = itens.Where(x => x.ToUpper().Contains(sbCursos.Text.ToUpper()));
        }

        private async void lstCursos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var ans = await DisplayAlert("Exclusao", "Excluir " + lstCursos.SelectedItem + "?", "Sim", "Não");
            if(ans)
            {
                itens.Remove(lstCursos.SelectedItem.ToString());
                lstCursos.ItemsSource = null;
                lstCursos.ItemsSource = itens;
            }
            sbCursos.Text = "";
        }
    }
}
