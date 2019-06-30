namespace SehirRehberi.API.Dtos
{
    public class UserForUpdateDto : BaseDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
