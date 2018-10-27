using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TSJCommunication.Models
{
    public class Polls
    {
        /// <summary>
        /// Id голосования в таблице Polls
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Заголовок голосования
        /// </summary>
        public string Title { get; set; }
        
        /// <summary>
        /// Описание, дополнительная информация к опросу
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// True = checkBox
        /// False = radioButton
        /// </summary>
        public bool MultipleChoice { get; set; }

        
    }
}