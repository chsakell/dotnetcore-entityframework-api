# Building REST APIs using ASP.NET Core and Entity Framework Core
[![Build status](https://ci.appveyor.com/api/projects/status/github/chsakell/dotnetcore-entityframework-api?branch=master&svg=true)](https://ci.appveyor.com/project/chsakell/dotnetcore-entityframework-api/branch/master)

<a href="http://wp.me/p3mRWu-18G" taget="_blank">Blog post</a><br/>
Frameworks - Packages - Patterns - Features used
<ul>
<li>ASP.NET Core</li>
<li>Entity Framework Core</li>
<li>Entity Framework Migrations - Code First</li>
<li>Repository pattern</li>
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
<li>Open the solution in VS 2017</li>
<li>Open Package Manager Console and navigate to Scheduler.API by typing cd <i>path_to_Scheduler.API</i></li>
<li>Modify the connection string in <i>appsettings.json</i> to reflect your database environment</li>
<li>run the following commands
<ol>
<li><b>Add-Migration Initial</b></li>
<li><b>Update-Database</b></li>
</ol>
</li>
<li>Build and run the Scheduler.API project</li>
</ol>

<h3>Installation Instructions (2) - Without Visual Studio</h3>
<ol>
<li>Clone or download the repository</li>

<li>Open a terminal/cmd</li>
<li>Open <i>Scheduler.API</i> folder in your favorite text editor (preferably VS Code). If you get a message <i>Required assets to build and debug are missing from your project. Add them?</i>, click Yes</li>
<li>Navigate to Scheduler.Model and run <b>dotnet restore</b></li>
<li>Navigate to Scheduler.Data and run <b>dotnet restore</b></li>
<li>Navigate to Scheduler.API and run <b>dotnet restore</b></li>
<li>If you haven't SQL Server <i>(Linux or MAC)</i> set "InMemoryProvider": <b>true</b> in the <i>appsettings.json</i> file and skip to the last step</li>
<li>Modify the connection string in <i>appsettings.json</i> to reflect your database environment</li>
<li>While at Scheduler.API run the following commands
<ol>
<li><b>Add-Migration Initial</b></li>
<li><b>Update-Database</b></li>
</ol>
</li>
<li>While at Scheduler.API run <b>dotnet run</b></li>
</ol>

> This project is used as the backend API in <a href="https://github.com/chsakell/angular2-features" target="_blank">this</a> Angular 2 - TypeScript SPA

<h2>Microsoft Azure Deployment</h2>
Learn how to deploy an ASP.NET Core app on Microsoft Azure <a href="http://wp.me/p3mRWu-1bi" target="_blank">here</a>.

<h2>Donations</h2>
For being part of open source projects and documenting my work here and on <a href="https://chsakell.com">chsakell's blog</a> I really do not charge anything. I try to avoid any type of ads also.

If you think that any information you obtained here is worth of some money and are willing to pay for it, feel free to send any amount through paypal.

<table>
<tr><th>Paypal</th></tr>
<tbody>
<tr>
<td><a href="https://www.paypal.com/cgi-bin/webscr?cmd=_donations&business=chsakell%40gmail%2ecom&lc=US&item_name=Donation%20for%20chsakell%27s%20blog&currency_code=USD&bn=PP%2dDonationsBF%3abtn_donateCC_LG%2egif%3aNonHosted" style="text-align:center;display:block">
<img src="https://www.paypalobjects.com/webstatic/en_US/btn/btn_donate_cc_147x47.png" alt="Buy me a beer" />
</a></td>
</tr>
</tbody>
</table>

<h3 style="font-weight:normal;">Follow chsakell's Blog</h3>
<table id="gradient-style" style="box-shadow:3px -2px 10px #1F394C;font-size:12px;margin:15px;width:290px;text-align:left;border-collapse:collapse;" summary="">
<thead>
<tr>
<th style="width:130px;font-size:13px;font-weight:bold;padding:8px;background:#1F1F1F repeat-x;border-top:2px solid #d3ddff;border-bottom:1px solid #fff;color:#E0E0E0;" align="center" scope="col">Facebook</th>
<th style="font-size:13px;font-weight:bold;padding:8px;background:#1F1F1F repeat-x;border-top:2px solid #d3ddff;border-bottom:1px solid #fff;color:#E0E0E0;" align="center" scope="col">Twitter</th>
</tr>
</thead>
<tfoot>
<tr>
<td colspan="4" style="text-align:center;">Microsoft Web Application Development</td>
</tr>
</tfoot>
<tbody>
<tr>
<td style="padding:8px;border-bottom:1px solid #fff;color:#FFA500;border-top:1px solid #fff;background:#1F394C repeat-x;">
<a href="https://www.facebook.com/chsakells.blog" target="_blank"><img src="https://chsakell.files.wordpress.com/2015/08/facebook.png?w=120&amp;h=120&amp;crop=1" alt="facebook" width="120" height="120" class="alignnone size-opti-archive wp-image-3578"></a>
</td>
<td style="padding:8px;border-bottom:1px solid #fff;color:#FFA500;border-top:1px solid #fff;background:#1F394C repeat-x;">
<a href="https://twitter.com/chsakellsBlog" target="_blank"><img src="https://chsakell.files.wordpress.com/2015/08/twitter-small.png?w=120&amp;h=120&amp;crop=1" alt="twitter-small" width="120" height="120" class="alignnone size-opti-archive wp-image-3583"></a>
</td>
</tr>
</tbody>
</table>
<h3>License</h3>
Code released under the <a href="https://github.com/chsakell/dotnetcore-entityframework-api/blob/master/licence" target="_blank"> MIT license</a>.
