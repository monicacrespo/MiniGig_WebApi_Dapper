# MiniGig_WebApi_Dapper
MiniGigWebApi is a ASP.NET Web API 2 service created in Visual Studio 2017 Professional, .NET Framework 4.7.2, ASP.NET Web API 2 and Dapper.

The motivation is to build a RESTful application using Dapper, a micro ORMs to implement the data layer, and async programming to improve the performance of our code. 

The solution contains four projects:
* Database
* MiniGigWebApi
* MiniGigWebApi.Data	
* MiniGigWebApi.Domain

The code illustrates the following topics:

* Implementation of a RESTful service using ASP.Net Web API 
* Use of Dapper for CRUD operations
* Dependency Injection in Web API using Autofac.WebApi2
* Use of Automapper to map the DTOs (Data Transfer Objects) to the model objects
* Allow for error handling in an HTTP way
* Testing the API using POSTMAN

Here's the URI Design

| Resource		    | GET (read)    		| POST (insert) | PUT (update) | DELETE (delete)  |
| ------------------------- | ------------------------- | ------------- | -------------| ---------------  |
| api/gigs 	            | Get List	    		| New Item	| Error **     | Error **	  |
| api/gigs/2                | Get Item      		| Error **	| Updated Item | Delete Item (200)|
| api/gigs?page=1&pageSize=4| First Page with 4 Items***| Error **	| Error **     | Error **	  |

** Error Status Code (405 Method Not Allowed)

*** The result will be sorted (OrderByDescending) by gig's date before its paged it.
	That's because page 2 of a list of items sorted by ID is much different than page 2 of a list of items sorted by Date.
	For pagination, both page and pagesize in the query string need to be greater than zero.
	http://.../api/gigs?page=0&pageSize=4 will return the same result as http://.../api/gigs, the list sorted (OrderBy) by ID.

How to test your Create Gig Request With Postman

![PostmanGetGig](https://github.com/monicacrespo/MiniGig_WebApi_Dapper/blob/master/MiniGigWebApi/Images/PostmanCreateGig.JPG)


GET Gig Request 
![PostmanGetGig](https://github.com/monicacrespo/MiniGig_WebApi_Dapper/blob/master/MiniGigWebApi/Images/PostmanGetGig.JPG)

