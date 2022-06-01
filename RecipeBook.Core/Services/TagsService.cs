using RecipeBook.Core.Database;
using RecipeBook.Core.Database.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Core.Services
{
    /// <summary>
    /// Database queries to Tags table
    /// </summary>
    public static class TagsService
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tagName"></param>
        /// <returns>id of tag by given name</returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tagName"></param>
        /// <returns>tag id</returns>
        public static int FindTag(string tagName)
        {
            using (var context = new MyDbContext())
            {
                int tagId = context.Tags.Where(x => x.TagName == tagName)
                .Select(x => x.TagId).FirstOrDefault();
                return tagId;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tagsIds">list of tags ids</param>
        /// <returns>returns list of tags name by their ids</returns>
        public static List<string> GetTagsName(List<int> tagsIds) 
        {
            List<string> tagsNames = new List<string>();

            using (var context = new MyDbContext())
            {
                foreach (var item in tagsIds)
                {
                    tagsNames.Add(context.Tags.Where(x => x.TagId == item).Select(x => x.TagName).Single());
                }
                return tagsNames;
                
            }
        }

    }
}
