namespace Pickles.Domain.Models;

public class User
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
}

public class Club
{
    public string Id { get; set; }
    public string Name { get; set; }
}

public class Player
{
    public string Id { get; set; }
}

public class League
{
    public string Id { get; set; }
    public string Style { get; set; }
}