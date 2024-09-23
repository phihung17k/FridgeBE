in repository
- Avoid returning `IQueryable`, because it breaks encapsulation and leaks data access responsiblities out of the repository abstraction where it belongs
	+ Add additional methods to the Repository as needed
- Return `IReadOnlyList` when return read-only list
	+ Common operations: indexing, iteration, and Count retrieval
- Return `IEnumerable` when using In-Memory Operations
	+ Common operations: filtering, sorting, and mapping in-memory after data retrieval
- Return `List`: a resizable and index-based collection
	+ Common operations: adding, removing, finding, sorting, and more


Flow: Api (UI) - Infrastructure - Core
(Controller - Service - Repository)
(dto - model - entity)

Core: include the independent components
- poco entities
- interface
- models
Infrastructure: implement Data access, file systems and database. Interact other components and process data, map entity to model
- DbContext
- Migration
- File systems
- Repositories
	- UnitOfWork: make sure that when you use multiple repositories, they share a single database context
- Services
Api: entry point for application, interact with Infrastructure through interfaces defined in Core (no call directly to Infrastructure)
- Controller
- Filters
- Middlewave
- Views
- ViewModels

Middleware and Filters
- Request -> Middleware -> Filters -> Controller (and vice versa)
- Filter
	- IActionFilter (OnActionExecuting) -> Controller -> IActionFilter (OnActionExecuted) -> IResultFilter (OnResultExecuting) -> IResultFilter (OnResultExecuted) -> Middleware
	- IActionFilter (OnActionExecuting) -> IResultFilter (OnResultExecuting): not include ContentType yet
	- IResultFilter (OnResultExecuted): included ContentType
