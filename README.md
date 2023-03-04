# Rick and Morty ASP.NET WebAPI Test Task
Created two endpoints:
1. check-person - checks if character with received name exists in received episode, if character and episode with that name exist.
2. person - returns info about character, if character with this name exists.

# **check-person**:  
Request:
```json
{
  "personName": "Rick Sanchez",
  "episodeName": "Pilot"
}
```

Response:
```
true/false/404 Not Found
```

# **person**
Query Parameters:  
```
?name=Rick Sanzhes
```
Response:  
```json
{
    "name": "Rick Sanchez",
    "status": "Alive",
    "species": "Human",
    "type": "",
    "gender": "Male",
    "origin": {
        "name": "Citadel of Ricks",
        "type": "Space station",
        "dimension": "unknown"
    }
}
```

# Task 2(SQL)
Created the airline database with 6 tables(clients, airports, flights, bookings, tickets, routes). Inserted test data.  
Created 3 SQL requests:
1. List of tickets of the client with his/her info.
2. Last 5 sold tickets
3. Top 3 clients by flights count
