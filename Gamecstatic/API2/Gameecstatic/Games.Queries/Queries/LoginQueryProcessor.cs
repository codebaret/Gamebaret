using System;
using System.Linq;
using System.Threading.Tasks;
using Games.API.Common.Exceptions;
using Games.API.Models.Login;
using Games.API.Models.Users;
using Games.Data.Access.DataAccessLayer;
using Games.Data.Access.Helpers;
using Games.Data.Model;
using Games.Queries.Models;
using Games.Security;
using Games.Security.Auth;
using Microsoft.EntityFrameworkCore;

namespace Games.Queries.Queries
{
    public class LoginQueryProcessor : ILoginQueryProcessor
    {
        private readonly IUnitOfWork _uow;
        private readonly ITokenBuilder _tokenBuilder;
        private readonly IUsersQueryProcessor _usersQueryProcessor;
        private readonly ISecurityContext _context;
        private Random _random;

        public LoginQueryProcessor(IUnitOfWork uow, ITokenBuilder tokenBuilder, IUsersQueryProcessor usersQueryProcessor, ISecurityContext context)
        {
            _random = new Random();
            _uow = uow;
            _tokenBuilder = tokenBuilder;
            _usersQueryProcessor = usersQueryProcessor;
            _context = context;
        }

        public UserWithToken Authenticate(string username, string password)
        {
            var user = (from u in _uow.Query<User>()
                        where u.Username == username && !u.IsDeleted
                        select u)
                .Include(x => x.Roles)
                .ThenInclude(x => x.Role)
                .FirstOrDefault();

            if (user == null)
            {
                throw new BadRequestException("username/password aren't right");
            }

            if (string.IsNullOrWhiteSpace(password) || !user.Password.VerifyWithBCrypt(password))
            {
                throw new BadRequestException("username/password aren't right");
            }

            var expiresIn = DateTime.Now + TokenAuthOption.ExpiresSpan;
            var token = _tokenBuilder.Build(user.Username, user.Roles.Select(x => x.Role.Name).ToArray(), expiresIn);

            return new UserWithToken
            {
                ExpiresAt = expiresIn,
                Token = token,
                User = user
            };
        }

        public async Task<User> Register(RegisterModel model)
        {
            var requestModel = new CreateUserModel
            {
                Email = model.Email,
                Password = model.Password,
                Username = model.Username
            };

            var user = await _usersQueryProcessor.Create(requestModel);
            return user;
        }

        public async Task ChangePassword(ChangeUserPasswordModel requestModel)
        {
            await _usersQueryProcessor.ChangePassword(_context.User.Id, requestModel);
        }
    }
}