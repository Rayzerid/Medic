using Medic.Core;
using Medic.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medic.ViewModel
{
    public class AnalyzesVM : ViewModelBase
    {
        private readonly HttpRequests _httpRequests;
        public AnalyzesVM()
        {
            _httpRequests = new HttpRequests();
            _httpRequests.GetNews(this);
            _httpRequests.GetCatalog(this);

            CarouselItem.Add(new CarouselCatalog
            {
                Name = "Популярные",
            });
            CarouselItem.Add(new CarouselCatalog
            {
                Name = "Covid",
            });
            CarouselItem.Add(new CarouselCatalog
            {
                Name = "Онкогенетические",
            });
            CarouselItem.Add(new CarouselCatalog
            {
                Name = "ЗОЖ",
            });
        }

        private ObservableCollection<CarouselCatalog> _carouselItem = new ObservableCollection<CarouselCatalog>();
        public ObservableCollection<CarouselCatalog> CarouselItem
        {
            get { return _carouselItem; }
            set { _carouselItem = value; OnPropertyChanged(); }
        }

        private ObservableCollection<NewItem> _newsCollection;
        public ObservableCollection<NewItem> NewsCollection
        {
            get { return _newsCollection; }
            set { _newsCollection = value; OnPropertyChanged(); }
        }
        private ObservableCollection<CatalogMenu> _catalogCollection;
        public ObservableCollection<CatalogMenu> CatalogCollection
        {
            get { return _catalogCollection; }
            set { _catalogCollection = value; OnPropertyChanged(); }
        }
    }
}
