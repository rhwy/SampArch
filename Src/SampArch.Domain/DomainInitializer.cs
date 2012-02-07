using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SampArch.Domain.Common;
using SampArch.Domain.Ideas;
using SampArch.Domain.Blog;
namespace SampArch.Domain
{
    public class DomainInitializer
    {
        private static List<Role> _roles;

        public List<Role> DefineRoles()
        {
            if (_roles == null)
            {
                List<Role> roles = new List<Role>();
                roles.Add(new Role("admin"));
                roles.Add(new Role("site_author"));
                roles.Add(new Role("post_author"));
                roles.Add(new Role("idea_author"));
                roles.Add(new Role("guest"));
                _roles = roles;
            }
            return _roles;
        }

        public List<User> DefineDefaultUsers()
        {
            List<User> users = new List<User>();
            List<Role> roles = DefineRoles();
            User admin = new User("Admin");
            admin.Login = "admin";
            admin.Email = "admindemo@artofnet.com";
            admin.Roles.Add(roles.SingleOrDefault(r => r.Name == "admin"));
            users.Add(admin);

            return users;
        }

        public List<Idea> DefineStartingIdea()
        {
            List<Idea> ideas = new List<Idea>();
            Idea startIdea = new Idea();
            startIdea.Title = "what about creating an ideas site?";
            startIdea.Author = "admin";
            startIdea.CreationDate = DateTime.Now;
            startIdea.Comments.Add(new Comment { UserName = "Admin", Content = "vote and add your comments about the idea" , PublishDate=DateTime.Now.AddHours(1)});
            startIdea.Tags.Add(new Tag("demo"));
            startIdea.Tags.Add(new Tag("meta"));
            startIdea.Tags.Add(new Tag("News"));
            startIdea.VoteUp();

            ideas.Add(startIdea);

            return ideas;
        }


        public List<Post> DefineIntroductionPost()
        {
            List<Post> posts = new List<Post>();
            Post introductionPost = new Post();
            introductionPost.Title = "Welcome to our blog!";
            introductionPost.Content = @"#Hello world " + Environment.NewLine + Environment.NewLine + " This is our new blog, **enjoy**";
            introductionPost.Author = "admin";
            introductionPost.PublishDate = DateTime.Now.AddDays(-2);
            introductionPost.Comments.Add(new Comment { UserName = "Admin", Content = "share and comment please!", PublishDate=DateTime.Now.AddDays(-1) });
            introductionPost.Tags.Add(new Tag("News"));
            introductionPost.Tags.Add(new Tag("about"));

            posts.Add(introductionPost);


            Post secondPost = new Post();
            secondPost.Title = "This is our second post!";
            secondPost.Content = @"#Hello TD " + Environment.NewLine + Environment.NewLine + " We use **Markdown** in our view!";
            secondPost.Author = "admin";
            secondPost.PublishDate = DateTime.Now.AddDays(-1);
            secondPost.Tags.Add(new Tag("News"));
            
            posts.Add(secondPost);


            Post thirdPost = new Post();
            thirdPost.Title = "TD presentation";
            thirdPost.Content = @"#asp.net mvc" + Environment.NewLine + Environment.NewLine + "this is our pres!";
            thirdPost.Author = "admin";
            thirdPost.PublishDate = DateTime.Now;
            thirdPost.Tags.Add(new Tag("Events"));

            posts.Add(thirdPost);
            return posts;
        }
    }
}
