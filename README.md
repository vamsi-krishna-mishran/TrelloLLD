<h1>Trello Low Level Design</h1>
<h2>Problem Statement</h2>
<a href="https://workat.tech/machine-coding/practice/trello-problem-t0nwwqt61buz">Problem Link</a>
<h2>Solution</h2>
<b>Directory Structure</b>
<pre>
  
C:.
¦   Program.cs
¦   trello.csproj
¦   TrelloLLD.sln
¦   
+---datalayer
¦       Database.cs
¦       
+---enums
¦       Privacy.cs
¦       
+---models
¦       Board.cs
¦       Card.cs
¦       List.cs
¦       User.cs
¦       
+---services
¦       BaseService.cs
¦       BoardService.cs
¦       CardService.cs
¦       IdService.cs
¦       ListService.cs
¦       LoggerService.cs
¦       UserService.cs
¦       
+---System
|      Trello.cs
</pre>
<b>Appraoch</b>
<article style="text-align:justify">
low level design problems are open-ended. we should always try to solve the problem by focusing <i>SOLID , KISS and DRY</i> principles.
<br/>
<i> I followed below steps to solve the problem in a efficient way without voilating above principles.</i>
<ol>
<li>
 Clarify the requirements, figure out the entities part of the system and their properties.
</li>
<li>
Write classes for each entity with properties. only put setters and getters inside it. I place all these in a folder <i>models</i>.
</li>
<li>
To use these objects inside our system, let's create a file called database and have List of these classes. I created <i>datalayer/database.cs</i> file which is an singleton instance.
</li>
<li>
Interaction to this database should be done from services.So create services for all entities as per the requirements.
Sometimes we need to add more services based on the client requirements such as <i>generateIds, sendmails</i> etc. I created all services inside <i>services</i> folder.
</li>
<li>
Create a fascade class that encapsulates all the services and provide <b>interface/API/public methods</b> to handle client use cases.
</li>
</ol>
<small><b>Note:</b> we can interact with this fascade class from CLI or Front-end tech.</small>
<br/>
<small><b>Desclaimer:</b> There can be multiple solutions to this design. I can't assure its the best.
<br/>
</small>

<b>Start Locally</b>
<ul>
<li> Install dotnet SDK 8.
</li>
<li> clone repository and go to folder where .csproj is present in your powershell or cmd.
</li>
<li>
   run <i>dotnet build</i> or <i>dotnet build trello.csproj</i>
</li>
<li>
  run <i>dotnet run</i> to get the code run.
</li>

</ul>
</article>
