namespace FootlooseFS.Models
{
    public class FootlooseFSConfiguration
    {
        public string SQLConnectionString { get; set; }
        public string SecretKey { get; set; }
        public bool AllowUpdates { get; set; }
    }
}
