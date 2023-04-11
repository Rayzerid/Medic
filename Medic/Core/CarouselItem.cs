using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Medic.Core
{
    public class CarouselItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
        public string ButtonText { get; set; }
        public ICommand ButtonCommand { get; set; }

    }
}
