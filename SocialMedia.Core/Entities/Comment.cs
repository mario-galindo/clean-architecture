﻿using System;

namespace SocialMedia.Core.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public bool IsActive { get; set; }

        public Post Post { get; set; }
        public User User { get; set; }
    }
}
