
using System.Text.RegularExpressions;


namespace Proiect_TWM.Services
{
    public static class ValidationService
    {
       public static bool validateName(string name)
        {
            if(name is null)
            {
                return false;
            }
            var regexItem = new Regex("^[a-zA-Z0-9 ]*$");
            if(!regexItem.IsMatch(name)) 
             {
                return false;
             }
            return true;
        } 
    }
}
