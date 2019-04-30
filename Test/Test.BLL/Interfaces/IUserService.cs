using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Test.BLL.Infrastructure;
using Test.BLL.Models;
using Test.Models;

namespace Test.BLL.Interfaces
{
   public interface IUserService
    {
        Task<SignInResult> SignIn(ApplicationUser applicationUser);
        Task<OperationResult> SignUp(ApplicationUser applicationUser);
        Task Logout();
        Task<CurrentUser> GetUser(string ApplicationUserName);
        Task<ApplicationUser> GetUserById(string id);
        Task<IEnumerable<string>> GetUserRoles(string ApplicationUserName);
        Task<IEnumerable<ApplicationUser>> GetUsers();
        Task<OperationResult> DeleteUser(ApplicationUser applicationUser);
        Task<OperationResult> UpdateUser(CurrentUser currentUser);
        Task<OperationResult> AddToRole(ApplicationUser applicationUser, string role);
        Task SeedDatabase();
        string Hash(string str);

        //IEnumerable<ApplicationUser> GetAll(); //все юзеры
       //  IEnumerable<ApplicationUser> GetAllUser();//все юзеры (роль=юзер) 
     //   string GetNameUserByTestId(int test_id);
     }
}
