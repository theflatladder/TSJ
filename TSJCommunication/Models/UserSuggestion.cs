using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TSJCommunication.Models
{
    /// <summary>
    /// Предложения пользователей о голосовании
    /// </summary>
    public class UserSuggestion
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Options { get; set; }
    }
}