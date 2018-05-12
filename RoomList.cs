
namespace wh_at_Helpdesk__for_Windows_10_
{
    public class RoomList
    {
        public string RoomName { get; set; }

        public string Block { get; set; }

        public override string ToString()
        {
            return RoomName;
        }

        public RoomList(string RoomName, string Block)
        {
            this.RoomName = RoomName;
            this.Block = Block;
        }
    }
}
