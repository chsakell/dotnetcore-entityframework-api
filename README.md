# Building REST APIs using ASP.NET Core and Entity Framework Core
<a href="http://wp.me/p3mRWu-18G" taget="_blank">Blog post</a><br/>
Frameworks - Packages - Patterns - Features used
<ul>
<li>ASP.NET Core</li>
<li>Entity Framework Core</li>
<li>Entity Framework Migrations - Code First</li>
<li>FluentValidation</li>
<li>Automapper</li>
<li>Global exception handler</li>
<li>Cors</li>
</ul>
<a href="http://wp.me/p3mRWu-18G" target="_blank"><img src="https://chsakell.files.wordpress.com/2016/06/dotnet-core-api-14.png?w=700" alt="dotnet-core-api-14" class="alignnone size-full wp-image-4397"></a>
<h3>Installation Instructions (1)</h3>
<ul>
<li>Install <a href="https://www.microsoft.com/net/core" target="_blank">.NET Core</a></li>
</ul>

<h3>Installation Instructions (2) - Visual Studio</h3>
<ol>
<li>Open the solution in VS 2015</li>
<li>Open Package Manager Console and navigate to Schduler.API by typing cd <i>path_to_Schduler.API</i></li>
<li>run the following commands
<ol>
<li><b>dotnet ef migrations add "initial"</b></li>
<li><b>dotnet ef database update</b></li>
</ol>
</li>
<li>Build and run the Schduler.API project</li>
</ol>

<h3>Installation Instructions (2) - Without Visual Studio</h3>
<ol>
<li>Clone or download the repository</li>

<li>Open a terminal/cmd</li>
<li>Open <i>Schduler.API</i> folder in your favorite text editor (preferably VS Code). If you get a message <i>Required assets to build and debug are missing from your project. Add them?</i>, click Yes</li>
<li>Navigate to Schduler.Model and run <b>dotnet restore</b></li>
<li>Navigate to Schduler.Data and run <b>dotnet restore</b></li>
<li>Navigate to Scheduler.API and run <b>dotnet restore</b></li>
<li>While at Scheduler.API run the following commands
<ol>
<li><b>dotnet ef migrations add "initial"</b></li>
<li><b>dotnet ef database update</b></li>
</ol>
</li>
<li>While at Scheduler.API run <b>dotnet run</b></li>
</ol>
