using BucketList;
using BucketList.Models;
using BucketList.ViewModels;
using BucketList.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Mocks;
using Xunit;

namespace BucketListTests
{
    public class ConvertApplicationToShellTests
    {       

        public ConvertApplicationToShellTests()
        {
            MockForms.Init();
            Application.Current = new App();
        }

        private bool UserHasCreatedSecondFlyoutItem()
        {
            var shell = ConvertToShellAppTest();
            return shell.Items.Count > 1;
        }

        [Fact(DisplayName = "1. Convert to the Xamarin.Forms Shell Application type  @set-mainpage-property")]
        public AppShell ConvertToShellAppTest()
        {
            var appShell = Application.Current.MainPage as AppShell;
            Assert.False(appShell is null ,"The `MainPage` property of `App.xml.cs` file has not been changed to an instance of `new AppShell()`");
            return appShell;
        }

        [Fact(DisplayName = "2. Add the MissionPage to the application @add-missionpage-as-new-tab")]
        public void AddMissionPageTest()
        {
            if (UserHasCreatedSecondFlyoutItem()) return;
            var shell = ConvertToShellAppTest();
            Assert.False(shell.CurrentItem.Items.Count < 3, "The `MissionPage` has not been added to the `<TabBar>` collection");
            
            if (shell.CurrentItem.Items[1].CurrentItem.ContentTemplate is null)
            {
                Assert.True(shell.CurrentItem.Items[1].CurrentItem.Content is MissionPage, "The `MissionPage` has not been added to the `<TabBar>` collection");
            }
            else
            {
                var secondTab = shell.CurrentItem.Items[1].CurrentItem.ContentTemplate.CreateContent();
                Assert.False(secondTab is AboutPage, "The second item of the `<TabBar>` is still pointing to the `AboutPage`");
            }            
        }

        [Fact(DisplayName = "3. Convert the MissionPage declaration to dynamically load the page @convert-mission-tab-to-dynamic-load")]
        public void ConvertMissionTabToDyanmicTest()
        {
            if (UserHasCreatedSecondFlyoutItem()) return;
            var shell = ConvertToShellAppTest();
            Assert.False(shell.CurrentItem.Items.Count < 3, "The `MissionPage` has not been added to the `<TabBar>` collection");

            Assert.False(shell.CurrentItem.Items[1].CurrentItem.Content is MissionPage, "The second element of the `<TabBar>` is still a direct reference to `<local:MissionPage/>`");
            Assert.False(shell.CurrentItem.Items[1].CurrentItem.ContentTemplate is null, "The second element of the `<TabBar>` is not declared as a `<ShellContent />` element  ");

            var missionPage = shell.CurrentItem.Items[1].CurrentItem.ContentTemplate.CreateContent();
            Assert.True(missionPage is MissionPage, "The second element of the `<TabBar>` has not declared as `<ShellContent ContentTemplate=\"{ DataTemplate local:MissionPage}\" />`");

            Assert.True(shell.CurrentItem.Items[1].CurrentItem.Title == "Mission", "The new `MissionPage` declartion in the `<TabBar>` is missing the `Title=\"Mission\"`");
        }

        [Fact(DisplayName = "4. Change navigation from Tabs to a Flyout menu @convert-to-flyoutitem")]
        public void ChangeNavigationToFlyoutMenuTest()
        {
            if (UserHasCreatedSecondFlyoutItem()) return;
            var shell = ConvertToShellAppTest();
            Assert.True(shell.Items[0].Route.Contains("FlyoutItem"), "The `<TabBar>` declaration has not been changed to `<FlyoutItem>`");
            
        }

        [Fact(DisplayName = "5. Add items to the Flyout menu @add-items-to-flyout-menu")]
        public void AddItemsToFlyoutMenuTest()
        {
            if (UserHasCreatedSecondFlyoutItem()) return;
            var shell = ConvertToShellAppTest();
            Assert.True(shell.CurrentItem.FlyoutDisplayOptions == FlyoutDisplayOptions.AsMultipleItems, "The first `<FlyoutItem>` delcaration is not configured with the property `FlyoutDisplayOptions=\"AsMultipleItems\"`");
        }

        [Fact(DisplayName = "6. Create a secondary navigation layer @create-secondary-navigation")]
        public void CreateSecondaryNavigationTest()
        {
            Assert.True(UserHasCreatedSecondFlyoutItem(), "The secondary `<FlyoutItem>` has not been declared");
            var shell = ConvertToShellAppTest();
            var secondaryFlyout = shell.Items[1] as FlyoutItem;
            Assert.False(secondaryFlyout.CurrentItem is null, "The secondary `<FlyoutItem>` does not contain any elements");
            Assert.False(secondaryFlyout.CurrentItem.CurrentItem is null, "The secondary `<FlyoutItem>` contains a `<Tab>` which does not contain any elements");
            Assert.True(secondaryFlyout.Title == "About", "The `Title` of the secondary `<FlyoutItem>` has not been set to `\"About\"`");
            
            
        }

        [Fact(DisplayName = "7. Separate items between the Flyout menu and Tab bar @separate-flyoutitems-and-tabs")]
        public void SeparateFlyoutitemsAndTabs()
        {
            var shell = ConvertToShellAppTest();
            var firstFlyout = shell.Items[0] as FlyoutItem;
            Assert.True(firstFlyout.FlyoutDisplayOptions == FlyoutDisplayOptions.AsSingleItem, "The `FlyoutDisplayOptions` property of the first `<FlyoutItem>` has not been changed to `\"AsSingleItem\"`");
            Assert.True(firstFlyout.Title == "Bucket List", "The first `<FlyoutItem>` has not been given a property of `Title=\"Bucket List\"`");
            Assert.True(firstFlyout.CurrentItem.Title == "List", "The `<Tab>` with `Title=\"Browse\"` needs to be changed to `Title=\"List\"` ");
        }

        [Fact(DisplayName = "8. Create tertiary navigation layer @create-tiertiary-navigation")]
        public void CreateTiertiaryNavigationTest()
        {
            var shell = ConvertToShellAppTest();
            var firstFlyout = shell.Items[0] as FlyoutItem;
            var firstTab = firstFlyout.Items[0];

            Assert.True(firstTab.Items.Count > 1, "The declaration `<local:NewItemPage />` has not been added to the first `<Tab>` of the first `<FlyoutItem>` ");
            Assert.True(firstTab.Items[1].Content is NewItemPage, "The declaration `<local:NewItemPage />` has not been added to the first `<Tab>` of the first `<FlyoutItem>` ");
        }
    }
}
