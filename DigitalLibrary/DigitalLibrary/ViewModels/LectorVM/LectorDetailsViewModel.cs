﻿using DigitalLibrary.Service.Reference;
using DigitalLibrary.ViewModels.Abstract;

namespace DigitalLibrary.ViewModels.LectorVM
{
    public class LectorDetailsViewModel : AItemDetailsViewModel<Lector>
    {
        #region Fields
        private string name;
        private string surname;
        private bool isActive;
        #endregion Fields

        #region Properties
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }
        public string Surname
        {
            get => surname;
            set => SetProperty(ref surname, value);
        }
        public bool IsActive
        {
            get => isActive;
            set => SetProperty(ref isActive, value);
        }
        #endregion Properties

        public LectorDetailsViewModel() : base() { }

        public override void LoadProperties(Lector item)
        {
            Name = item.Name;
            Surname = item.Surname;
            IsActive = item.IsActive;
        }
    }
}
