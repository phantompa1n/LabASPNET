using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameAPP.Models
{
    public class Record
    {
        public int Id { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("Player")]
        public int Player_Id { get; set; }

        public int Size_field { get; set; }
        public int Step_count { get; set; }

        public Player Player { get; set; }
    }
}