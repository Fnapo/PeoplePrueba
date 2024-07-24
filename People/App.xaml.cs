namespace People;

public partial class App : Application
{
    // TODO: Add a public static PersonRepository property
    public static PersonRepository PersonRepository { get; private set; }

    public App(PersonRepository repository)
	{
		InitializeComponent();

		MainPage = new AppShell();

        // TODO: Initialize the PersonRepository property with the PersonRespository singleton object
        PersonRepository = repository;
    }
}
