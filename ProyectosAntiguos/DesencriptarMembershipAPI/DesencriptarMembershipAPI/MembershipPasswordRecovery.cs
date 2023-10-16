using System;
using System.Text;
using System.Web.Security;

namespace DesencriptarMembershipAPI
{
    public class MembershipPasswordRecovery : SqlMembershipProvider
    {
        public string GetClearTextPassword(string encryptedPwd)
        {
            var encodedPassword = Convert.FromBase64String(encryptedPwd);
            var bytes = DecryptPassword(encodedPassword);
            return bytes == null ? null : Encoding.Unicode.GetString(bytes, 0x10, bytes.Length - 0x10);
        }
    }
}