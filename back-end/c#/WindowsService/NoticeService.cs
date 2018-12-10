using BLL;
using BOL.Help;
using System.ServiceProcess;
using System.Timers;

namespace WindowsService
{
    public partial class NoticeService : ServiceBase
    {

        public NoticeService()
        {
            InitializeComponent();

        }

        protected override void OnStart(string[] args)
        {

            // Set up a timer that triggers every minute.
            Timer timer = new Timer();
            timer.Interval = 60000; // 60 seconds
            timer.Elapsed += new ElapsedEventHandler(OnTimer);
            timer.Start();
        }

        public void OnTimer(object sender, ElapsedEventArgs args)
        {
            // TODO: Insert monitoring activities here.
            Email email = new Email() { Subject = "first testing", Body = "windows service is working!!" };
            email.ToAddress.Add("efratz0879@gmail.com");
            BaseService.SendEmail(email);
        }

        protected override void OnStop()
        {

        }
       
    }
}
