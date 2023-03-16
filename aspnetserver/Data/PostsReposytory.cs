using Microsoft.EntityFrameworkCore;

namespace aspnetserver.Data
{
    internal static class PostsReposytory
    {
        internal async static Task<List<Post>> GetPostsAsync()
        {
            using(var db = new appDBContext())
            {
                return await db.Post.ToListAsync();
            }
            
        }

        internal async static Task<Post> GetPostById(int PostId)
        {
            using (var db = new appDBContext())
            {
                return await db.Post.FirstOrDefaultAsync(predicate: post => post.PostId == PostId);
            }
        }

        internal async static Task<bool> CreatePostAsync(Post postToCreate)
        {
            using (var db = new appDBContext())
            {
                try
                {
                    await db.Post.AddAsync(entity: postToCreate);
                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception e)
                {

                    return false;
                }
            }
        }

        internal async static Task<bool> updatePostAsync(Post postToUpdate)
        {
            using (var db = new appDBContext())
            {
                try
                {
                    db.Post.Update(entity: postToUpdate);
                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception e)
                {

                    return false;
                }
            }
        }

        internal async static Task<bool> deletePostAsync(int postId)
        {
            using (var db = new appDBContext())
            {
                try
                {
                    Post postToDelete = await GetPostById(PostId: postId);
                    db.Remove(entity: postToDelete);
                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception e)
                {

                    return false;
                }
            }
        }
    }
}
