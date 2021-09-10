using Autofac.Extras.Moq;
using Moq;
using MyNUnitDemo.Models;
using MyNUnitDemo.Repositories;
using MyNUnitDemo.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NUnitTest
{
    class LicenseRenewServiceTest
    {
        private AutoMock autoMock;



        [SetUp]
        public void SetUp()
        {
            autoMock = AutoMock.GetLoose();
        }

        [Test]
        public void GetAll_HaveModels_ReturnListModel()
        {
            // mock repository จำลอง db
            autoMock.Mock<ILicenseRenewRepository>().Setup(m => m.GetAll()).Returns(GetLicenseRenews());
            var licenseRenewService = autoMock.Create<LicenseRenewService>();
            var licenseRenews = licenseRenewService.GetAll().ToList();

            Assert.Greater(licenseRenews.Count() , 0);
        }
        
        [Test]
        public void GetById_Found_ReturnModel()
        {
            autoMock.Mock<ILicenseRenewRepository>().Setup(m => m.GetById(It.IsAny<string>())).Returns((string licenseId) => GetLicenseRenews().Where(m=>m.FK_LicenseId == licenseId).FirstOrDefault());

            var licenseRenewService = autoMock.Create<LicenseRenewService>();
            var res = licenseRenewService.GetById("11");

            Assert.NotNull(res);
            Assert.AreEqual(res.FK_PONo, "A002");
        }

        [Test]
        public void GetById_NotFound_ReturnModel()
        {
            autoMock.Mock<ILicenseRenewRepository>().Setup(m => m.GetById(It.IsAny<string>())).Returns((string licenseId) => GetLicenseRenews().Where(m => m.FK_LicenseId == licenseId).FirstOrDefault());

            var licenseRenewService = autoMock.Create<LicenseRenewService>();
            var res = licenseRenewService.GetById("55");

            Assert.Null(res);
        }


        [TearDown]
        public void TearDown()
        {
            autoMock.Dispose();
        }

        public IEnumerable<LicenseRenew> GetLicenseRenews()
        {
            return new List<LicenseRenew>{
                new LicenseRenew{ Id = 1, FK_PONo="A001", FK_LicenseId="10"},
                new LicenseRenew{ Id = 2, FK_PONo="A002", FK_LicenseId="11"}
                };
        }   
    }
}
