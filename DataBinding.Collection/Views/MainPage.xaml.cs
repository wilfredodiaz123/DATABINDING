using DataBinding.Collection.Models;
using System.Collections.ObjectModel;
namespace DataBinding.Collection.Views;

public partial class MainPage : ContentPage
{
	public ObservableCollection<OrigenDePaquete> Origenes { get; }
	private OrigenDePaquete? _origenSeleccionado = null;
	private string? _nombreDelOrigen = string.Empty; 
	private string? _rutaDelOrigen = string.Empty;
    public OrigenDePaquete? OrigenSeleccionado
	{
		get => _origenSeleccionado;
		set
		{
			if (_origenSeleccionado != value)
			{
				_origenSeleccionado = value;
					OnPropertyChanged(nameof(OrigenSeleccionado));
			}
		}
	}
	public string? NombreDelOrigen
	{
		get => _nombreDelOrigen;
		set
		{
			if (_nombreDelOrigen != value)
			{
				_nombreDelOrigen = value;
			
            OnPropertyChanged(nameof(NombreDelOrigen));
        }
		}
	}
    public string? RutaDelOrigen
    {
        get => _rutaDelOrigen;
        set
        {
            if (_rutaDelOrigen != value)
            {
                _rutaDelOrigen = value;
                OnPropertyChanged(nameof(RutaDelOrigen));
            }
        }
    }
    public MainPage()
	{
		InitializeComponent();

		OrigenSeleccionado = null;
		Origenes = new ObservableCollection<OrigenDePaquete>();
		CargarDatos();
        BindingContext = this;
        OrigenesListView.ItemsSource = Origenes;
		if ( Origenes.Count > 0 ){
		OrigenSeleccionado = Origenes[0];
		}
		
	}
	private void CargarDatos()
	{
		Origenes.Add(new OrigenDePaquete
		{
			Nombre = "nuget.org",
			Origen = "https://api.nuget.org/v3/index.json",
			EstaHabilitado = false
		});
		Origenes.Add(new OrigenDePaquete
		{
			NombGITre = "Microsoft Visual Studio Offline Packages",
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
		Origenes.Add(origen);
		OrigenSeleccionado = origen;
	}
	private void OnDeleteButtonClicked(object sender, EventArgs e) 
	{
		
		if (OrigenSeleccionado != null)
		{
			
			var indice = Origenes.IndexOf(OrigenSeleccionado);
			OrigenDePaquete? origenSelecionado;
			if (Origenes.Count > 1)
			{
				//hay mas de uno
				if (indice < Origenes.Count - 1) 
				{
				  //el selecionado no es el ultimo
				  origenSelecionado = Origenes[indice + 1];
				}
				else 
				{
					//el elemento selecionado es el ultimo
					origenSelecionado = Origenes[indice - 1];
				}
			}
			else 
			{
				//hay 1 solo elemento o ninguno
				origenSelecionado = null;
			}
			Origenes.Remove(OrigenSeleccionado);
			OrigenSeleccionado = origenSelecionado;
		}

    }
	private void OrigenesListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		
		if (OrigenSeleccionado != null)
		{
			NombreDelOrigen = OrigenSeleccionado.Nombre;
			RutaDelOrigen = OrigenSeleccionado.Origen;
		}
		else
		{
			NombreDelOrigen= string.Empty;
			RutaDelOrigen = string.Empty;
		}
	}
	private void OnButtonClicked(object sender, EventArgs e)
	{ 
		if (OrigenSeleccionado != null)
		{ 
			OrigenSeleccionado.Nombre = NombreDelOrigen;
			OrigenSeleccionado.Origen = RutaDelOrigen;
        }
	}
}