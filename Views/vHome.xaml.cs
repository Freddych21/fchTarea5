using fchTarea5.Models;
using System.Collections.ObjectModel;

namespace fchTarea5.Views;

public partial class vHome : ContentPage
{
    public ObservableCollection<Personas> persons { get; set; }
    public Personas selectedPerson { get; set; }
    public vHome()
    {
        InitializeComponent();
        // listDataPersons();

    }

    private void listDataPersons()
    {
        persons = new ObservableCollection<Personas>();
        List<Personas> listPersons = App.personRepo.GetAllPeople();

        listViewPerson.ItemsSource = listPersons;
    }

    private void clearEntries()
    {
        txtNombre.Text = "";
    }

    private void btnInsertar_Clicked(object sender, EventArgs e)
    {
        lblStatus.Text = "";
        App.personRepo.AddNewPersona(txtNombre.Text);
        lblStatus.Text = App.personRepo.StatusMessage;
        if (!lblStatus.Text.Contains("Error"))
        {
            listDataPersons();
            clearEntries();
        }
    }

    private void listViewPerson_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        selectedPerson = (Personas)e.SelectedItem;

        if (selectedPerson != null)
        {
            txtNombre.Text = selectedPerson.Nombre;
            btnInsertar.IsEnabled = false;
            btnActualizar.IsEnabled = true;
            btnEliminar.IsEnabled = true;
        }
        else
        {
            clearEntries();
            btnInsertar.IsEnabled = true;
            btnActualizar.IsEnabled = false;
            btnEliminar.IsEnabled = false;
        }
    }

    private void btnActualizar_Clicked(object sender, EventArgs e)
    {
        lblStatus.Text = "";
        Personas person = new()
        {
            Id = selectedPerson.Id,
            Nombre = txtNombre.Text,

        };
        App.personRepo.UpdatePerson(person);
        lblStatus.Text = App.personRepo.StatusMessage;
        if (!lblStatus.Text.Contains("Error"))
        {
            listDataPersons();
            clearEntries();
            btnInsertar.IsEnabled = true;
            btnActualizar.IsEnabled = false;
            btnEliminar.IsEnabled = false;

        }

    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        lblStatus.Text = "";
        App.personRepo.UpdatePerson(selectedPerson);
        lblStatus.Text = App.personRepo.StatusMessage;
        if (!lblStatus.Text.Contains("Error"))
        {
            listDataPersons();
            clearEntries();
            btnInsertar.IsEnabled = false;
            btnActualizar.IsEnabled = false;
            btnEliminar.IsEnabled = true;
        }
    }
}