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
            if (!context.HistoryList.Any())
            {
                var Posts = new List<HistEvent>
                {
                    new HistEvent {
                        Title = "First post",
                        Tags = TagsGenerator.TestTags(10),
                        Date = DateTime.Now.AddDays(-10)
                    },
                    new HistEvent {
                        Title = "Second post",
                        Tags = TagsGenerator.TestTags(10),
                        Date = DateTime.Now.AddDays(-7)
                    },
                    new HistEvent {
                        Title = "Third post",
                        Tags = TagsGenerator.TestTags(10),
                        Date = DateTime.Now.AddDays(-4)
                    }
                };

                context.HistoryList.AddRange(Posts);
                context.SaveChanges();
            }
        }
    }
}