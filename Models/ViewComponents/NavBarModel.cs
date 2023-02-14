namespace App.Models.ViewComponents
{
    public class NavBarModel
    {
        public string activeRoute { get; set; }
        public bool isAuthenticated { get; set; }

        public NavBarModel(string activeRoute, bool isAuthenticated)
        {
            this.activeRoute = activeRoute;
            this.isAuthenticated = isAuthenticated;
        }
    }
}
