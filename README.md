<h2>Trello Low Level Design</h2>
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
        Trello.cs
</pre>
