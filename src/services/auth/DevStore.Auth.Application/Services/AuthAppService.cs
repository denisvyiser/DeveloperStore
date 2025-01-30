
using DevStore.Auth.Application.Grpc.Config;
using DevStore.Auth.Application.Grpc.Contracts;
using DevStore.Auth.Application.Views;
using DevStore.Core.Authentication.Config;
using DevStore.Core.Interfaces.Bus.MediatR;
using DevStore.Core.Mediatr.Messages;
using DevStore.Core.Models.Erros;
using DevStore.Grpc.Contracts;
using DevStore.Users.Application.Interfaces;
using Grpc.Net.Client;
using Newtonsoft.Json.Linq;
using ProtoBuf.Grpc.Client;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.Versioning;

namespace DevStore.Users.Application.Services
{
    public class AuthAppService : IAuthAppService
    {
        private readonly GrpcConfig _grpcConfig;
        private readonly IMediatorHandler _mediator;
        private readonly SigningConfig _signingConfig;
        private readonly TokenConfig _tokenConfig;

        public AuthAppService(GrpcConfig grpcConfig, IMediatorHandler mediator, SigningConfig signingConfig, TokenConfig tokenConfig)
        {
            _grpcConfig = grpcConfig;
            _mediator = mediator;
            _signingConfig = signingConfig;
            _tokenConfig = tokenConfig;
        }

        public async Task<LoginResponseView> Login(LoginRequestView request)
        {
            using var channel = GrpcChannel.ForAddress(_grpcConfig.Url);
            var client = channel.CreateGrpcService<IUserCredentialsGrpcService>();

            var reply = await client.GetUserByCredentials(new UserCredentialsRequest { UserName = request.UserName, Password = request.Password });

            if (reply.Data == null)
            {
                await _mediator.RaiseEvent(new DomainNotification(ErrorType.ValidationError, "Invalid Credentials", "Invalid User or Password"));
            }

            return await GenerateTokenAsync(reply.Data!);
        }

        private async Task<LoginResponseView> GenerateTokenAsync(UserCredentialsResponse user)
        {
            DateTimeOffset time = new DateTimeOffset(DateTime.Now);

            

            var claims = TokenGenerator.ClaimsDados(user.UserName, user.Name.FirstName, user.Role,
                    _tokenConfig,
                    time.AddSeconds(_tokenConfig.ExpirationTime).ToUnixTimeSeconds().ToString(),
                    time.ToUnixTimeSeconds().ToString());


            var secutiryToken = TokenGenerator.TokenKey(_tokenConfig.Issuer, _signingConfig.SigningCredentials, claims, time.DateTime, time.AddSeconds(_tokenConfig.ExpirationTime).DateTime);

            var tokenKey = new JwtSecurityTokenHandler().WriteToken(secutiryToken);

           return new LoginResponseView { Token = tokenKey };
          
        }

    }
}

