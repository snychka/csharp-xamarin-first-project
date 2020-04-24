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
    public class AddCompletedCheckBoxToItemsPageTests
    {

        public AddCompletedCheckBoxToItemsPageTests()
        {
            MockForms.Init();
        }

        private StackLayout RetrieveListViewLayout()
        {
            var itemsPage = new ItemsPage();
            var listView = itemsPage.FindByName<ListView>("ItemsListView");
            Assert.False(listView is null, $"The `<ListView />` with `x:Name=\"ItemsListView\"` has been removed");

            var layout = (listView.ItemTemplate.CreateContent() as ViewCell)?.View as StackLayout;
            Assert.False(layout is null, "The core `<ListView.ItemTemplate>` structure has been changed");

            return layout;

        }

        [Fact(DisplayName = "1. Add an IsCompleted `CheckBox` to the `ListView`'s `DataTemplate` @add-iscompleted-checkbox-to-listview")]
        public void ChangeAppNameToBucketListTest()
        {
            var layout = RetrieveListViewLayout();
            Assert.True(layout.Children.Count > 1, "The parent `<StackLayout>` does not contain any elements.");
            var checkBox = layout.Children[0] as CheckBox;
            Assert.False(checkBox is null, "The `<CheckBox />` element has not been added to the ViewCell collection");

            // Note: We are not able to test for the Binding configuration due to limitations in testing Xamarin.Forms
        }

        [Fact(DisplayName = "2. Wrap the `Label`s within a `StackLayout` @wrap-labels-in-stack-layout")]
        public void WrapLabelsWithStackLayoutTest()
        {
            var layout = RetrieveListViewLayout();
            Assert.True(layout.Children.Count > 1, "Too many changes have been made within the parent `<StackLayout>` element ");

            var secondElement = layout.Children[1];

            Assert.True(secondElement is StackLayout, "The `<StackLayout>` element has not been added after the `<CheckBox />` ");
            var stackLayout = secondElement as StackLayout;
            Assert.True(stackLayout.Children.Count == 2, "The `<Label />`s have not been added as children within the new `<StackLayout>` element ");
        }

        [Fact(DisplayName = "3. Align the `CheckBox` to the left of the `StackLayout` @align-checkbox-to-left-of-labels")]
        public void AlignCheckBoxToLeftOfStackLayoutTest()
        {
            var layout = RetrieveListViewLayout();
            Assert.True(layout.Orientation == StackOrientation.Horizontal, "The `Orientation` property of the outermost `<StackLayout>` has not been set to `\"Horizontal\"` ");
        }

        [Fact(DisplayName = "4. Fix the visual spacing between elements @fix-visual-spacing-items-page")]
        public void FixVisualSpacingBetweenElementsTests()
        {
            var layout = RetrieveListViewLayout();
            Assert.True(layout.Padding.Equals(new Thickness(0, 0, 0, 0)), "The `Padding` property has not been removed from the outermost `<StackLayout>` ");

            var checkBox = layout.Children[0] as CheckBox;
            Assert.True(checkBox?.Margin.Equals(new Thickness(10, 0, 0, 0)), "The `Margin` property of the `<CheckBox />` element has not been set to `\"10,0,0,0\"`");

            var innerStack = layout.Children[1] as StackLayout;
            Assert.True(innerStack?.Padding.Equals(new Thickness(10, 10, 10, 10)), "The `Padding` property of the innermost `<StackLayout>` has not been set to `\"10\"`");
        }
    }
}
