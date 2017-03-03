# Band Tracker

#### _Webpage to Save and Search Recipes_

#### By _**Cassie Musolf_

## Description

This web application will allow users to add and view specific bands and see the venues that they have played at. It will also allow users to add or choose an already existing venue and see the bands that play there.

## Specifications

**The user can add a band**
* Example Input: "Rascal Flatts"
* Example Output: "Rascal Flatts"

**The user can add a venue**
* Example Input: "The Gorge, WA"
* Example Output: "The Gorge, WA"

**The user can add a venue for their band**
* Example Input: "Rascal Flatts; Add Venue - The Gorge, WA"
* Example Output: "Rascal Flatts: The Gorge, WA"

**The user can add multiple venues for a band**
* Example Input: "Rascal Flatts; Add Venue - White River Amphitheater"
* Example Output: "Rascal Flatts: The Gorge, White River Amphitheater"

**The user can view a list of all venues or all bands**
* Example Input: "View All"
* Example Output: "The Gorge, Key Arena, Puyallup Fairgrounds" or "Rascal Flatts, Beyonce, Dave Mathews, Keith Urban"

**The user can view a venue and add a band to it**
* Example Input: "*Click on the Gorge* Add: Dave Mathews Band"
* Example Output: "The Gorge: Dave Mathews, Keith Urban, Rascal Flatts, etc."

**The user can update and delete a venue**
* Example Input: "Dave Mathews Band: The Gorge, Key Arena" *delete Key Arena category*
* Example Output: "Dave Mathews Band: The Gorge"

**The user can update a venue**
* Example Input:
* Example Output:

### Icebox

**The user can search venue by state**
* Example Input: "Washington"
* Example Output: "The Gorge, Key Arena, Century Link"

## Setup/Installation Requirements

* Requires DNU, DNX, and Mono
* Clone to local machine
* Use command "dnu restore" in command prompt/shell
* Use command "dnx kestrel" to start server
* Navigate to http://localhost:5004 in web browser of choice

## Support and contact details

Please contact Cassie Musolf at cassiemusolf@gmail.com with any questions, concerns, or suggestions.

## Technologies Used

This web application uses:
* Nancy
* Sql
* DNVM
* C#
* Razor

### License

*This project is licensed under the MIT license.*

Copyright (c) 2017 **_Cassie Musolf_**
