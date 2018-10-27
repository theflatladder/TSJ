using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TSJCommunication.Models
{
    public class Options
    {
        /// <summary>
        /// Id варианта в таблице Options
        /// </summary>
        public int Id { get; set; }


        /// <summary>
        /// Id голосования в таблице Polls
        /// </summary>
        public int PollId { get; set; }

        /// <summary>
        /// Текст варианта 
        /// </summary>
        public string Value { get; set; }
    }
}