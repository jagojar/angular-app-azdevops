using Blog.Controllers;
using Blog.Data;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AngularExampleVs.UnitTests
{
    public abstract class BlogPostsControllerTests
    {
        protected DbContextOptions<BlogPostsContext> _contextOptions { get; }
        protected BlogPostsControllerTests(DbContextOptions<BlogPostsContext> contextOptions)
        {
            _contextOptions = contextOptions;
            Seed();
        }

        private void Seed()
        {
            using (var context = new BlogPostsContext(_contextOptions))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                int count = 3;

                for (int i = 0; i < count; i++)
                {
                    int id = i + 1;
                    var blogPost = new BlogPost
                    {
                        PostId = id,
                        Title = $"Title {id}",
                        Body = $"Body {id}",
                        Creator = $"Creator {id}",
                        Dt = DateTime.Now
                    };

                    context.Set<BlogPost>().Add(blogPost);
                }

                context.SaveChanges();
            }
        }
    

        [Fact]
        public void BlogPostsController_Adds_BlogPosts_Result_Is_Not_Null_Repo_Add_and_Save_Once()
        {
            var blogPost = new Mock<BlogPost>();

            var context = new BlogPostsContext(_contextOptions);
            var mockRepository = new Mock<IDataRepository<BlogPost>>();

            mockRepository.Setup(m => m.Add(It.IsAny<BlogPost>()));
            mockRepository.Setup(m => m.SaveAsync(It.IsAny<BlogPost>()));

            BlogPostsController controller = new BlogPostsController(context, mockRepository.Object);
            var result = controller.PostBlogPost(blogPost.Object);

            mockRepository.Verify(m => m.Add(It.IsAny<BlogPost>()), Times.Once());
            mockRepository.Verify(m => m.SaveAsync(It.IsAny<BlogPost>()), Times.Once());

            Assert.NotNull(result);
            Assert.NotNull(result.Result);
            Assert.IsType<ActionResult<BlogPost>>(result.Result);
        }

        [Fact]
        public void BlogPostsController_Get_All_BlogPosts_Result_Is_3_BlogPosts()
        {
            var context = new BlogPostsContext(_contextOptions);
            var repo = new DataRepository<BlogPost>(context);
                        

            BlogPostsController controller = new BlogPostsController(context, repo);
            var result = controller.GetBlogPost();

            Assert.NotNull(result);
            Assert.NotNull(result.Result);
            Assert.IsAssignableFrom<IEnumerable<BlogPost>>(result.Result.Value);
            Assert.Equal(3, result.Result.Value.Count());
        }
    }
}
