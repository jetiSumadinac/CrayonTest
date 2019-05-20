# Crayon Test Task
Exposed endpoint's URL is "https://localhost:xxxxx/api/test/get-rates" which tackes parameters through the http GET request body.  <br/>Example of http body in JSON:
<br/> ```
{
	BaseCurr:"SEK",
	TargetCurr:"NOK",
	Dates:["2016-01-01", "2016-09-02", "2017-04-05"]
}```
<br/>
It's a ASP.NET Visual Studio solution, so, in order to run it you have to download project, have it opened in Visual Studio and run it on IIS express. 
