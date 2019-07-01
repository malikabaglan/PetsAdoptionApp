using System;
namespace AdoptMe.Models
{
    public class CreateUserBindingModel
    {
        
        public string Email { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string RoleName { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }


    public class RootObject
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public string userName { get; set; }
        public string issued { get; set; }
        public string expires { get; set; }
    }
    public class AuthResponse
    {
        /// <summary>   
        /// Tells if the API call was processed successfully.
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Result received from the API.
        /// Could be JSON or String.
        /// </summary>
        public string Result { get; set; }
    }



}

