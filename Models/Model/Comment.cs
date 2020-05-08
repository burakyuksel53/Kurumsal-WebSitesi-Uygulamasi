using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KurumsalWeb1.Models.Model
{
    [Table("Comment")]
    public class Comment
    {

        public int CommentId { get; set; }

        [Required,StringLength(50,ErrorMessage ="En fazla 50 karakter olabilir.")]
        public string NameSurname { get; set; }


        public string EPosta { get; set; }

        [DisplayName("Yorumunuz")]
        public string UserComment { get; set; }

        public bool Confirm { get; set; }

        public int? BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}