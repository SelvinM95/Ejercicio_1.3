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
    public partial class Tablas : ContentPage
    {
        public Tablas()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var listapersonas = await App.SQLiteDB.GetPersonasAsync();
            if(listapersonas!=null)
            {
                lstPersonas.ItemsSource = listapersonas;
            }

        }

        private async void lstPersonas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (Personas)e.SelectedItem;

            if (!string.IsNullOrEmpty(obj.id.ToString()))
            {
                var persona = await App.SQLiteDB.GetPersonasByIdAsync(obj.id);
                if(persona !=null)
                {
                     
                    Personas person = new Personas
                    {
                        id = persona.id,
                        nombre = persona.nombre,
                        apellidos = persona.apellidos,
                        edad = persona.edad,
                        correo = persona.correo,
                        direccion = persona.direccion,
                        fechanac = persona.fechanac
                    };

                    var detalles = new Detalles();
                    detalles.BindingContext = person;
                    await Navigation.PushAsync(detalles);
                }
            }
        }
    }
}