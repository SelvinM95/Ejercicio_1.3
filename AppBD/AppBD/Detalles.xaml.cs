using AppBD.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBD
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Detalles : ContentPage
    {
        public Detalles()
        {
            InitializeComponent();
        }

        private async void userUpdate_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(id.Text))
            {
                Personas persona = new Personas()
                {
                    id= Convert.ToInt32(id.Text),
                    nombre = nombre.Text,
                    apellidos = apellido.Text,
                    edad = Convert.ToInt32(edad.Text),
                    correo = correo.Text,
                    direccion = direccion.Text,
                    fechanac = FNacimiento.Date
                };

                await App.SQLiteDB.SavePersonaAsync(persona);
                await DisplayAlert("Registro", "Datos actualizados correctamente", "Ok");
                LimpiarControles();
                id.IsVisible = false;
            }
        }

        private async void userDelete_Clicked(object sender, EventArgs e)
        {
            var persona = await App.SQLiteDB.GetPersonasByIdAsync(Convert.ToInt32(id.Text));

            if (persona != null)
            {
                await App.SQLiteDB.DeletePersonasAsync(persona);
                await DisplayAlert("Exitoso", "Datos eliminado correctamente", "Ok");
                LimpiarControles();
                id.IsVisible = false;
            }
        }

        public void LimpiarControles()
        {
            id.Text = "";
            nombre.Text = "";
            apellido.Text = "";
            edad.Text = "";
            correo.Text = "";
            direccion.Text = "";
            FNacimiento.Date = DateTime.Now;
        }
    }
}