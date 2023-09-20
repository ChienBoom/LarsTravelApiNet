using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace LarsTravel.Service
{
	[Authorize]
	public class UploadImage
	{
		private readonly IConfiguration _configuration;
		private readonly IHttpContextAccessor _httpContextAccessor;
		public UploadImage(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
		{
			_configuration = configuration;
			_httpContextAccessor = httpContextAccessor;
		}
		public async void UploadToDriver(IFormFile file)
		{
			var credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
			new ClientSecrets
			{
				ClientId = _configuration["Authentication:Google:ClientId"],
				ClientSecret = _configuration["Authentication:Google:ClientSecret"]
			},
			new[] { DriveService.Scope.DriveFile },
			"user",
			CancellationToken.None,
			new FileDataStore("Drive.Api.Auth.Store"));

			var service = new DriveService(new BaseClientService.Initializer
			{
				HttpClientInitializer = credential,
				ApplicationName = "LarsTravel"
			});

			var fileMetadata = new Google.Apis.Drive.v3.Data.File
			{
				Name = file.FileName
			};


			using (var stream = file.OpenReadStream())
			{
				var request = service.Files.Create(fileMetadata, stream, file.ContentType);
				request.Fields = "id";
				await request.UploadAsync();
			}
		}
	}
}
