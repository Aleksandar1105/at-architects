﻿namespace AtArchitects.Domain.Models
{
    using System.ComponentModel.DataAnnotations;

    public class NewsletterSubscriber : BaseEntity
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        public DateTime SubscriptionDate { get; set; } = DateTime.UtcNow;

        public DateTime? LatestEmailSentDate { get; set; } = null;
    }
}
