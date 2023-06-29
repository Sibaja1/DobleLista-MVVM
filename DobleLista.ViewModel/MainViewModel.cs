
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using DobleLista.Model;

namespace DobleLista.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<Person> ListRigth;
        private ObservableCollection<Person> ListLeft;
        private Person PersonaSelecionada;

        private ICommand clickCommandRigth;
        private ICommand clickCommandLeft;
        private ICommand clickCommandRigthAll;
        private ICommand clickCommandLeftAll;

        public ObservableCollection<Person> ListaRigth
        {
            get { return ListRigth; }
            set
            {
                ListRigth = value;
                OnPropertyChanged(nameof(ListRigth));
            }
        }

        public ObservableCollection<Person> ListaLeft
        {
            get { return ListLeft; }
            set
            {
                ListLeft = value;
                OnPropertyChanged(nameof(ListLeft));
            }
        }

        public Person SeleccionarPersona
        {
            get { return PersonaSelecionada; }
            set
            {
                PersonaSelecionada = value;
                OnPropertyChanged();
            }
        }

        public ICommand ClickCommandRigth
        {
            get
            {
                if (clickCommandRigth == null)
                {
                    clickCommandRigth = new RelayCommand(p => this.MoverUno(ListaLeft, ListaRigth));
                }
                return clickCommandRigth;
            }
        }

        public ICommand ClickCommandLeft
        {
            get
            {
                if (clickCommandLeft == null)
                {
                    clickCommandLeft = new RelayCommand(p => this.MoverUno(ListaRigth, ListaLeft));
                }
                return clickCommandLeft;
            }
        }

        public ICommand ClickCommandRigthAll
        {
            get
            {
                if (clickCommandRigthAll == null)
                {
                    clickCommandRigthAll = new RelayCommand(p => this.MoverTodo(ListaLeft, ListaRigth, "izquierdo"));
                }
                return clickCommandRigthAll;
            }
        }

        public ICommand ClickCommandLeftAll
        {
            get
            {
                if (clickCommandLeftAll == null)
                {
                    clickCommandLeftAll = new RelayCommand(p => this.MoverTodo(ListaRigth, ListaLeft, "derecho"));
                }
                return clickCommandLeftAll;
            }
        }
        public MainViewModel()
        {
            ListaRigth = new ObservableCollection<Person>();
            ListaLeft = new ObservableCollection<Person>();
            
            for (int i = 1; i <= 5; i++)
            {
                Person p1 = new Person(i, $"User{i}");
                ListaRigth.Add(p1);
                Person p2 = new Person(5 + i, $"User{5+i}");
                ListaLeft.Add(p2);
            }


        }

        public bool search(ObservableCollection<Person> data) 
        {
            if(SeleccionarPersona != null)
            {
                for (int i = 0; i < data.Count; i++)
                {
                    if (data[i].Id == SeleccionarPersona.Id)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void MoverUno(ObservableCollection<Person> data, ObservableCollection<Person> Destination)
        {
            if (SeleccionarPersona != null && !search(data))
            {
                Destination.Add(SeleccionarPersona);
                data.Remove(SeleccionarPersona);
                SeleccionarPersona = null;
            }
            else
            {
                if (search(data) & SeleccionarPersona != null)
                {
                    MessageBox.Show("Estas tratando de mover a una persona a su misma ubicación", "Información");
                }
                if (SeleccionarPersona == null)
                {
                    MessageBox.Show("No hay ninguna persona seleccionada. Selecciona una persona", "Información");
                }
            }
        }

        public void MoverTodo(ObservableCollection<Person> data, ObservableCollection<Person> Destination, string lado)
        {
            if (data.Count > 0)
            {
                while (data.Count > 0)
                {
                    var data2 = data[0];
                    data.RemoveAt(0);
                    Destination.Add(data2);
                }
            }
            else
            {
                MessageBox.Show($"No existen personas en la tabla", "Información");
            }
        }
    }
}
