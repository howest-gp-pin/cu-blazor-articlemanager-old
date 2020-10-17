using ArticleManager.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ArticleManager.Core.Entities
{
    public class Article: EntityBase<int>
    {
        [Required]
        [StringLength(500)]
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string Content { get; set; }
    }
}
