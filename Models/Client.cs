using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PocMVVM.Models
{
    public class Client : INotifyPropertyChanged
    {
        private string _nom;
        public string Nom
        {
            get
            {
                return _nom;
            }
            set
            {
                if (value == _nom) return;
                _nom = value;
                OnPropertyChanged();
            }
        }

        private string _prenom;
        public string Prenom
        {
            get
            {
                return _prenom;
            }
            set
            {
                if (value == _prenom) return;
                _prenom = value;
                OnPropertyChanged();
            }
        }

        private string _sexe;
        public string Sexe
        {
            get
            {
                return _sexe;
            }
            set
            {
                if (value == _sexe) return;
                _sexe = value;
                OnPropertyChanged();
            }
        }

        private int _age;
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                if (value == _age) return;
                _age = value;
                OnPropertyChanged();
            }
        }

        public Client()
        {
            Nom = "Nom";
            Prenom = "Prénom";
            Age = 0;
            Sexe = "M/F";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }               
    }
}
