using System;
using System.Linq;
using System.Reflection.Metadata;
namespace ef_task;
class Program
{
    static void Main(string[] args)
    {
        var db = new BloggingContext();

        // Note: This sample requires the database to be created before running.
        Console.WriteLine($"Database path: {db.DbPath}");

        if (!db.Blogs.Any() || db.Posts.Any())
        {
            db.RemoveRange(db.Posts);
            db.RemoveRange(db.Blogs.ToList());
            db.SaveChanges();
        }

        // Create
        Console.WriteLine("Inserting a new blog");
        db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
        db.SaveChanges();

        // Read, We want to grab the first blog
        Console.WriteLine("Querying for a blog");
        var blog = db.Blogs.OrderBy(b => b.BlogId).First();
        Console.WriteLine(blog.Url);

        //Update
        Console.WriteLine("Updating the blog and adding a post");
        blog.Url = "https://devblogs.microsoft.com/dotnet";
        blog.Posts.Add(new Post { Title = "First Post ever LOL", Content = "Help me please" });
        db.SaveChanges();
        Console.WriteLine(blog.Url);

        // Delete
        Console.WriteLine("Delete the blog");
        db.Remove(blog);
        db.RemoveRange(db.Posts);
        db.RemoveRange(db.Blogs.ToList());
        db.SaveChanges();
    }
}