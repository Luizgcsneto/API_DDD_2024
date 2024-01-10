using Microsoft.IdentityModel.Tokens;

namespace WebApi.Token
{
    public class TokenJwtBuilder
    {
        private SecurityKey securityKey = null;
        private string subject = "";
        private string audience = "";
        private string issuer = "";
        private Dictionary<string, string> claims = new Dictionary<string, string>();
        private int expireInMinutes = 20;

        public TokenJwtBuilder AddSecurityKey(SecurityKey securityKey)
        {
            this.securityKey = securityKey;
            return this;
        }

        public TokenJwtBuilder AddSubject(string subject)
        {
            this.subject = subject;
            return this;
        }

        public TokenJwtBuilder AddAudience(string audience)
        {
            this.audience = audience;
            return this;
        }

        public TokenJwtBuilder AddIssuer(string issuer)
        {
            this.issuer = issuer;
            return this;
        }

        public TokenJwtBuilder AddClaim(string type, string value)
        {
            this.claims.Add(type, value);
            return this;
        }

        public TokenJwtBuilder AddExperiInMinutes(int expireInMinutes)
        {
            this.expireInMinutes = expireInMinutes;
            return this;
        }
    }
}
