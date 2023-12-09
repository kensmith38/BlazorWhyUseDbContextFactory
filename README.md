# BlazorWhyUseDbContextFactory
Show why Blazor Server should use DbContextFactory. 

This Blazor Server web app (.NET 8.0) is a simple to-do list which shows a page with two lists on it:
<li>High priority to-dos</li>
<li>All to-dos</li>
<strong>An exception occurs if a simple DbContext is used instead of a DbContextFactory.</strong>

The project is saved using a DbContextFactory, but the code exists in the project to switch to plain DbContext (not factory).
<h3>You must create a database in order to run the program</h3>
<ol>
  <li>Change the Default connection string as appropriate for your environment.</li>
  <li>Execute code first migration commands to create the database</li>
  <ul>
    <li>Add-Migration InitialCreate</li>
    <li>Update-Database</li>
  </ul>
</ol>
<h3>Steps to switch to DbContextFactory</h3>
In Program.cs
<ol>
  <li>Comment the line to use AddDbContext</li>
  <li>Un-comment the line to use AddDbContextFactory</li>
</ol>
In ToDoService.cs
<ol>
  <li>Comment the entire top half of code (which uses DbContextFactory)</li>
<li>Un-comment the bottom half of code (which uses plain DbContext</li>
</ol>

<h2>Note that both DbContext and DbContextFactory will work if you use the component (ListOfToDoItems> ONLY ONCE on page, ShowToDos.</h2>
