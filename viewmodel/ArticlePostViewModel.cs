﻿using postArticle.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace postArticle.viewmodel
{
    public class ArticleManageViewModel
    {

        [AllowHtml]
        public Article article { get; set; }



        public bool IsChecked { get; set; }
        public ArticleManageViewModel()
        {

            article = new Article(); // 初始化 article 对象

            IsChecked = false; // 初始化 IsChecked 属性

        }


        public string[] Classification =
        {
            "工作","健康","學業","家庭","經濟"
        };

    }
}