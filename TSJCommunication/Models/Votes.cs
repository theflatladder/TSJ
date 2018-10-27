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
        /// Id проголосовавшего пользователя из таблицы Users
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Id опроса из таблицы
        /// </summary>
        public int PollId { get; set; }

        /// <summary>
        /// Индекс выбранного варианта (для списка Options в таблице Polls)
        /// </summary>
        public int OptionIndex { get; set; }

        
    }
}