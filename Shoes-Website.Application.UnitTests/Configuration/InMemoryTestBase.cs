using Moq;
using Shoes_Website.Domain.AutorizationServices;
using Shoes_Website.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Shoes_Website.Application.UnitTests.Configuration
{
    public abstract class InMemoryTestBase
    {
        protected ShoesWebsiteDbContext _dbContext;
        private Mock<IAuthorizationService> _authorization;
    }
}
