using DataBinding.Collection.Models;
namespace DataBinding.Collection.Views;

public partial class MainPage : ContentPage
{
	private List<OrigenDePaquete> _origenes;
	public MainPage()
	{
		InitializeComponent();

		OrigenDePaquete? origenSeleccionado;

		_origenes = new List<OrigenDePaquete>();
		CargarDatos();
		OrigenesListView.ItemsSource = _origenes;
		if ( _origenes.Count > 0 ){
		origenSeleccionado = _origenes[0];
		}
    OrigenesListView.ItemsSource = _origenes;
	}
	private void CargarDatos()
	{
		_origenes.Add(new OrigenDePaquete
		{
			Nombre = "nuget.org",
			Origen = "https://api.nuget.org/v3/index.json",
			EstaHabilitado = false
		});
		_origenes.Add(new OrigenDePaquete
		{
			Nombre = "Microsoft Visual Studio Offline Packages",
			Origen = @"C:\Program Files(x86)\Microsoft SDKs\NuGetPackages",
			EstaHabilitado = false
		});


	}
	private void OnAgregarButtonClicked(object sender, EventArgs e)
	{
		var origen = (new OrigenDePaquete
		{
			Nombre = "Origen del Paquete",
			Origen = "URL o Ruta del Origen del Paquete",
			EstaHabilitado = false
		});
		_origenes.Add(origen);
		OrigenesListView.ItemsSource = null;
		OrigenesListView.ItemsSource = _origenes;
	}
	private void OnDeleteButtonClicked(object sender, EventArgs e) 
	{
		OrigenDePaquete seleccionado = 
			(OrigenDePaquete) OrigenesListView.SelectedItem;

		if (seleccionado != null)
		{
			
			var indice = _origenes.IndexOf(seleccionado);
			OrigenDePaquete? origenSelecionado;
			if (_origenes.Count > 1)
			{
				//hay mas de uno
				if (indice < _origenes.Count - 1) 
				{
				  //el selecionado no es el ultimo
				  origenSelecionado = _origenes[indice + 1];
				}
				else 
				{
					//el elemento selecionado es el ultimo
					origenSelecionado = _origenes[indice - 1];
				}
			}
			else 
			{
				//hay 1 solo elemento o ninguno
				origenSelecionado = null;
			}
			_origenes.Remove(seleccionado);
			OrigenesListView.ItemsSource = null;
			OrigenesListView.ItemsSource = _origenes;
			OrigenesListView.SelectedItem = origenSelecionado;
		}

    }
	private void OrigenesListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		OrigenDePaquete origenSeleccionado = (OrigenDePaquete)OrigenesListView.SelectedItem;
		if (origenSeleccionado != null)
		{
			NombreEntry.Text = origenSeleccionado.Nombre;
			OrigenEntry.Text = origenSeleccionado.Origen;
		}
		else
		{
			NombreEntry.Text = string.Empty;
			OrigenEntry.Text = string.Empty;
		}
	}
	private void OnButtonClicked(object sender, EventArgs e)
	{ 
	  OrigenDePaquete? origenSelecionado = OrigenesListView.SelectedItem as OrigenDePaquete;
		if (origenSelecionado != null)
		{ 
			origenSelecionado.Nombre = NombreEntry.Text;
			origenSelecionado.Origen = OrigenEntry.Text;
            OrigenesListView.ItemsSource = null;
            OrigenesListView.ItemsSource = _origenes;
            OrigenesListView.SelectedItem = origenSelecionado;
        }
	}
}