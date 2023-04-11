using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Medic.Core;
using Medic.View;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medic.ViewModel
{
    public class FirstonBoardVM : ViewModelBase
    {
        // View Model для View FirstonBoard
        public FirstonBoardVM()
        {
            CarouselItems.Add(new CarouselItem
            {
                Title = "Анализ",
                Description = "Экспресс сбор и получение проб",
                ImageName = "firstimage.png",
                ButtonText = "Пропустить",
                ButtonCommand = new Command<string>(ExecuteButtonCommand1)
            });
            CarouselItems.Add(new CarouselItem
            {
                Title = "Уведомления",
                Description = "Вы быстро узнаете о результатах",
                ImageName = "secondimage.png",
                ButtonText = "Пропустить",
                ButtonCommand = new Command<string>(ExecuteButtonCommand2)
            });
            CarouselItems.Add(new CarouselItem
            {
                Title = "Мониторинг",
                Description = "Наши врачи всегда наблюдают за вашими показателями здоровья",
                ImageName = "thirdimage.png",
                ButtonText = "Завершить",
                ButtonCommand = new Command<string>(ExecuteButtonCommand3)
            });
        }
        private int _position;
        public int Position
        {
            get => _position;
            set => SetProperty(ref _position, value);
        }
        public ObservableCollection<CarouselItem> CarouselItems { get; set; } = new ObservableCollection<CarouselItem>();

        private void ExecuteButtonCommand1(string parameter)
        {
            Position += 1;
        }

        private void ExecuteButtonCommand2(string parameter)
        {
            Position += 1;
        }

        private async void ExecuteButtonCommand3(string parameter)
        {
            await AppShell.Current.GoToAsync($"//{nameof(DashboardView)}");
        }
    }
}
