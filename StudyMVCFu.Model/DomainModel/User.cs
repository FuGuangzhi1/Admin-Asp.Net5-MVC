﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace StudyMVCFu.Model
{
    [Description("UserModel")]
    [Table("User")]
    public class User
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "plaese input UserName")]
        [StringLength(20, ErrorMessage = "It's too long ,please be less than 20")]
        public string Name { get; set; }
        [Required(ErrorMessage = "plaese input Account")]
        [StringLength(20, ErrorMessage = "It's too long ,please be less than 20")]
        public ulong? Account { get; set; }
        [StringLength(20)]
        public string Moblie { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        public ulong? QQ { get; set; }
        [Required(ErrorMessage = "plaese input CheckCode")]
        public string CheckCode { get; set; }
        [StringLength(20)]
        public bool? Remeber { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? CreateDateTime { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? UpdateDateTime { get; set; }
        public UserPassword UserPassword { get; set; }
        public Guid UserPasswordId { get; set; }


    }
}