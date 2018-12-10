using System.Collections.Generic;

namespace BOL.Help
{
    public class Email
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<string> ToAddress { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Email()
        {
            ToAddress = new List<string>();
            UserName = "taskManagementCompany@gmail.com";
            Password = "tm!@#qwe";

        }
   
    }
}
