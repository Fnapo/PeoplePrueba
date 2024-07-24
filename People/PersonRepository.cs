using DatosSakila.Datos;
using DatosSakila.Modelos;
using Microsoft.EntityFrameworkCore;

namespace People;

public class PersonRepository
{
    public string StatusMessage { get; set; }

    // TODO: Add variable for the SQLite connection
    PersonasContext _context;
    /*
    private void Init()
    {
        // TODO: Add code to initialize the repository
        if (_context != null)
        {
            return;
        }
        _context = new PersonasContext();
    }*/

    public PersonRepository()
    {
        // TODO: Add code to initialize the repository
        if (_context != null)
        {
            return;
        }
        _context = new PersonasContext();
    }

    public async Task AddNewPerson(string firstName, string lastName)
    {
        int result;

        try
        {
            // TODO: Call Init()
            //Init();
            // basic validation to ensure a name was entered
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            {
                StatusMessage = "Valid strings required";

                return;
            }

            // TODO: Insert the new person into the database
            //result = 0;

            //Actor actor = new(firstName, lastName);
            Actor actor = new() { FirstName = firstName, LastName = lastName };

            await _context.AddAsync(actor);
            result = await _context.SaveChangesAsync();

            StatusMessage = string.Format("{0} record added (FirstName: {1}, LastName: {2})", result, firstName, lastName);
        }
        catch (Exception ex)
        {
            StatusMessage = string.Format("Failed to add a Actor. Error: {0}", ex.Message);
        }

    }

    public async Task<List<Actor>> GetAllPeople()
    {
        // TODO: Init then retrieve a list of Person objects from the database into a list
        try
        {
            //Init();
 
            return await _context.Actors.ToListAsync();
            //[.. _context.Actors];
            //return _context.Actors.ToList();
        }
        catch (Exception ex)
        {
            StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
        }

        return new List<Actor>();
    }
}
