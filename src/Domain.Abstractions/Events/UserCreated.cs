using Pickles.Domain.Messaging;
using Pickles.Domain.Models;

namespace Pickles.Domain.Events;

public class UserCreated : User, IEvent
{
    
}

public class PlayerAddedClub : Player, IEvent
{
    
}

public class PlayerAddedToLeague : Player, IEvent
{
    
}

public class LeagueCreated : League, IEvent
{
    
}

public class MatchCreated : Match, IEvent
{
    
}

public class PlayerAddedToMatch : Match, IEvent
{
    
}

public class PlayerRemovedFromMatch : Match, IEvent
{
    
}

public class MatchFilledAndReadyToPlay : Match, IEvent
{
    
}

public class MatchScored : Match, IEvent
{
    
}

public class LeagueStandingsUpdated : IEvent
{
    
}