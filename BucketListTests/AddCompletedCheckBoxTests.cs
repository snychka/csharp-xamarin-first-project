using BucketList.Views;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Mocks;
using Xunit;

namespace BucketListTests
{
    public class AddCompletedCheckBoxTests
    {
        private NewItemPage newItem;
        private StackLayout content;

        public AddCompletedCheckBoxTests()
        {
            MockForms.Init();
            newItem = new NewItemPage();
            content = newItem.Content as StackLayout;
        }

        [Fact(DisplayName = "1. Add CheckBox to the NewItemPage.xaml Tests @add-checkbox-to-newitempage")]
        public void AddCompleteCheckBoxTest()
        {        
            Assert.True(content.Children.Count > 4, "The `<CheckBox />` element has not been added");

            var forthElement = content.Children[4];
            if (forthElement is Label label)
            {
                //Ignoring this test since the label was added in test 2
            }
            else 
            {
                Assert.True(forthElement is CheckBox, "The `<CheckBox />` element has not been added");
            }
        }

        [Fact(DisplayName = "2. Add Completed Label element Tests @add-completed-label-element")]
        public void AddCompletedLabelElementTest()
        {
            Assert.True(content.Children.Count > 4, "The `<Label />` element has not been added");

            var label = content.Children[4] as Label;
            Assert.True(label is Label, "The `<Label />` element has not been added");

            Assert.True(label.Text == "Completed", $"The <Label />'s Text property has not been set to `\"Completed\"` ");
        }

        [Fact(DisplayName="3. Add IsCompleted property to Item model @add-iscompleted-property")]
        public void AddIsCompletedPropertyTest()
        {
            var item = new BucketList.Models.Item();
            var prop = item.GetType().GetProperty("IsCompleted");
            Assert.True(prop != null, "The `IsCompleted` property has not been added to the `Item` model");
            Assert.True(prop.PropertyType.Name == "Boolean", "The `IsCompleted` property was not declared as a `bool`");
        }

        [Fact(DisplayName="4. Bind the CheckBox's IsChecked property to the Item.IsCompleted property @bind-checkbox-ischecked-to-iscompleted")]
        public void BindCheckBoxIsCheckedTest()
        {
            Assert.True(content.Children.Count > 5, "The `<CheckBox />` element is not available for binding");

            var checkBox = content.Children[5] as CheckBox;
            Assert.True(checkBox != null, "The `<CheckBox />` element is not the sixth element within the StackLayout");

            checkBox.IsChecked = true;
            var prop = newItem.Item.GetType().GetProperty("IsCompleted");
            var val = prop.GetValue(newItem.Item).ToString();
            Assert.True(val.Equals("True"), "The `<CheckBox IsChecked=\"\" />` property has not been bound to `Item.IsCompleted`");
        }
    }
}
