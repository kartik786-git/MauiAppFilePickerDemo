using MauiAppFilePickerDemo.Model;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;

namespace MauiAppFilePickerDemo
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<ImageModel> imagesModel = new ObservableCollection<ImageModel>();

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            var resutl = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "picimage ",
                FileTypes = FilePickerFileType.Images
            });

            if (resutl == null)
            {
                return;
            }

            var stream = await resutl.OpenReadAsync();

            myImage.Source = ImageSource.FromStream(() => stream);
        }

        private async void PickImages_Clicked(object sender, EventArgs e)
        {
            var resutls = await FilePicker.PickMultipleAsync(new PickOptions
            {
                PickerTitle = "picimage ",
                FileTypes = FilePickerFileType.Images
            });

            if (resutls == null)
            {
                return;
            }

            foreach (var restult in resutls)
            {
                var stream = await restult.OpenReadAsync();

                imagesModel.Add(new ImageModel
                {
                    Name = restult.FileName,
                    ImageSource = ImageSource.FromStream(() => stream)
                });
            }

            collectionView.ItemsSource = imagesModel;   
        }
    }

}
