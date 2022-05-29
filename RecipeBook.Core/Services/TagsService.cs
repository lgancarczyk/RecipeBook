using RecipeBook.Core.Database;
using RecipeBook.Core.Database.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Core.Services
{
    public static class TagsService
    {

        public static int AddTag(string tagName)
        {
            using (var context = new MyDbContext())
            {
                var tagId = FindTag(tagName);

                if (tagId == 0)
                {
                    var tag = new TagDbModel()
                    {
                        TagName = tagName
                    };
                    var x = context.Tags.Add(tag);
                    context.SaveChanges();
                    tagId = FindTag(tagName);
                }
                return tagId;
            }
        }

        public static  int FindTag(string TagName)
        {
            using (var context = new MyDbContext())
            {
                int tagId = context.Tags.Where(x => x.TagName == TagName)
                .Select(x => x.TagId).FirstOrDefault();
                return tagId;
            }
        }

    }
}
