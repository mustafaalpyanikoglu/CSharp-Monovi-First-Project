using Business.Abstract;
using Business.Constants;
using Business.Constants.Messages;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Concrete;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation.Results;

namespace Business.Concrete
{
    public class AuthManager:IAuthService
    {
        private readonly IUserService _userService;
        private readonly ITokenHelper _tokenHelper;
        private readonly IRoleDal _roleDal;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper, IRoleDal roleDal)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _tokenHelper = tokenHelper ?? throw new ArgumentNullException(nameof(tokenHelper));
            _roleDal = roleDal ?? throw new ArgumentNullException(nameof(roleDal));
        }

        public IResult ChangePassword(UserForLoginDto userForLoginDto)
        {
            byte[] passwordHash, passwordSalt;

            var userResult = _userService.GetByMail(userForLoginDto.Email);

            HashingHelper.CreatePasswordHash(userForLoginDto.Password, out passwordHash, out passwordSalt);
            userResult.Data.PasswordHash = passwordHash;
            userResult.Data.PasswordSalt = passwordSalt;
            _userService.Update(userResult.Data);

            return new SuccessResult(AppMessages.ChangePassword);
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _roleDal.GetAll(p => p.Id == user.RoleId);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            if (accessToken != null)
                return new SuccessDataResult<AccessToken>(accessToken, UserMessages.AccessTokenCreated);
            return new ErrorDataResult<AccessToken>(UserMessages.AccessTokenNotCreated);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck.Data == null)
            {
                return new ErrorDataResult<User>(UserMessages.UserNotFound);
            }
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>(userToCheck.Data, UserMessages.PasswordError);
            }
            return new SuccessDataResult<User>(userToCheck.Data, UserMessages.SuccesfulLogin);
        }

        [ValidationAspect(typeof(RegisterValidator))]
        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            ValidationResult validationResult = new ValidationResult();
            var a= validationResult.Errors;
            var result = BusinessRules.Run
            (
            emailMustBeUnique(userForRegisterDto.Email)
            );
            if (result != null)
            {
                return new ErrorDataResult<User>(result.Message);
            }
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                RoleId = 1
            };

            _userService.Add(user);
            return new SuccessDataResult<User>(user, UserMessages.UserRegistered);
        }

        public IDataResult<string> SendMail(string email)
        {
            throw new NotImplementedException();
        }

        public IResult UserExists(string email)
        {
            var result = _userService.GetByMail(email);
            if (result.Success)
            {
                return new SuccessResult(UserMessages.UserAlreadyExists);
            }
            return new ErrorResult(UserMessages.MailAvailable);
        }

        private IResult emailMustBeUnique(string email)
        {
            IDataResult<User> user = _userService.GetByMail(email);
            if (user.Data is not null)
            {
                return new ErrorResult("Bu mail sistemde mevcut");
            }
            return new SuccessResult();
        }
    }
}
