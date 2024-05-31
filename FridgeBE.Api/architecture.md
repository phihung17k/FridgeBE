in repository
- Avoid returning `IQueryable`, because it breaks encapsulation and leaks data access responsiblities out of the repository abstraction where it belongs
	+ Add additional methods to the Repository as needed
- Return `IReadOnlyLis`t when return read-only list
	+ Common operations: indexing, iteration, and Count retrieval
- Return `IEnumerable` when using In-Memory Operations
	+ Common operations: filtering, sorting, and mapping in-memory after data retrieval
- Return `List`: a resizable and index-based collection
	+ Common operations: adding, removing, finding, sorting, and more


Flow: Api - Infrastructure - Core
(Controller - Service - Repository)

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