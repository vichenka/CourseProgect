using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Test.BLL.Infrastructure;
using Test.BLL.Interfaces;
using Test.BLL.Models;
using Test.DAL.Interfaces;
using Test.Models;

namespace Test.BLL.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork db { get; set; }
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private RoleManager<IdentityRole> _roleManager;


        public UserService(IUnitOfWork uow, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            db = uow;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        string IUserService.Hash(string input)
        {
            byte[] hash = Encoding.ASCII.GetBytes(input);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] hashenc = md5.ComputeHash(hash);
            string output = "";
            foreach (var b in hashenc)
            {
                output += b.ToString("x2");
            }
            return output;
        }

        async Task<OperationResult> IUserService.AddToRole(ApplicationUser user, string role)
        {
            var result = await _userManager.AddToRoleAsync(user, role);
            var operationResult = new OperationResult
            {
                Result = result.Succeeded,
                Errors = result.Errors.Select(p => p.Description)
            };
            return operationResult;

        }

        async Task<OperationResult> IUserService.DeleteUser(ApplicationUser user)
        {
            var result = await _userManager.DeleteAsync(user);
            var operationResult = new OperationResult
            {
                Result = result.Succeeded,
            Errors = result.Errors.Select(p => p.Description)
            };
        return operationResult;
         }

        async Task<CurrentUser> IUserService.GetUser(string userName)
        {
            var userDb = await _signInManager.UserManager.FindByNameAsync(userName);
            if(userDb != null)
            {
                var user = new CurrentUser
                {
                    Id = userDb.Id,
                    Roles = await _signInManager.UserManager.GetRolesAsync(userDb),
                    Email = userDb.Email,
                    Username = userDb.UserName,
                    FIO = userDb.FIO
                };
                return user;
            }
            return null;
        }

        async Task<ApplicationUser> IUserService.GetUserById(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

        async Task<IEnumerable<string>> IUserService.GetUserRoles(string userName)
        {
            var userDb = await _userManager.FindByNameAsync(userName);
            return await _userManager.GetRolesAsync(userDb);
         }

        async Task<IEnumerable<ApplicationUser>> IUserService.GetUsers()
        {
            var users = await Task.Factory.StartNew(() => _userManager.Users.ToList());
            return users;
         }

        public string Hash(string str)
        {
            throw new NotImplementedException();
        }

        async Task IUserService.Logout()
        {
            await _signInManager.SignOutAsync();
        }

        async Task IUserService.SeedDatabase()
        {
            await _roleManager.CreateAsync(new IdentityRole("Admin"));
            var user = new ApplicationUser
            {
                UserName = "pas@mail.ru",
                EmailConfirmed = true,
                Email = "Pas@mail.ru"
            };
            await _userManager.CreateAsync(user, "a80291227107_A");
            await _userManager.AddToRoleAsync(user, "Admin");
        }

        async Task<SignInResult> IUserService.SignIn(ApplicationUser user)
        {
            return await _signInManager.PasswordSignInAsync(user.UserName, user.PasswordHash, true, false);
        }

        private async Task<IdentityResult> AddUser(ApplicationUser ApplicationUser)
        {
            var result = await _userManager.CreateAsync(ApplicationUser, ApplicationUser.PasswordHash);
            return result;
        }


        async Task<OperationResult> IUserService.SignUp(ApplicationUser applicationUser)
        {
            var result = await AddUser(applicationUser);
            var operationResult = new OperationResult
            {
                Result = result.Succeeded,
                Errors = result.Errors.Select(p => p.Description)
            };
            return operationResult;
        }

        async Task<OperationResult> IUserService.UpdateUser(CurrentUser currentUser)
        {
            var user = await _userManager.FindByNameAsync(currentUser.Username);
            var result = await _userManager.UpdateAsync(user);
            var operationResult = new OperationResult
            {
                Result = result.Succeeded,
                Errors = result.Errors.Select(p => p.Description)
            };
            return operationResult;
        }


        //    public UserService(IUnitOfWork uow)
        //    {
        //        db = uow;
        //    }

        //    public void Create(ApplicationUser user)
        //    {
        //        try
        //        {
        //            db.Users.Create(user);
        //            db.Save();
        //        }
        //        catch (Exception e)
        //        {

        //        }

        //    }

        //    public void Delete(ApplicationUser applicationUser)
        //    {
        //        try
        //        {

        //        }
        //        catch (Exception e)
        //        {

        //        }
        //    }

        //    public IEnumerable<ApplicationUser> GetAll()
        //    {
        //        try
        //        {
        //            return db.Users.GetAll().ToList();

        //        }
        //        catch (Exception e)
        //        {
        //            return null;
        //        }
        //    }

        //    public IEnumerable<ApplicationUser> GetAllUser()//??????????????
        //    {
        //        try
        //        {
        //            return db.Users.GetAll().ToList();
        //        }
        //        catch (Exception e)
        //        {
        //            return null;
        //        }
        //    }

        //    //public string GetNameUserByTestId(int test_id)
        //    //{
        //    //    try
        //    //    {
        //    //        return db.Test.Find(m => m.ID == test_id).ToList(); //????????
        //    //    }
        //    //    catch (Exception e)
        //    //    {
        //    //        return null;
        //    //    }
        //    //}

        //    public ApplicationUser GetUser(string user_id)
        //    {
        //        try
        //        {
        //            return db.Users.Find(m => m.Id == user_id).FirstOrDefault();
        //        }
        //        catch (Exception e)
        //        {
        //            return null;

        //        }
        //    }

        //    public void Update(ApplicationUser user)
        //    {
        //        try
        //        {
        //            db.Users.Update(user);
        //            db.Save();
        //        }
        //        catch (Exception e)
        //        {

        //        }
        //    }

        //    public void Dispose()
        //    {
        //        db.Dispose();
        //    }
    }
 }
