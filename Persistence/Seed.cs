using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Persistence
{
    public class Seed
    {
        public static void SeedData(DataContext context)
        {
            if (!context.Posts.Any())
            {
                var Posts = new List<Post>
                {
                    new Post {
                        Title = "First post",
                        Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        Date = DateTime.Now.AddDays(-10)
                    },
                    new Post {
                        Title = "Second post",
                        Body = "Ultrices gravida dictum fusce ut placerat orci nulla pellentesque. Augue interdum velit euismod in pellentesque. Et magnis dis parturient montes nascetur ridiculus. Placerat duis ultricies lacus sed turpis tincidunt id. Lectus sit amet est placerat in egestas erat imperdiet. Enim facilisis gravida neque convallis a cras semper auctor. Tempor id eu nisl nunc mi. Tristique nulla aliquet enim tortor at auctor urna nunc id. Gravida arcu ac tortor dignissim convallis aenean et tortor. At imperdiet dui accumsan sit amet nulla facilisi. Blandit massa enim nec dui nunc mattis. Dolor morbi non arcu risus quis varius. Auctor eu augue ut lectus.",
                        Date = DateTime.Now.AddDays(-7)
                    },
                    new Post {
                        Title = "Third post",
                        Body = "Adipiscing elit pellentesque habitant morbi tristique senectus. Sodales neque sodales ut etiam sit. Vel turpis nunc eget lorem dolor sed viverra ipsum. Tincidunt vitae semper quis lectus nulla at volutpat. Amet justo donec enim diam vulputate ut pharetra sit. Sapien pellentesque habitant morbi tristique senectus. Maecenas pharetra convallis posuere morbi. Consectetur a erat nam at. Eleifend donec pretium vulputate sapien nec sagittis aliquam malesuada. Eget gravida cum sociis natoque penatibus et magnis. Lorem ipsum dolor sit amet consectetur adipiscing elit.",
                        Date = DateTime.Now.AddDays(-4)
                    }
                };

                context.Posts.AddRange(Posts);
                context.SaveChanges();
            }
        }
    }
}