using System.Collections.Generic;
using System.Linq;
using Domain;
using Domain.Domain;
using Factories.Factories;
using InterfaceActions.Actions;
using Moq;
using NUnit.Framework;

namespace UnitTest
{
    [TestFixture]
    internal class HumanResourcesFixture
    {
        [SetUp]
        public void SetUp()
        {
            _mockDisplayInfoAction = new Mock<ICompany>();
            _mockDisplayIntern = new Mock<IDisplayInfoAction>();

            
            CompanyFactory factory = new CompanyFactory(_mockDisplayInfoAction.Object);
            var comp = factory.CreateCompany(1, "Amdaris", FieldOfActivity.IT, "Puskin 22", "Chisinau");
            InternFactory internf = new InternFactory(_mockDisplayIntern.Object);
            var intern = internf.CreateIntern("Wano", "Smith", 1, 1, 1990, 500, 6, comp);
            InternFactory internf2 = new InternFactory(_mockDisplayIntern.Object);
            var intern2 = internf2.CreateIntern("Ion", "Bamby", 10, 10, 2000, 525, 8.5, comp);
            InternList = new List<Intern> {intern, intern2};
            //var hr = new HumanResources();
        }

        protected List<Intern> InternList;
        private Mock<ICompany> _mockDisplayInfoAction;
        private Mock<IDisplayInfoAction> _mockDisplayIntern;
        private HumanResources hr = new HumanResources();

        [Test]
        public void ItShouldReturnNumberOfValidInterns()
        {
            var hiring = hr.Hire(InternList);
            Assert.AreEqual(1, hiring.Count);
        }
        
        [Test]
        public void ItChecksInternAverageMarkGreaterThanEight()
        {
            var hiring = hr.Hire(InternList);
            Assert.IsFalse(hiring.Any(x => x.AverMark < 8));
        }
    }
}