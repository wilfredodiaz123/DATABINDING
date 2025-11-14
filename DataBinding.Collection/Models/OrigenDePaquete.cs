
using System.ComponentModel;

using System.ComponentModel
namespace DataBinding.Collection.Models
{
    public class OrigenDePaquete : INotifyPropertyChanged

    {
        private string? _nombre = string.Empty;
        private string? _origen = string.Empty;
        private bool? _estaHabilitado = false;
        public event PropertyChangingEventHandler? PropertyChanged;

        public string? nombre
        {
            get => _nombre;
            set
            {
                if (_nombre != value)
                {
                    _nombre = value;
                    OnPropertyChanged(nameof(nombre));
                }

            }
        }
        public string? origen
        {
            get => _origen;
            set
            {
                if (_origen != value)
                {
                    _origen = value;
                    OnPropertyChanged(nameof(origen));
                }

            }
        }
        public bool? EstaHabilitado
        {
            get => _estaHabilitado;
            set
            {
                if (_estaHablilitado != value)
                {
                    _estaHabilitado = value;
                    OnPropertyChanged(nameof(nombre));
                }

            }
        }
        public override string ToString()
        {
            return $"{Nombre} - {Origen}";
        }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke;
        }
     }
}