- Flow: [image](https://learn.microsoft.com/en-us/aspnet/core/mvc/controllers/filters/_static/filter-pipeline-2.png?view=aspnetcore-8.0)

Authorization:
- Policy (Role)
- Policy (Claim)
- Policy (Requirement + Handler): in project
- Elements in authorization:
	- AuthorizeAttribute(policy name): to authorize by policy name
	- IAuthorizationPolicyProvider: to add policy from AuthorizeAttribute(policy name), (add Requirements, Claims or Roles in policy)
	- IAuthorizationRequirement: transform authorization infor from policy name to add Requirements in policy in IAuthorizationPolicyProvider
	- IAuthorizationHandler: compare user's claims to Requirements 

Other architecture:
- Core: should not have any dependencies.
- Infrastructure: depends on Core for domain models.
- Application: depends on Core and might reference Infrastructure for interfaces.
- Presentation: depends on Application for processing requests.

entity and model
- Entity: used in repository
- Model: used in service

Pooling (DbContext) [Pool](https://learn.microsoft.com/en-us/ef/core/performance/advanced-performance-topics?tabs=with-di%2Cexpression-api-with-constant#dbcontext-pooling)
- Issue: Default context is created continuously
=> Using Pool context instance: meaning context disposed 
	- EF Core reset context's state and store in pool 
	- when a new instance is requested, that pooled instance is returned instead of setting up a new one (cost once)

Compiled queries (DbContext)
- Issue: 
	- EF receive a LINQ query to produce SQL
	- Some operations: recursively compared with the expression trees, so on...
	- EF caches queries (ensures that executing the same LINQ query multiple times is very fast, even if parameter values differ)
- Solution:
	- Compiled queries: 
		+ Explicit compilation of a LINQ query into a .NET delegate
		+ Invoked directly to execute the query, without providing the LINQ expression tree
		+ Bypasses the cache lookup, optimize the query executing
	- Limitations: 
		+ Only be used against a single EF Core model, a context instance
		+ Parameters are simple

Model
- Fluent API > Data anotation
- Default nullable reference types (NRT) enable in Properties Project
	+ With NRT: `string` -> required property, `string?` -> optional property
	+ Without NRT: `[Required]` -> required property, default is optional property

client and server
- client evaluation: data is pulled into memory to execute/query at client (poor performance sometimes)
- server evaluation: data is execute/query at server (priority)
=> When parts of the query can't be translated into SQL to server, EF Core fetch data from server to evaluate query at client
```c#
var groupedHighlyRatedBlogs = await context.Blogs
    .AsQueryable()
    .Where(b => b.Rating > 3) // server-evaluated
    .AsAsyncEnumerable()
    .GroupBy(b => b.Rating) // client-evaluated
    .ToListAsync();
```
- client evaluation (CE) careful: 
  - CE explicit: call method like `AsEnumerable` or `ToList` (`AsAsyncEnumerable` or `ToListAsync`). `AsEnumerable` stream result, `ToList` buffer by create a list (take additional memory)
  - Avoid potential memory leak by: (in LINQ) constants can't be garbage collected since they're still being referenced => memory grow over time. Solution:
     + Using an instance method
     + Passing constant arguments to method
     + Use local variable into parameter

Query (DBContext)
- Identity resolution: result contains the same entity multiple times, the same instance is returned for each occurrence (default for tracking)
- No-tracking: read-only scenario
	- Identity resolution: return new instance of entity when query
- Tracking: 
	- track when 
		+ returns an anonymous type: `blog = context.Blogs.Select(b => new { Blog = b, PostCount = b.Posts.Count() });`
		+ result set contains entity types coming out from LINQ: `blog = context.Blogs.Select(b => new { Blog = b, Post = b.Posts.OrderBy(p => p.Rating).LastOrDefault() });`
		+ pass entity to client method: `blogs = context.Blogs.Select(b => new { Id = blog.BlogId, Url = StandardizeUrl(blog) });`
	- NO track when
		+ result set doesn't contain any entity types, then **NO** tracking: `blog = context.Blogs.Select(b => new { Id = b.BlogId, b.Url });`
		+ result set contain the keyless entity

Load navigation property
- Eager: `Include()`, load from DB as initial query (RECOMMEND)
	- Filtered include: consider using NoTracking
- Explicit: load at a later time, `DbContext.Entry(...)`
- Lazy: load when navigation property is accessed, `UseLazyLoadingProxies()`
- Explicit and Lazy load related entities that aren't needed (AVOID)

Split Query
- Cartesian explosion: huge unintentional data to client (include duplicate) when `Include()` 2 tables at the same level
	```c#
		var blogs = ctx.Blogs.Include(b => b.Posts)
							 .Include(b => b.Contributors).ToList();
	```
	- Solution: `Include()` 2 tables aren't at the same level (using `ThenInclude()`)
	```c#
		var blogs = ctx.Blogs.Include(b => b.Posts)
							 .ThenInclude(b => b.Contributors).ToList();
	```
- Data duplication: avoid duplication by using `Select()` to get the necessary properties
	```c#
		var blogs = ctx.Blogs.Select(b => new
							{
								b.Id,
								b.Name,
								b.Posts
							}).ToList();
	```
- Split query: avoid the above problems by using `AsSplitQuery()`
	- Default LINQ `var blogs = ctx.Blogs.Include(b => b.Posts).ToList();` transfer into SQL `Blog LEFT JOIN Posts`
		```sql
			SELECT [b].[Id], [b].[Name], [b].[HugeColumn], [p].[Id], [p].[BlogId], [p].[Title]							        FROM [Blogs] AS [b]
	        LEFT JOIN [Posts] AS [p] ON [b].[Id] = [p].[BlogId]
	        ORDER BY [b].[Id]
		```
	- Using `AsSplitQuery()` in LINQ `var blogs = ctx.Blogs.Include(b => b.Posts).AsSplitQuery().ToList();` equivalent to SQL (self table + `INNER JOIN`)
		```sql
			SELECT [b].[BlogId], [b].[OwnerId], [b].[Rating], [b].[Url]
	        FROM [Blogs] AS [b]
	        ORDER BY [b].[BlogId]

			SELECT [p].[PostId], [p].[AuthorId], [p].[BlogId], [p].[Content], [p].[Rating], [p].[Title], [b].[BlogId]
	        FROM [Blogs] AS [b]
	        INNER JOIN [Posts] AS [p] ON [b].[BlogId] = [p].[BlogId]
	        ORDER BY [b].[BlogId]
		```
	- Using split queru with `Skip/Take`, check carefully `Order` column
		- Ex: if results are ordered by Date, but multiple results with the same Date => split query get different results
		- Solution: Order by *unique property* or *combination of properties* (unique required)
		- Ex solution: use Data and ID
	- Disadvantages:
		- No guarantees exist for multiple queries => single querie is more consistent (issue DB is updated concurrently when executing multiple queries)
		- Need more the additional network to DB => latency to DB is high
		- Some DB do not support multiple queries => most results must be buffered in memory => increase memory
		- When `Include()` multiple reference navigations / collection navigations => degrade performance [issue](https://github.com/dotnet/efcore/issues/29182)

Pagination
- Make sure order is unique
- Use `Skip` and `Take` (`OFFSET` and `LIMIT` in SQL) (NOT RECOMMEND)
	- Ex: `ctx.Posts.OrderBy(b => b.PostId).Skip(20).Take(10).ToList()`
	- Issues:
		- DB still process the first 20 entries
		- Wrong results when any updates occur concurrently
- Keyset pagination
	- Use `WHERE` to skip rows
	 ```
		lastId = 20;
		ctx.Posts.OrderBy(b => b.PostId).Where(b.PostId > lastId).Take(10).ToList()	 ```	- Issues: Not use in concurrent changes and random access pagination- Multiple pagination keys	- Order by more than 1 property	- Ex: use Date and ID	``` c#		var lastDate = new DateTime(2020, 1, 1);
		var lastId = 55;
		var nextPage = context.Posts
			.OrderBy(b => b.Date)
			.ThenBy(b => b.PostId)
			.Where(b => b.Date > lastDate || (b.Date == lastDate && b.PostId > lastId))
			.Take(10)
			.ToList();	```- Index	- Index speed up query, but slow down updates (they need to be kept up-to-date)	=> Avoid defining index which aren't needed, use [index filters](https://learn.microsoft.com/en-us/ef/core/modeling/indexes#index-filter)Save data- Tracked Changes: using `SaveChanges()` (add, update, delete)	- Add:		```c#			var blog = new Blog { Url = "http://example.com" };
			context.Blogs.Add(blog);
			context.SaveChanges();
		```
	- Update:		```c#			var blog = context.Blogs.Single(b => b.Url == "http://example.com");
  			blog.Url = "http://example.com/blog";
			context.SaveChanges();
		```
	- Delete:		```c#			var blog = context.Blogs.Single(b => b.Url == "http://example.com/blog");
  			context.Blogs.Remove(blog);
			context.SaveChanges();
		```
- Untracked Changes: bulk update (update, delete), execute **immediately**
	- `ExecuteDelete`: delete multiple entities rather than delete one by one with `Remove`
		```c#			context.Blogs.Where(b => b.Rating < 3).ExecuteDelete();
		```
		- Equals 
			```sql 
				DELETE FROM [b] 
				FROM [Blogs] AS [b] 
				WHERE [b].[Rating] < 3
			```
	- `ExecuteUpdate`: update multiple entities, more details [ExecuteUpdate](https://learn.microsoft.com/en-us/ef/core/saving/execute-insert-update-delete#executeupdate)
		```c#			context.Blogs.Where(b => b.Rating < 3).ExecuteUpdate(setters => setters.SetProperty(b => b.IsVisible, false));
		```
		- Equals 
			```sql 
				UPDATE [b]
				SET [b].[IsVisible] = CAST(0 AS bit)
				FROM [Blogs] AS [b]
				WHERE [b].[Rating] < 3
			```
	- Use `SaveChanges` to persist tracked changes to DB after using `ExecuteDelete` or `ExecuteUpdate`
		```c#			context.Blogs.Where(b => b.Rating < 3).ExecuteUpdate(setters => setters.SetProperty(b => b.IsVisible, false));
			context.SaveChanges();
		```
	- Transaction: `ExecuteDelete` and `ExecuteUpdate` do not start a transaction. Solution:
		```c#			using (var transaction = context.Database.BeginTransaction())
			{
				context.Blogs.ExecuteUpdate(/* some update */);
				context.Blogs.ExecuteUpdate(/* another update */);

				...
			}
		```
		- Details: (Using Transactions)[https://learn.microsoft.com/en-us/ef/core/saving/transactions]

