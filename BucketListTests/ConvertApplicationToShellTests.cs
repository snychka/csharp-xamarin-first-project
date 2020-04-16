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
    public class ConvertApplicationToShellTests
    {
        //@set-mainpage-property
        //@add-missionpage-as-new-tab
        //@add-title-to-missionpage
        //@convert-to-flyoutitem
        //@add-items-to-flyout-menu
        //@create-secondary-navigation?
        //@create-tiertiary-navigation?
        [Fact(DisplayName = "1. Add an IsCompleted `CheckBox` to the `ListView`'s `DataTemplate` @add-iscompleted-checkbox-to-listview")]
        public void ConverToShellAppTest()
        {
            MockForms.Init();
            var app = new App();
            var test = app.MainPage;

            var t = "";
            //var layout = RetrieveListViewLayout();
            //var checkBox = layout.Children[0] as CheckBox;
            //Assert.False(checkBox is null, "The `<CheckBox />` element has not been added to the ViewCell collection"); //TODO 

            // Note: We are not able to test for the Binding configuration due to limitations in testing Xamarin.Forms
        }
        // @wrap-labels-in-stack-layout

        // @align-checkbox-to-left-of-labels

        // @fix-visual-spacing-items-page
        /*
        [Fact(DisplayName = "2. Add Platform Specific environment name to Resource Dictionary Tests @add-platform-specific-name-to-resource-dictionary")]
        public void AddPlatformSpecificEnvironmentNameResourceDictionary()
        {
            MockForms.Init();

            //Verify the OnPlatform element with x:Key='platformName' has been added
            var about = new BucketList.Views.AboutPage();
            Assert.True(about.Resources.ContainsKey(PLATFORM_NAME), $"The `<OnPlatform x:Key=\"{PLATFORM_NAME}\" />` element was not added to the `<ContentPage.Resources><ResourceDictionary>` collection");
            
            //Verify the OnPlatform type is configured as "x:String"
            object pnObj;
            about.Resources.TryGetValue(PLATFORM_NAME, out pnObj);
            var pnType = pnObj.GetType().FullName;
            Assert.True(pnType.Contains("Xamarin.Forms.OnPlatform"), $"The `{PLATFORM_NAME}` resource was not added as an `<OnPlatform />` element");
            Assert.True(pnType.Contains("System.String"), $"The `{PLATFORM_NAME}` element does not contain the property `x:TypeArguments=\"x:String\"`");

            //Verify OnPlatform contains the iOS declaration
            var pnOnPlatform = pnObj as OnPlatform<string>;
            Assert.True(pnOnPlatform.Platforms.Any(on => on.Platform.Any(p => p=="iOS")), $"The `{PLATFORM_NAME}` resource does not contain an `<On Platform=\"{IOS}\" Value=\"{IOS}\" />` element ");
            Assert.True(pnOnPlatform.Platforms.Any(on => on.Value.Equals("iOS")), $"The `<On Platform=\"{IOS}\" />` element does not contain a value of \"{IOS}\" ");

            //Verify OnPlatform contains the Android declaration
            Assert.True(pnOnPlatform.Platforms.Any(on => on.Platform.Any(p => p == "Android")), $"The `{PLATFORM_NAME}` resource does not contain an `<On Platform=\"{ANDROID}\" Value=\"{ANDROID}\" />` element    ");
            Assert.True(pnOnPlatform.Platforms.Any(on => on.Value.Equals("Android")), $"The `<On Platform=\"{ANDROID}\" />` element does not contain a value of \"{ANDROID}\" ");
        }

        [Fact(DisplayName = "3. Add the `platformName` resource to the application name Tests @add-platformName-to-bucketlist")]
        public void AddPlatformNameToBucketListTest()
        {
            // Create an Android instance of the Xamarin.Forms application to test the OnPlatform Resource
            MockForms.Init(Device.Android);

            // Verify the overall structure has not been changed
            var label = RetrieveFirstLabel();
            var spanPlatformName = label?.FormattedText.Spans[2];
            Assert.False(spanPlatformName == null, "Appears that the xaml structure has changed other than adding `<Span Text=\"{ StaticResource platformName}\" />` ");

            // Verify that 1) the Span has been added and 2) has been added in the correct position
            var spanIDX = label?.FormattedText.Spans.ToList().FindIndex(s => s.Text == ANDROID);
            Assert.False(spanIDX == -1, $"The `<Formatted.Spans>` collection is missing the `<Span Text =\"{{StaticResource {PLATFORM_NAME}}}\"` />");
            Assert.True(spanIDX == 2, $"`<Span Text=\"{{StaticResource {PLATFORM_NAME}}}\" />` is not added as the third Span");
            
        }
        */
    }
}
