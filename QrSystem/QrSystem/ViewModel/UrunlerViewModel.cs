using QrSystem.Models;

namespace QrSystem.ViewModel
{
    public class UrunlerViewModel
    {
        public Dictionary<int, Dictionary<string, List<BasketİtemVM>>> UrunlerByQrCodeAndTable { get; set; }
        public List<SaxlanilanSifarish>saxlanilanSifarishes { get; set; }
        public UrunlerViewModel()
        {
            UrunlerByQrCodeAndTable = new Dictionary<int, Dictionary<string, List<BasketİtemVM>>>();
        }
    }


}
