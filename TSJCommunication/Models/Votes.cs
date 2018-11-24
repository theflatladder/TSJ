using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TSJCommunication.Models
{
    public class Votes
    {
        /// <summary>
        /// Id голоса в таблице Votes
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// User.Identity.Name
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Id опроса из таблицы
        /// </summary>
        public int PollId { get; set; }

        /// <summary>
        /// Id из таблицы Options которое пользователь выбрал
        /// </summary>
        public int OptionId { get; set; }

        
    }
}