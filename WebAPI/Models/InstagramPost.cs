using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class InstagramPost
    {
        public Pagination Pagination { get; set; }
        public List<ImageData> Data { get; set; }
        public Meta Meta { get; set; }
    }

    public class ImageData
    {
        public string Id { get; set; }
        public User User { get; set; }
        public Images Images { get; set; }
        public string Created_Time { get; set; }
        public object Caption { get; set; }
        public bool User_Has_Liked { get; set; }
        public Likes Likes { get; set; }
        public List<object> Tags { get; set; }
        public string Filter { get; set; }
        public string Type { get; set; }
        public string Link { get; set; }
        public Location Location { get; set; }
        public object Attribution { get; set; }
    }

    public class Pagination
    {
    }

    public class User
    {
        public string Id { get; set; }
        public string Full_Name { get; set; }
        public string Profile_Picture { get; set; }
        public string Username { get; set; }
    }

    public class ImageDetails
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public string Url { get; set; }
    }
    
    public class Images
    {
        public ImageDetails Thumbnail { get; set; }
        public ImageDetails Low_Resolution { get; set; }
        public ImageDetails Standard_Resolution { get; set; }
    }

    public class Likes
    {
        public int Count { get; set; }
    }

    public class Location
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
    }

    public class Meta
    {
        public int Code { get; set; }
    }
}