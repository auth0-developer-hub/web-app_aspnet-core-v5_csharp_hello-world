namespace App.Models.ViewComponents
{
    public class NavBarModel
    {
        public string activeRoute { get; set; }

        public NavBarModel(string activeRoute)
        {
            this.activeRoute = activeRoute;
        }
    }
}
