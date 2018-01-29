using Domain.Entities.Cms;
using Domain.Entities.Customers;
using Domain.Entities.Suppliers;
using NUnit.Framework;

namespace ApplicationTests {

    [TestFixture]
    [Category("testCms")]
    internal class Tests {

        [SetUp]
        public void set() {
        }

        [TearDown]
        public void empty() {
        }

        [Test]
        public void Execute_() {
            //Arrange
            var item = new Supplier {
                Name = "supplier1",
                Address = "address1",
                CityId = 1,
                RegionId = 1,
                Code = "j f lkf ehlkvekx",
                Email = " sdfklersdlkj",
                Notes = "ek xklkerdxlkgnvlerdjnxlgknveldrnxlgkverkd",
                Phone = "f sdf wersd"
            };
            var uow = Builders.UnitOfWorkBuilder.GetUnitOfWork();
            //Act
            using (uow) {
                uow.SupplierRepository.Insert(item);
                uow.Complete();
            }
            //Assert.
            Assert.AreEqual(item.Id > 0, true);
        }

        [Test]
        public void Execute_2() {
            //Arrange
            var item = new Customer {
                Name = "supplier1",
                Address = "address1",
                CityId = 1,
                RegionId = 1,
                Code = "j f lkf ehlkvekx",
                Email = " sdfklersdlkj",
                Notes = "ek xklkerdxlkgnvlerdjnxlgknveldrnxlgkverkd",
                Phone = "f sdf wersd"
            };
            var uow = Builders.UnitOfWorkBuilder.GetUnitOfWork();
            //Act
            using (uow) {
                uow.CustomerRepository.Insert(item);
                uow.Complete();
            }
            //Assert.
            Assert.AreEqual(item.Id > 0, true);
        }

        [Test]
        public void Execute_1() {
            //Arrange
            var item = new Paint {
                Name = "paint1",
            };
            var uow = Builders.UnitOfWorkBuilder.GetUnitOfWork();
            //Act
            using (uow) {
                uow.PaintRepository.Insert(item);
                uow.Complete();
            }
            //Assert.
            Assert.AreEqual(item.Id > 0, true);
        }
    }
}