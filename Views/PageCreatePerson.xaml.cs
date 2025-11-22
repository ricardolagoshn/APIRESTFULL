namespace APIRESTFULL.Views;

public partial class PageCreatePerson : ContentPage
{
	public PageCreatePerson()
	{
		InitializeComponent();
	}

    private void btnfoto_Clicked(object sender, EventArgs e)
    {

    }

    private async void btnproceso_Clicked(object sender, EventArgs e)
    {
        var persona = new Models.Personas
        {
            nombres = Nombres.Text,
            apellidos = Apellidos.Text,
            direccion = Direccion.Text,
            telefono = Telefono.Text,
            foto = "sdsdsdsdsd"
        };

        if (await Controllers.PersonasController.CreatePerson(persona) != null)
        {
            await DisplayAlert("Aviso", "Registro ingresado exitosamente ","OK");
        }
        else
        {
            await DisplayAlert("Aviso", "No se pudo ingresar ", "OK");
        }

    }
}