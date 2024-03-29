﻿using ConstructionCompanyMobile.Util;
using ConstructionCompanyMobile.ViewModels;
using ConstructionCompanyModel.ViewModels.Tasks;
using System.ComponentModel;
using Xamarin.Forms;

namespace ConstructionCompanyMobile.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class TaskPage : ContentPage
    {
        TaskViewModel viewModel;

        public TaskPage(TaskViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;

            HideTaskRatingIfWorker();
        }

        public TaskPage()
        {
            InitializeComponent();

            var task = new TaskVM
            {
                Title = "Task",
                Description = "This is an item description."
            };

            viewModel = new TaskViewModel(task);
            BindingContext = viewModel;

            HideTaskRatingIfWorker();
        }

        private void HideTaskRatingIfWorker()
        {
            if (CurrentUserManager.IsWorker())
            {
                HideTaskRating();
            }
        }

        private void HideTaskRating()
        {
            TaskRatingPicker.IsVisible = false;
            TaskRatingButton.IsVisible = false;
        }
    }
}