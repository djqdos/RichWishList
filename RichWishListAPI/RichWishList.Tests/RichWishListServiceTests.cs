using Moq;
using RichWishList.Models;
using RichWishList.Repository.Interface;
using RichWishList.Services.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RichWishList.Tests
{
    public class RichWishListServiceTests
    {
        private WishListService _service;


        [Fact]
        public async Task WishListService_NewItem_ShouldAllowNewItem()
        {
            // Arrange
            Guid guid = Guid.NewGuid();
            WishListItem item = new WishListItem { Id = guid, ItemName = "Test Item", Quantity = 1 };

            var repoMock = new Mock<IRepositoryBase<WishListItem>>();
            repoMock.Setup(x => x.Create(item)).Returns(Task.FromResult(item));

            _service = new WishListService(repoMock.Object);

            // Act
            var result = await _service.Create(item);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(guid, item.Id);
            Assert.Equal("Test Item", item.ItemName);
            Assert.Equal(1, item.Quantity);
        }


        [Fact]
        public async Task WishListService_UpdateItem_ShouldReturnModified()
        {
            // Arrange
            Guid guid = Guid.NewGuid();
            WishListItem item = new WishListItem { Id = guid, ItemName = "Test Item", Quantity = 1 };

            var repoMock = new Mock<IRepositoryBase<WishListItem>>();
            repoMock.Setup(x => x.Update(item)).Returns(Task.FromResult("modified"));

            _service = new WishListService(repoMock.Object);


            // Act
            var response = await _service.Update(item);


            // Assert
            Assert.NotNull(response);
            Assert.Equal("modified", response);
        }

        [Fact]
        public async Task WishListService_GetAll_ShouldReturnListOfItems()
        {
            // Arrange
            Guid guid1 = Guid.NewGuid();
            Guid guid2 = Guid.NewGuid();
            Guid guid3 = Guid.NewGuid();


            List<WishListItem> items = new List<WishListItem>
            {
                new WishListItem { Id = guid1, ItemName = "Test Item 1", Quantity = 1 },
                new WishListItem { Id = guid2, ItemName = "Test Item 2", Quantity = 2 },
                new WishListItem { Id = guid3, ItemName = "Test Item 3", Quantity = 3 }
            };


            var repoMock = new Mock<IRepositoryBase<WishListItem>>();
            repoMock.Setup(x => x.GetAll()).Returns(Task.FromResult(items));

            _service = new WishListService(repoMock.Object);


            // Act
            var response = await _service.GetAll();


            // Assert
            Assert.NotNull(response);
            Assert.Equal(3, items.Count);
        }

        [Fact]
        public async Task WishListService_GetById_ShouldReturnItemById()
        {
            // Arrange
            Guid guid = Guid.NewGuid();
            WishListItem item = new WishListItem { Id = guid, ItemName = "Test Item", Quantity = 1 };

            var repoMock = new Mock<IRepositoryBase<WishListItem>>();
            repoMock.Setup(x => x.Get(guid)).Returns(Task.FromResult(item));

            _service = new WishListService(repoMock.Object);


            // Act
            var response = await _service.GetById(guid);


            // Assert
            Assert.NotNull(response);
            Assert.Equal(guid, item.Id);
        }

        [Fact]
        public async Task WishListService_GetByInvalidId_ShouldReturnNull()
        {
            // Arrange
            Guid guid = Guid.NewGuid();
            WishListItem item = new WishListItem { Id = guid, ItemName = "Test Item", Quantity = 1 };

            var repoMock = new Mock<IRepositoryBase<WishListItem>>();
            repoMock.Setup(x => x.Get(guid)).Returns(Task.FromResult<WishListItem>(null));

            _service = new WishListService(repoMock.Object);


            // Act
            Guid invalidGuid = Guid.NewGuid();
            var response = await _service.GetById(invalidGuid);


            // Assert
            Assert.Null(response);
        }


        [Fact]
        public async Task WishListService_DeleteItem_ShouldReturnDetatched()
        {
            // Arrange
            Guid guid = Guid.NewGuid();
            WishListItem item = new WishListItem { Id = guid, ItemName = "Test Item", Quantity = 1 };

            var repoMock = new Mock<IRepositoryBase<WishListItem>>();
            repoMock.Setup(x => x.Update(item)).Returns(Task.FromResult("detatched"));

            _service = new WishListService(repoMock.Object);


            // Act
            var response = await _service.Update(item);


            // Assert
            Assert.NotNull(response);
            Assert.Equal("detatched", response);
        }
    }
}
