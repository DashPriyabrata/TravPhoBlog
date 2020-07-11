﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAPI.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class MyTravelBlogEntities : DbContext
    {
        public MyTravelBlogEntities()
            : base("name=MyTravelBlogEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<role> roles { get; set; }
        public virtual DbSet<blogger> bloggers { get; set; }
        public virtual DbSet<blog_user> blog_user { get; set; }
        public virtual DbSet<postcontent> postcontents { get; set; }
        public virtual DbSet<blog_tag> blog_tag { get; set; }
        public virtual DbSet<tag_mapper> tag_mapper { get; set; }
        public virtual DbSet<bloginfo> bloginfoes { get; set; }
        public virtual DbSet<blog_comment> blog_comment { get; set; }
        public virtual DbSet<blog_category> blog_category { get; set; }
        public virtual DbSet<newsletter_sub> newsletter_sub { get; set; }
        public virtual DbSet<panorama> panoramas { get; set; }
        public virtual DbSet<instagram> instagram { get; set; }
    
        public virtual ObjectResult<bloginfo> SP_NextPost(Nullable<int> postId)
        {
            var postIdParameter = postId.HasValue ?
                new ObjectParameter("PostId", postId) :
                new ObjectParameter("PostId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<bloginfo>("SP_NextPost", postIdParameter);
        }
    
        public virtual ObjectResult<bloginfo> SP_NextPost(Nullable<int> postId, MergeOption mergeOption)
        {
            var postIdParameter = postId.HasValue ?
                new ObjectParameter("PostId", postId) :
                new ObjectParameter("PostId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<bloginfo>("SP_NextPost", mergeOption, postIdParameter);
        }
    
        public virtual ObjectResult<bloginfo> SP_PrevPost(Nullable<int> postId)
        {
            var postIdParameter = postId.HasValue ?
                new ObjectParameter("PostId", postId) :
                new ObjectParameter("PostId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<bloginfo>("SP_PrevPost", postIdParameter);
        }
    
        public virtual ObjectResult<bloginfo> SP_PrevPost(Nullable<int> postId, MergeOption mergeOption)
        {
            var postIdParameter = postId.HasValue ?
                new ObjectParameter("PostId", postId) :
                new ObjectParameter("PostId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<bloginfo>("SP_PrevPost", mergeOption, postIdParameter);
        }
    
        public virtual ObjectResult<blog_tag> SP_GetBlogTags(Nullable<int> passedBlogTagId)
        {
            var passedBlogTagIdParameter = passedBlogTagId.HasValue ?
                new ObjectParameter("PassedBlogTagId", passedBlogTagId) :
                new ObjectParameter("PassedBlogTagId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<blog_tag>("SP_GetBlogTags", passedBlogTagIdParameter);
        }
    
        public virtual ObjectResult<blog_tag> SP_GetBlogTags(Nullable<int> passedBlogTagId, MergeOption mergeOption)
        {
            var passedBlogTagIdParameter = passedBlogTagId.HasValue ?
                new ObjectParameter("PassedBlogTagId", passedBlogTagId) :
                new ObjectParameter("PassedBlogTagId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<blog_tag>("SP_GetBlogTags", mergeOption, passedBlogTagIdParameter);
        }
    
        public virtual ObjectResult<bloginfo> SP_GetLastFiveCommentedPosts()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<bloginfo>("SP_GetLastFiveCommentedPosts");
        }
    }
}
