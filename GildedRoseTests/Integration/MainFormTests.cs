using GuildedRose.Model;
using GuildedRose;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GildedRoseTests.EndToEnd;
using System.Windows.Forms;
using FlaUI.Core.Overlay;

namespace GildedRoseTests.Integration
{
    public class MainFormTests
    {
        private Mock<UserRequestListener> userRequestListenerMock;
        private FormDriver formDriver;

        public MainFormTests()
        {
            userRequestListenerMock = new Mock<UserRequestListener>();
            var form = new MainForm(new Inventory());
            form.AddListener(userRequestListenerMock.Object);
            formDriver = new FormDriver(form);
        }

        [Fact]
        public void MakeUserRequestWhenAddButtonClicked()
        {
            var item= new Item("an item");
            
            formDriver.AddItem(item);

            userRequestListenerMock.Verify(listener => listener.AddItemToInventory(item), Times.Once);
        }

        [Fact]
        public void RemoveItemWhemRemoveButtonClicked()
        {
            var item = new Item("an item");
            formDriver.AddItem(item);

            formDriver.RemoveItem(item.Name);

            userRequestListenerMock.Verify(listener => listener.RemovedItemFromInventory(item.Name), Times.Once); // todo: what happens when there are more items with the same name?
        }
    }
}
