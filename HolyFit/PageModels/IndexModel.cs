using HolyFit.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HolyFit.PageModels
{
    public class IndexModel : PageModel
    {
        public string user_input { get; set; }
        public void OnGet()
        {
        }
        public void OnPostSubmit(UserDataEntry entry)
        {
            this.user_input = string.Format("textbox name: {0}", entry.user_entry);
        }
    }
}
