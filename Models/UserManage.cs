//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace postArticle.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class UserManage
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserManage()
        {
            this.Articles = new HashSet<Article>();
            this.Chatrooms = new HashSet<Chatroom>();
            this.Chatrooms1 = new HashSet<Chatroom>();
            this.ChatroomLogs = new HashSet<ChatroomLog>();
            this.Checkins = new HashSet<Checkin>();
            this.Collects = new HashSet<Collect>();
            this.ExpertAnswers = new HashSet<ExpertAnswer>();
            this.ExpertApplies = new HashSet<ExpertApply>();
            this.Likes = new HashSet<Like>();
            this.Messages = new HashSet<Message>();
            this.Moods = new HashSet<Mood>();
            this.Notifications = new HashSet<Notification>();
            this.Reports = new HashSet<Report>();
            this.ReportMembers = new HashSet<ReportMember>();
            this.ReportMembers1 = new HashSet<ReportMember>();
            this.UserQuestions = new HashSet<UserQuestion>();
        }


        public int UserID { get; set; }


        [Required(ErrorMessage = "請輸入暱稱")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "請輸入帳號")]
        public string Account { get; set; }

        [Required(ErrorMessage = "請輸入密碼")]
        public string Password { get; set; }

        [Required(ErrorMessage = "請輸入信箱")]
        public string Email { get; set; }
        public string UserType { get; set; }
        public int LevelValue { get; set; }
        public int Experience { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "請輸入生日")]
        public System.DateTime Birthday { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<int> ExpertExperience { get; set; }
        public string UserInfo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Article> Articles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chatroom> Chatrooms { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chatroom> Chatrooms1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChatroomLog> ChatroomLogs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Checkin> Checkins { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Collect> Collects { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExpertAnswer> ExpertAnswers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExpertApply> ExpertApplies { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Like> Likes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Message> Messages { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mood> Moods { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Notification> Notifications { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Report> Reports { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReportMember> ReportMembers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReportMember> ReportMembers1 { get; set; }
        public virtual ThanksfulThing ThanksfulThing { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserQuestion> UserQuestions { get; set; }
    }
}
