using System.Net.Http.Json;
using BlazerSozluk.common.Events.User;
using BlazerSozluk.common.Infrastructure.Exceptions;
using System.Text.Json;
using BlazerSozluk.common.Models.Queries;
using BlazerSozluk.common.Results;
using BlazorSozluk.WebApp.Infrastructure.Services.Interfaces;

namespace BlazorSozluk.WebApp.Infrastructure.Services
{
    public class UserService : IUserService
	{
		private readonly HttpClient Client;

		public UserService(HttpClient client)
		{
			Client = client;
		}

		public async Task<UserDetailViewModel> GetUserDetail(Guid? id)
		{
			var userDetail = await Client.GetFromJsonAsync<UserDetailViewModel>($"api/user/{id}");
			return userDetail;
		}

		public async Task<UserDetailViewModel> GetUserDetail(string userName)
		{
			var userDetail = await Client.GetFromJsonAsync<UserDetailViewModel>($"api/user/username/{userName}");
			return userDetail;
		}

		public async Task<bool> UpdateUser(UserDetailViewModel user)
		{
			var res = await Client.PostAsJsonAsync($"api/user/update", user);
			return res.IsSuccessStatusCode;
		}

		public async Task<bool> ChangeUserPassword(string oldPassword, string newPassword)
		{
			var command = new ChangeUserPasswordCommand(Guid.Empty, oldPassword, newPassword);
			var httpResponse = await Client.PostAsJsonAsync($"api/User/ChangePassword", command);

			if (httpResponse != null && !httpResponse.IsSuccessStatusCode)
			{
				if (httpResponse.StatusCode == System.Net.HttpStatusCode.BadRequest)
				{
					var responseStr = await httpResponse.Content.ReadAsStringAsync();
					var validation = JsonSerializer.Deserialize<ValidationResponseModel>(responseStr);
					responseStr = validation.FlattenErrors;
					throw new DataBaseValidationException(responseStr);
				}

				return false;
			}

			return httpResponse.IsSuccessStatusCode;
		}


	}
}
