using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Proiect_TWM.ViewModel
{
    public class LoginViewModel
    {
        public string Username { get; set; }
        public ICommand LoginCommand { get; set; }

        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await OnLoginAsync());
        }
        async Task OnLoginAsync()
        {
            var query = new Dictionary<string, object>();
            query["Username"] = Username;
        }
    }
}
