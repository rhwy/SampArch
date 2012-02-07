using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.WindowsAzure.StorageClient;
using Microsoft.WindowsAzure;
using SampArchi.Infrastructure.Azure.TableEntities.Blog;
using SampArchi.Infrastructure.Azure.TableEntities.Common;
using SampArchi.Infrastructure.Azure.TableEntities.Ideas;

namespace SampArchi.Infrastructure.Azure
{
    public class SampleArchTableContext : TableServiceContext
    {
        public SampleArchTableContext(string baseAddress, StorageCredentials credentials)
            : base(baseAddress, credentials)
        {

        }

        #region Blog
        public IQueryable<PostTableEntity> Posts
        {
            get { return CreateQuery<PostTableEntity>("Posts"); }
        } 
        #endregion

        #region Common
        public IQueryable<CommentTableEntity> Comments
        {
            get { return CreateQuery<CommentTableEntity>("Comments"); }
        }

        public IQueryable<RoleTableEntity> Roles
        {
            get { return CreateQuery<RoleTableEntity>("Roles"); }
        }

        public IQueryable<TagTableEntity> Tags
        {
            get { return CreateQuery<TagTableEntity>("Tags"); }
        }

        public IQueryable<UserTableEntity> Users
        {
            get { return CreateQuery<UserTableEntity>("Users"); }
        } 
        #endregion

        #region Ideas

        public IQueryable<IdeaTableEntity> Suggests
        {
            get { return CreateQuery<IdeaTableEntity>("Suggests"); }
        }

        public IQueryable<VoteTableEntity> Votes
        {
            get { return CreateQuery<VoteTableEntity>("Votes"); }
        }

        #endregion
    }
}
