namespace CanvasApp.API.Models
{
    public class Account
    {
        public int id { get; set; }
        public string name { get; set; }
        public string uuid { get; set; }
        public int parent_account_id { get; set; }
        public string workflow_state { get; set; }
    }
}