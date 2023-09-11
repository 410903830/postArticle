﻿using postArticle.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace postArticle.viewmodel
{
    public class ArticleManageViewModel
    {
        public Article article { get; set; }

        public string[] Classification =
        {
            "工作","健康","學業","家庭","經濟"
        };

    }
}