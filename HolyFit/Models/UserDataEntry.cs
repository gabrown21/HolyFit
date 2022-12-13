using Microsoft.AspNetCore.Mvc;

namespace HolyFit.Models
{
    public class UserDataEntry
    {
        [BindProperty]
        public string user_entry { get; set; }
    }
}
