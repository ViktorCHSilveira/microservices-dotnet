﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.Product.Api.Model.Base {
    public class BaseEntity {

        [Key]
        [Column("id")]
        public long id { get; set; }

    }
}
