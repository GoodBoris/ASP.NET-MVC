using System.ServiceModel;
using System.Threading.Tasks;
using Service.Messages.Membership;

namespace Service
{
    //Service for managing User profiles: create, edit, etc
    [ServiceContract]
    public interface IMembershipService
    {
        [OperationContract]
        Task<CreateResponse> CreateAsync(CreateRequest request);

        [OperationContract]
        Task<LoginResponse> LoginAsync(LoginRequest request);

        [OperationContract]
        Task<UserProfileResponse> GetProfileAsync(string userName);

        [OperationContract]
        Task<ChangeUserPasswordResponse> ChangeUserPasswordAsync(ChangeUserPasswordRequest request);

        [OperationContract]
        Task<ChangeUserInfoResponse> ChangeUserInfoAsync(ChangeUserInfoRequest request);
    }
}
