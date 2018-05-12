
namespace wh_at_Helpdesk__for_Windows_10_
{
    public class ProblemList
    {
        public string ProblemName { get; set; }

        public string ProblemType { get; set; }

        //public string Address { get; set; }

        //public string Phone { get; set; }

        public override string ToString()
        {
            return ProblemName;
        }

        public ProblemList(string RoomName, string Block)//, string address, string phone)
        {
            this.ProblemName = ProblemName;
            this.ProblemType = ProblemType;
            //this.Address = address;
            //this.Phone = phone;
        }
    }
}
