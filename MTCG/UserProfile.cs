namespace MTCG
{
    public class UserProfile
    {
        public string Name { get; set; }
        public string Bio { get; set; }

        public UserProfile()
        {
            Name = "Unknown Player";
            Bio = "This player hasn't set a bio yet.";
        }
        
        // TODO: Edit profile
    }
}