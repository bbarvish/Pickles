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
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public int MaxPlayerCount { get; set; }
    public List<Player> Players { get; set; }
}

public class Tournament
{
    public string Id { get; set; }
    public string Style { get; set; }
    public DateTime RegistrationOpens { get; set; }
    public DateTime RegistrationCloses { get; set; }
    public DateOnly OccursOn { get; set; }
    public int MaxPlayerCount { get; set; }
    public List<Player> Players { get; set; }
}

public class Match
{
    public string Id { get; set; }
    public string LeagueId { get; set; }
    public string MatchType { get; set; }  //two games or best of three POD or one on one
    public DateTime ScheduledFor { get; set; }
    public string Location { get; set; }
    public string CourtNumber { get; set; }
    public List<Player> Players { get; set; }
    public Player InitiatedBy { get; set; }
    public DateTime CompletedOn { get; set; }
    public List<GameOutcome> GameOutcomes { get; set; }
    public List<MatchOutcome> MatchOutcomes { get; set; }
}

public class GameOutcome
{
    public int GameNumber { get; set; }
    public List<Player> Players { get; set; }
    public int PointsScored { get; set; }
}

public class MatchOutcome
{
    public Player Player { get; set; }
    public int RankBeforeMatch { get; set; }
    public int NumberOfGamesWon { get; set; }
    public int TotalPointsScored { get; set; }
}

public class LeagueStandings
{
    public string LeagueId { get; set; }
    public Dictionary<DateTime, (Player, int)> Standing { get; set; }
}