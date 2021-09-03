using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace WebApplication.AOP
{
    public class CustomAuthorizationPolicyProvider : IAuthorizationPolicyProvider
    {
        private AuthorizationOptions _options;
        public CustomAuthorizationPolicyProvider(IOptions<AuthorizationOptions> options)
        {
            _options = options.Value;
        }
        public Task<AuthorizationPolicy> GetDefaultPolicyAsync()
        {
            return Task.FromResult(this._options.DefaultPolicy); 
        }

        public Task<AuthorizationPolicy> GetFallbackPolicyAsync()
        {
            return default;
        }

        public Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
        {
          AuthorizationPolicy policy=  this._options.GetPolicy(policyName);
            if (policy != null) 
            {
                return Task.FromResult(policy);
            }
            string[] cliams = policyName.Split(new char[] { '-'},StringSplitOptions.None);
            _options.AddPolicy(policyName,builder=> {
                builder.RequireClaim(cliams[0], cliams[1]);
            });
            return Task.FromResult(this._options.GetPolicy(policyName));
        }
    }
}
