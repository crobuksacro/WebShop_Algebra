﻿using Newtonsoft.Json;
using WebShop.Validation;

namespace WebShop.Models.Binding
{
    public class UserBinding: UserBaseBinding
    {
        public AdressBinding UserAdress { get; set; }
    }


    public class UserBaseBinding
    {
        //Validirati empty
        public string Firstname { get; set; }
        //Validirati empty
        public string Lastname { get; set; }
        //Validirati DOB min 18g
        public DateTime DOB { get; set; }
        [UserEmailValidation]
        public string Email { get; set; }
        [StringGreaterThanThanSeven]
        public string Password { get; set; }
    }

    public class UserAdminBinding: UserBaseBinding
    {
        public string RoleId { get; set; }
    }

    public class UserAdminUpdateBinding : UserAdminBinding
    {
        public string Id { get; set; }
    }



}
