using System;
using System.Security.Claims;
using System.ServiceModel;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNet.Identity;
using PhotoAlbum.DAL.Entities;
using PhotoAlbum.DAL.Interfaces;
using Service.Messages;
using Service.Messages.Membership;
using Service.Utilities.Membership;
using Service.Views.Membership;


namespace Service
{
    public class MembershipService : IMembershipService
    {
        private IUnitOfWork Database { get; }

        public MembershipService(IUnitOfWork uow)
        {
            Database = uow;
        }


        public async Task<CreateResponse> CreateAsync(CreateRequest request)
        {
            var response = new CreateResponse();
            return await SurroundWithTryCatchAsync(async () =>
            {
                if (await Database.UserManager.FindByEmailAsync(request.Email) != null 
                || await Database.UserManager.FindByNameAsync(request.UserName) != null)
                {
                    throw new AddressAlreadyInUseException("User Name or Email adress is already taken.");
                }
                var newUser = new ApplicationUser { UserName = request.UserName, Email = request.Email };
                await Database.UserManager.CreateAsync(newUser, request.Password);
                var authType = EnumStringValue.GetStringValue(request.AuthenticationType);
                var claimIdentity = await Database.UserManager.CreateIdentityAsync(newUser, authType);
                await Database.UserManager.AddToRoleAsync(newUser.Id, request.Role);
                Database.ClientManager.Add(new ClientProfile
                {
                    Id = newUser.Id,
                    UserName = newUser.UserName,
                    FullName = request.FullName
                });
                response.UserId = newUser.Id;
                response.ClaimIdentityView = Mapper.Map<ClaimsIdentity, ClaimIdentityView>(claimIdentity);
                await Database.CommitAsync();
            }, response);
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            var response = new LoginResponse();
            return await SurroundWithTryCatchAsync(async () =>
            {
                var user = await Database.UserManager.FindAsync(request.UserName, request.Password);
                if (user == null)
                {
                    throw new NullReferenceException("Uncorrect User Name or Password!");
                }
                var claimIdentity = await Database.UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
                response.ClaimIdentityView = Mapper.Map<ClaimsIdentity, ClaimIdentityView>(claimIdentity);
            }, response);
        }

        public async Task<UserProfileResponse> GetProfileAsync(string userName)
        {
            var response = new UserProfileResponse();
            return await SurroundWithTryCatchAsync(async () =>
            {
                var profile = await Database.ClientManager.GetByUserNameAsync(userName);
                response.UserName = profile.UserName;
                response.Email = profile.ApplicationUser.Email;
                response.FullName = profile.FullName;
            }, response);
        }

        public async Task<ChangeUserPasswordResponse> ChangeUserPasswordAsync(ChangeUserPasswordRequest request)
        {
            var response = new ChangeUserPasswordResponse();
            return await SurroundWithTryCatchAsync(async () =>
            {
                var result = await Database.UserManager.ChangePasswordAsync(request.UserId, request.OldPassword, request.NewPassword);
                response.AddErrors(result.Errors);
            }, response);
        }

        public async Task<ChangeUserInfoResponse> ChangeUserInfoAsync(ChangeUserInfoRequest request)
        {
            var response = new ChangeUserInfoResponse();
            return await SurroundWithTryCatchAsync(async () =>
            {
                var result = await Database.UserManager.SetEmailAsync(request.UserId, request.Email);
                response.AddErrors(result.Errors);
                if (!result.Succeeded) return;
                var clientProfile = await Database.ClientManager.GetByIdAsync(request.UserId);
                clientProfile.FullName = request.FullName;
                await Database.CommitAsync();
            }, response);
        }

        #region helpers
        //Wrap all contracts to the try-catch block
        private async Task<T> SurroundWithTryCatchAsync<T>(Func<Task> t, T response) where T : BaseResponse
        {
            try
            {
                await t();
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Errors.Add(e.Message);
            }
            return response;
        }
        #endregion
    }
}
