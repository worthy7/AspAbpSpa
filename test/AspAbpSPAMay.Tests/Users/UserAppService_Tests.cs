using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Xunit;
using Abp.Application.Services.Dto;
using AspAbpSPAMay.Users;
using AspAbpSPAMay.Users.Dto;
using System.Linq;

namespace AspAbpSPAMay.Tests.Users
{
    public class UserAppService_Tests : AspAbpSPAMayTestBase
    {
        private readonly IUserAppService _userAppService;

        public UserAppService_Tests()
        {
            _userAppService = Resolve<IUserAppService>();
        }

        [Fact]
        public async Task GetUsers_Test()
        {
            // Act
            var output = await _userAppService.GetAll(new PagedUserResultRequestDto{MaxResultCount=20, SkipCount=0} );

            // Assert
            output.Items.Count.ShouldBeGreaterThan(0);
        }

        [Fact]
        public async Task CreateUser_Test()
        {
            // Act
            await _userAppService.Create(
                new CreateUserDto
                {
                    EmailAddress = "john@volosoft.com",
                    IsActive = true,
                    Name = "John",
                    Surname = "Nash",
                    Password = "123qwe",
                    UserName = "john.nash"
                });

            await UsingDbContextAsync(async context =>
            {
                var johnNashUser = await context.Users.FirstOrDefaultAsync(u => u.UserName == "john.nash");
                johnNashUser.ShouldNotBeNull();
            });
        }


        [Fact]
        public async Task GetDeletedUsers_Test()
        {
            // Arrange
            var user = await _userAppService.Create(
                new CreateUserDto
                {
                    EmailAddress = "john@volosoft.com",
                    IsActive = true,
                    Name = "John",
                    Surname = "Nash",
                    Password = "123qwe",
                    UserName = "john.nash"
                });

            await _userAppService.Delete(user);

            // Act
            var output = await _userAppService.GetAll(new PagedUserResultRequestDto { MaxResultCount = 10, SkipCount = 0, Keyword = "" });

            // Assert
            output.Items.Where(c=>c.IsDeleted).Count().ShouldBeGreaterThan(0);
        }
    }
}
