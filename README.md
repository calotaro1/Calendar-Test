# Calendar-Test
This is a divelement test project for a developer position.

<h1>Maint tecnologies</h1>
.NET Core 3.1<br>
Entity Framework<br>
Microsoft SQL Server<br>

<h1>Features:</h1>
1 Add new event<br>
2 Delete event by id<br>
3 Edit event by id<br>
4 Get all events<br>
5 Get all events by organizer<br>
6 Get event by id<br>
7 Get event by location<br>
8 Get event by name<br>
9 Sort event as per time<br>

<h1>Installation</h1>
<h2>Database</h2>
Install <a href="https://www.microsoft.com/es-mx/sql-server/sql-server-downloads">SQL Server</a> from Microsoft<br>
Create a new local database called "ProjectTestDB"<br>
Create the Calendars table in the default schema<br>
Should be like this ![image](https://user-images.githubusercontent.com/88073656/138998880-1b2840ef-e2a8-45bb-b352-eb5cadef65dd.png) <br>

<h2>API Project</h2>
<a href="https://visualstudio.microsoft.com/es/thank-you-downloading-visual-studio/?sku=Community&rel=16">Install visual Studio 2019</a>, any version should be compatible, this was created with visual studio community<br>
Clone API project from the current Github repo in a visual studio instance<br>

<h2>Postman</h2>
<a href="https://www.postman.com/downloads/">Install Postman</a><br>
Import the <a href="https://github.com/calotaro1/Calendar-Test/blob/main/CalendarWebApi/Extras/TestCalendar.postman_collection.json">json file</a> to postman<br>

<h1>Run project</h1>
Run "ProjectTestDB" database<br>
Run the API project<br>
Send every petition in postman, every tab is a petition, tabs were saved in order like the features<br>

