# Scenarios

## Match

### Overview
League play consists of playing matches (pods) which include exactly four players with each combination played as a set of games to 11, win by 2.  
For examples, if there are four players (p1, p2, p3 and p4), the match will consist of all three combination of players playing 
together against the others:
```text
p1 + p2
vs.
p3 + p4

p1 + p3
vs.c
p2 + p4

p1 + p4
vs.
p2 + p3
```

Currently, this can be best of two games or best of 3 games for each matchup.

A specific player will initiate the match and that may affect the league standing depending on their final position in the outcome.  
A match would be scored as follows (using two games per team combination):

```text
            game 1, game 2
p1 + p2       11      11
vs.
p3 + p4        7       9

p1 + p3       11      10
vs.c
p2 + p4        7      12

p1 + p4        8      11
vs.
p2 + p3       11       6
```

There are several ways a match may enter a system.
1)  A match is initiated by a player and scheduled into the future at a location and a time.  In the current world, this would manifest as a post on the channel reading like
"Who wants to play a pod on Sunday morning at 7am at La Paloma court 9?".  From a systems perspective, a match can be crated with just one player, usually the initiator. 
As more players opt in to play (up to four total), the match grows to four people and is then locked down.
2) Sometimes, matches are impromptu and just rise up like mushrooms, without any notice.  If that it the case, the entire match, along with results is created as single unit.

### Scoring
In the match, every player will have a number of games won and a total points scored.  Using the example above:
p1 wins 4 games and scores (11 + 11 + 11 + 10 + 8 + 11) 62 points
p2 wins 4 games and scores (11 + 11 + 7 + 12 + 11 + 6) 58 points
p3 wins 2 games and scores (7 + 9 + 11 + 10 + 11 + 6) 54 points
p4 wins 2 games and scores (7 + 9 + 7 + 12 + 8 + 11) 54 points

Final standing are bases on number of games won, then total points as the tie-breaker.  So the final outcome of this match would be:
p1, p2, p3, p4 (sorry, the number alignment was not intentional)

### Lifecycle
* As mentioned above, a match can be created and requires a least one player playing in a league.  This player will become the initiator of the match.
* Players may be added at any time until arrive at a file count of four
* Location is optional and may be provided at any in the lifecycle
* The player list must be finalized before a final score is reported
* The score is reported without the accumulation (the system can handle that)

None of these activities affect the final outcome until they have all be completed, marking the match as "completed".  Note, this can also enter the system 
as a single data entry event, providing all the requisite parts in one shot.

A standard score sheet is used to keep track of the score on the court and it would be nice to attach that to the email once the match is finalized.

Once the match is completed, its outcome can be calculated and the league standings updated.

### Nerd Stuff
When the match is first created, assuming the slower path, publish a **MatchCreated** event, which should notify the players of their upcoming match, its location and time.  
This is likely a single email per player, with the exact same content.

The match can go through changes of players being added and/or removed, publish **MatchUpdated** event, likely stating that the match has been updated and why not show the 
changes based on the current and previous version of the match.

Finally, the match will be scored, publish a **MatchScored** event maybe (Match Completed?).  Send out an email to all player with the final scores.
The **MatchScored** event will also be used to update the league ranking.

### Match Domain Object
LeagueId
