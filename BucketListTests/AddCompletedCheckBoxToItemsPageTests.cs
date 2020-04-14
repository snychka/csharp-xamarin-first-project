using BucketList;
using BucketList.Models;
using BucketList.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Mocks;
using Xunit;

namespace BucketListTests
{
    public class AddCompletedCheckBoxToItemsPageTests
    {
        
        private StackLayout RetrieveListViewLayout()
        {
            var itemsPage = new BucketList.Views.ItemsPage();
            var listView = itemsPage.FindByName<ListView>("ItemsListView");
            Assert.False(listView is null, $"The `<ListView />` with `x:Name=\"ItemsListView\"` has been removed");

            var layout = (listView.ItemTemplate.CreateContent() as ViewCell)?.View as StackLayout;
            Assert.False(layout is null, "The core `<ListView.ItemTemplate>` structure has been changed"); //TODO

            return layout;           

        }

        [Fact(DisplayName = "1. Add an IsCompleted `CheckBox` to the `ListView`'s `DataTemplate` @add-iscompleted-checkbox-to-listview")]
        public void ChangeAppNameToBucketListTest()
        {
            MockForms.Init();

            var layout = RetrieveListViewLayout();
            Assert.True(layout.Children.Count > 1, "");
            var checkBox = layout.Children[0] as CheckBox;
            Assert.False(checkBox is null, "The `<CheckBox />` element has not been added to the ViewCell collection"); //TODO 

            // Note: We are not able to test for the Binding configuration due to limitations in testing Xamarin.Forms
        }

        [Fact(DisplayName = "2. Wrap the `Label`s within a `StackLayout` @wrap-labels-in-stack-layout")]
        public void WrapLabelsWithStackLayoutTest()
        {
            MockForms.Init();

            var layout = RetrieveListViewLayout();
            Assert.True(layout.Children.Count > 1, "");

            var secondElement = layout.Children[1];

            Assert.False(secondElement is Label, "The `<StackLayout>` element has not been added after the `<CheckBox />` ");

            var stackLayout = secondElement as StackLayout;
            Assert.True(stackLayout.Children.Count == 2, "");
        }

        [Fact(DisplayName = "3. Align the `CheckBox` to the left of the `StackLayout` @align-checkbox-to-left-of-labels")]
        public void AlignCheckBoxToLeftOfStackLayoutTest()
        {
            MockForms.Init();

            var layout = RetrieveListViewLayout();
            var secondElement = layout.Children[1];

            Assert.False(secondElement is Label, "The `<StackLayout>` element has not been added after the `<CheckBox />` ");
        }


        // @fix-visual-spacing-items-page

    }
}
