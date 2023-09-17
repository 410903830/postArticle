﻿using postArticle.Models;
using postArticle.viewmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;

namespace postArticle.Controllers
{
    public class CharRoomController : Controller
    {
        //---------------基礎屬性-----------------------------------------
        #region 基礎屬性
        private healingForestEntities db = new healingForestEntities();

        public BasicData basicData = new BasicData();
        public bool CheckLoggedIn() => Session["UserID"] != null;

        public int GetUserID() => Convert.ToInt32(Session["UserID"]);

        #endregion
        // -----------------------------------------===============================
        public ActionResult FindChatUser()
        {
            if (CheckLoggedIn())
            {
                int MyUserId = GetUserID();
                UserManage currentUser = db.UserManages.Find(MyUserId);
                string currentUserUsername = currentUser.UserName;

                var chatroom = db.Chatrooms.FirstOrDefault(cr => cr.member.Contains("/" + currentUserUsername + "/") ||
                                                   cr.member.StartsWith(currentUserUsername + "/") ||
                                                   cr.member.EndsWith("/" + currentUserUsername));

                if (chatroom != null)
                {
                    string member = chatroom.member;

                    // 拆分 member 字符串，并选择非当前用户的用户名
                    string[] usernames = member.Split('/');
                    string otherUserName = "";
                    int OtherUserID;

                    foreach (string username in usernames)
                    {
                        if (username != currentUserUsername)
                        {
                            otherUserName = username;
                            break;
                        }
                    }
                    var UserManageID = from UserManagedb in db.UserManages
                                       where UserManagedb.UserName == otherUserName
                                       select UserManagedb.UserID;

                    if (UserManageID.Any())
                    {
                        OtherUserID = UserManageID.FirstOrDefault();

                        return RedirectToAction("DemoChar", "CharRoom", new { id = OtherUserID });
                    }
                }
            }
            return RedirectToAction("UserIndex", "CharRoom");
        }

        public ActionResult UserIndex()
        {
            if (CheckLoggedIn())
            {
                int currentUserID = GetUserID();// 填入當前使用者的 userID

                var userManage = db.UserManages
                            .Where(u => u.UserID != currentUserID)
                            .Include(u => u.ThanksfulThing)
                            .ToList();

                return View(userManage.ToList());
            }
            return RedirectToAction("ArticleIndex", "Home");
        }


        public ActionResult DemoChar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            int MyUserId = GetUserID();
            UserManage currentUser = db.UserManages.Find(MyUserId);
            UserManage otherUser = db.UserManages.Find(id);

            if (otherUser == null || !CheckLoggedIn())
            {
                return HttpNotFound();
            }

            string currentUserUsername = currentUser.UserName;
            string otherUserUsername = otherUser.UserName;

            string memberName1 = currentUserUsername + "/" + otherUserUsername;
            string memberName2 = otherUserUsername + "/" + currentUserUsername;

            Chatroom chatroom = db.Chatrooms.FirstOrDefault(cr => cr.member == memberName1 || cr.member == memberName2);

            if (chatroom == null)
            {
                chatroom = new Chatroom
                {
                    member = memberName1,
                    ChatRoomName = memberName2 + "的私聊"
                };

                db.Chatrooms.Add(chatroom);
                db.SaveChanges();
            }

            int chatRoomID = chatroom.ChatroomID;

            var chatRoomLogList = db.ChatroomLogs.Where(cl => cl.ChatroomID == chatRoomID);

            TempData["ChatRoomID"] = chatRoomID;
            TempData["userManageID"] = id;

            List<Chatroom> chatrooms = db.Chatrooms
                .Where(cr => cr.member.Contains("/" + currentUserUsername + "/") ||
                             cr.member.StartsWith(currentUserUsername + "/") ||
                             cr.member.EndsWith("/" + currentUserUsername))
                .ToList();

            return View(new DemoCharViewModel
            {
                ChatRoomLog = chatRoomLogList,
                OtherUser = otherUserUsername,
                MyUser = currentUserUsername,
                ChatRoom = chatrooms,
                ChatRoomName = chatroom.ChatRoomName,
                OtherUserId = (int)id,
                myUserId = MyUserId
            });
        }

        public ActionResult CreateCharLog(DemoCharViewModel demoCharViewModel)
        {
            if (demoCharViewModel == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            int ChatRoomID = (int)(TempData["ChatRoomID"]);
            int id = (int)TempData["userManageID"];

            Chatroom Chatroom = db.Chatrooms.Find(ChatRoomID);

            if (Chatroom == null || !CheckLoggedIn())
            {
                return HttpNotFound();
            }

            int UserID = GetUserID();

            if (!string.IsNullOrEmpty(demoCharViewModel.Log))
            {
                if (ModelState.IsValid)
                {
                    ChatroomLog ChatroomLog = new ChatroomLog
                    {
                        Content = demoCharViewModel.Log,
                        UserID = UserID,
                        ChatroomID = ChatRoomID,
                        Time = DateTime.Now
                    };


                    db.ChatroomLogs.Add(ChatroomLog);
                    db.SaveChanges();
                }
            }

            return RedirectToAction("DemoChar", "CharRoom", new { id });
        }

        public ActionResult OtherChatRoom(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Chatroom Chatroom = db.Chatrooms.Find(id);

            if (Chatroom == null || !CheckLoggedIn())
            {
                return HttpNotFound();
            }

            int UserID = GetUserID();

            UserManage UserManage = db.UserManages.Find(UserID);
            string MyUserName = UserManage.UserName;

            string member = Chatroom.member;

            // 拆分 member 字符串，并选择非当前用户的用户名
            string[] usernames = member.Split('/');
            string otherUserName = "";
            int OtherUserID;

            foreach (string username in usernames)
            {
                if (username != MyUserName)
                {
                    otherUserName = username;
                    break;
                }
            }

            var UserManageID = from UserManagedb in db.UserManages
                               where UserManagedb.UserName == otherUserName
                               select UserManagedb.UserID;

            if (UserManageID.Any())
            {
                OtherUserID = UserManageID.FirstOrDefault();

                return RedirectToAction("DemoChar", "CharRoom", new { id = OtherUserID });
            }
            else
            {
                return HttpNotFound();

            }

        }



        public ActionResult Charmember()
        {

            var Expert = from a in db.UserManages
                         where a.UserType == "Expert"
                         select a;


            return View(Expert);
        }






    }
}