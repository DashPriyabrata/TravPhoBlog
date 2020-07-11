using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public class InstagramPost
    {
        public string Id { get; set; }
        public string Media_Url { get; set; }
        public string Caption { get; set; }
        public string Media_Type { get; set; }
        public DateTime Timestamp { get; set; }
        public string Permalink { get; set; }
        public string Thumbnail_Url { get; set; }
    }

    public class Media
    {
        public List<Post> Data { get; set; }
        public Paging Paging { get; set; }
    }

    public class Post
    {
        public string Id { get; set; }
    }

    public class Paging
    {
        public Cursors Cursors { get; set; }
    }

    public class Cursors
    {
        public string Before { get; set; }
        public string After { get; set; }
    }
}