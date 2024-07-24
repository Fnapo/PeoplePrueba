//using People.Models;
using DatosSakila.Modelos;
using System.Collections.Generic;

namespace People;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

    public async void OnNewButtonClicked(object sender, EventArgs args)
    {
        statusMessage.Text = "";
        
        await App.PersonRepository.AddNewPerson(FirstName.Text, LastName.Text);
        FirstName.Text = LastName.Text = "";
        statusMessage.Text = App.PersonRepository.StatusMessage;
       
    }

    public async void OnGetButtonClicked(object sender, EventArgs args)
    {
        statusMessage.Text = "";

        List<Actor> people = await App.PersonRepository.GetAllPeople();
        peopleList.ItemsSource = people.OrderBy(a => a.NombreCompleto);
    }

    private void OnEntryFirstNameChanged(object sender, TextChangedEventArgs e)
    {
        string ayudaFirst = e.NewTextValue.Trim(), ayudaLast = LastName.Text?.Trim();

        BotonAdd.IsEnabled = ValidarActor(ayudaFirst, ayudaLast);
    }

    private void OnEntryLastNameChanged(object sender, TextChangedEventArgs e)
    {
        string ayudaLast = e.NewTextValue.Trim(), ayudaFirst = FirstName.Text.Trim();

        BotonAdd.IsEnabled = ValidarActor(ayudaFirst, ayudaLast);
    }

    private bool ValidarActor(string firstName, string lastName)
    {
        return !string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName);
    }

    private void OnActorSeleccionado(object sender, SelectedItemChangedEventArgs e)
    {
        int valor = e.SelectedItemIndex;
        Actor actor = e.SelectedItem as Actor;
    }
}

