namespace TaskManagmant.Help
{
    public class ReportItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TeamLeader { get; set; }
        public int Hours { get; set; }
        public double Presence { get; set; }
        public string PresencePercent { get; set; }
        public string Customer { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int? Days { get; set; }
        public int? WorkedDays { get; set; }
        public string WorkedPercent { get; set; }
        public string State { get; set; }
        public int ParentId { get; set; }

        //overloading c'tors

        public ReportItem() { }

        public ReportItem(
            int id, string name, int hours, double presence,
            string presencePercent, int parentId)
        {
            Id = id;
            Name = name;
            Hours = hours;
            Presence = presence;
            PresencePercent = presencePercent;
            ParentId = parentId;
        }

        public ReportItem(
            int id, string name, string teamLeader, int hours, double presence,
            string presencePercent, int parentId) : this(id, name, hours, presence, presencePercent, parentId)
        {
            TeamLeader = teamLeader;
        }

        public ReportItem(
            int id, string name, string teamLeader, int hours, double presence,
            string presencePercent, string customer, string startDate, string endDate, int? days,
            int? workedDays, string workedPercent, string state, int parentId) : this(id, name, teamLeader, hours, presence, presencePercent, parentId)
        {
            Customer = customer;
            StartDate = startDate;
            EndDate = endDate;
            Days = days;
            WorkedDays = workedDays;
            WorkedPercent = workedPercent;
            State = state;
        }
    }
}
