using Blog.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AngularExampleVs.UnitTests.ControllersTests
{
    public class InMemoryBlogPostsControllerTests : BlogPostsControllerTests
    {
        public InMemoryBlogPostsControllerTests()
            : base(
                  new DbContextOptionsBuilder<BlogPostsContext>()
                  .UseInMemoryDatabase("TestDatabase")
                  .Options)
        {
        }
    }
}
