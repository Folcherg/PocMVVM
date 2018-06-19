using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using PocMVVM.Components;
using PocMVVM.Models;

namespace PocMVVM.ModelsViews
{
    public class FicheClientsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] string str = "")
        {            
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(str));
        }

        private ObservableCollection<Client> _fiches;
        public ObservableCollection<Client> Fiches
        {
            get
            {
                return _fiches;
            }

            set
            {
                if (value == _fiches) return;
                _fiches = value;
                NotifyPropertyChanged();
            }
        }

        private Client _ficheSelectionnee;
        public Client FicheSelectionnee
        {
            get
            {
                return _ficheSelectionnee;
            }

            set
            {
                if (value == _ficheSelectionnee) return;
                _ficheSelectionnee = value;
                NotifyPropertyChanged();
            }
        }



        public FicheClientsViewModel()
        {
            Fiches = new ObservableCollection<Client>();

            FicheSelectionnee = new Client()
            {
                Nom = "Dupont",
                Prenom = "Pierre",
                Age = 32,
                Sexe = "M"
            };

            Fiches.Add(FicheSelectionnee);
        }

        private readonly ICommand _remiseAZeroDeLaFicheSelectionnee = new RelayCommand<Client>((client) =>
        {
            client.Age = 0;
            client.Nom = "";
            client.Prenom = "";
            client.Sexe = "";
        });

        public ICommand RemiseAZeroDeLaFicheSelectionnee => _remiseAZeroDeLaFicheSelectionnee;
        

        private ICommand _ajoutDUneFicheClient;
        public ICommand AjoutDUneFicheClient
        {
            get
            {
                if (_ajoutDUneFicheClient == null)                
                    _ajoutDUneFicheClient = new RelayCommand<object>((obj) => Fiches.Add(new Client()));
                
                return _ajoutDUneFicheClient;
            }
        }

        private ICommand _retraitDUneFicheClient;
        public ICommand RetraitDUneFicheClient
        {
            get
            {
                if (_retraitDUneFicheClient == null)                
                    _retraitDUneFicheClient = new RelayCommand<Client>((client) => Fiches.Remove(client));
                
                return _retraitDUneFicheClient;
            }
        }        
    }
}
