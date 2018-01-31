using App15.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.ViewModels
{
    class HomeViewModel
    {
        public ViewPosts feedPosts { get; set; }
        public ViewPosts userPosts { get; set; }
        public ViewComments userComments { get; set; }
        public ViewPosts userLikedPosts { get; set; }
        public ViewPosts userCommentedPosts { get; set; }
        public ViewPosts userPostsLiked { get; set; }
        public ViewPosts userPostsCommented { get; set; }

        public HomeViewModel()
        {
            feedPosts = new ViewPosts("https://socialnetworking1.d4science.org/social-networking-library-ws/rest/2/posts/get-posts-vre?gcube-token=994e41a4-01fb-4c6b-b953-24d02c8a5949-843339462");
            userPosts = new ViewPosts("https://socialnetworking1.d4science.org/social-networking-library-ws/rest/2/posts/get-posts-user?gcube-token=994e41a4-01fb-4c6b-b953-24d02c8a5949-843339462");
            userComments = new ViewComments("https://socialnetworking1.d4science.org/social-networking-library-ws/rest/2/comments/get-comments-user?gcube-token=994e41a4-01fb-4c6b-b953-24d02c8a5949-843339462");
            userLikedPosts = new ViewPosts("https://socialnetworking1.d4science.org/social-networking-library-ws/rest/2/posts/get-liked-posts?gcube-token=994e41a4-01fb-4c6b-b953-24d02c8a5949-843339462");

            userCommentedPosts= new ViewPosts(null);
            foreach(var post in feedPosts.posts.result)
            {
                foreach (var comment in userComments.comments.result)
                {
                    if(String.Compare(comment.feedid, post.key) == 0)
                    {
                        userCommentedPosts.posts.result.Add(post);
                        break;
                    }
                }
            }
            userCommentedPosts.posts.success = true;
            userCommentedPosts.posts.message = null;
            userCommentedPosts.total = userCommentedPosts.posts.result.Count();

            userPostsLiked = new ViewPosts(null);
            userPostsLiked.total = 0;
            foreach (var post in userPosts.posts.result)
            {
                int numVal = Int32.Parse(post.likes_no);
                if(numVal > 0)
                {
                    userPostsLiked.posts.result.Add(post);
                    userPostsLiked.total += numVal;
                }
            }
            userPostsLiked.posts.success = true;
            userPostsLiked.posts.message = null;

            userPostsCommented = new ViewPosts(null);
            userPostsCommented.total = 0;
            foreach (var post in userPosts.posts.result)
            {
                int numVal = Int32.Parse(post.comments_no);
                if (numVal > 0)
                {
                    userPostsCommented.posts.result.Add(post);
                    userPostsCommented.total += numVal;
                }
            }
            userPostsCommented.posts.success = true;
            userPostsCommented.posts.message = null;
        }
    }
}
